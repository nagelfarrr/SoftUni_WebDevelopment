CREATE DATABASE CigarShop

USE CigarShop


--01.Database design

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL CHECK([Length] BETWEEN 10 AND 25),
	RingRange DECIMAL(2,1) NOT NULL CHECK(RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) NOT NULL UNIQUE,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT NOT NULL REFERENCES Brands(Id),
	TastId INT NOT NULL REFERENCES Tastes(Id),
	SizeId INT NOT NULL REFERENCES Sizes(Id),
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL VARCHAR(100) NOT NULL,
)


CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
	AddressId INT NOT NULL REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars
(
	ClientId INT NOT NULL REFERENCES Clients(Id),
	CigarId INT NOT NULL REFERENCES Cigars(Id)

	
	PRIMARY KEY(ClientId, CigarId)
)

--02.Insert

INSERT INTO Cigars VALUES

('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')


INSERT INTO Addresses VALUES

('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
('Athens', 'Greece', '4342 McDonald Avenue', 10435),
('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)


--03.Update

UPDATE Cigars
SET PriceForSingleCigar += PriceForSingleCigar * 20/100
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--04.Delete

DELETE Clients
WHERE AddressId IN (SELECT
					Id
				FROM Addresses
				WHERE Country LIKE 'C%')

DELETE Addresses
WHERE Country LIKE 'C%'

--05.Cigars by Price

SELECT
	CigarName
	, PriceForSingleCigar
	, ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar , CigarName DESC

--06.Cigars by Taste

SELECT
	c.Id
	, c.CigarName
	, c.PriceForSingleCigar
	, t.TasteType
	, t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t
	ON c.TastId = t.Id
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY c.PriceForSingleCigar DESC

--07.Clients without Cigars

SELECT
	cl.Id
	, CONCAT(cl.FirstName, ' ', cl.LastName) AS ClientName
	, cl.Email
FROM Clients AS cl
LEFT JOIN ClientsCigars AS cc
	ON cl.Id = cc.ClientId
LEFT JOIN Cigars AS c
	ON cc.CigarId = c.Id
WHERE cc.CigarId IS NULL
ORDER BY ClientName 

--08.First 5 Cigars

SELECT TOP(5)
	c.CigarName
	, c.PriceForSingleCigar
	, c.ImageURL
FROM Cigars AS c
JOIN Sizes AS s
	ON c.SizeId = s.Id
WHERE s.[Length] >=12
AND (c.CigarName LIKE '%ci%'
OR
c.PriceForSingleCigar > 50) 
AND s.RingRange > 2.55
ORDER BY c.CigarName, c.PriceForSingleCigar DESC

--09.Clients with ZIP Codes

SELECT
	cwzc.FullName,
	cwzc.Country,
	cwzc.ZIP,
	CONCAT('$', MAX(cwzc.PriceForSingleCigar)) AS CigarPrice
FROM
(
SELECT
	CONCAT(cl.FirstName, ' ', cl.LastName) AS FullName
	, a.Country
	, a.ZIP
	,c.PriceForSingleCigar
FROM Clients AS cl
JOIN Addresses AS a
	ON cl.AddressId = a.Id
JOIN ClientsCigars AS cc
	ON cl.Id = cc.ClientId
JOIN Cigars AS c
	ON cc.CigarId = c.Id
WHERE ISNUMERIC(ZIP) = 1
) AS cwzc
GROUP BY cwzc.FullName, cwzc.Country,cwzc.ZIP
ORDER BY cwzc.FullName 