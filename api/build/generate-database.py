# /api/build/generate-database.py
#
# Generates a SQLite database from the given schema.
#
# See /LICENCE.md for Copyright information
"""Generates a SQLite database from the given schema."""

import os

import sys

import sqlite3

import argparse


def main(argv=None):
    argv = argv or sys.argv[1:]
    parser = argparse.ArgumentParser()
    parser.add_argument("--output",
                        type=str,
                        required=True,
                        metavar="OUTPUT",
                        help="""The location to save the created """
                             """database to.""")
    parser.add_argument("--schema",
                        type=str,
                        required=True,
                        metavar="SCHEMA",
                        help="""The SQL script to run to create the file.""")
    result = parser.parse_args(argv)

    with open(result.schema, "r") as schema_fileobj:
        schema_script = schema_fileobj.read()

    os.makedirs(os.path.dirname(result.output), exist_ok=True)
    if os.path.exists(result.output):
        try:
            os.unlink(result.output)
        except:
            pass
    connection = sqlite3.connect(result.output)
    connection.executescript(schema_script)

if __name__ == "__main__":
    main()
