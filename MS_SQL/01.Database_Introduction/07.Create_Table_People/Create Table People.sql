CREATE TABLE [People]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL,
    [Picture] VARBINARY(2000),
    [Height] DECIMAL(3, 2),
    [Weight] DECIMAL(4,2),
    [Gender] CHAR NOT NULL CHECK([Gender] = 'm' OR [Gender] = 'f'),
    [Birthdate] DATETIME2 NOT NULL,
    [Biography] NVARCHAR(MAX)
)

INSERT INTO [People] VALUES
    ('Dragan', NULL, 1.80, 58.00, 'm', '2000-01-20', 'some bio'),
    ('Ivan', NULL, 1.50, 90.00, 'm', '2002-02-22', 'some bio2'),
    ('Draganka', NULL, 1.70, 48.00, 'f', '1990-02-20', 'some bio3'),
    ('Petar', NULL, 1.80, 58.00, 'm', '2000-01-20', 'some bio4'),
    ('Gosho', NULL, 1.80, 58.00, 'm', '2000-01-20', NULL)

