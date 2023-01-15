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
       [Id] INT PRIMARY KEY IDENTITY NOT NULL,
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
       [Id] INT PRIMARY KEY IDENTITY,
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

--09-Change Primary Key
ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC07EF8B2B7A

ALTER TABLE [Users]
ADD PRIMARY KEY ([Id], [Username])


--10-Add Check Constraint
ALTER TABLE [Users]
ADD CHECK (LEN([Password])>=5)

--11-Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT df_LastLoginTime
DEFAULT CURRENT_TIMESTAMP FOR [LastLoginTime]

--12-Set Unique Field
ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__7722245950A5D66E

ALTER TABLE [Users]
ADD PRIMARY KEY ([Id])

ALTER TABLE[Users]
ADD CONSTRAINT AK_Username UNIQUE ([Username])

ALTER TABLE [Users]
ADD CHECK (LEN([Username])>=3)

--13-Movies Database
CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
       [Id] INT PRIMARY KEY IDENTITY NOT NULL,
	   [DirectorName] NVARCHAR(50) NOT NULL,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [Genres](
       [Id] INT PRIMARY KEY IDENTITY NOT NULL,
	   [GenreName] NVARCHAR(50) NOT NULL,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [Categories](
       [Id] INT PRIMARY KEY IDENTITY NOT NULL,
	   [CategoryName] NVARCHAR(50) NOT NULL,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [Movies](
       [Id] INT PRIMARY KEY IDENTITY NOT NULL,
	   [Title] NVARCHAR(50) NOT NULL,
	   [DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id)NOT NULL,
	   [CopyrightYear] CHAR(4),
	   [Length] TIME,
	   [GenreId] INT FOREIGN KEY REFERENCES [Genres](Id)NOT NULL,
	   [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id)NOT NULL,
	   [Rating] INT,
	   [Notes] NVARCHAR(MAX)
	   )
	   

INSERT INTO [Directors]([DirectorName], [Notes])
       VALUES
	   ('Gosho', NULL),
	   ('Petar', NULL),
	   ('Ivan', NULL),
	   ('Ganka', NULL),
	   ('Stefka', NULL)

INSERT INTO [Genres]([GenreName], [Notes])
       VALUES
	   ('Action', NULL),
	   ('Drama', NULL),
	   ('Drama', NULL),
	   ('Horror', NULL),
	   ('Fantasy', NULL)

INSERT INTO [Categories]([CategoryName], [Notes])
       VALUES
	   ('Basic', NULL),
	   ('Basic', NULL),
	   ('Basic', NULL),
	   ('Basic', NULL),
	   ('Basic', NULL)

INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
       VALUES
	   ('Imposible Movie', 2, '2023', '2:34:54.1237',  1, 1, 10, NULL),
	   ('Ending Slowly', 2, '2023', '2:34:54.1237',  1, 3, 10, NULL),
	   ('Princess', 2, '2020', '1:34:54.1237',  1, 1, 9, NULL),
	   ('Casandra', 2, '1958', '2:30:50.1007',  1, 1, 4, NULL),
	   ('I cant do it anymore', 2, '2023', '2:34:00.0000',  1, 1, 6, NULL)


--14-Car Rental Database
CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
       [Id] INT PRIMARY KEY IDENTITY,
	   [CategoryName] NVARCHAR(50) NOT NULL,
	   [DailyRate] INT,
	   [WeeklyRate] INT,
	   [MonthlyRate] INT,
	   [WeekendRate] INT
	   )

CREATE TABLE [Cars](
       [Id] INT PRIMARY KEY IDENTITY,
	   [PlateNumber] INT NOT NULL,
	   [Manufacturer] NVARCHAR(20) NOT NULL,
	   [Model] NVARCHAR(20)NOT NULL,
	   [CarYear] DATE,
	   [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	   [Doors] INT,
	   [Picture] VARBINARY(MAX),
	   [Condition] NVARCHAR(100),
	   [Available] BIT
	   )

CREATE TABLE [Employees](
       [Id] INT PRIMARY KEY IDENTITY,
	   [FirstName] NVARCHAR(10) NOT NULL,
	   [LastName] NVARCHAR(10) NOT NULL,
	   [Title] NVARCHAR(10),
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [Customers](
       [Id] INT PRIMARY KEY IDENTITY,
	   [DriverLicenceNumber] INT NOT NULL,
	   [FullName] NVARCHAR(50) NOT NULL,
	   [Address] NVARCHAR(50),
	   [City] NVARCHAR(30),
	   [ZIPCode] INT,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [RentalOrders](
       [Id] INT PRIMARY KEY IDENTITY,
	   [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	   [CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL,
	   [CarId] INT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL,
	   [TankLevel] INT,
	   [KilometrageStart] INT,
	   [KilometrageEnd] INT,
	   [TotalKilometrage] INT,
	   [StartDate] DATE,
	   [EndDate] DATE,
	   [RateApplied] NVARCHAR(10),
	   [TaxRate] DECIMAL,
	   [OrderStatus] BIT,
	   [Notes] NVARCHAR(MAX)
	   )


INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
       VALUES
	   ('Truck', NULL, NULL, NULL, NULL),
	   ('Nice Car', 9, 10, 10, 10),
	   ('Small Car', 5, 7, 7, 6)

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Condition], [Available])
       VALUES
	   (1254, 'Seat', 'Ibiza', '2011-10-05', 2, 3, 'I have no idea', 1),
	   (5874, 'Opel', 'Astra', NULL, 1, 5, NULL, 1),
	   (1254, 'BMW', 'M5', NULL, 3, 5, NULL, 1)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
       VALUES
	   ('Иванка', 'Михайлова', 'Учител', NUll),
	   ('Geroge', 'Snow', NULL, NUll),
	   ('John', 'Snow', NULL, NUll)

INSERT INTO [Customers]([DriverLicenceNumber],[FullName],[Address], [City], [ZIPCode], [Notes])
       VALUES
	   (587499865, 'Gabriel Mondo', 'Unknown', 'Viena', 854421, NULL),
	   (547022100, 'Alexander Martin', NULL, 'London', NULL, NULL),
	   (587499865, 'Sara Ivanova', NULL, 'Sofia', NULL, NULL)

INSERT INTO [RentalOrders]([EmployeeId],[CustomerId],[CarId],[TankLevel],[KilometrageStart], [KilometrageEnd] ,[TotalKilometrage],[StartDate],[EndDate],[RateApplied],[TaxRate],[OrderStatus], [Notes])
       VALUES
	   (1, 1, 1, 5, 100000, 120000, 120000, '2022-12-01', '2023-01-15', NULL, 3.5, 1, NULL),
	   (2, 2, 2, 10, 100000, 110000, 110000, '2022-08-01', '2022-09-10', NULL, 3.5, 1, NULL),
	   (3, 3, 3, 7, 100000, 105000, 105000, '2022-10-01', '2022-11-25', NULL, 3.5, 1, NULL)


--15-Hotel Database
CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees](
       [Id] INT PRIMARY KEY IDENTITY,
	   [FirstName] NVARCHAR(10) NOT NULL,
	   [LastName] NVARCHAR(10) NOT NULL,
	   [Title] NVARCHAR(10),
	   [NOTES] NVARCHAR(MAX)
	   )

CREATE TABLE [Customers](
       [AccountNumber] INT PRIMARY KEY IDENTITY,
	   [FirstName] NVARCHAR(10) NOT NULL,
	   [LastName] NVARCHAR(10) NOT NULL,
	   [PhoneNumber] INT,
	   [EmergencyName] NVARCHAR(10),
	   [EmergencyNumber] INT,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [RoomStatus](
       [RoomStatus] INT PRIMARY KEY IDENTITY,
	   [