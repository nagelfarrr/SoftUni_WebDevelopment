CREATE DATABASE [SoftUni]

USE [SoftUni]

CREATE TABLE [Towns]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Addresses]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [AddressText] VARCHAR(50) NOT NULL,
    [TownId] INT FOREIGN KEY REFERENCES [Towns](Id)
)

CREATE TABLE [Departments]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(20) NOT NULL
)

CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(20) NOT NULL,
    [MiddleName] VARCHAR(20),
    [LastName] VARCHAR(20) NOT NULL,
    [JobTitle] VARCHAR(50) NOT NULL,
    [DepartmentId] INT FOREIGN KEY REFERENCES [Departments](Id),
    [HireDate] DATE NOT NULL,
    [Salary] DECIMAL(6,2) NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id)
)

