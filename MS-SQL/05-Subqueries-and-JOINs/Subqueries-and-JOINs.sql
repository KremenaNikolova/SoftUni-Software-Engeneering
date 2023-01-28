--01. Employee Address
USE SoftUni
GO

SELECT TOP 5 
    e.EmployeeId
	,e.JobTitle
	,e.AddressId
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a 
ON e.AddressID = a.AddressID
ORDER BY e.AddressID


--02. Addresses with Towns
SELECT TOP 50
    e.FirstName
	,e.LastName
	,t.[Name] AS Town
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a 
ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName


--03. Sales Employees
SELECT e.EmployeeID
       ,e.FirstName
	   ,e.LastName
	   ,d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d 
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID


--04. Employee Departments
SELECT TOP (5)
        e.EmployeeID
       ,e.FirstName
	   ,e.Salary
	   ,d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d 
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID


--05. Employees Without Projects
SELECT TOP (3)
     e.EmployeeID
	,e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep 
ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID


--06. Employees Hired After
SELECT 
     e.FirstName
	,e.LastName
	,e.HireDate
	,d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d 
ON e.DepartmentID = d.DepartmentID AND d.[Name] IN ('Finance', 'Sales')
WHERE e.HireDate > '1999-1-1'
ORDER BY e.HireDate


--07. Employees With Project
SELECT TOP (5)
     e.EmployeeID
	,e.FirstName
	,p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > 2002-08-13 AND p.EndDate IS NULL
ORDER BY e.EmployeeID


--08. Employee 24
SELECT 
     e.EmployeeID
	,e.FirstName
	,CASE
	    WHEN p.StartDate >= '2005-01-01' THEN NULL
	    ELSE p.[Name]
	 END
	 AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24


--09. Employee Manager
SELECT 
     e.EmployeeID
	,e.FirstName
	,e.ManagerID
	,emp.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS emp ON e.ManagerID = emp.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID


--10. Employees Summary
SELECT TOP (50)
     e.EmployeeID
	,CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName
	,CONCAT(m.FirstName, ' ',m.LastName) AS ManagerName
	,d.Name AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID


--11. Min Average Salary
SELECT TOP (1)
     AVG(Salary) AS MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY MIN(Salary)


--12. Highest Peaks in Bulgaria
USE [Geography]
GO


SELECT 
     c.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation>2835
ORDER BY p.Elevation DESC


--13. Count Mountain Ranges
SELECT mc.CountryCode
    ,COUNT(m.MountainRange) AS MountainRanges
FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.MountainId = m.Id
GROUP BY mc.CountryCode
HAVING mc.CountryCode IN ('US', 'RU', 'BG')


--14. Countries With or Without Rivers
SELECT TOP (5)
     c.CountryName
	,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName


--15. Continents and Currencies 
SELECT 
     ContinentCode
	,CurrencyCode
	,CurrencyUsage
FROM
    (
	  SELECT *
	         ,DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC)
			 AS CurrencyRank
	  FROM
	      (
		   SELECT 
                  ContinentCode
	             ,CurrencyCode
	             ,COUNT(*) AS CurrencyUsage
           FROM Countries
           GROUP BY ContinentCode, CurrencyCode
		   HAVING COUNT(*) > 1
		  ) AS CurrencyUsageSubquery
	)AS CurrencyRankSubqery
WHERE CurrencyRank = 1
ORDER BY ContinentCode


--16. Countries Without any Mountains
SELECT COUNT(c.CountryName) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
GROUP BY mc.MountainId
HAVING mc.MountainId IS NULL


--17. Highest Peak and Longest River by Country
SELECT TOP (5)
     c.CountryName
	,MAX(p.Elevation) AS HighestPeakElevation
	,MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName


--18. Highest Peak Name and Elevation by Country
SELECT TOP (5)
    CountryName AS Country
   ,ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name]
   ,ISNULL(Elevation, 0) AS [Highest Peak Elevation]
   ,ISNULL(MountainRange, '(no mountain)') AS Mountain
FROM
    (
	 SELECT 
	      c.CountryName
		 ,p.PeakName
		 ,p.Elevation 
		 ,m.MountainRange
		 ,DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
	 FROM Countries AS c
     LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
     LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	) AS PeakRankSubquery
WHERE [Rank] = 1
ORDER BY Country, [Highest Peak Name]



--FIND name and elevation of the highnest peak, along with its mountain


select * from Mountains
select * from Countries
select * from CountriesRivers
select * from Rivers
