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
    sqlite_lib_dirs = os.listdir(os.path.join(sqlite_pkg_path, "lib"))
    sqlite_build_dirs = os.listdir(os.path.join(sqlite_pkg_path, "build"))

    for dotnet_version in sqlite_lib_dirs:
        # On windows (and possibly) other platforms there is not a
        # netstandard2.0 folder under /build but the highest netX dll/so
        # does the job. So the logic here is if there isn't a direct match
        # just grab the one from the newest netX folder.
        if dotnet_version not in sqlite_build_dirs:
            is_netX = lambda n: re.match(r"net\d+", n)
            dotnet_version = sorted(
                filter(is_netX, sqlite_build_dirs),
                reverse=True
            )[0]

        # Depending on the system we need to go into different folders to get
        # the dll/so within a build/<dotnet-version> folder.
        dll_path_components = [sqlite_pkg_path, "build", dotnet_version]
        if system() == "Windows":
            if is_x64():
                dll_path_components.extend(["x64", "SQLite.Interop.dll"])
            else:
                dll_path_components.extend(["x86", "SQLite.Interop.dll"])
        else:
            dll_path_components.extend(["SQLite.Interop.so"])

        dll_path = os.path.join(*dll_path_components)
        lib_folder = os.path.join(sqlite_pkg_path, "lib", dotnet_version)
        copy2(dll_path, lib_folder)

if __name__ == "__main__":
    main()