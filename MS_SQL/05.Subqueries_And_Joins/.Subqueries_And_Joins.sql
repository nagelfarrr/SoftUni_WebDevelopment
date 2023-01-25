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