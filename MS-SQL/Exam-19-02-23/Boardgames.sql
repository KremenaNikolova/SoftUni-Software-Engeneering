CREATE DATABASE Boardgames
GO

USE Boardgames
GO

--01. DDL
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
	)

CREATE TABLE Publishers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
	Website NVARCHAR(40),
	Phone NVARCHAR(20)
	)

CREATE TABLE PlayersRanges(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
	)

CREATE TABLE Boardgames(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(4,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
	PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
	)

CREATE TABLE Creators(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL
	)

CREATE TABLE CreatorsBoardgames(
	CreatorId INT FOREIGN KEY REFERENCES Creators(Id),
	BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id),
	PRIMARY KEY(CreatorId, BoardgameId)
	)


--02. Insert
INSERT INTO Boardgames([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
	VALUES
		('Deep Blue', '2019', 5.67, 1, 15, 7),
		('Paris', '2016',9.78, 7, 1, 5),
		('Catan: Starfarers', '2021', 9.87, 7, 13, 6),
		('Bleeding Kansas', '2020', 3.25, 3, 7, 4),
		('One Small Step', '2019', 5.75, 5, 9, 2)


INSERT INTO Publishers([Name], AddressId, Website, Phone)
	VALUES
		('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
		('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
		('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')


--03. Update
UPDATE PlayersRanges
   SET PlayersMax = PlayersMax+1
 WHERE (PlayersMin = 2 AND PlayersMax = 2)

UPDATE Boardgames
   SET [Name] = CONCAT([Name], 'V2')
 WHERE YearPublished >=2020

SELECT COUNT(*) FROM PlayersRanges
WHERE PlayersMin= 2 AND PlayersMax=3
SELECT COUNT(*) FROM Boardgames
WHERE [Name] LIKE '%V2%'

SELECT * FROM PlayersRanges



--04. Delete
DELETE 
  FROM CreatorsBoardgames
 WHERE BoardgameId IN (SELECT b.Id
	  FROM Addresses AS a
	  JOIN Publishers AS p ON a.Id = p.AddressId
	  JOIN Boardgames AS b ON p.Id = b.PublisherId
	 WHERE a.Town LIKE 'L%')

DELETE
  FROM Boardgames
 WHERE Id IN (SELECT b.Id
	   FROM Addresses AS a
	   JOIN Publishers AS p ON a.Id = p.AddressId
	   JOIN Boardgames AS b ON p.Id = b.PublisherId
	  WHERE a.Town LIKE 'L%')
 
DELETE
  FROM Publishers
 WHERE Id IN (SELECT p.Id
	   FROM Addresses AS a
	   JOIN Publishers AS p ON a.Id = p.AddressId
	  WHERE a.Town LIKE 'L%')

DELETE 
 FROM Addresses
WHERE Town LIKE 'L%'


--05. Boardgames by Year of Publication
  SELECT [Name],
		 Rating
    FROM Boardgames
ORDER BY YearPublished,
		 [Name] DESC


--06. Boardgames by Category
  SELECT b.Id,
		 b.[Name],
		 b.YearPublished,
		 c.[Name] AS CategoryName
    FROM Boardgames AS b
	JOIN Categories AS c ON b.CategoryId = c.Id
   WHERE c.[Name] IN('Strategy Games', 'Wargames')
ORDER BY b.YearPublished DESC


--07. Creators without Boardgames
   SELECT c.Id,
		  CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName,
		  c.Email
     FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
    WHERE BoardgameId IS NULL


--08. First 5 Boardgames
  SELECT TOP(5)
		 b.[Name],
		 b.Rating,
  		 c.[Name] AS CategoryName
    FROM Boardgames AS b
    JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
    JOIN Categories AS c ON b.CategoryId = c.Id
   WHERE (b.Rating > 7.00 AND b.[Name] LIKE '%a%')
      OR (b.Rating > 7.50 AND (pr.PlayersMin > 1 AND PlayersMax <6))
ORDER BY b.[Name],
		 b.Rating DESC


--09. Creators with Emails
SELECT FullName,
	   Email,
	   Rating
  FROM(
	  SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
			 c.Email,
			 b.Rating,
			 DENSE_RANK() OVER(PARTITION BY CONCAT(c.FirstName, ' ', c.LastName) ORDER BY b.Rating DESC) AS [Rank]
		FROM Creators AS c
		JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
		JOIN Boardgames AS b ON cb.BoardgameId = b.Id
	   WHERE c.Email LIKE '%.com' 
	   ) AS SubQuery
  WHERE [Rank] = 1
ORDER BY FullName


--10. Creators by Rating
  SELECT c.LastName,
	     CAST(AVG(CEILING (b.Rating)) AS INTEGER) AS AverageRating,
		 p.[Name] AS PublisherName
    FROM Creators AS c
	JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
	JOIN Boardgames AS b ON cb.BoardgameId = b.Id
	JOIN Publishers AS p ON b.PublisherId = p.Id
   WHERE p.[Name] = 'Stonemaier Games'
GROUP BY LastName, p.[Name]
ORDER BY AVG(b.Rating) DESC

GO


--11. Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
	BEGIN
		DECLARE @TotalNumberOfBoardGames INT = (
			SELECT COUNT(*)
			  FROM Creators AS c
			  JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
			 WHERE c.FirstName = @name
			 )

		RETURN @TotalNumberOfBoardGames
	END
GO

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

GO


--12. Search for Boardgame with Specific Category
CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
	BEGIN
		   SELECT b.[Name],
				  b.YearPublished,
				  b.Rating,
				  c.[Name] AS CategoryName,
				  p.[Name] AS PublisherName,
				  CASE
				   WHEN pr.PlayersMin > 0 THEN CONCAT(PlayersMin, ' people')
				  END AS MinPlayers,
				  CASE
					WHEN pr.PlayersMax > 0 THEN CONCAT(PlayersMax, ' people')
				  END AS MaxPlayers
		     FROM Boardgames AS b
		LEFT JOIN Categories AS c ON b.CategoryId = c.Id
		LEFT JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
		LEFT JOIN Publishers AS p ON b.PublisherId = p.Id
		    WHERE c.[Name] = @category
		 ORDER BY PublisherName, YearPublished DESC
	END
GO

EXEC usp_SearchByCategory 'Wargames'
		 
		 



