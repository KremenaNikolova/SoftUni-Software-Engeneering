CREATE DATABASE NationalTouristSitesOfBulgaria
GO

USE NationalTouristSitesOfBulgaria
GO

--01. DDL
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	)

CREATE TABLE Locations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Municipality VARCHAR(50),
	Province VARCHAR(50)
	)

CREATE TABLE Sites(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Establishment VARCHAR(15)
	)

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT NOT NULL
	CHECK(Age BETWEEN 0 AND 120),
	PhoneNumber VARCHAR(20) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Reward VARCHAR(20)
	)

CREATE TABLE SitesTourists(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL
	PRIMARY KEY(TouristId, SiteId)
	)

CREATE TABLE BonusPrizes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	)

CREATE TABLE TouristsBonusPrizes(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL
	PRIMARY KEY(TouristId, BonusPrizeId)
	)


--02. Insert
INSERT INTO Tourists([Name], Age, PhoneNumber, Nationality, Reward)
	VALUES
		('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
		('Peter Bosh', 48, '+359896354244', 'UK', NULL),
		('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
		('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
		('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites([Name], LocationId, CategoryId, Establishment)
	VALUES
		('Ustra fortress', 90, 7, 'X'),
		('Karlanovo Pyramids', 65, 7, NULL),
		('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
		('Sinite Kamani Natural Park', 17, 1, NULL),
		('St. Petka of Bulgaria – Rupite', 92, 6, '1994')


--03. Update
UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL


--04. Delete
DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = (SELECT Id FROM BonusPrizes WHERE [Name] = 'Sleeping bag')

DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'


--05. Tourists
  SELECT [Name],
		 Age,
		 PhoneNumber,
		 Nationality
    FROM Tourists
ORDER BY Nationality, 
		 Age DESC,
		 [Name]


--06. Sites with Their Location and Category
  SELECT s.[Name],
		 loc.[Name],
		 s.Establishment,
		 c.[Name]
    FROM Sites AS s
	JOIN Locations AS loc ON s.LocationId = loc.Id
	JOIN Categories AS c ON c.Id = s.CategoryId
ORDER BY c.[Name] DESC,
		 loc.[Name],
		 s.[Name]


--07. Count of Sites in Sofia Province
 SELECT loc.Province,
        loc.Municipality,
        loc.[Name] As [Location],
	    COUNT(*) AS CountOfSites
   FROM Locations AS loc
   JOIN Sites AS s ON s.LocationId = loc.Id
   WHERE Province = 'Sofia'
GROUP BY loc.Province, loc.Municipality, loc.[Name]
ORDER BY CountOfSites DESC,
	     [Location]


--08. Tourist Sites established BC
  SELECT s.[Name] AS [Site],
		 loc.[Name] AS [Location],
		 loc.Municipality,
		 loc.Province,
		 s.Establishment
    FROM Sites AS s
	JOIN Locations AS loc ON s.LocationId = loc.Id 
						 AND loc.[Name] NOT LIKE 'B%' 
						 AND loc.[Name] NOT LIKE 'M%' 
						 AND loc.[Name] NOT LIKE 'D%'
   WHERE Establishment LIKE '%BC'
ORDER BY [Site]


--09. Tourists with their Bonus Prizes

   SELECT *
   FROM Sites
   WHERE Establishment LIKE '%BC%'




	 
   

    
   


   SELECT * FROM Sites
   SELECT * FROM SitesTourists
   SELECT * FROM Locations