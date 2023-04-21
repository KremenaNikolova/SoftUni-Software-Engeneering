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
  SELECT [DepositGroup],
		 SUM([DepositAmount])
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]


--06. Deposits Sum for Ollivander Family
  SELECT [DepositGroup],
		 SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]


--07. Deposits Filter
  SELECT [DepositGroup],
		 SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC


--08. Deposit Charge
  SELECT [DepositGroup],
		 [MagicWandCreator],
		 MIN([DepositCharge]) AS [MinDepositeCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup], 
		 [MagicWandCreator]
ORDER BY [MagicWandCreator],
		 [DepositGroup]


--09. Age Groups
  SELECT [AgeGroup],
		 COUNT(*) AS [WizardCount]
    FROM
         (
	      SELECT 
	    	    CASE
	    		    WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
	    		    WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
	    		    WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
	    		    WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
	    		    WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
					WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
	    		    ELSE '[61+]'
	    		 END AS [AgeGroup]
	        FROM [WizzardDeposits]
	      )   AS [AgeGroupSubquery]
GROUP BY [AgeGroup]


--10. First Letter
  SELECT 
DISTINCT LEFT([FirstName], 1)
    FROM [WizzardDeposits]
   WHERE [DepositGroup] = 'Troll Chest'
GROUP BY [FirstName]
ORDER BY LEFT([FirstName], 1)


--11. Average Interest
  SELECT [DepositGroup],
         [IsDepositExpired],
		 AVG([DepositInterest]) AS [AverageInterest]
    FROM [WizzardDeposits]
   WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC,
		 [IsDepositExpired]


--12. *Rich Wizard, Poor Wizard
SELECT SUM([Difference]) AS [SumDifference]
  FROM
       (
	    SELECT [wz1].[FirstName] AS [Host Wizard],
			   [wz1].[DepositAmount] AS [Host Wizard Deposit],
			   [wz2].[FirstName] AS [Guest Wizard],
			   [wz2].[DepositAmount] AS [Guest Wizard Deposit],
			   [wz1].[DepositAmount] - [wz2].[DepositAmount] AS [Difference]
		  FROM [WizzardDeposits] AS [wz1]
		  JOIN [WizzardDeposits] AS [wz2] ON [wz1].[Id]+1 = [wz2].[Id]
	   ) AS [SumSubquery]


--13. Departments Total Salaries
USE[SoftUni]
GO

  SELECT [DepartmentID],
		 SUM([Salary]) AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]


--14. Employees Minimum Salaries
  SELECT [DepartmentID],
		 MIN([Salary]) AS [MinimumSalary]
    FROM [Employees]
   WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '01/01/2000'
GROUP BY [DepartmentID]


--15. Employees Average Salaries
SELECT *
  INTO [CopyEmployeesTable]
  FROM [Employees]
 WHERE [Salary] > 30000

DELETE
  FROM [CopyEmployeesTable]
 WHERE [ManagerID] = 42

UPDATE [CopyEmployeesTable]
   SET [Salary] += 5000
 WHERE [DepartmentID] = 1

  SELECT [DepartmentID],
	     AVG([Salary]) AS [AverageSalary]
    FROM [CopyEmployeesTable]
GROUP BY [DepartmentID]


--16. Employees Maximum Salaries
  SELECT [DepartmentID],
		 MAX([Salary]) AS [MaxSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000


--17. Employees Count Salaries
SELECT COUNT([EmployeeID])
  FROM [Employees]
 WHERE [ManagerID] IS NULL


--18. *3rd Highest Salary
WITH [SubQueryRank]
  AS (
	  SELECT [DepartmentID],
			 [Salary],
	         DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [SalaryRank]
        FROM [Employees]
     )

  SELECT 
DISTINCT [DepartmentID],
	     [Salary] AS [ThirdHignestSalary]
    FROM [SubQueryRank]
   WHERE [SubQueryRank].[SalaryRank] = 3


--19. **Salary Challenge
  SELECT TOP(10)
         [e].[FirstName],
         [e].[LastName],
	     [e].[DepartmentID]
    FROM [Employees] AS [e]
   WHERE [e].[Salary] > (
						   SELECT AVG([sub].[Salary])
						     FROM [Employees] AS [sub]
							WHERE [e].[DepartmentID] = [sub].[DepartmentID]
						 GROUP BY [sub].[DepartmentID]
					    )
ORDER BY [e].[DepartmentID]






SELECT *
  FROM [Employees]



