CREATE DATABASE Bakery
GO

USE Bakery
GO

--01. DDL
CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE
	)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR CHECK(Gender = 'M' OR Gender = 'F'),
	Age INT,
	PhoneNumber CHAR(10) CHECK(LEN(PhoneNumber)=10),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
	)

CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price MONEY CHECK(Price>0)
	)

CREATE TABLE Feedbacks(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	Rate DECIMAL(6,2) CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
	)

CREATE TABLE Distributors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25),
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
	)

CREATE TABLE Ingredients(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30),
	[Description] NVARCHAR(200),
	OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
	)

CREATE TABLE ProductsIngredients(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id),
	PRIMARY KEY(ProductId, IngredientId)
	)


--02. Insert
INSERT INTO Distributors([Name], CountryId, AddressText, Summary)
	VALUES
		('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
		('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
		('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
		('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
		('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
	VALUES
		('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
		('Kendra', 'Loud', 22, 'F', '0063631526', 11),
		('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
		('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
		('Tom', 'Loeza', 31, 'M', '0144876096', 23),
		('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
		('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
		('Josefa', 'Opitz', 43, 'F', '0197887645', 17)


--03. Update
UPDATE Ingredients
   SET DistributorId = 35
 WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

 UPDATE Ingredients
   SET OriginCountryId = 14
 WHERE OriginCountryId = 8


--04. Delete
DELETE
  FROM Feedbacks
 WHERE CustomerId = 14
	OR ProductId = 5


--05. Products By Price
  SELECT [Name],
		 Price,
		 [Description]
    FROM Products
ORDER BY Price DESC,
		 [Name]


--06. Negative Feedback
  SELECT f.ProductId,
		 f.Rate,
		 f.[Description],
		 f.CustomerId,
		 c.Age,
		 c.Gender
    FROM Feedbacks AS f
	JOIN Customers AS c on f.CustomerId = c.Id
   WHERE f.Rate<5.0
ORDER BY f.ProductId DESC,
		 f.Rate


--07. Customers without Feedback
   SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
		  c.PhoneNumber,
		  c.Gender
     FROM Customers AS c
LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
	WHERE f.Id IS NULL
 ORDER BY c.Id


--08. Customers by Criteria
DECLARE @GreeceID INT =
	(SELECT Id
	   FROM Countries
	  WHERE [Name] = 'Greece'
	 )

  SELECT c.FirstName,
		 c.Age,
		 c.PhoneNumber
    FROM Customers AS c
   WHERE (c.Age>=21 AND c.FirstName LIKE '%an%')
      OR (c.PhoneNumber LIKE '%38' AND c.CountryId<>@GreeceID)
ORDER BY c.FirstName,
		 c.Age DESC


--09. Middle Range Distributors
  SELECT d.[Name] AS DistributorName,
		 i.[Name] AS IngredientName,
		 p.[Name] AS ProductName,
		 AVG(f.Rate) AS AverageRate
    FROM Distributors AS d
	JOIN Ingredients AS i ON d.Id = i.DistributorId
	JOIN ProductsIngredients AS [pi] ON i.Id = [pi].IngredientId
	JOIN Products AS p ON [pi].ProductId = p.Id
	JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY d.[Name],
		 i.[Name],
		 p.[Name]
  HAVING AVG(f.Rate) BETWEEN 5 AND 8


--10. Country Representative
  SELECT CountryName,
		 DisributorName
    FROM (
		     SELECT c.[Name] AS CountryName,
				    d.[Name] AS DisributorName,
				    RANK() OVER(PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS [Rank]
			   FROM Countries AS c
		  LEFT JOIN Distributors AS d ON c.Id = d.CountryId
		  LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
		   GROUP BY c.[Name],
				    d.[Name]
		  ) AS SubQuery
	WHERE [Rank] = 1
 ORDER BY CountryName,
		  DisributorName
GO


--11. Customers With Countries
CREATE VIEW v_UserWithCountries 
AS
	SELECT CONCAT(ct.FirstName, ' ', ct.LastName) AS CustomerName,
		   ct.Age,
		   ct.Gender,
		   c.[Name]
	  FROM Customers AS ct
	  JOIN Countries AS c ON c.Id = ct.CountryId
GO

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

GO

--12. Delete Products
CREATE TRIGGER t_DeleteFromProducts
	ON Products INSTEAD OF DELETE
    AS 
	BEGIN
		DECLARE @ProductID INT = (SELECT Id FROM deleted)
		DELETE 
		  FROM FeedBacks
		 WHERE ProductId = @ProductID

		DELETE 
		  FROM ProductsIngredients
		 WHERE ProductId = @ProductID

		DELETE
		  FROM Products
		 WHERE Id = @ProductID
	END
GO

DELETE FROM Products WHERE Id = 7
		



