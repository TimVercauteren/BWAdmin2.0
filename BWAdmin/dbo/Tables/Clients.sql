CREATE TABLE [dbo].[Clients] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ClientReference] INT              NOT NULL,
    [IsDeleted]       BIT              NOT NULL,
    [AccountNumber]   NVARCHAR (MAX)   NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [InfoId]          UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Clients_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AppUsers] ([Id]),
    CONSTRAINT [FK_Clients_PersonInfo_InfoId] FOREIGN KEY ([InfoId]) REFERENCES [dbo].[PersonInfo] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clients_InfoId]
    ON [dbo].[Clients]([InfoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Clients_UserId]
    ON [dbo].[Clients]([UserId] ASC);

