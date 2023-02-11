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


--05. Tourists --Start with fresh Database from here
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
   SELECT t.[Name],
		  t.Age,
		  t.PhoneNumber,
		  CASE
			WHEN bp.[Name] IS NULL THEN '(no bonus prize)'
			ELSE bp.[Name]
		  END AS Reward
     FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tbp ON tbp.TouristId = t.Id
LEFT JOIN BonusPrizes AS bp ON tbp.BonusPrizeId = bp.Id
 ORDER BY t.[Name]


--10. Tourists visiting History and Archaeology sites
  SELECT DISTINCT(SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) +1, LEN(t.[Name]))) AS LastName,
		 t.Nationality,
		 t.Age,
		 t.PhoneNumber
    FROM Tourists AS t
	JOIN SitesTourists AS st ON st.TouristId = t.Id
	JOIN Sites AS s ON st.SiteId = s.Id
	JOIN Categories AS c ON s.CategoryId = c.Id
   WHERE c.[Name] = 'History and archaeology'
ORDER BY LastName
GO

--11. Tourists Count on a Tourist Site
CREATE FUNCTION udf_GetTouristsCountOnATouristSite(@Site VARCHAR(100))
RETURNS INT 
AS
	BEGIN

		DECLARE @CountOfTourist INT
		SET @CountOfTourist = (
			SELECT COUNT(*)
			  FROM Tourists AS t
			  JOIN SitesTourists AS st ON st.TouristId = t.Id
			  JOIN Sites AS s ON st.SiteId = s.Id
			 WHERE s.[Name] = @Site
			 )

		 RETURN @CountOfTourist
	END
GO

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')

GO

--12. Annual Reward Lottery
CREATE OR ALTER PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
	BEGIN
		DECLARE @TouristID INT = (SELECT Id
								   FROM Tourists
								  WHERE [Name] = @TouristName)

		DECLARE @CountSites INT = (SELECT COUNT(*)
								     FROM SitesTourists
									WHERE @TouristID = TouristId)

		DECLARE @Reward VARCHAR(20) = (
										CASE
											WHEN @CountSites>=100 THEN 'Gold badge'
											WHEN @CountSites>=50 THEN 'Silver badge'
											WHEN @CountSites>=25 THEN 'Bronze badge'
											ELSE NULL
										END )

		UPDATE Tourists
		   SET Reward = @Reward
		 WHERE [Name] = @TouristName

		 SELECT [Name],
				Reward
		   FROM Tourists
		  WHERE [Name] = @TouristName

	END
GO
	 
EXEC usp_AnnualRewardLottery 'Gerhild Lutgard' --Gerhild Lutgard/Gold badge
EXEC usp_AnnualRewardLottery 'Teodor Petrov' --Teodor Petrov/Silver badge
EXEC usp_AnnualRewardLottery 'Zac Walsh' --Zac Walsh/Bronze badge
EXEC usp_AnnualRewardLottery 'Brus Brown' --Brus Brown/NULL