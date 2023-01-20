CREATE DATABASE Exercise
GO

USE Exercise

--01. One-To-One Relationship
CREATE TABLE Passports
(
             PersonID INT PRIMARY KEY IDENTITY(101,1),
			 PassportNumber CHAR(8)
)

CREATE TABLE Persons
(
             PersonID INT PRIMARY KEY IDENTITY,
			 FirstName VARCHAR(50),
			 Salary DECIMAL(9,2),
			 PassportID INT FOREIGN KEY REFERENCES Passports(PersonID) UNIQUE
)

INSERT INTO Passports(PassportNumber)
VALUES
       ('N34FG21B'),
	   ('K65LO4R7'),
	   ('ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
       ('Roberto', 43300.00, 102),
	   ('Tom', 56100.00, 103),
	   ('Yana', 60200.00, 101)


--02. One-To-Many Relationship
