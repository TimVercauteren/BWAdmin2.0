CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Username]     NVARCHAR (MAX)   NULL,
    [Password]     NVARCHAR (MAX)   NULL,
    [IsDeleted]    BIT              NOT NULL,
    [PersonInfoId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_PersonInfo_PersonInfoId] FOREIGN KEY ([PersonInfoId]) REFERENCES [dbo].[PersonInfo] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_PersonInfoId]
    ON [dbo].[Users]([PersonInfoId] ASC);

