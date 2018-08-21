# /api/build/copy-sqlite-interop.py
#
# Copy the SQLite interop dll/so into the required directory.
#
# See /LICENCE.md for Copyright information
"""Copy the SQLite interop dll/so into the required directory."""

import re

import os

from glob import glob

import sys

from shutil import copy2

import argparse

from platform import system


def is_x64():
    # This is the recommended approach from the python docs:
    # https://docs.python.org/3.6/library/platform.html
    return sys.maxsize > 2**32


SYSTEM_TO_OS = {"Darwin": "osx", "Linux": "linux", "Windows": "win"}

def runtime():
    os = SYSTEM_TO_OS.get(system(), None)
    if os is None:
        raise NotImplementedError("""The platform {} was not amoung the """
                                  """supported ones: {}""".format(
                                      system(),
                                      SYSTEM_TO_OS
                                  ))
    arch = "x64" if is_x64() else "x86"
    return "{os}-{arch}".format(os=os, arch=arch)


def main(argv=None):
    argv = argv or sys.argv[1:]
    parser = argparse.ArgumentParser()
    parser.add_argument("--packages",
                        type=str,
                        required=True,
                        metavar="PACKAGES",
                        help="""The location of the nuget packages.""")
    result = parser.parse_args(argv)

    result.packages = os.path.abspath(result.packages)

    try:
        sqlite_pkg_path = glob(
            os.path.join(result.packages, "system.data.sqlite.core/*/")
        )[0]
    except IndexError:
        raise RuntimeError("""Could not locate a """
                           """system.data.sqlite.core package.""")

    # Try locate the SQLite.Interop.(dll|so) under the runtime folder.
    # This will involving going into the appropriate runtime 'win-x64', etc...
    # then into the /lib folder, then into the dotnet version folder to finally
    # find (hopefully) a dll or so.
    runtime_version = runtime()
    runtime_dir = os.path.join(sqlite_pkg_path, "runtimes", runtime_version)
    if not os.path.exists(runtime_dir):
        raise RuntimeError("""Expected to find a runtime {} """
                           """but it did not exist.""".format(runtime_dir))
    runtime_lib_dir = os.path.join(runtime_dir, "lib")
    dotnet_version_to_interop_dll = {}
    for dotnet_version in os.listdir(runtime_lib_dir):
        interop_dll_glob = os.path.join(runtime_lib_dir,
                                        dotnet_version,
                                        "SQLite.Interop.*")
        try:
            interop_dll = glob(interop_dll_glob)[0]
            dotnet_version_to_interop_dll[dotnet_version] = interop_dll
        except IndexError:
            raise RuntimeError("""Could not find a SQLite.Interop dll or so """
                               """in the folder {}.""".format(interop_dll_glob))

    sqlite_lib_dirs = os.listdir(os.path.join(sqlite_pkg_path, "lib"))
    for lib_dotnet_version in sqlite_lib_dirs:
        if lib_dotnet_version not in dotnet_version_to_interop_dll:
            print(""".NET Version '{}' did not have an associated """
                  """SQLite.Interop.(dll|so)""".format(lib_dotnet_version))
            continue
        dll_path = dotnet_version_to_interop_dll[lib_dotnet_version]
        destination = os.path.join(sqlite_pkg_path,
                                   "lib",
                                   lib_dotnet_version,
                                   os.path.basename(dll_path))
        try:
            copy2(dll_path, destination)
        except PermissionError as err:
            if not os.path.exists(destination):
                raise err
            dst_size = os.stat(destination).st_size
            dll_size = os.stat(dll_path).st_size
            if dst_size != dll_size:
                raise RuntimeError(
                    """When attemping to copy {} to {} a PermissionError """
                    """was encountered due to the destination being in """
                    """use. They had a different file size which shouldn't """
                    """occur, this is probably an error. Try deleting your """
                    """packages folder and rebuilding. dst = {} vs dll = {}""".format(
                        dll_path,
                        destination,
                        dst_size,
                        dll_size
                    )
                )

if __name__ == "__main__":
    main()