--01. Create Table Logs
USE[Bank]
GO

CREATE TABLE [Logs](
	[LogId] INT PRIMARY KEY,
	[AccountId] INT FOREIGN KEY REFERENCES [Accounts](Id),
	[OldSum] DECIMAL (18,2) NOT NULL,
	[NewSum] DECIMAL (18,2) NOT NULL
	)
GO

CREATE TRIGGER [enters_new_entry]
ON [Accounts] FOR UPDATE
AS
	INSERT INTO [Logs]([AccountId], [OldSum], [NewSum])
	SELECT [i].[Id], [d].[Balance], [i].[Balance]
	  FROM [inserted] AS [i]
	  JOIN [deleted] AS [d] ON [i].[Id] = [d].[Id]
	 WHERE [i].[Balance] <> [d].[Balance]
GO


--02. Create Table Emails
CREATE TABLE [NotificationEmails](
	[Id] INT PRIMARY KEY,
	[Recipient] INT FOREIGN KEY REFERENCES [Accounts]([Id]),
	[Subject] VARCHAR(100) NOT NULL,
	[Body] VARCHAR(200) NOT NULL
	)
GO

CREATE TRIGGER [tr_createNewEmail]
ON [Logs] AFTER INSERT
AS
	INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
	SELECT [AccountId], 
	       CONCAT('Balance change for account: ',[AccountId]),
		   CONCAT('On ', FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt'), ' your balance was change from ', [OldSum], ' to ', [NewSum], '.')
	  FROM [inserted]
GO


--03. Deposit Money
CREATE OR ALTER PROCEDURE [usp_DepositMoney](@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
	BEGIN
		IF @MoneyAmount>0
		BEGIN
			UPDATE [Accounts]
			SET [Balance] += @MoneyAmount
			WHERE [Id] = @AccountId
		END
	END
GO


--04. Withdraw Money Procedure
CREATE PROCEDURE [usp_WithdrawMoney](@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
	BEGIN
		IF @MoneyAmount>0
		BEGIN
			UPDATE [Accounts]
			SET [Balance] -= @MoneyAmount
			WHERE [Id] = @AccountId
		END
	END
GO


--05. Money Transfer
CREATE PROCEDURE [usp_TransferMoney](@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
	BEGIN TRANSACTION

		BEGIN TRY
		EXECUTE [dbo].[usp_DepositMoney] @ReceiverId, @Amount
		EXECUTE [dbo].[usp_WithdrawMoney] @SenderId, @Amount 
		END TRY

		BEGIN CATCH
			ROLLBACK
		END CATCH

	COMMIT
GO



--07. *Massive Shopping
USE[Diablo]
GO

DECLARE @userGameID INT = (
    SELECT [ug].[Id]
      FROM [UsersGames] AS [ug]
      JOIN [Users] AS [u] ON [u].[Id] = [ug].[UserId]
      JOIN [Games] AS [g] ON [g].[Id] = [ug].[GameId]
    WHERE [g].[Name] = 'Safflower' AND [u].[Username] = 'Stamat'
)

DECLARE @totalItemCost DECIMAL(18,4)

DECLARE @minLevelOne INT = 11
DECLARE @maxLevelOne INT = 12
DECLARE @availablePlayerCash DECIMAL(18,4) = (
    SELECT [Cash]
      FROM [UsersGames]
     WHERE [Id] = @userGameID
)

SET @totalItemCost = (
    SELECT SUM([Price])
      FROM [Items]
     WHERE [MinLevel] BETWEEN @minLevelOne AND @maxLevelOne
)

IF(@availablePlayerCash >= @totalItemCost)
BEGIN
     BEGIN TRANSACTION
    UPDATE [UsersGames]
       SET [Cash] -= @totalItemCost
     WHERE [Id] = @userGameID

    INSERT INTO UserGameItems
    SELECT [Id], @userGameID
      FROM [Items]
     WHERE [MinLevel] BETWEEN @minLevelOne AND @maxLevelOne

    COMMIT TRANSACTION
END

DECLARE @minLevelTwo INT = 19
DECLARE @maxLevelTwo INT = 21
SET @availablePlayerCash = (
    SELECT [Cash]
      FROM [UsersGames]
     WHERE [Id] = @userGameID
)

SET @totalItemCost = (
    SELECT SUM([Price])
      FROM [Items]
     WHERE [MinLevel] BETWEEN @minLevelTwo AND @maxLevelTwo
)

IF(@availablePlayerCash >= @totalItemCost)
BEGIN
     BEGIN TRANSACTION
    UPDATE [UsersGames]
       SET [Cash] -= @totalItemCost
     WHERE [Id] = @userGameID

    INSERT INTO [UserGameItems]
    SELECT [Id], @userGameID
      FROM [Items]
     WHERE [MinLevel] BETWEEN @minLevelTwo AND @maxLevelTwo

    COMMIT TRANSACTION
END

  SELECT [i].[Name] AS [Item Name]
    FROM [UserGameItems] AS [ugi]
    JOIN [Items] AS [i] ON [i].[Id] = [ugi].[ItemId]
    JOIN [UsersGames] AS [ug] on [ug].[Id] = [ugi].[UserGameId]
    JOIN [Games] AS [g] on [g].[Id] = [ug].[GameId]
    JOIN [Users] AS [u] on [u].[Id] = [ug].[UserId]
   WHERE [g].[Name] = 'Safflower' AND [u].[Username] = 'Stamat'
ORDER BY [i].[Name]
GO



--08. Employees with Three Projects
USE[SoftUni]
GO

CREATE OR ALTER PROCEDURE usp_AssignProject
(@employeeId INT, @projectID INT)
AS
    BEGIN TRANSACTION
    DECLARE @projectsForGivenEmployee INT = (
        SELECT COUNT([EmployeeID])
          FROM [EmployeesProjects]
         WHERE [EmployeeID] = @employeeId
    )

    IF(@projectsForGivenEmployee >= 3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1);
    END

    INSERT INTO [EmployeesProjects] VALUES
    (@employeeId, @projectID)

    COMMIT TRANSACTION
GO


--09. Delete Employees
CREATE TABLE [Deleted_Employees](
    EmployeeId INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    MiddleName VARCHAR(50),
    JobTitle VARCHAR(50),
    DepartmentId INT,
    Salary MONEY
)
GO

CREATE TRIGGER [tr_OnDeletedEmployee]
ON [Employees] FOR DELETE
AS
    INSERT INTO [Deleted_Employees]
    SELECT [FirstName], 
		   [LastName], 
		   [MiddleName], 
		   [JobTitle], 
		   [DepartmentId], 
		   [Salary]
      FROM [deleted]
GO
