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
) t
 WHERE [Rank] = 2
 ORDER BY Salary DESC


--12. Countries Holding 'A' 3 or More Times

