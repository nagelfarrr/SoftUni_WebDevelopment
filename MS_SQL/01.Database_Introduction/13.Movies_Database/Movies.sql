CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [DirectorName] VARCHAR(60) NOT NULL,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [Genres]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [GenreName] VARCHAR(30) NOT NULL,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [Categories]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [CategoryName] VARCHAR(30) NOT NULL,
    [Notes] VARCHAR(MAX)
)

CREATE TABLE [Movies]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Title] VARCHAR(MAX) NOT NULL,
    [DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id),
    [CopyrightYear] DATE NOT NULL,
    [Length] TIME NOT NULL,
    [GenreId] INT FOREIGN KEY REFERENCES [Genres](Id),
    [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id),
    [Rating] DECIMAL(2,1) NOT NULL,
    [Notes] VARCHAR(MAX) 
)

INSERT INTO [Directors] VALUES
    ('Director 1', NULL),
    ('Director 2', NULL),
    ('Director 3', NULL),
    ('Director 4', NULL),
    ('Director 5', NULL)

INSERT INTO [Genres] VALUES
    ('Genre 1', 'Note 1'),
    ('Genre 2', 'Note 2'),
    ('Genre 3', 'Note 3'),
    ('Genre 4', 'Note 4'),
    ('Genre 5', 'Note 5')

INSERT INTO [Categories] VALUES
    ('Category 1', NULL),
    ('Category 2', NULL),
    ('Category 3', NULL),
    ('Category 4', NULL),
    ('Category 5', NULL)


INSERT INTO [Movies] VALUES
    ('Movie 1', 1, '1990-01-29', '01:25:20', 5, 4, 9.5, NULL),
    ('Movie 1', 4, '1990-01-29', '01:25:20', 4, 1, 9.5, NULL),
    ('Movie 1', 5, '1990-01-29', '01:25:20', 3, 3, 9.5, NULL),
    ('Movie 1', 3, '1990-01-29', '01:25:20', 1, 5, 9.5, NULL),
    ('Movie 1', 2, '1990-01-29', '01:25:20', 2, 2, 9.5, NULL)

