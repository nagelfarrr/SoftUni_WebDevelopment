CREATE TABLE [Persons]
(
    [PersonId] INT NOT NULL,
    [FirstName] VARCHAR(20) NOT NULL,
    [Salary] DECIMAL(7,2) NOT NULL,
    [PassportID] INT NOT NULL
)

CREATE TABLE [Passports]
(
    [PassportID] INT PRIMARY KEY IDENTITY(101,1) ,
    [PassportNumber] CHAR(8) NOT NULL
)

INSERT INTO [Passports] VALUES
    ('N34FG21B'),
    ('K65LO4R7'),
    ('ZE657QP2')

INSERT INTO [Persons] VALUES
    (1, 'Roberto', 43300.00, 102),
    (2, 'Tom', 56100.00, 103),
    (3, 'Yana', 60200.00, 101)

ALTER TABLE [Persons]
    ADD PRIMARY KEY ([PersonId])

ALTER TABLE [Persons]
    ADD CONSTRAINT [FK_PersonPassportID] 
    FOREIGN KEY ([PassportID]) REFERENCES [Passports]([PassportID])