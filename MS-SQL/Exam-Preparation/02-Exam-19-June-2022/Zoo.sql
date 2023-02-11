CREATE DATABASE Zoo
GO

USE Zoo
GO


--01. DDL
CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
	)

CREATE TABLE AnimalTypes(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
	)

CREATE TABLE Cages(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
	)

CREATE TABLE Animals(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
	)

CREATE TABLE AnimalsCages(
	CageId INT FOREIGN KEY REFERENCES Cages(Id),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
	PRIMARY KEY(CageId, AnimalId)
	)

CREATE TABLE VolunteersDepartments(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
	)

CREATE TABLE Volunteers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
	)


--02. Insert
INSERT INTO Volunteers([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
	VALUES
		('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
		('Dimitur Stoev', '0877564223', NULL, 42, 4),
		('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
		('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
		('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
	VALUES
	 ('Giraffe', '2018-09-21', 21, 1),
	 ('Harpy Eagle', '2015-04-17', 15, 3),
	 ('Hamadryas Baboon', '2017-11-02', NULL, 1),
	 ('Tuatara', '2021-06-30', 2, 4)


--03. Update
DECLARE @OwnerID INT = (SELECT Id FROM Owners WHERE [Name] = 'Kaloqn Stoqnov')

UPDATE Animals
   SET OwnerId = @OwnerID
 WHERE OwnerId IS NULL


--04. Delete 

--The Zoo decided to close one of the Volunteers Departments - Education program assistant. 
--Your job is to delete this department from the database. 
DECLARE @DepartmentID INT = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant')

DELETE 
  FROM Volunteers
 WHERE DepartmentId = @DepartmentID

DELETE
  FROM VolunteersDepartments
 WHERE Id = @DepartmentID


--05. Tourists
  SELECT [Name],
  	     PhoneNumber,
  	     [Address], 
  	     AnimalId,
  	     DepartmentId
    FROM Volunteers
ORDER BY [Name],
		 DepartmentId


--06. Sites with Their Location and Category
   SELECT a.[Name],
		  [at].AnimalType,
		  FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
     FROM Animals AS a
LEFT JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
 ORDER BY a.[Name]


--07. Count of Sites in Sofia Province
  SELECT TOP(5)
         o.[Name] AS [Owner],
		 COUNT(*) AS CountOfAnimals
    FROM Owners AS o
	JOIN Animals AS a ON o.Id = a.OwnerId
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC,
		 [Owner]


--08. Tourist Sites established BC
  SELECT CONCAT(o.[Name], '-', a.[Name]) AS OwnersAnimals,
		 o.PhoneNumber,
		 ac.CageId AS CageId
    FROM Owners AS o
	JOIN Animals AS a ON o.Id = a.OwnerId
	JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
	JOIN AnimalsCages AS ac ON a.Id = ac.AnimalId
   WHERE [at].AnimalType = 'mammals'
ORDER BY o.[Name],
	     a.[Name] DESC


--09. Tourists with their Bonus Prizes
  SELECT v.[Name],
		 v.PhoneNumber,
		 TRIM(REPLACE(REPLACE(v.[Address], 'Sofia', ''), ',', ''))AS [Address]
    FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
   WHERE vd.DepartmentName = 'Education program assistant' 
		 AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name]


--10. Tourists visiting History and Archaeology sites
   SELECT a.[Name],
	      YEAR(a.BirthDate) AS BirthYear,
		  [at].AnimalType
     FROM Animals AS a
LEFT JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
    WHERE a.OwnerId IS NULL
		  AND DATEDIFF(YEAR, a.BirthDate, '01/01/2022') <5
		  AND [at].AnimalType <> 'Birds'
 ORDER BY a.[Name]
 GO

--11. Tourists Count on a Tourist Site
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30)) 
RETURNS INT
AS
	BEGIN
		DECLARE @CountOfVolunteers INT
		SET @CountOfVolunteers = (SELECT COUNT(*)
									FROM VolunteersDepartments AS vd
									JOIN Volunteers AS v ON vd.Id = v.DepartmentId
								   WHERE DepartmentName = @VolunteersDepartment
								GROUP BY vd.DepartmentName
								   )

		RETURN @CountOfVolunteers
	END
GO

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant') --6
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement') --4
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events') --5
GO

--12. Annual Reward Lottery
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
	BEGIN
	   SELECT a.[Name],
			  CASE
				WHEN o.[Name] IS NULL THEN 'For adoption'
				ELSE o.[Name]
			  END AS OwnersName
	     FROM Animals AS a
	LEFT JOIN Owners AS o ON a.OwnerId = o.Id
	    WHERE a.[Name] = @AnimalName
	END
GO

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish' --Pumkingseed Sunfish/Kamelia Yancheva
EXEC usp_AnimalsWithOwnersOrNot 'Hippo' --For adoption
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear' --Brown bear/Gergana Mancheva