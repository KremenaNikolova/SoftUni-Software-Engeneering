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
GO


--03. Town Names Starting With
CREATE PROCEDURE [usp_GetTownsStartingWith] @firstTownLetter VARCHAR(10)
AS
	BEGIN

		SELECT [Name] AS [Town]
		  FROM [Towns]
		 WHERE [Name] LIKE CONCAT (@firstTownLetter, '%') 

	END
GO

EXECUTE [dbo].[usp_GetTownsStartingWith] 'b'
GO


--04. Employees from Town
CREATE PROCEDURE [usp_GetEmployeesFromTown] @townName VARCHAR(50)
AS
	BEGIN

		SELECT [e].[FirstName] AS [First Name],
			   [e].[LastName] AS [Last Name]
		  FROM [Employees] AS [e]
		  JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].AddressID
		  JOIN [Towns] AS [t] ON [a].TownID = [t].[TownID]
		 WHERE [t].[Name] = @townName

	END
GO

EXECUTE [dbo].[usp_GetEmployeesFromTown] 'Sofia'
GO


--05. Salary Level Function
CREATE FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS
	BEGIN
		
		DECLARE @salaryLevel VARCHAR(8)

			IF @salary <30000
				BEGIN
					SET @salaryLevel = 'Low'
				END
			ELSE IF @salary BETWEEN 30000 AND 50000
				BEGIN
					SET @salaryLevel = 'Average'
				END
			ELSE
				BEGIN
					SET @salaryLevel = 'High'
				END

		RETURN @salaryLevel

	END
GO


--06. Employees by Salary Level
CREATE PROCEDURE [usp_EmployeesBySalaryLevel] @levelOfSalary VARCHAR(8)
AS
	BEGIN

		SELECT [FirstName] AS [First Name],
			   [LastName] As [Last Name]
		  FROM [Employees]
		 WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @levelOfSalary

	END
GO

EXECUTE [dbo].[usp_EmployeesBySalaryLevel] 'High'
GO


--07. Define Function
CREATE FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
	BEGIN

		DECLARE @index INT = 1
		WHILE @index<=LEN(@word)
			BEGIN

			DECLARE @currLetter CHAR = SUBSTRING(@word, @index, 1)
				IF CHARINDEX(@currLetter, @setOfLetters) = 0
				BEGIN
					RETURN 0;
				END

			SET @index +=1;
			END

		RETURN 1;

	END
GO

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'Sofia')
GO

--08. *Delete Employees and Departments
