# /api/build/generate-database.py
#
# Generates a SQLite database from the given schema.
#
# See /LICENCE.md for Copyright information
"""Generates a SQLite database from the given schema."""

import os

import sys

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
    parser.add_argument("--schma",
                        type=str,
                        required=True,
                        metavar="SCHEMA",
                        help="""The SQL script to run to create the file.""")
    