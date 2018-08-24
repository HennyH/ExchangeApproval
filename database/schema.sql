-- Store generic information about each university.
CREATE TABLE IF NOT EXISTS university
(
    university_id INTEGER PRIMARY KEY,
    university_name TEXT
);

-- A 'unit' is the minimal set of information nessacery to uniquely describe
-- a unit at any university.
CREATE TABLE IF NOT EXISTS unit
(
    unit_id INTEGER PRIMARY KEY,
    unit_name TEXT NOT NULL,
    unit_code TEXT NULL,
    university_id INTEGER NOT NULL,
    FOREIGN KEY (university_id) REFERENCES university (university_id)
);

-- Exchange units hold additional information to the underlying 'unit' table
-- such as a link to the unit outline.
CREATE TABLE IF NOT EXISTS exchange_unit
(
    exchange_unit_id INTEGER PRIMARY KEY,
    unit_id INTEGER NOT NULL,
    exchange_unit_outline_href TEXT NOT NULL,
    FOREIGN KEY (unit_id) REFERENCES unit (unit_id)
);

-- Units at UWA have some additional information attached to them
CREATE TABLE IF NOT EXISTS uwa_unit_context
(
    uwa_unit_context_id INTEGER PRIMARY KEY,
    uwa_unit_context_name TEXT NOT NULL
);
INSERT INTO uwa_unit_context
VALUES (1, 'Elective'), (2, 'Core'), (3, 'Complementary');

CREATE TABLE IF NOT EXISTS uwa_unit_level
(
    uwa_unit_level_id INTEGER PRIMARY KEY,
    uwa_unit_level_name TEXT NOT NULL
);
INSERT INTO uwa_unit_level
VALUES (1, '1000'), (2, '2000'), (3, '3000'), (4, '>4000');

CREATE TABLE IF NOT EXISTS uwa_unit
(
    uwa_unit_id INTEGER PRIMARY KEY,
    uwa_unit_level_id INTEGER NOT NULL,
    unit_id INTEGER NOT NULL,
    FOREIGN KEY (uwa_unit_level_id) REFERENCES uwa_unit_level (uwa_unit_level_id),
    FOREIGN KEY (unit_id) REFERENCES unit (unit_id)
);

-- Represents a decision about a unit for an exchange program.
CREATE TABLE IF NOT EXISTS unit_decision
(
    decision_id INTEGER PRIMARY KEY,
    decision_date DATE NOT NULL,
    uwa_unit_context_id INTEGER NOT NULL,
    uwa_unit_id INTEGER NULL,
    exchange_unit_id INTEGER NOT NULL,
    approved BOOLEAN NOT NULL,
    FOREIGN KEY (uwa_unit_context_id) REFERENCES uwa_unit_context_id (uwa_unit_context_id),
    FOREIGN KEY (uwa_unit_id) REFERENCES unit (unit_id),
    FOREIGN KEY (exchange_unit_id) REFERENCES unit (unit_id)
);

-- Nice helper views for common operations
CREATE VIEW IF NOT EXISTS denormalized_uwa_units AS
SELECT
    uwa_unit.uwa_unit_id AS uwa_unit_id,
    unit.unit_id AS unit_id,
    unit.unit_name AS unit_name,
    unit.unit_code AS unit_code,
    uwa_unit_level.uwa_unit_level_id AS uwa_unit_level_id,
    uwa_unit_level.uwa_unit_level_name AS uwa_unit_level_name
FROM uwa_unit
INNER JOIN uwa_unit_level ON uwa_unit_level.uwa_unit_level_id = uwa_unit.uwa_unit_level_id
INNER JOIN unit ON unit.unit_id = uwa_unit.unit_id
INNER JOIN university ON unit.university_id = university.university_id
WHERE university.university_name = 'University of Western Australia';

CREATE VIEW IF NOT EXISTS denormalized_exchange_units AS
SELECT
    exchange_unit.exchange_unit_id AS exchange_unit_id,
    exchange_unit.exchange_unit_outline_href AS exchange_unit_outline_href,
    unit.unit_id AS unit_id,
    unit.unit_name AS unit_name,
    unit.unit_code AS unit_code,
    university.university_id AS university_id,
    university.university_name AS university_name
FROM exchange_unit
INNER JOIN unit ON unit.unit_id = exchange_unit.unit_id
INNER JOIN university ON unit.university_id = university.university_id
WHERE university.university_name <> 'University of Western Australia';

CREATE VIEW IF NOT EXISTS denormalized_unit_decisions AS
SELECT
    unit_decision.decision_id AS decision_id,
    unit_decision.decision_date AS decision_date,
    exchange_unit.university_id AS exchange_university_id,
    exchange_unit.university_name AS exchange_university_name,
    exchange_unit.unit_name AS exchange_unit_name,
    exchange_unit.unit_code AS exchange_unit_code,
    exchange_unit.exchange_unit_outline_href AS exchange_unit_outline_href,
    uwa_unit_context.uwa_unit_context_id AS uwa_unit_context_id,
    uwa_unit_context.uwa_unit_context_name AS uwa_unit_context_name,
    uwa_unit.uwa_unit_level_id AS uwa_unit_level_id,
    uwa_unit.uwa_unit_level_name AS uwa_unit_level_name,
    uwa_unit.unit_name AS uwa_unit_name,
    uwa_unit.unit_code AS uwa_unit_code,
    unit_decision.approved AS approved
FROM unit_decision
LEFT OUTER JOIN denormalized_uwa_units AS uwa_unit
    ON unit_decision.uwa_unit_id = uwa_unit.uwa_unit_id
LEFT OUTER JOIN uwa_unit_context
    ON uwa_unit_context.uwa_unit_context_id = unit_decision.uwa_unit_context_id
INNER JOIN denormalized_exchange_units AS exchange_unit
    ON exchange_unit.exchange_unit_id = unit_decision.exchange_unit_id;