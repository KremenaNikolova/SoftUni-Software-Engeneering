USE [Gringotts]
GO

--01. Records’ Count
SELECT COUNT(*) AS [Count]
  FROM [WizzardDeposits]


--02. Longest Magic Wand
  SELECT TOP(1)
         MAX([wz].[MagicWandSize]) AS [LongestMagicWand]
    FROM [WizzardDeposits] AS [wz]
GROUP BY [MagicWandSize]
ORDER BY [LongestMagicWand] DESC


--03. Longest Magic Wand per Deposit Groups
  SELECT [wz].[DepositGroup],
         MAX([wz].[MagicWandSize]) AS [LongestMagicWand]
    FROM [WizzardDeposits] AS [wz]
GROUP BY [DepositGroup]


--04. Smallest Deposit Group per Magic Wand Size
  SELECT TOP(2)
         [wz].[DepositGroup] 
    FROM [WizzardDeposits] AS [wz]
GROUP BY [DepositGroup]
ORDER BY AVG([wz].[MagicWandSize])


--05. Deposits Sum
