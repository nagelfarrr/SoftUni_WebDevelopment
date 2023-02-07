CREATE DATABASE NationalTouristSitesOfBulgaria

GO
USE NationalTouristSitesOfBulgaria
GO

--01.DDL

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations
(
    Id INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
    ,Municipality VARCHAR(50)
    ,Province VARCHAR(50)
)

CREATE TABLE Sites
(
    Id INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(100) NOT NULL
    ,LocationId INT REFERENCES Locations(Id) NOT NULL
    ,CategoryId INT REFERENCES Categories(Id) NOT NULL
    ,Establishment VARCHAR(15) 
)

CREATE TABLE Tourists
(
    Id INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
    ,Age INT CHECK (Age >= 0 AND Age <=120) NOT NULL
    ,PhoneNumber VARCHAR(20) NOT NULL
    ,Nationality VARCHAR(30) NOT NULL
    ,Reward VARCHAR(20) 
)

CREATE TABLE SitesTourists
(
    TouristId INT  REFERENCES Tourists(Id) NOT NULL
    ,SiteId INT  REFERENCES Sites(Id) NOT NULL
    CONSTRAINT PK_TouristsSites PRIMARY KEY(TouristId, SiteId)
)

CREATE TABLE BonusPrizes
(
    Id INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes
(
    TouristId INT REFERENCES Tourists(Id) NOT NULL
    ,BonusPrizeId INT REFERENCES BonusPrizes(Id) NOT NULL
    CONSTRAINT PK_TouristBonus PRIMARY KEY(TouristId, BonusPrizeId)
)

--02 Insert

INSERT INTO Tourists VALUES
    ('Borislava Kazakova' , 52, '+359896354244', 'Bulgaria', NULL)
    ,('Peter Bosh',	48,	'+447911844141', 'UK', NULL)
    ,('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge')
    ,('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge')
    ,('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites VALUES
    ('Ustra fortress', 90, 7, 'X')
    ,('Karlanovo Pyramids', 65, 7, NULL)
    ,('The Tomb of Tsar Sevt', 63, 8, 'V BC')
    ,('Sinite Kamani Natural Park', 17, 1, NUll)
    ,('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

--03 Update

UPDATE Sites
    SET Establishment = '(not defined)'
WHERE Establishment IS NULL

--04 Delete

DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = 
(
    SELECT 
        Id
    FROM BonusPrizes
    WHERE [Name] = 'Sleeping bag'
)

DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'

--05 Tourists

SELECT
	[Name]
	,Age
	,PhoneNumber
	,Nationality
FROM Tourists
ORDER BY Nationality ASC, Age DESC,[Name] ASC

--06. Sites with Their Location and Category

SELECT
	s.[Name] AS [Site]
	,l.[Name] AS [Location]
	,s.Establishment
	,c.[Name] AS Category
FROM Sites AS s
JOIN Locations AS l
	ON s.LocationId = l.Id
JOIN Categories AS c
	ON s.CategoryId = c.Id
ORDER BY c.[Name] DESC, l.[Name] ASC, s.[Name] ASC

--07.Count of Sites in Sofia Province

SELECT
	l.Province
	,l.Municipality
	,l.[Name] AS [Location]
	,COUNT(s.Id) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s
	ON l.Id = s.LocationId
WHERE Province = 'Sofia'
GROUP BY l.Province,l.Municipality,l.[Name]
ORDER BY CountOfSites DESC, [Location]

--08. Tourist Sites established BC

SELECT
	s.[Name] AS [Site]
	,l.[Name] AS [Locations]
	,l.Municipality
	,l.Province
	,s.Establishment
FROM Sites AS s
JOIN Locations AS l
	ON s.LocationId = l.Id
WHERE 
l.[Name] NOT LIKE 'B%' 
AND l.[Name] NOT LIKE 'M%'
AND l.[Name] NOT LIKE 'D%'
AND s.Establishment LIKE '%BC%'
ORDER BY s.[Name]

--09. Tourists with their Bonus Prizes

SELECT
	t.[Name]
	,t.Age
	,t.PhoneNumber
	,t.Nationality
	,CASE
		WHEN b.[Name] IS NULL THEN '(no bonus prize)'
		ELSE b.[Name]
	END AS Reward
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tb
	ON t.Id = tb.TouristId
LEFT JOIN BonusPrizes AS b
	ON tb.BonusPrizeId = b.Id
ORDER BY t.[Name]

--10. Tourists visiting History & Archaeology sites

SELECT
	DISTINCT SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) + 1, LEN(t.[Name]) - CHARINDEX(' ', t.[Name])) AS LastName
	,t.Nationality
	,t.Age
	,t.PhoneNumber
FROM Tourists AS t
JOIN SitesTourists AS st
	ON t.Id = st.TouristId
JOIN Sites AS s
	On st.SiteId = s.Id
JOIN Categories AS c
	ON s.CategoryId = c.Id
WHERE c.[Name] = 'History and archaeology'
ORDER BY LastName

--11. Tourists Count on a Tourist Site
GO

CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
BEGIN
	DECLARE @countOfTourists INT =
	(
	SELECT
		COUNT(*)
	FROM Sites AS s
	JOIN SitesTourists AS st
		ON s.Id = st.SiteId
	JOIN Tourists AS t
		ON st.TouristId = t.Id
	WHERE s.[Name] = @Site
	GROUP BY s.[Name]
	)
	RETURN @countOfTourists
END

--12.Annual Reward Lottery
GO

CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
	DECLARE @countOfSites INT = 
	(
		SELECT
			COUNT(s.Id)
		FROM Tourists AS t
		JOIN SitesTourists AS st
			ON t.Id = st.TouristId
		JOIN Sites AS s
			ON st.SiteId = s.Id
		WHERE t.[Name] = @TouristName
		GROUP BY t.[Name]
	)

	DECLARE @reward VARCHAR(20) = NULL
	
		IF (@countOfSites >= 100)
		BEGIN
			SET @reward = 'Gold badge'
		END
		ELSE IF (@countOfSites >= 50)
		BEGIN
			SET @reward = 'Silver badge'
		END
		ELSE IF (@countOfSites >= 25)
		BEGIN
			SET @reward = 'Bronze badge'
		END
	
	SELECT
			t.[Name]
			,@reward AS Reward
		FROM Tourists AS t
		JOIN SitesTourists AS st
			ON t.Id = st.TouristId
		JOIN Sites AS s
			ON st.SiteId = s.Id
		WHERE t.[Name] = @TouristName
		GROUP BY t.[Name]
END