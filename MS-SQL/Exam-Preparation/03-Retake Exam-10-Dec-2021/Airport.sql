CREATE DATABASE Airport
GO

USE Airport
GO

--01. DDL
CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
	)

CREATE TABLE Pilots(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK(AGE BETWEEN 21 AND 62),
	Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0)
	)

CREATE TABLE AircraftTypes(
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
	)

CREATE TABLE Aircraft(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
	)

CREATE TABLE PilotsAircraft(
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id),
	PilotId INT FOREIGN KEY REFERENCES Pilots(Id)
	PRIMARY KEY(AircraftId, PilotId)
	)

CREATE TABLE Airports(
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
	)

CREATE TABLE FlightDestinations(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18, 2) DEFAULT 15 NOT NULL
	)


--02. Insert
INSERT INTO Passengers (FullName, Email)
     SELECT CONCAT(FirstName, ' ', LastName) AS FullName,
			CONCAT(FirstName, LastName, '@gmail.com')
	   FROM Pilots 
      WHERE Id BETWEEN 5 AND 15


--03. Update
UPDATE Aircraft
   SET Condition = 'A'
 WHERE Condition IN ('C', 'B')
	   AND (FlightHours IS NULL OR FlightHours<=100)
	   AND [Year] >= 2013


--04. Delete
DELETE 
  FROM Passengers
 WHERE LEN(FullName) <=10


--05. Aircraft --Start with fresh Database from here
  SELECT Manufacturer,
		 Model,
		 FlightHours,
		 Condition
    FROM Aircraft
ORDER BY FlightHours DESC


--06. Pilots and Aircraft
  SELECT p.FirstName,
		 p.LastName,
		 a.Manufacturer,
		 a.Model,
		 a.FlightHours
    FROM Pilots AS p
	JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
	JOIN Aircraft AS a ON pa.AircraftId = a.Id AND a.FlightHours<304
ORDER BY a.FlightHours DESC,
		 p.FirstName


--07. Top 20 Flight Destinations
   SELECT TOP(20)
		  fd.Id AS DestionationId,
		  fd.[Start],
		  p.FullName,
		  a.AirportName,
		  fd.TicketPrice
     FROM FlightDestinations AS fd
LEFT JOIN Passengers AS p ON fd.PassengerId = p.Id
LEFT JOIN Airports AS a ON a.Id = fd.AirportId
    WHERE DAY(fd.[Start]) % 2 = 0
 ORDER BY fd.TicketPrice DESC,
		  a.AirportName


--08. Number of Flights for Each Aircraft
  SELECT a.Id AS AircrftId,
		 a.Manufacturer,
		 a.FlightHours,
		 COUNT(fd.Id) AS FlightDestinationsCount,
		 ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
    FROM Aircraft AS a
	JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
GROUP BY a.Id, a.Manufacturer, a.FlightHours
  HAVING COUNT(fd.Id)>=2
ORDER BY FlightDestinationsCount DESC,
		 a.Id


--09. Regular Passengers
  SELECT p.FullName,
		 COUNT(*) AS CountOfAircraft,
		 SUM(fd.TicketPrice) AS TotalPayed
    FROM Passengers AS p
	JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
	JOIN Aircraft AS a ON fd.AircraftId = a.Id
   WHERE SUBSTRING(p.FullName, 2, 1) = 'a'
GROUP BY p.FullName
  HAVING COUNT(*) >1
ORDER BY p.FullName


--10. Full Info for Flight Destinations
  SELECT a.AirportName,
		 fd.[Start] AS DayTime,
		 fd.TicketPrice,
		 p.FullName,
		 af.Manufacturer,
		 af.Model
    FROM FlightDestinations AS fd
	JOIN Airports AS a ON fd.AirportId = a.Id
	JOIN Aircraft AS af ON fd.AircraftId = af.Id
	JOIN Passengers AS p ON fd.PassengerId = p.Id
   WHERE CAST(fd.[Start] AS TIME) BETWEEN '6:00' and '20:00'
		 AND fd.TicketPrice > 2500
ORDER BY af.Model
GO

--11. Find all Destinations by Email Address
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50)) 
RETURNS INT
AS
	BEGIN
		DECLARE @NumbersOfFlightDestinations INT =(
			   SELECT COUNT(*)
			     FROM Passengers AS p
			     JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
			    WHERE Email = @email
			   )

		RETURN @NumbersOfFlightDestinations
	END
GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com') --1
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com') --3
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com') --0
GO


--12. Full Info for Airports
CREATE PROCEDURE usp_SearchByAirportName(@airportName VARCHAR(70))
AS
	BEGIN
		--we search airport location with given @airportName
		  SELECT ap.AirportName,
		  	     p.FullName,
			     CASE
					WHEN fd.TicketPrice <=400 THEN 'Low'
					WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
					WHEN fd.TicketPrice >=1501 THEN 'High'
			     END AS LevelOfTickerPrice,
				 af.Manufacturer,
				 af.Condition,
				 [at].TypeName
		    FROM Airports AS ap
		    JOIN FlightDestinations AS fd ON ap.Id = fd.AirportId
		    JOIN Passengers AS p ON fd.PassengerId = p.Id
		    JOIN Aircraft AS af ON fd.AircraftId = af.Id
		    JOIN AircraftTypes AS [at] ON af.TypeId=[at].Id
		   WHERE ap.AirportName = @airportName
		ORDER BY af.Manufacturer,
				 p.FullName
	END
GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'
GO