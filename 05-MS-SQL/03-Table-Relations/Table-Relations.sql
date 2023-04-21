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
CREATE TABLE Manufacturers
(
             ManufacturerID INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50),
			 EstablishedOn DATE
)

CREATE TABLE Models
(
             ModelID INT PRIMARY KEY IDENTITY(101, 1),
			 [Name] VARCHAR(50),
			 ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name], EstablishedOn)
VALUES
       ('BMW', '07/03/1916'),
	   ('Tesla','01/01/2003'),
	   ('Lada', '01/05/1966')

INSERT INTO Models([Name], ManufacturerID)
VALUES
       ('X1', 1),
	   ('i6', 1),
	   ('Model S', 2),
	   ('Model X', 2),
	   ('Model 3', 2),
	   ('Nova', 3)


--03. Many-To-Many Relationship
CREATE TABLE Students
(
             StudentID INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(50) NOT NULL,
)

CREATE TABLE Exams
(
             ExamID INT PRIMARY KEY IDENTITY(101, 1),
			 [Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE StudentsExams
(
             StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
			 ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
			 PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students([Name])
VALUES
            ('Mila'),
			('Toni'),
			('Ron')

INSERT INTO Exams([Name])
VALUES
            ('SpringMVC'),
			('Neo4j'),
			('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES
            (1, 101),
			(1, 102),
			(2, 101),
			(3, 103),
			(2, 102),
			(2, 103)


--04. Self-Referencing
CREATE TABLE Teachers
(
             TeacherID INT PRIMARY KEY IDENTITY(101, 1),
			 [Name] VARCHAR(50),
			 ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID)
VALUES
            ('John', NULL),
			('Maya', 106), 
			('Silvia', 106), 
			('Ted', 105), 
			('Mark', 101), 
			('Greta', 101)


--05. Online Store Database
CREATE DATABASE [Online Store]
GO

USE [Online Store]
GO

CREATE TABLE Cities
(
             CityID INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(50)
)

CREATE TABLE ItemTypes
(
             ItemTypeID INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(50)
)

CREATE TABLE Customers
(
             CustomerID INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(50),
			 Birthday DATE,
			 CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
             OrderID INT PRIMARY KEY IDENTITY,
			 CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE Items
(
             ItemID INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(50),
			 ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
             OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
			 ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
			 PRIMARY KEY(OrderID, ItemID)
)


--06. University Database
CREATE DATABASE University 
GO

USE University
GO

CREATE TABLE Majors
(
             MajorID INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Subjects
(
             SubjectID INT PRIMARY KEY IDENTITY,
			 SubjectName NVARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
             StudentID INT PRIMARY KEY IDENTITY,
			 StudentNumber INT NOT NULL,
			 StudentName NVARCHAR(50) NOT NULL,
			 MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
             Payment INT PRIMARY KEY IDENTITY,
			 PaymentDate DATE NOT NULL,
			 PaymentAmount DECIMAL(9,2) NOT NULL,
			 StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda
(
             StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
			 SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
			 PRIMARY KEY(StudentID, SubjectID)
)


--09. *Peaks in Rila
USE [Geography]

   SELECT m.MountainRange, p.PeakName, p.Elevation
     FROM Mountains AS m
LEFT JOIN Peaks AS p
       ON p.MountainId = m.Id
    WHERE MountainRange = 'Rila'
 ORDER BY p.Elevation DESC
