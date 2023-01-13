CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [CategoryName] VARCHAR(MAX) NOT NULL,
    [DailyRate] DECIMAL(6,2) NOT NULL,
    [WeeklyRate] DECIMAL(6,2) NOT NULL,
    [MonthlyRate] DECIMAL(6,2) NOT NULL,
    [WeekendRate] DECIMAL(6,2) NOT NULL
)

CREATE TABLE [Cars]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [PlateNumber] VARCHAR(20) NOT NULL,
    [Manufacturer] VARCHAR(30) NOT NULL,
    [Model] VARCHAR(30) NOT NULL,
    [CarYear] INT NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id),
    [Doors] INT NOT NULL,
    [Picture] VARBINARY(MAX),
    [Condition] VARCHAR(MAX),
    [Available] BIT NOT NULL
)

CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(20) NOT NULL,
    [LastName] VARCHAR(20) NOT NULL,
    [Title] VARCHAR(MAX) NOT NULL,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [Customers]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [DriverLicenceNumber] INT NOT NULL,
    [FullName] VARCHAR(50) NOT NULL,
    [Address] VARCHAR(200) NOT NULL,
    [City] VARCHAR(200) NOT NULL,
    [ZIPCode] INT NOT NULL,
    [Notes] VARCHAR(MAX)
)


CREATE TABLE [RentalOrders]
(
    [Id] INT PRIMARY KEY IDENTITY ,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id),
    [CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id),
    [CarId] INT FOREIGN KEY REFERENCES [Cars](Id),
    [TankLevel] DECIMAL(4,2) NOT NULL,
    [KilometrageStart] INT NOT NULL,
    [KilometrageEnd] INT NOT NULL,
    [TotalKilometrage] AS ([KilometrageStart] + [KilometrageEnd]),
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [TotalDays] INT NOT NULL,
    [RateApplied] DECIMAL(6,2) NOT NULL,
    [TaxRate] DECIMAL(4,2) NOT NULL,
    [OrderStatus] VARCHAR(MAX) NOT NULL,
    [Notes] VARCHAR(MAX)

)

INSERT INTO [Categories] VALUES
    ('Category 1', 50.00, 100.00,150.00, 20.00),
    ('Category 2', 10.00, 20.00,40.00, 5.00),
    ('Category 3', 20.00, 40.00,60.00, 10.00)

INSERT INTO [Cars] VALUES
    ('TX4050PM', 'Ford', 'Escort', 1990, 2, 4, NULL, 'GOOD' , 1),
    ('CB4551AM', 'BMW', 'R8-Sport', 2015, 3, 2, NULL, 'PERFECT' , 0),
    ('PB2121BC', 'Mitsubishi', 'COLT', 1995, 1, 2, NULL, 'BAD' , 1)

INSERT INTO [Employees] VALUES
    ('Ivan', 'Petrov', 'Salesman', NULL),
    ('Georgi', 'Ivanov', 'Mechanic', NULL),
    ('Petar', 'Dimitrov', 'Manager', NULL)

INSERT INTO [Customers] VALUES
    (123456, 'Ivan Ivanov', 'Lozenetz', 'Sofia', 1550, NULL),
    (789101, 'Petar Petrov', 'Chaika', 'Varna', 2010, NULL),
    (112131, 'Gosho Goshov', 'ul. Hadji Dimitar 20', 'Plovdiv', 3333, NULL)

INSERT INTO [RentalOrders] VALUES 
    (1, 2, 3, 50.00, 10, 50, '2023-01-13', '2023-01-18', 5, 100.00, 20.00, 'Status', NULL),
    (2, 3, 2, 40.00, 10, 50, '2023-01-13', '2023-01-18', 5, 100.00, 20.00, 'Status', NULL),
    (3, 1, 1, 30.00, 10, 50, '2023-01-13', '2023-01-18', 5, 100.00, 20.00, 'Status', NULL)
