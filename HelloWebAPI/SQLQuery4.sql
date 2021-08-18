CREATE TABLE Student(
    student_id INTEGER CONSTRAINT student_pk PRIMARY KEY,
    student_name VARCHAR(20) NOT NULL,
    univ_id INTEGER NOT NULL CONSTRAINT student_fk_university REFERENCES university (univ_id)
);

INSERT INTO Student VALUES(1, 'Ema Javor', 3);
INSERT INTO Student VALUES(2, 'Ana Vulic', 1);
INSERT INTO Student VALUES(3, 'Luka Peric', 2);
INSERT INTO Student VALUES(4, 'Marko Ovic', 3);
INSERT INTO Student VALUES(5, 'Lucija Kalic', 4);
INSERT INTO Student VALUES(6, 'David Dadic', 1);
INSERT INTO Student VALUES(7, 'Filip Jukic', 2);
