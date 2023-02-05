--01. Employees with Salary Above 35000
USE[SoftUni]
GO

CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
AS
   BEGIN

	  SELECT [FirstName] AS [First Name],
			 [LastName] AS [Last Name]
		FROM [Employees]
	   WHERE [Salary] > 35000

     END
GO

EXECUTE [dbo].[usp_GetEmployeesSalaryAbove35000]
GO


--02. Employees with Salary Above Number
CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @MinSalary DECIMAL(18, 4)
AS
	BEGIN

		SELECT [FirstName] AS [First Name],
			   [LastName] AS [Last Name]
		  FROM [Employees]
		 WHERE [Salary] >= @MinSalary

	END
GO

EXECUTE [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100