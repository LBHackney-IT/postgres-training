CREATE SCHEMA IF NOT EXISTS dbo;

CREATE TABLE dbo.persons {
  id int PRIMARY KEY,
  first_name varchar(45) NULL,
  middle_name varchar(45) NULL,
  surname varchar(45) NULL,
  title title,
  place_of_birth varchar(45) NULL,
  date_of_birth timestamp NULL
} 

CREATE TYPE title as ENUM (Mr, Mrs, Miss, Mx)
