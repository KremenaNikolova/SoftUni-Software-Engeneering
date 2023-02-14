CREATE DATABASE ColonialJourney 
GO

USE ColonialJourney
GO

--01. DDL
CREATE TABLE Planets(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
	)

CREATE TABLE Spaceports(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
	)

CREATE TABLE Spaceships(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
	)

CREATE TABLE Colonists(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
	)

CREATE TABLE Journeys(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN('Medical', 'Technical', 'Educational', 'Military')) NOT NULL,
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id),
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
	)

CREATE TABLE TravelCards(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) CHECK(LEN(CardNumber)=10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
	)


--02. Insert
INSERT INTO Planets([Name])
	VALUES
		('Mars'),
		('Earth'),
		('Jupiter'),
		('Saturn')

INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate)
	VALUES
		('Golf', 'VW', 3),
		('WakaWaka', 'Wakanda', 4),
		('Falcon9', 'SpaceX', 1),
		('Bed', 'Vidolov', 6)


--03. Update
UPDATE Spaceships
   SET LightSpeedRate += 1
 WHERE Id BETWEEN 8 AND 12


--04. Delete
DELETE 
  FROM TravelCards
 WHERE JourneyId IN (1, 2, 3)

DELETE
  FROM Journeys
 WHERE id IN (1, 2, 3)


--05. Select All Military Journeys
  SELECT Id,
		 FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
		 FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
    FROM Journeys
   WHERE Purpose = 'Military'
ORDER BY JourneyStart


--06. Select All Pilots
  SELECT c.Id,
		 CONCAT(c.FirstName, ' ', c.LastName) AS FullName
    FROM Colonists c
	JOIN TravelCards AS tc ON c.Id = tc.ColonistId
   WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id


--07. Count Colonists
  SELECT COUNT(*) AS [Count]
    FROM Colonists AS c
	JOIN TravelCards AS tc ON c.Id = tc.ColonistId
	JOIN Journeys AS j ON tc.JourneyId = j.Id
   WHERE j.Purpose = 'Technical'
GROUP BY j.Purpose


--08. Select Spaceships With Pilots
  SELECT s.[Name],
		 s.Manufacturer
    FROM Spaceships AS s
	JOIN Journeys AS j ON s.Id = j.SpaceshipId
	JOIN TravelCards AS tc ON j.Id = tc.JourneyId
	JOIN Colonists AS c ON tc.ColonistId = c.Id
   WHERE (YEAR('01/01/2019') - YEAR(c.BirthDate)) < 30 AND tc.JobDuringJourney = 'Pilot'
ORDER BY s.[Name]


--09. Planets And Journeys
  SELECT p.[Name] AS PlanetName,
		 COUNT(*) AS JourneyCount
    FROM Planets AS p
	JOIN Spaceports AS sp ON p.Id = sp.PlanetId
	JOIN Journeys AS j ON sp.Id = j.DestinationSpaceportId
GROUP BY p.[Name]
ORDER BY JourneyCount DESC,
		 PlanetName


--10. Select Special Colonists
  SELECT *
    FROM (
	  SELECT tc.JobDuringJourney,
			 CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
			 RANK() OVER(PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
	    FROM Colonists AS c
	    JOIN TravelCards AS tc ON c.Id = tc.ColonistId
		  ) SubQuery
	WHERE JobRank = 2
GO


--11. Get Colonists Count
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
	BEGIN
		DECLARE @CountOfColonistsSentToThisPlanet INT =
			(SELECT COUNT(*)
			   FROM Planets AS p
			   JOIN Spaceports AS s ON p.Id = s.PlanetId
			   JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
			   JOIN TravelCards AS tc ON j.Id = tc.JourneyId
			   JOIN Colonists AS c ON tc.ColonistId = c.Id
			  WHERE p.[Name] = @PlanetName
			)

		RETURN @CountOfColonistsSentToThisPlanet
	END
GO

SELECT dbo.udf_GetColonistsCount('Otroyphus') --35