CREATE TABLE [Users]
(
    [Id] BIGINT PRIMARY KEY IDENTITY,
    [Username] VARCHAR(30) NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    [ProfilePicture] VARBINARY(MAX),
    [LastLoginTime] DATETIME2,
    [IsDeleted] BIT
)

INSERT INTO [Users] VALUES
	('Username 1', 'Password 1', NULL, NULL, 0),
	('Username 2', 'Password 2', NULL, NULL, 0),
	('Username 3', 'Password 3', NULL, NULL, 0),
	('Username 4', 'Password 4', NULL, NULL, 1),
	('Username 5', 'Password 5', NULL, NULL, 1)
