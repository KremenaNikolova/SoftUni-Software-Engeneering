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
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [Customers](
       [AccountNumber] INT PRIMARY KEY IDENTITY,
	   [FirstName] NVARCHAR(10) NOT NULL,
	   [LastName] NVARCHAR(10) NOT NULL,
	   [PhoneNumber] INT,
	   [EmergencyName] NVARCHAR(20),
	   [EmergencyNumber] INT,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [RoomStatus](
       [RoomStatus] VARCHAR(25) PRIMARY KEY NOT NULL,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [RoomTypes](
       [RoomType] VARCHAR(25) PRIMARY KEY NOT NULL,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [BedTypes](
       [BedType] VARCHAR(25) PRIMARY KEY NOT NULL,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [Rooms](
       [RoomNumber] INT PRIMARY KEY IDENTITY,
	   [RoomType] VARCHAR(25) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL,
	   [BedType] VARCHAR(25) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL,
	   [Rate] INT,
	   CHECK ([Rate]<=10),
	   [RoomStatus] VARCHAR(25) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]) NOT NULL,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [Payments](
       [Id] INT PRIMARY KEY IDENTITY,
	   [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	   [PaymentDate] DATE,
	   [AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	   [FirstDateOccupied] DATE NOT NULL,
	   [LastDateOccupied] DATE NOT NULL,
	   [TotalDays] INT NOT NULL,
	   [AmountCharged] DECIMAL NOT NULL,
	   [TaxRate] DECIMAL,
	   [TaxAmount] DECIMAL,
	   [PaymentTotal] DECIMAL NOT NULL,
	   [Notes] NVARCHAR(MAX)
	   )

CREATE TABLE [Occupancies](
       [Id] INT PRIMARY KEY IDENTITY,
	   [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	   [DateOccupied] DATE,
	   [AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	   [RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
	   [RateApplied] DECIMAL (5,2),
	   [PhoneCharge] DECIMAL (5,2),
	   [Notes] NVARCHAR(MAX)
	   )

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
       VALUES
	   ('Ivan', 'Ivanov', 'Director', 'I have no idea'),
	   ('Ganka', 'Grozdanova', 'IT', NULL),
	   ('Kremena', 'Nikolova', NULL, NULL)

INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
       VALUES
	   ('Geroge', 'Depp', 000147299, 'Ivan', 000178995, 'This is just exercise'),
	   ('Stefan', 'Old', 000555666, 'Deamon', 000777888, 'This is just exercise'),
	   ('Baby', 'Boy', 000147258, 'Bbaby', 000369852, 'This is just exercise')

INSERT INTO [RoomStatus]([RoomStatus], [Notes])
       VALUES
	   ('Availible', NULL),
	   ('Availible Sometimes', 'Good clean'),
	   ('Not Availible', NULL)

INSERT INTO [RoomTypes]([RoomType], [Notes])
       VALUES
	   ('Apartment', 'Nice one'),
	   ('2 rooms', NULL),
	   ('Studio', NULL)

INSERT INTO [BedTypes]([BedType], [Notes])
       VALUES
	   ('Double bed', 'For couples'),
	   ('Signle bed', 'When you are signle man'),
	   ('Big Romantic Bed', NULL)

INSERT INTO [Rooms]([RoomType], [BedType], [Rate], [RoomStatus], [Notes])
       VALUES
	   ('Apartment', 'Double bed', 10, 'Availible', NULL),
	   ('Studio', 'Big Romantic Bed', 10, 'Availible Sometimes', 'Really nice one'),
	   ('2 rooms', 'Signle bed', 8, 'Not Availible', NULL)

INSERT INTO [Payments]([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [TotalDays], [AmountCharged], [TaxRate], [TaxAmount], [PaymentTotal], [Notes])
       VALUES
	   (2, '2023-01-03', 2, '2023-05-25', '2023-05-30', 5, 2050, 2.25, 410, 2460, NULL),
	   (1, '2023-01-10', 3, '2023-07-07', '2023-07-27', 10, 4100, 2.25, 820, 4920, NULL),
	   (3, '2023-01-05', 1, '2023-05-15', '2023-05-25', 10, 4100, 2.25, 820, 4920, NULL)

INSERT INTO [Occupancies]([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
       VALUES
	   (2, '2023-05-25', 2, 1, 9.00, NULL, NULL),
	   (1, '2023-07-07', 3, 2, 9.00, NULL, NULL),
	   (3, '2023-05-15', 1, 3, 7.00, NULL, 'Very Well')


--16-Create SoftUni Database
CREATE DATABASE [SoftUni]

USE[SoftUni]

CREATE TABLE [Towns](
       [Id] INT PRIMARY KEY IDENTITY,
	   [Name] NVARCHAR(50) NOT NULL
	   )

CREATE TABLE [Addresses](
       [Id] INT PRIMARY KEY IDENTITY,
	   [AddressText] NVARCHAR(MAX),
	   [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
	   )

CREATE TABLE [Departments](
       [Id] INT PRIMARY KEY IDENTITY,
	   [Name] NVARCHAR(50) NOT NULL
	   )

CREATE TABLE [Employees](
       [Id] INT PRIMARY KEY IDENTITY,
	   [FirstName] NVARCHAR(15) NOT NULL,
	   [MiddleName] NVARCHAR(15) NOT NULL,
	   [LastName] NVARCHAR(15) NOT NULL,
	   [JobTitle] NVARCHAR(15),
	   [DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
	   [HireDate] DATE,
	   [Salary] DECIMAL (6,2),
	   [AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
	   )


--17-Backup Database
USE[master]
GO

BACKUP DATABASE [SoftUni]
TO DISK = 'C:\Users\aradi\Desktop\softuni-backup.bak'
GO

DROP DATABASE [SoftUni]
GO

RESTORE DATABASE [SoftUni]
FROM DISK = 'C:\Users\aradi\Desktop\softuni-backup.bak'


--18-Basic Insert
USE [SoftUni]
GO

INSERT INTO [Towns]([Name])
       VALUES
	   ('Sofia'),
	   ('Plovdiv'),
	   ('Varna'),
	   ('Burgas')

INSERT INTO [Addresses]([AddressText], [TownId])
       VALUES
	   ('bul. Simeon Veliki 33', 1),
	   ('Peach Garden 1', 2),
	   ('Uknown 21', 3)

INSERT INTO [Departments]([Name])
       VALUES
	   ('Engineering'),
	   ('Sales'),
	   ('Marketing'),
	   ('Software Development'),
	   ('Quality Assurance')

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
       VALUES
	   ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	   ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	   ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	   ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	   ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)


--19-Basic Select All Fields
SELECT * FROM [Towns]

SELECT * FROM [Departments]

SELECT * FROM [Employees]


--20-Basic Select All Fields and Order Them







