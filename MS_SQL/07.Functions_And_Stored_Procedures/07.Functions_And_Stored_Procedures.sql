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
