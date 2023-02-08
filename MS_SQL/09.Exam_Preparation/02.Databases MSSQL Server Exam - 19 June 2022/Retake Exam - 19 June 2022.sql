 USE master
CREATE DATABASE Zoo

GO

USE Zoo
GO

------

--01.Database design

CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,PhoneNumber VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50) 
)

CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY
	,AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY
	,AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL
	,BirthDate Date NOT NULL
	,OwnerId INT NULL REFERENCES Owners(Id)
	,AnimalTypeId INT NOT NULL REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages
(
	CageId INT NOT NULL REFERENCES Cages(Id)
	,AnimalId INT NOT NULL REFERENCES Animals(Id)
	, PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY
	,DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,PhoneNumber VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50)
	,AnimalId INT NULL REFERENCES Animals(Id)
	,DepartmentId INT NOT NULL REFERENCES VolunteersDepartments(Id)
)


--02. Insert

INSERT INTO Volunteers VALUES
	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', NULL, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals VALUES
	('Giraffe', '2018-09-21', 21, 1),
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', NULL, 1),
	('Tuatara', '2021-06-30', 2, 4)

--03.Update

UPDATE Animals
SET OwnerId =
			(
				SELECT 
					Id
				FROM Owners
				WHERE [Name] = 'Kaloqn Stoqnov'
			)
WHERE OwnerId IS NULL

--04.Delete

DELETE FROM Volunteers
WHERE DepartmentId = (
						SELECT
							Id
						FROM VolunteersDepartments
						WHERE DepartmentName = 'Education program assistant'
					 )

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

--05. Volunteers

SELECT
	[Name]
	,PhoneNumber
	,[Address]
	,AnimalId
	,DepartmentId
FROM Volunteers
ORDER BY [Name], AnimalId, DepartmentId

--06. Animals data

SELECT
	a.[Name]
	,[at].AnimalType
	,FORMAT(a.BirthDate, 'dd.MM.yyyy' ) AS BirthDate
FROM Animals AS a
JOIN AnimalTypes AS [at]
	ON a.AnimalTypeId = [at].Id
ORDER BY a.[Name]

--07. Owners and Their Animals

SELECT TOP(5)
	o.[Name] AS [Owner]
	,COUNT(a.Id) AS CountOfAnimals
FROM Animals AS a
JOIN Owners AS o
	ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC

--08. Owners, Animals and Cages

SELECT
	CONCAT(o.[Name], '-', a.[Name]) AS OwnersAnimals
	,o.PhoneNumber
	,c.Id AS CageId
FROM Animals AS a
JOIN Owners AS o
	ON a.OwnerId = o.Id
JOIN AnimalTypes AS [at]
	ON a.AnimalTypeId = [at].Id
JOIN AnimalsCages AS ac
	ON a.Id = ac.AnimalId
JOIN Cages AS c
	ON ac.CageId = c.Id
WHERE [at].AnimalType = 'Mammals'
ORDER BY o.[Name], a.[Name] DESC

--09. Volunteers in Sofia

SELECT
	v.[Name]
	,v.PhoneNumber
	,SUBSTRING([Address], CHARINDEX(',', [Address]) + 1, LEN([Address])) AS [Address]
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd
	ON v.DepartmentId = vd.Id
WHERE v.[Address] LIKE '%Sofia%'
AND vd.DepartmentName = 'Education program assistant'
ORDER BY v.[Name]

--10. Animals for Adoption

SELECT
	a.[Name]
	,YEAR(a.BirthDate) AS BirthYear
	,[at].AnimalType
FROM Animals AS a
JOIN AnimalTypes AS [at]
	ON a.AnimalTypeId = [at].Id
WHERE a.OwnerId IS NULL
AND DATEDIFF(YEAR, a.BirthDate, '2022-01-01') < 5
AND [at].AnimalType != 'Birds'
ORDER BY a.[Name]

--11. All Volunteers in a Department

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
BEGIN
	DECLARE @countOfVolunteers INT = (
										SELECT
											COUNT(v.Id)
										FROM Volunteers AS v
										JOIN VolunteersDepartments AS vd
											ON v.DepartmentId = vd.Id
										WHERE vd.DepartmentName = @VolunteersDepartment
								      )
	RETURN @countOfVolunteers
END


--12. Animals with Owner or Not

CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT
		a.[Name]
		,CASE
			WHEN a.OwnerId IS NULL THEN 'For adoption'
			ELSE o.[Name]
		END AS OwnersName
	FROM Animals AS a
	LEFT JOIN Owners AS o
		ON a.OwnerId = o.ID
	WHERE a.[Name] = @AnimalName
END