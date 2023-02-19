CREATE DATABASE [Service]

USE [Service]

--01.Table design

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age >= 14 AND Age <=110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age >= 18 AND Age <= 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(20) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	StatusId INT NOT NULL REFERENCES [Status](Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT NOT NULL REFERENCES Users(Id),
	EmployeeId INT REFERENCES Employees(Id)
)

--02.Insert

INSERT INTO Employees  (FirstName, LastName, Birthdate, DepartmentId) VALUES
	('Marlo', 'O''Malley', '1958-9-21', 1),
	('Niki', 'Stanaghan', '1969-11-26', 4),
	('Ayrton', 'Senna', '1960-03-21', 9),
	('Ronnie', 'Peterson', '1944-02-14', 9),
	('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports VALUES
	(1,	1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6,	2),
	(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running',	3, 5),
	(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--03.Update

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--04.Delete

DELETE Reports
WHERE StatusId = 4

--05.Unassigned Reports

SELECT
	[Description],
	FORMAT(OpenDate, 'dd-MM-yyy' ) AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, [Description]

--06.Reports & Categories

SELECT
	r.[Description],
	c.[Name]
FROM Reports AS r
JOIN Categories AS c
	ON r.CategoryId = c.Id
ORDER BY r.[Description], c.[Name]

--07.Most Reported Category

SELECT TOP(5)
	c.Name,
	COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c
	ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC, c.Name

--08.Birthday Report

SELECT
	u.Username,
	c.[Name] AS CategoryName
FROM Users AS u
LEFT JOIN Reports AS r
	ON u.Id = r.UserId
LEFT JOIN Categories AS c
	ON r.CategoryId = c.Id
WHERE MONTH(r.OpenDate) = MONTH(u.Birthdate) AND DAY(r.OpenDate) = DAY(u.Birthdate)
ORDER BY u.Username, CategoryName

--09.Users per Employee

SELECT
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	COUNT(r.UserId) AS UsersCount
FROM Reports AS r
RIGHT JOIN Employees AS e
	ON r.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName 


--10.FUll Info

SELECT
	IIF(e.FirstName IS NULL AND e.LastName IS NULL, 'None', CONCAT(e.FirstName, ' ', e.LastName)) AS Employee,
	IIF(d.[Name] IS NULL, 'None', d.[Name]) AS Department,
	c.[Name] AS Category,
	r.[Description],
	FORMAT(OpenDate, 'dd.MM.yyyy') AS OpenDate,
	s.[Label],
	u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e
	ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d
	ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c
	ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s
	ON r.StatusId = s.Id
LEFT JOIN Users AS u
	ON r.UserId = u.Id
ORDER BY
	e.FirstName DESC,
	e.LastName DESC,
	Department,
	Category,
	r.[Description],
	OpenDate,
	s.[Label],
	[User]

--11.Hours To Complete
GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @result INT =
						(
							SELECT
								DATEDIFF(HOUR, OpenDate,CloseDate)
							FROM Reports
							WHERE OpenDate = @StartDate
							AND CloseDate = @EndDate
						)
	RETURN IIF(@result IS NULL, 0, @result)
END

--12.Assign Employee
GO

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @departmentIdEmployee INT = 
(
    SELECT DepartmentId 
    FROM Employees 
    WHERE Id = @EmployeeId
)
DECLARE @departmentIdReport INT = 
(
    SELECT c.DepartmentId 
    FROM Reports AS r 
    JOIN Categories AS c ON r.CategoryId = c.Id
    WHERE r.Id = @ReportId
)
IF @departmentIdEmployee <> @departmentIdReport 
    THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
ELSE 
    UPDATE Reports 
    SET EmployeeId = @EmployeeId 
    WHERE Id = @ReportId
END