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