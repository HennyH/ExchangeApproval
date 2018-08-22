CREATE TABLE IF NOT EXISTS university
(
    university_id INTEGER PRIMARY KEY,
    university_name TEXT
);

CREATE TABLE IF NOT EXISTS unit
(
    unit_id INTEGER PRIMARY KEY,
    unit_name TEXT NOT NULL,
    unit_code TEXT NULL,
    university_id INTEGER NOT NULL,
    FOREIGN KEY (university_id) REFERENCES university (university_id)
);

CREATE TABLE IF NOT EXISTS uwa_unit_context
(
    uwa_unit_context_id INTEGER PRIMARY KEY,
    uwa_unit_context_name TEXT NOT NULL
);

INSERT INTO uwa_unit_context
VALUES (1, 'Elective'), (2, 'Core'), (3, 'Complementary');

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


CREATE VIEW IF NOT EXISTS uwa_units AS
SELECT
    unit_id as unit_id,
    unit_name as unit_name,
    unit_code as unit_code
FROM unit
INNER JOIN university ON unit.university_id = university.university_id
WHERE university.university_name = 'University of Western Australia';

CREATE VIEW IF NOT EXISTS exchange_units AS
SELECT
    unit_id as unit_id,
    unit_name as unit_name,
    unit_code as unit_code,
    university.university_id as university_id,
    university.university_name as university_name
FROM unit
INNER JOIN university ON unit.university_id = university.university_id
WHERE university.university_name <> 'University of Western Australia';