CREATE TABLE [dbo].[Clients] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ClientReference] INT              NOT NULL,
    [IsDeleted]       BIT              NOT NULL,
    [RekeningNummer]  NVARCHAR (MAX)   NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [InfoId]          UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Clients_PersonInfo_InfoId] FOREIGN KEY ([InfoId]) REFERENCES [dbo].[PersonInfo] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Clients_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clients_InfoId]
    ON [dbo].[Clients]([InfoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Clients_UserId]
    ON [dbo].[Clients]([UserId] ASC);

