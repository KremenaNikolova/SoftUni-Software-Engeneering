--01. Find Names of All Employees by First Name
USE SoftUni
GO

SELECT FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE('Sa%')


--02. Find Names of All Employees by Last Name
SELECT FirstName, LastName
  FROM Employees
 WHERE LastName LIKE('%ei%')

--03. Find First Names of All Employees
SELECT FirstName
  FROM Employees
 WHERE DepartmentID = 3 OR DepartmentID = 10 
  AND HireDate BETWEEN '1995' AND '2005'


 --04. Find All Employees Except Engineers
SELECT FirstName, LastName
  FROM Employees
 WHERE JobTitle NOT LIKE ('%engineer%')


--05. Find Towns with Name Length
SELECT [Name]
  FROM Towns
 WHERE LEN([Name])=5 OR LEN([Name])=6
 ORDER BY [Name]


--06. Find Towns Starting With
SELECT TownID, [Name]
  FROM Towns
 WHERE [Name] LIKE '[M, K, B, E]%'
 ORDER BY [Name]


--07. Find Towns Not Starting With
SELECT TownID, [Name]
  FROM Towns
 WHERE [Name] NOT LIKE '[R, B, D]%'
 ORDER BY [Name]


--08. Create View Employees Hired After 2000 Year
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT FirstName, LastName
  FROM Employees
 WHERE HireDate > '2001'


--09. Length of Last Name
SELECT FirstName, LastName
  FROM Employees
 WHERE LEN(LastName)=5


--10. Rank Employees by Salary
SELECT e.EmployeeID, e.FirstName, e.LastName, e.Salary
       ,DENSE_RANK() OVER
	   (PARTITION BY e.Salary ORDER BY e.EmployeeID) AS Rank
  FROM Employees AS e
 WHERE e.Salary BETWEEN 10000 AND 50000
 ORDER BY Salary DESC


--11. Find All Employees with Rank 2
SELECT * FROM
(
              SELECT e.EmployeeID, e.FirstName, e.LastName, e.Salary
                     ,DENSE_RANK() OVER
              	     (PARTITION BY e.Salary ORDER BY e.EmployeeID) [Rank]
                FROM Employees AS e
			   WHERE e.Salary BETWEEN 10000 AND 50000
) [Rank Subquery]
 WHERE [Rank] = 2
 ORDER BY Salary DESC


--12. Countries Holding 'A' 3 or More Times
USE [Geography]
GO

SELECT CountryName AS [Country Name], 
	   IsoCode AS [ISO Code]
  FROM Countries
 WHERE CountryName LIKE '%a%a%a%'
 ORDER BY IsoCode


--13. Mix of Peak and River Names
SELECT PeakName, RiverName,
 LOWER (CONCAT (SUBSTRING(PeakName, 1, LEN(PeakName)-1), SUBSTRING(RiverName, 1, LEN(RiverName)))) AS Mix
  FROM Peaks, Rivers
 WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
 ORDER BY Mix


--14. Games From 2011 and 2012 Year
USE Diablo
GO

  SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM Games
   WHERE YEAR([Start]) = 2011 OR YEAR([Start]) = 2012
ORDER BY [Start]


--15. User Email Providers
  SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email)+1, LEN(Email)) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], Username


--16. Get Users with IP Address Like Pattern
  SELECT Username, IpAddress AS [IP Address]
    FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username


--17. Show All Games with Duration & Part of the Day
  SELECT g.[Name] AS Game,
         CASE
            WHEN DATEPART(HOUR, [Start])>=0 AND DATEPART(HOUR, [Start])<12 THEN 'Morning'
  		    WHEN DATEPART(HOUR, [Start])>=12 AND DATEPART(HOUR, [Start])<18 THEN 'Afternoon'
  		    ELSE 'Evening'
  	     END
  	       AS [Part of the Day],
          CASE
  	        WHEN Duration <=3 THEN 'Extra Short'
  		    WHEN Duration BETWEEN 4 and 6 THEN 'Short'
  		    WHEN Duration > 6 THEN 'Long'
  		    ELSE 'Extra Long'
  		 END
  		   AS Duration
    FROM Games AS g
ORDER BY g.[Name], Duration, [Part of the Day]
