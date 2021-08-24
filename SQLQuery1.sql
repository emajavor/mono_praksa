

CREATE TABLE University
(
	University_id INT CONSTRAINT university_pk PRIMARY KEY,
	University_name VARCHAR(20) NOT NULL,
	City VARCHAR(15) NOT NULL
);

CREATE TABLE Student
( 
	Student_id INT CONSTRAINT student_pk PRIMARY KEY,
	First_name VARCHAR(20) NOT NULL,
	Last_name VARCHAR(20) NOT NULL,
	University_id INT NOT NULL CONSTRAINT student_fk_university REFERENCES University(University_id)
);



INSERT INTO University VALUES(1, 'PMF', 'Zagreb');
INSERT INTO University VALUES(2, 'MATHOS', 'Osijek');
INSERT INTO University VALUES(3, 'FOI', 'Varazdin');

INSERT INTO Student VALUES(10, 'Marko', 'Lukic', 1);
INSERT INTO Student VALUES(20, 'Ana', 'Pastor', 2);
INSERT INTO Student VALUES(30, 'Ivan', 'Gajic', 3);

SELECT * FROM Student;
SELECT * FROM University;