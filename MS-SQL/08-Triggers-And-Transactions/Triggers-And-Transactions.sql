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


SELECT * FROM [AccountHolders]
SELECT * FROM [Accounts]