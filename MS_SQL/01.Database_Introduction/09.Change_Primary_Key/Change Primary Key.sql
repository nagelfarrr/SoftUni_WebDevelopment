ALTER TABLE [Users] DROP CONSTRAINT PK__Users__3214EC070D11F347

ALTER TABLE [Users] ADD  CONSTRAINT [PK_IdUsername] PRIMARY KEY ([Id], [Username])