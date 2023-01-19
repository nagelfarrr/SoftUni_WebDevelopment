CREATE DATABASE [University]

USE [University]

CREATE TABLE [Subjects]
(
    [SubjectID] INT PRIMARY KEY IDENTITY,
    [SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Majors]
(
    [MajorID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students]
(
    [StudentID] INT PRIMARY KEY IDENTITY,
    [StudentNumber] VARCHAR(15) NOT NULL,
    [StudentName] VARCHAR(30) NOT NULL,
    [MajorID] INT NOT NULL FOREIGN KEY REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Agenda]
(
    [StudentID] INT NOT NULL FOREIGN KEY REFERENCES [Students]([StudentID]),
    [SubjectID] INT NOT NULL FOREIGN KEY REFERENCES [Subjects]([SubjectID])
)

CREATE TABLE [Payments]
(
    [PaymentID] INT PRIMARY KEY IDENTITY,
    [PaymentDate] DATE NOT NULL,
    [PaymentAmount] DECIMAL(6,2) NOT NULL,
    [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)

ALTER TABLE [Agenda]
ADD CONSTRAINT [PK_StudentSubjectID] PRIMARY KEY ([StudentID], [SubjectID])