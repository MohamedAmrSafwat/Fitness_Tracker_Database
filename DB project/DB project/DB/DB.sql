CREATE DATABASE FitnessApp;

GO
USE FitnessApp;

CREATE TABLE Users (
    userID INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(50) NOT NULL,
    Name VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    age INT NOT NULL,
    gender VARCHAR(50) NOT NULL
);

INSERT INTO Users (username, password, Name, email, age, gender)
VALUES 
('moemad', '3012', 'Mohammad Emad', 'moemad@gmail.com', 20, 'Male');

CREATE TABLE Coach (
    coachID INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(50) NOT NULL,
    Name VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    experience_years INT NOT NULL,
    phone VARCHAR(20) NOT NULL 
);

INSERT INTO Coach
VALUES
('pepG' , 'barca2009' , 'Pep Guardiola', 'pep@gmail.com' , 53 , '0222334');

CREATE TABLE Nutritionist (
    nutritionistID INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(50) NOT NULL,
    Name VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    experience_years INT NOT NULL,
    phone VARCHAR(20) NOT NULL
);
INSERT INTO Nutritionist
VALUES
('Cbum' , 'Mrolympia' , 'Chris Bumstead', 'cbum@gmail.com' , 29 , '07775000');


SELECT * FROM Coach
SELECT * FROM Users
SELECT * FROM Nutritionist
DELETE FROM Coach WHERE experience_years = 20;