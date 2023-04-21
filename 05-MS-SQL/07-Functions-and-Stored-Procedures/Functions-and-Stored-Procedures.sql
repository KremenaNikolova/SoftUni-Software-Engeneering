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
CREATE PROCEDURE [usp_DeleteEmployeesFromDepartment] @departmentID INT
AS
	BEGIN
		ALTER TABLE [Departments]
		ALTER COLUMN [ManagerID] INT

		DECLARE @copyOfEmployeesToDelete TABLE ([ID] INT)
		INSERT INTO @copyOfEmployeesToDelete
			SELECT [EmployeeID]
			  FROM [Employees]
			 WHERE [DepartmentID] = @departmentID

		DELETE
		  FROM [EmployeesProjects]
		 WHERE [EmployeeID] IN (SELECT * FROM @copyOfEmployeesToDelete)

		 UPDATE [Departments]
		    SET [ManagerID] = NULL
		  WHERE [ManagerID] IN (SELECT * FROM @copyOfEmployeesToDelete)

		  UPDATE [Employees]
		    SET [ManagerID] = NULL
		  WHERE [ManagerID] IN (SELECT * FROM @copyOfEmployeesToDelete)
		  
		 DELETE 
		   FROM [Employees]
		  WHERE [DepartmentID] = @departmentID

		 DELETE
		   FROM [Departments]
		  WHERE [DepartmentID] = @departmentID

		 SELECT COUNT(*)
		   FROM [Employees]
		  WHERE [DepartmentID] = @departmentID
	END
GO

EXECUTE [dbo].[usp_DeleteEmployeesFromDepartment] 7


--09. Find Full Name
USE[Bank]
GO

CREATE PROCEDURE [usp_GetHoldersFullName]
AS
	BEGIN
		SELECT CONCAT ([FirstName], ' ', [LastName]) AS [Full Name]
		  FROM [AccountHolders]
	END
GO

EXECUTE [dbo].[usp_GetHoldersFullName]
GO

--10. People with Balance Higher Than
CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan] @moneyInAccount DECIMAL (18, 2)
AS
	BEGIN
		  SELECT [ah].[FirstName], [ah].[LastName]
		    FROM [AccountHolders] AS [ah]
		    JOIN [Accounts] AS [ac] ON [ah].[id] = [ac].[AccountHolderId]
		GROUP BY [ah].[FirstName], [ah].[LastName]
		  HAVING SUM([ac].[Balance])> @moneyInAccount
		ORDER BY [ah].[FirstName], [ah].[LastName]
	END
GO

EXECUTE [dbo].[usp_GetHoldersWithBalanceHigherThan] 35000
GO

--11. Future Value Function
CREATE FUNCTION [ufn_CalculateFutureValue] (@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
AS
	BEGIN
		RETURN @sum*POWER(1+@yearlyInterestRate, @numberOfYears)
	END
GO

SELECT [dbo].[ufn_CalculateFutureValue](1000, 0.1, 5)
GO

--12. Calculating Interest
CREATE PROCEDURE [usp_CalculateFutureValueForAccount] (@accountID INT, @interestRate FLOAT)
AS
	BEGIN
		SELECT TOP(1)
			   [ah].[Id] AS [Account Id],
			   [ah].[FirstName] AS [First Name],
			   [ah].[LastName] AS [Last Name],
			   [a].[Balance] AS [Current Balance],
			   [dbo].[ufn_CalculateFutureValue]([a].[Balance], @interestRate, 5) AS [Balance in 5 years]
		  FROM [AccountHolders] AS [ah]
		  JOIN [Accounts] AS [a] ON [ah].Id = [a].[AccountHolderId]
		 WHERE [ah].[Id] = @accountID
	END
GO

EXECUTE [dbo].[usp_CalculateFutureValueForAccount] 1, 0.1
GO

--13. *Cash in User Games Odd Rows
USE[Diablo]
GO

CREATE FUNCTION [ufn_CashInUsersGames] (@gameName VARCHAR(50))
RETURNS TABLE
AS
	RETURN
		SELECT SUM([Cash]) AS [SumCash]
		  FROM (
				SELECT ROW_NUMBER() OVER(ORDER BY [ug].[Cash]DESC) AS [RowNumber],
			           [ug].[Cash]
				  FROM [UsersGames] AS [ug]
				  JOIN [Games] AS [g] ON [ug].[GameId] = [g].Id
				 WHERE [g].[Name] = @gameName
			   ) AS [SubRowQuery]
		 WHERE [RowNumber] % 2 <>0
GO

SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')





SELECT *
  FROM [UsersGames]

SELECT *
  FROM [Games]