CREATE TABLE [dbo].[PersonInfo] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (MAX)   NULL,
    [StraatNaam]     NVARCHAR (MAX)   NULL,
    [HuisNummer]     NVARCHAR (MAX)   NULL,
    [BusNummer]      NVARCHAR (MAX)   NULL,
    [Postcode]       NVARCHAR (MAX)   NULL,
    [Gemeente]       NVARCHAR (MAX)   NULL,
    [Email]          NVARCHAR (MAX)   NULL,
    [TelefoonNummer] NVARCHAR (MAX)   NULL,
    [BtwNummer]      NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_PersonInfo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

