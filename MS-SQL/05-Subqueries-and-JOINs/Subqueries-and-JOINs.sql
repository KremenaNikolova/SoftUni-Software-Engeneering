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



select * from Projects
select * from EmployeesProjects
select * from Employees
