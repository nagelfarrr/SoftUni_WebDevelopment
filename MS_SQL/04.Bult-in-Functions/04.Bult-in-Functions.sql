USE [SoftUni]
 
--01. Find Names of All Employees by First Name

SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE [FirstName] LIKE 'Sa%'

--02. Find Names of All Employees by Last Name

SELECT [FirstName],
       [LastName]
FROM [Employees]
WHERE [LastName] LIKE '%ei%'

--03. Find First Names of All Employees

SELECT [FirstName]
FROM [Employees]
WHERE [DepartmentID] = 3 
    OR [DepartmentID] = 10
    AND YEAR([HireDate]) BETWEEN 1995 AND 2005

--04. Find All Employees Except Engineers

SELECT 
    [FirstName],
    [LastName]
FROM 
    [Employees]
WHERE [JobTitle] NOT LIKE '%engineer%'

--05. Find Towns with Name Length

SELECT [Name]
FROM [Towns]
WHERE
    LEN([Name]) = 5 OR
    LEN([Name]) = 6
ORDER BY [Name]

--06. Find Towns Starting With

SELECT [TownID] , [Name]
FROM [Towns]
WHERE 
    [Name] LIKE 'M%' OR 
    [Name] LIKE 'K%' OR
    [Name] LIKE 'B%' OR
    [Name] LIKE 'E%'
ORDER BY [Name]

--07. Find Towns Not Starting With

SELECT [TownID] , [Name]
FROM [Towns]
WHERE 
    [Name] NOT LIKE 'R%' AND 
    [Name] NOT LIKE 'B%' AND
    [Name] NOT LIKE 'D%' 
ORDER BY [Name]

GO
--08. Create View Employees Hired After 2000 Year

CREATE VIEW [V_EmployeesHiredAfter2000] AS
    SELECT [FirstName], [LastName]
    FROM [Employees]
    WHERE
        YEAR([HireDate]) > 2000

GO
--09. Length of Last Name

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE
    LEN([LastName]) = 5

--10. Rank Employees by Salary

SELECT
    [EmployeeID],
    [FirstName],
    [LastName],
    [Salary], 
        DENSE_RANK() OVER
        (
           PARTITION BY [Salary] ORDER BY [EmployeeID]
        ) 
        [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--11. Find All Employees with Rank 2


SELECT * FROM
(
	SELECT [EmployeeID], [FirstName], [LastName], [Salary],
		DENSE_RANK() OVER
		(PARTITION BY [Salary] ORDER BY [EmployeeID])
		AS [Rank]
	FROM [Employees]
) 
AS [RankedSelection]
WHERE [Salary] BETWEEN 10000 AND 50000 AND [Rank] = 2
ORDER BY [Salary] DESC


--12.Countries Holding 'A' 3 or More Times

--------------------

GO

USE [Geography]

GO

---------------------

SELECT 
    [CountryName] AS [Country Name]
    ,[IsoCode] AS [ISO Code]
FROM [Countries]
    WHERE LOWER([CountryName]) LIKE '%a%a%a%'
    ORDER BY [IsoCode]

--13. Mix of Peak and River Names

SELECT
    [peak].[PeakName]
    ,[river].[RiverName]
    ,LOWER(LEFT(([peak].[PeakName]), LEN([peak].[PeakName])) + RIGHT(river.RiverName, LEN([river].[RiverName]) -1)) AS Mix
FROM
    [Peaks] AS [peak]
    ,[Rivers] AS [river]
WHERE RIGHT([peak].PeakName, 1) = LEFT([river].[RiverName], 1)
ORDER BY Mix

---------------------

GO

USE[Diablo]

GO

---------------------


--14. Games From 2011 and 2012 Year

SELECT TOP(50)
    [Name]
    ,FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--15. User Email Providers

SELECT 
    [Username]
    ,SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])) AS [Email Provider]
FROM [Users]
 ORDER BY [Email Provider], [Username]