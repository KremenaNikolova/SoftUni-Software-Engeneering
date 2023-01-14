--01-Create Database
CREATE DATABASE [Minions]

USE [Minions]

--02-Create Tables
CREATE TABLE [Minions] (
       [Id] INT PRIMARY KEY NOT NULL,
	   [Name] NVARCHAR(50),
	   [Age] INT
	   )


CREATE TABLE [Towns] (
       [Id] INT PRIMARY KEY NOT NULL,
	   [Name] NVARCHAR(70)
	   )


--03-Alter Minions Table
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns](Id) NOT NULL

--04-Insert Records in Both Tables
INSERT INTO [Towns]([Id], [Name])
       VALUES
       (1, 'Sofia'),
	   (2, 'Plovdiv'),
	   (3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
       VALUES
	   (1, 'Kevin', 22, 1),
	   (2, 'Bob', 15, 3),
	   (3, 'Steward', NULL, 2)

--05-Truncate Table Minions
TRUNCATE TABLE [Minions]

--06-Drop All Tables
DROP TABLE [Minions]
DROP TABLE [Towns]

--07-Create Table People
CREATE TABLE [People](
       [Id] INT IDENTITY NOT NULL,
	   [Name] NVARCHAR(200) NOT NULL,
	   [Picture] VARBINARY(MAX), 
	   CHECK (DATALENGTH([Picture]) <= 2000000),
	   [Height] DECIMAL(3,2),
	   [Weight] DECIMAL(5,2),
	   [Gender] CHAR(1) NOT NULL,
	   CHECK ([Gender] = 'f' OR [Gender] = 'm'),
	   [Birthdate] DATE NOT NULL,
	   [Biography] NVARCHAR(MAX)
	   )

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate], [Biography])
       VALUES
       ('Petar', 1.75, 75.43, 'm', '1990-10-18', NULL),
	   ('Gosho', NULL, NUll, 'm', '1998-03-03', NULL),
	   ('Gina', 1.99, 123.55, 'f', '2000-12-24', NULL),
	   ('Gabriela', 1.55, 73, 'f', '1985-10-10', NULL),
	   ('Ivanka', NULL, NULL, 'f', '1978-05-28', NULL)


--08-Create Table Users
CREATE TABLE [Users](
       [Id] INT IDENTITY NOT NULL,
	   [Username] VARCHAR(30) NOT NULL,
	   [Password] VARCHAR(26) NOT NULL,
	   [ProfilePicture] VARBINARY(MAX),
	   CHECK (DATALENGTH([ProfilePicture])<=900000),
	   [LastLoginTime] DATETIME2,
	   [IsDeleted] BIT NOT NULL,
	   )

INSERT INTO [Users]([Username], [Password], [LastLoginTime], [IsDeleted])
       VALUES
	   ('Georgi', '12345', NULL, 0),
	   ('Petar', '58745', NULL, 0),
	   ('Stefan', '36544g', NULL, 0),
	   ('Mary', '1gew5', NULL, 0),
	   ('Sara', 'wqss45', NULL, 1)
