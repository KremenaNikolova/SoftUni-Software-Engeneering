--01. Employee Address
USE SoftUni
GO

SELECT TOP 5 
    e.EmployeeId
	,e.JobTitle
	,e.AddressId
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID


--02. Addresses with Towns
SELECT TOP 50
    e.FirstName
	,e.LastName
	,t.[Name] AS Town
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

