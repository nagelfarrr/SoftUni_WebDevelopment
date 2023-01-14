CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(20) NOT NULL,
    [LastName] VARCHAR(20) NOT NULL,
    [Title] VARCHAR(20) NOT NULL,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [Customers]
(
    [AccountNumber] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(20) NOT NULL,
    [LastName] VARCHAR(20) NOT NULL,
    [PhoneNumber] VARCHAR(15) NOT NULL,
    [EmergencyName] VARCHAR(40) NOT NULL,
    [EmergencyNumber] VARCHAR(15) NOT NULL,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [RoomStatus]
(
    [RoomStatus] VARCHAR(20) PRIMARY KEY,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [RoomTypes]
(
    [RoomType] VARCHAR(20) PRIMARY KEY,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [BedTypes]
(
    [BedType] VARCHAR(20) PRIMARY KEY,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [Rooms]
(
    [RoomNumber] VARCHAR(10) PRIMARY KEY,
    [RoomType] VARCHAR(20) FOREIGN KEY REFERENCES [RoomTypes](RoomType),
    [BedType] VARCHAR(20) FOREIGN KEY REFERENCES [BedTypes](BedType),
    [Rate] DECIMAL(4,2) NOT NULL,
    [RoomStatus] VARCHAR(20) FOREIGN KEY REFERENCES [RoomStatus](RoomStatus),
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [Payments]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [EmployeeID] INT FOREIGN KEY REFERENCES [Employees](Id),
    [PaymentDate] DATE NOT NULL,
    [AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber),
    [FirstDateOccupied] DATE NOT NULL,
    [LastDateOccupied] DATE NOT NULL,
    [TotalDays] INT NOT NULL,
    [AmountCharged] DECIMAL(6,2) NOT NULL,
    [TaxRate] DECIMAL(6,2) NOT NULL,
    [TaxAmount] DECIMAL(6,2) NOT NULL,
    [PaymentTotal] DECIMAL(6,2) NOT NULL,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [Occupancies]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [EmployeeID] INT FOREIGN KEY REFERENCES [Employees](Id),
    [DateOccupied] DATE NOT NULL,
    [AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber),
    [RoomNumber] VARCHAR(10) FOREIGN KEY REFERENCES [Rooms](RoomNumber),
    [RateApplied] DECIMAL(4,2) NOT NULL,
    [PhoneCharge] DECIMAL(4,2) NOT NULL,
    [Notes] VARCHAR(MAX)
)

INSERT INTO [Employees] VALUES
    ('Ivan', 'Ivanov', 'Receptionist', NULL),
    ('Petar', 'Petrov', 'Manager', NULL),
    ('Gosho', 'Goshov', 'Host', NULL)

INSERT INTO [Customers] VALUES
    ('Ivanka', 'Ivanova', '+359883876543', 'Ginka Grozdanova', '+320992999999', 'Some Note'),
    ('Draganka', 'Draganova', '+359883876544', 'Despa Despinova', '+320992997799', 'Some Note 2'),
    ('Tanya', 'Pehlivanska', '+359883876545', 'Galina Galinova', '+320992988999', 'Some Note 3')

INSERT INTO [RoomStatus] VALUES
    ('Status 1', NULL),
    ('Status 2', NULL),
    ('Status 3', NULL)

INSERT INTO [RoomTypes] VALUES
    ('Type 1', NULL),
    ('Type 2', NULL),
    ('Type 3', NULL)

INSERT INTO [BedTypes] VALUES
    ('BedType 1', NULL),
    ('BedType 2', NULL),
    ('BedType 3', NULL)

INSERT INTO [Rooms] VALUES
    ('110A', 'Type 3', 'BedType 1', 9.50, 'Status 1', 'Random note'),
    ('110B', 'Type 1', 'BedType 3', 6.50, 'Status 2', 'Random note 2'),
    ('120C', 'Type 2', 'BedType 2', 10.00, 'Status 3', 'Random note 3')

INSERT INTO [Payments] VALUES
    (1, '2023-01-10', 3, '2023-01-10', '2023-01-12', 2, 150.20, 1.50, 20.50, 300.00, NULL),
    (2, '2023-01-10', 1, '2023-01-10', '2023-01-12', 2, 150.20, 1.50, 20.50, 300.00, NULL),
    (3, '2023-01-10', 2, '2023-01-10', '2023-01-12', 2, 150.20, 1.50, 20.50, 300.00, NULL)

INSERT INTO [Occupancies] VALUES
    (1,'2023-01-11', 2, '110A', 9.50, 20.50, NULL),
    (2,'2023-01-11', 2, '110B', 9.50, 20.50, NULL),
    (3,'2023-01-11', 2, '120C', 9.50, 20.50, NULL)