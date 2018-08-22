# /database/seed_test_data.py
#
# Seeds a database with test data.
#
# See /LICENCE.md for Copyright information
"""Seeds a database with test data."""

import os

import sys

import sqlite3

import argparse

import random

import datetime

from string import ascii_uppercase, digits

WORDS = [
    "people",
    "history",
    "way",
    "art",
    "world",
    "information",
    "map",
    "two",
    "family",
    "government",
    "health",
    "system",
    "computer",
    "meat",
    "year",
    "thanks",
    "music",
    "person",
    "reading",
    "method",
    "data",
    "food",
    "understanding",
    "theory",
    "law",
    "bird",
    "literature",
    "problem",
    "software",
    "control",
    "knowledge",
    "power",
    "ability",
    "economics",
    "love",
    "internet",
    "television",
    "science",
    "library",
    "nature",
    "fact",
    "product",
    "idea",
    "temperature",
    "investment",
    "area",
    "society",
    "activity",
    "story",
    "industry",
    "media",
    "thing",
    "oven",
    "community",
    "definition",
    "safety",
    "quality",
    "development",
    "language",
    "management",
    "player",
    "variety",
    "video",
    "week",
    "security",
    "country",
    "exam",
    "movie",
    "organization",
    "equipment",
    "physics",
    "analysis",
    "policy",
    "series",
    "thought",
    "basis",
    "boyfriend",
    "direction",
    "strategy",
    "technology",
    "army",
    "camera",
    "freedom",
    "paper",
    "environment",
    "child",
    "instance"
]

def generate_universities(c):
    names = [
        "Western Australia",
        "New York",
        "Los Angeles",
        "Chicago",
        "Houston",
        "Philadelphia",
        "Phoenix",
        "San Antonio",
        "San Diego",
        "Dallas",
        "San Jose",
        "Austin",
        "Jacksonville",
        "San Francisco",
        "Indianapolis",
        "Columbus",
        "Fort Worth",
        "Charlotte",
        "Detroit"
    ]
    names = ["University of {}".format(n) for n in names]
    universities = list(enumerate(names, start=1))
    for idx, name in universities:
        c.execute("INSERT INTO university (university_id, university_name) "
                  "VALUES (?, ?)",
                  (idx, name))
    return universities


def generate_units(c, universites):
    units = []
    for uni_id, uni_name in universites:
        for _ in range(20):
            n_name_parts = random.randint(2, 4)
            unit_name = " ".join(
                w.capitalize() for w in random.sample(WORDS, n_name_parts)
            )
            unit_code = "".join(
                random.sample(ascii_uppercase, random.randint(2, 4)) +
                random.sample(digits, random.randint(2, 4))
            )
            c.execute("INSERT INTO unit (unit_name, unit_code, "
                      "university_id) VALUES (?, ?, ?)",
                      (unit_name, unit_code, uni_id))
            unit_id = c.lastrowid
            units.append((unit_id, unit_name, unit_code, uni_id, uni_name))
    return units


def generate_decisions(c, universities, units):
    decisions = []
    uwa_name = "University of Western Australia"
    uwa_units = [u for u in units if uwa_name in u]
    for exch_unit_id, *_ in units:
        unit_context = random.randint(1, 3)
        if unit_context == 1:
            uwa_unit_id = None
        else:
            uwa_unit_id, *_ = random.choice(uwa_units)
        approved = random.choice([True, True, False])
        c.execute("INSERT INTO unit_decision (decision_date, "
                  "uwa_unit_context_id, uwa_unit_id, exchange_unit_id, "
                  "approved) VALUES (?, ?, ?, ?, ?)",
                  (
                      datetime.datetime.now() - datetime.timedelta(days=random.randint(1, 900)),
                      unit_context,
                      uwa_unit_id,
                      exch_unit_id,
                      approved
                  ))
        decision_id = c.lastrowid
        decisions.append((
            datetime.datetime.now() - datetime.timedelta(days=random.randint(1, 900)),
            unit_context,
            uwa_unit_id,
            exch_unit_id,
            approved,
            decision_id
        ))
    return decisions


def main(argv=None):
    argv = argv or sys.argv[1:]
    parser = argparse.ArgumentParser()
    parser.add_argument("--database",
                        type=str,
                        required=True,
                        metavar="DATABASE",
                        help="""The database to populate with seed data.""")
    result = parser.parse_args(argv)
    conn = sqlite3.connect(result.database)
    cur = conn.cursor()
    universities = generate_universities(cur)
    units = generate_units(cur, universities)
    generate_decisions(cur, universities, units)
    conn.commit()
    conn.close()


if __name__ == "__main__":
    main()
