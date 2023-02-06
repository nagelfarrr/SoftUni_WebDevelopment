--01. Employees with Salary Above 35000

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
    BEGIN
        SELECT
            FirstName
            ,LastName
        FROM Employees
        WHERE Salary > 35000
    END

--02. Employees with Salary Above Number
GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
    BEGIN
        SELECT
            FirstName
            ,LastName
        FROM Employees
        WHERE Salary >= @Number
    END

GO
EXEC usp_GetEmployeesSalaryAboveNumber 35000

--03. Town Names Starting With
GO

CREATE OR ALTER PROC usp_GetTownsStartingWith @letter VARCHAR(20)
AS
    BEGIN
        SELECT
            [Name]
        FROM Towns
        WHERE SUBSTRING([Name], 1, LEN(@letter)) = @letter
    END

GO

EXEC usp_GetTownsStartingWith 'Bo'

--04. Employees from Town

GO

CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(20)
AS
    BEGIN
        SELECT
            e.FirstName
            ,e.LastName
        FROM Employees AS e
        LEFT JOIN Addresses AS a
            ON e.AddressID = a.AddressID
        LEFT JOIN Towns AS t
            ON a.TownID = t.TownID
        WHERE t.Name = @townName
    END

GO

EXEC usp_GetEmployeesFromTown 'Plovdiv'

--05. Salary Level Function
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(8)  
BEGIN
    DECLARE @result NVARCHAR(8) = 'Average'

    IF (@salary < 30000)
    BEGIN
        SET @result = 'Low'
    END;
    IF (@salary > 50000)
    BEGIN
        SET @result = 'High'
    END
    RETURN @result
END;

GO

SELECT
    FirstName
    ,dbo.ufn_GetSalaryLevel(Salary)
FROM Employees


--06. Employees by Salary Level
GO

CREATE PROC usp_EmployeesBySalaryLevel(@level VARCHAR(7))
AS
    BEGIN
        SELECT
            FirstName
            ,LastName
        FROM Employees
        WHERE dbo.ufn_GetSalaryLevel(Salary) = @level
    END

GO

EXEC usp_EmployeesBySalaryLevel 'High'


--07. Define Function
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(20), @word VARCHAR(20))
RETURNS BIT
BEGIN
    DECLARE @counter INT = 1

    WHILE (@counter <= LEN(@word))
    BEGIN
        IF @setOfLetters NOT LIKE '%' + SUBSTRING(@word, @counter, 1) + '%' RETURN 0
        SET @counter += 1
    END
    RETURN 1
END

--08. *Delete Employees and Departments
GO

CREATE PROC usp_DeleteEmployeesFromDepartment 
(@departmentId INT)
AS
BEGIN
	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT NULL
	
	DELETE FROM [EmployeesProjects]	
	WHERE [EmployeeID] IN
	(
		SELECT [EmployeeID] FROM [Employees]
		WHERE [DepartmentID] = @departmentId
	)

	UPDATE [Employees]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN
	(
		SELECT [EmployeeID] FROM [Employees]
		WHERE [DepartmentID] = @departmentId
	)
	
	UPDATE [Departments]
	SET [ManagerID] = NULL
	WHERE [DepartmentID] = @departmentId
	
 	DELETE FROM [Employees]
	WHERE [DepartmentID] = @departmentId

	DELETE FROM [Departments]
	WHERE [DepartmentID] = @departmentId

	SELECT COUNT(*) FROM [Employees]
	WHERE [DepartmentID] = @departmentId
END

------------------------------------------
GO

USE [Bank]
--09. Find Full Name
GO

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
    SELECT 
        FirstName + ' ' + LastName AS [Full Name]
    FROM AccountHolders
END

--10. People with Balance Higher Than
GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(18,4))
AS
BEGIN
    SELECT
        ah.FirstName
        ,ah.LastName
    FROM AccountHolders AS ah
    JOIN
    (
        SELECT
            AccountHolderId
            ,SUM(Balance) AS TotalBalance
        FROM Accounts
        GROUP BY AccountHolderId
    ) AS acc
        ON ah.Id = acc.AccountHolderId
    WHERE acc.TotalBalance > @number
    ORDER BY ah.FirstName , ah.LastName
END

--11. Future Value Function

GO

CREATE FUNCTION ufn_CalculateFutureValue 
(@sum DECIMAL(18, 4), @annualRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
	BEGIN
		RETURN @sum * POWER(1 + @annualRate, @years)
	END


--12. Calculating Interest
 GO

CREATE PROC usp_CalculateFutureValueForAccount 
(@accountId INT, @annualRate FLOAT)
AS
	SELECT
		acc.Id AS [Account Id],
		h.FirstName AS [First Name],
		h.LastName AS [Last Name],
		acc.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(acc.Balance, @annualRate, 5) AS [Balance in 5 years]
	FROM Accounts AS acc
	JOIN AccountHolders AS h
		ON acc.AccountHolderId = h.Id
	WHERE acc.Id = @accountId