CREATE TABLE university(
    univ_id INTEGER CONSTRAINT univ_pk PRIMARY KEY,
    univ_name VARCHAR(20) NOT NULL,
    univ_location VARCHAR(15) NOT NULL,
    
);

INSERT INTO university VALUES(1, 'FER', 'Zagreb');
INSERT INTO university VALUES(2, 'PMF', 'Zagreb');
INSERT INTO university VALUES(3, 'MATHOS', 'Osijek');
INSERT INTO university VALUES(4, 'FOI', 'Varazdin');