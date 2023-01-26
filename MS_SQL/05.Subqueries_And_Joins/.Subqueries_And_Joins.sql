USE [SoftUni]

--01. Employee Address

SELECT TOP 5
    [e].[EmployeeId]
    ,[e].[JobTitle]
    ,[e].[AddressID]
    ,[a].[AddressText]

FROM [Employees] AS [e]
JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
ORDER BY [e].[AddressID] ASC

--02. Addresses with Towns

SELECT TOP (50)
    [e].[FirstName]
    ,[e].[LastName]
    ,[t].[Name]
    ,[a].[AddressText]

FROM [Employees] AS [e]
JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
JOIN [Towns] AS [t] ON [a].[TownID] = [t].[TownID]

ORDER BY [e].[FirstName], [e].[LastName]

--03. Sales Employees

SELECT
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,[e].[LastName]
    ,[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
    WHERE [d].[Name] = 'Sales'
ORDER BY [e].[EmployeeID]

--04. Employee Departments

SELECT TOP (5)
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,[e].[Salary]
    ,[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
JOIN [Departments] as [d] 
ON [e].[DepartmentID] = [d].[DepartmentID]
    WHERE [e].[Salary] > 15000
ORDER BY [d].[DepartmentID]

--05. Employees Without Projects

SELECT TOP (3)
    [e].[EmployeeID]
    ,[e].[FirstName]
FROM [Employees] AS [e]
LEFT JOIN [EmployeesProjects] AS [ep]
ON [e].[EmployeeID] = [ep].[EmployeeID]
WHERE [ep].[EmployeeID] IS NULL
ORDER BY [e].[EmployeeID]

--06. Employees Hired After

SELECT
    [e].[FirstName]
    ,[e].[LastName]
    ,[e].[HireDate]
    ,[d].[Name] AS [DeptName]
FROM [Employees] AS [e]
JOIN [Departments] AS [d]
    ON [e].[DepartmentID] = [d].[DepartmentID] 
WHERE
    YEAR([e].[HireDate]) > 1998
    AND [d].[Name] = 'Sales'
    OR [d].[Name] = 'Finance'
ORDER BY [e].[HireDate]

--07. Employees With Project

SELECT TOP (5)
    [ep].[EmployeeID]
    ,[e].[FirstName]
    ,[p].[Name]
FROM [Employees] AS [e]
JOIN [EmployeesProjects] AS [ep]
    ON [e].[EmployeeID] = [ep].[EmployeeID]
JOIN [Projects] as [p]
    ON [ep].[ProjectID] = [p].[ProjectID]
WHERE [p].[StartDate] > '2002-08-13'
    AND [p].[EndDate] IS NULL

--08. Employee 24

SELECT
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,CASE 
        WHEN YEAR([p].[StartDate]) >= 2005 THEN NULL
        ELSE [p].[Name]
    END AS [ProjectName]
FROM [Employees] AS [e]
JOIN [EmployeesProjects] as [ep]
    ON [e].[EmployeeID] = [ep].[EmployeeID]
JOIN [Projects] AS [p]
    ON [ep].[ProjectID] = [p].[ProjectID]
WHERE [ep].[EmployeeID] = 24

--09. Employee Manager

SELECT
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,[e].[ManagerID]
    ,[em].[FirstName] AS [ManagerName]
FROM [Employees] AS [e]
JOIN [Employees] AS [em]
    ON [e].[ManagerID] = [em].[EmployeeID]
WHERE 
    [e].[ManagerID] = 3 
    OR [e].[ManagerID] = 7

--10. Employees Summary

SELECT TOP (50)
    [e].[EmployeeID]
    ,CONCAT_WS(' ', [e].[FirstName], [e].[LastName]) AS [EmployeeName]
    ,[em].[FirstName] + ' ' + [em].[LastName] AS [ManagerName]
    ,[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
JOIN [Employees] AS [em]
    ON [e].[ManagerID] = [em].[EmployeeID]
JOIN [Departments] AS [d]
    ON [e].[DepartmentID] = [d].[DepartmentID]
ORDER BY [e].[EmployeeID]

--11. Min Average Salary

SELECT
    MIN([avg]) AS [MinAverageSalary]
FROM
(
    SELECT
        AVG([Salary]) AS [avg]
    FROM [Employees]
    GROUP BY [DepartmentID]
) AS AverageSalary

--------------------------------------

USE [Geography]

--------------------------------------

--12. Highest Peaks in Bulgaria

SELECT
    [c].[CountryCode]
    ,[m].[MountainRange]
    ,[p].[PeakName]
    ,[p].[Elevation]
FROM 
    [Countries] AS [c]
JOIN [MountainsCountries] AS [mc]
    ON [c].[CountryCode] = [mc].[CountryCode]
JOIN [Mountains] AS [m]
    ON [mc].[MountainId] = [m].[Id]
JOIN [Peaks] AS [p]
    ON [m].[Id] = [p].[MountainId]
WHERE
    [c].[CountryCode] = 'BG'
    AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC

--13. Count Mountain Ranges

SELECT
    [mc].[CountryCode]
    ,COUNT([m].[MountainRange]) AS [MountainRanges]
FROM
    [Countries] AS [c]
JOIN [MountainsCountries] AS [mc]
    ON [c].[CountryCode] = [mc].[CountryCode]
JOIN [Mountains] AS [m]
    ON [mc].[MountainId] = [m].[Id]
WHERE [mc].[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY [mc].[CountryCode]