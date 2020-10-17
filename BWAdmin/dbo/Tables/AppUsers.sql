CREATE TABLE [dbo].[AppUsers] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Username]     NVARCHAR (MAX)   NULL,
    [Password]     NVARCHAR (MAX)   NULL,
    [IsDeleted]    BIT              NOT NULL,
    [PersonInfoId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AppUsers_PersonInfo_PersonInfoId] FOREIGN KEY ([PersonInfoId]) REFERENCES [dbo].[PersonInfo] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsers_PersonInfoId]
    ON [dbo].[AppUsers]([PersonInfoId] ASC);

