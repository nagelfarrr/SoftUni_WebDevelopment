CREATE DATABASE WMS

USE WMS

--01.Database design

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL REFERENCES Models(ModelId),
	[Status] VARCHAR(11) CHECK([Status] IN ('Pending', 'In Progress', 'Finished'))  DEFAULT('Pending'),
	ClientId INT NOT NULL REFERENCES Clients(ClientId),
	MechanicId INT NOT NULL REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT NOT NULL DEFAULT(0)
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	[Description] VARCHAR(255),
	Price DECIMAL(6,2) NOT NULL CHECK(Price >0),
	VendorId INT NOT NULL REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL CHECK(StockQty >=0) DEFAULT(0)
)

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL REFERENCES Orders(OrderId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT NOT NULL CHECK(Quantity > 0) DEFAULT(1)
	PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT NOT NULL CHECK(Quantity > 0) DEFAULT(1)
	PRIMARY KEY(JobId, PartId)
)

--02.Insert

INSERT INTO Clients VALUES
	('Teri', 'Ennaco', '570-889-5187'),
	('Merlyn', 'Lawler','201-588-7810'),
	('Georgene', 'Montezuma','925-615-5185'),
	('Jettie', 'Mconnell','908-802-3564'),
	('Lemuel', 'Latzke','631-748-6479'),
	('Melodie', 'Knipp','805-690-1682'),
	('Candida', 'Corbley','908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId) VALUES
	('WP8182119', 'Door Boot Seal', 117.86, 2),
	('W10780048', 'Suspension Rod', 42.81, 1),
	('W10841140', 'Silicone Adhesive', 6.77, 4),
	('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--03.Update

UPDATE Jobs
SET [Status] = 'In Progress' ,
 MechanicId = 3
WHERE [Status] = 'Pending' 

--04.Delete

DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--05.Mechanic Assignments

SELECT
	CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	j.[Status],
	j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j
	ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--06.Current Clients

SELECT 
    c.FirstName + ' ' + c.LastName AS Client,
    DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS DaysGoing,
    j.Status
FROM Clients AS c
JOIN Jobs AS j ON c.ClientId = j.ClientId
WHERE j.[Status] <> 'Finished'
ORDER BY DaysGoing DESC, c.ClientId ASC

--07.Mechanic Performance

SELECT
    m.FirstName + ' ' + m.LastName AS Mechanic,
    AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS AverageDays
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
GROUP BY m.FirstName, m.LastName, j.MechanicId
ORDER BY j.MechanicId

--08.Available Mechanics

SELECT
    FirstName + ' ' + LastName AS Available
FROM Mechanics
WHERE MechanicId NOT IN
(
    SELECT MechanicId 
    FROM Jobs
    WHERE [Status] = 'In Progress'
)
ORDER BY MechanicId

--09.Past Expenses

SELECT 
    j.JobId, 
    ISNULL(SUM(p.Price * op.Quantity), 0) as Total
FROM Jobs AS j
LEFT JOIN Orders o on j.JobId = o.JobId
LEFT join OrderParts op on o.OrderId = op.OrderId
LEFT join Parts p on op.PartId = p.PartId
WHERE J.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

--10.Missing Parts

SELECT
    p.PartId,
    p.[Description],
    SUM(pn.Quantity) AS Required,
    SUM(p.StockQty) AS InStock,
    ISNULL(SUM(op.Quantity), 0) AS Ordered
FROM Parts AS p
LEFT JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
LEFT JOIN Jobs AS j ON pn.JobId = j.JobId
LEFT JOIN Orders AS o ON j.JobId = o.JobId
LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
WHERE j.[Status] <> 'Finished'
GROUP BY p.PartId, p.[Description]
HAVING SUM(pn.Quantity) > SUM(p.StockQty) + ISNULL(SUM(op.Quantity), 0)
ORDER BY p.PartId

--11.Place Order
GO

CREATE PROC usp_PlaceOrder
(@jobId INT, @serial VARCHAR(50), @quantity INT)
AS
BEGIN
IF (@jobId IN (SELECT JobId FROM Jobs WHERE Status = 'Finished')) THROW 50011, 'This job is not active!', 1
IF (@quantity <= 0) THROW 50012, 'Part quantity must be more than zero!', 1
IF (@jobId NOT IN (SELECT JobId FROM Jobs)) THROW 50013, 'Job not found!', 1
IF (@serial NOT IN (SELECT SerialNumber FROM Parts)) THROW 50014, 'Part not found!', 1

DECLARE @partId INT = (SELECT TOP(1) PartId FROM Parts WHERE SerialNumber = @serial)
DECLARE @orderId INT

IF (@jobId IN (SELECT JobId FROM Orders WHERE IssueDate IS NULL))
    BEGIN
    SET @OrderId = (SELECT TOP(1) OrderId FROM Orders WHERE JobId = @jobId)
    IF (@partId IN (SELECT PartId FROM OrderParts WHERE OrderId = @OrderId))
        BEGIN
        UPDATE OrderParts
            SET Quantity += @quantity 
            WHERE OrderId = @OrderId AND PartId = @partId
        RETURN
        END
    INSERT INTO OrderParts VALUES (@OrderId, @partId, @quantity)
    RETURN
    END

INSERT INTO Orders VALUES (@jobId, NULL, 0)
SET @orderId = (SELECT TOP(1) OrderId FROM Orders ORDER BY OrderId DESC)
INSERT INTO OrderParts VALUES (@OrderId, @partId, @quantity)
END

--12.Cost of Order
GO

CREATE FUNCTION udf_GetCost 
(@jobId INT)
RETURNS DECIMAL(18, 2)
AS
BEGIN
RETURN ISNULL(
(
    SELECT 
    SUM(p.Price * op.Quantity) 
    FROM Orders AS o
    JOIN OrderParts AS op ON o.OrderId = op.OrderId
    JOIN Parts AS p ON op.PartId = p.PartId
    WHERE o.JobId = @jobId
    GROUP BY o.JobId
), 0)
END