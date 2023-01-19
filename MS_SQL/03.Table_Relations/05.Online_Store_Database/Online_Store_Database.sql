CREATE DATABASE [OnlineStore]

USE [OnlineStore]

CREATE TABLE [ItemTypes]
(
    [ItemTypeID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20) NOT NULL
)
CREATE TABLE [Items]
(
    [ItemID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20) NOT NULL,
    [ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [Cities]
(
    [CityID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20) NOT NULL
)

CREATE TABLE [Customers]
(
    [CustomerID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20) NOT NULL,
    [Birthday] DATE,
    [CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
)

CREATE TABLE [Orders]
(
    [OrderID] INT PRIMARY KEY IDENTITY,
    [CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [OrderItems]
(
    [OrderID] INT NOT NULL FOREIGN KEY REFERENCES [Orders]([OrderID]),
    [ItemID] INT NOT NULL FOREIGN KEY REFERENCES [Items]([ItemID])
)

ALTER TABLE [OrderItems]
    ADD CONSTRAINT [PK_OrderItems] PRIMARY KEY ([OrderID], [ItemID])

