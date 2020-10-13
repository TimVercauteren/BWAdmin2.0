IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [PersonInfo] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [StraatNaam] nvarchar(max) NULL,
    [HuisNummer] nvarchar(max) NULL,
    [BusNummer] nvarchar(max) NULL,
    [Postcode] nvarchar(max) NULL,
    [Gemeente] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [TelefoonNummer] nvarchar(max) NULL,
    [BtwNummer] nvarchar(max) NULL,
    CONSTRAINT [PK_PersonInfo] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Username] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    [PersonInfoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_PersonInfo_PersonInfoId] FOREIGN KEY ([PersonInfoId]) REFERENCES [PersonInfo] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Clients] (
    [Id] uniqueidentifier NOT NULL,
    [ClientReference] int NOT NULL,
    [IsDeleted] bit NOT NULL,
    [RekeningNummer] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    [InfoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clients_PersonInfo_InfoId] FOREIGN KEY ([InfoId]) REFERENCES [PersonInfo] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Clients_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Offers] (
    [Id] uniqueidentifier NOT NULL,
    [OfferNumber] nvarchar(max) NULL,
    [ExperationDate] datetime2 NOT NULL,
    [Date] datetime2 NOT NULL,
    [FileName] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    [VatPercentage] int NOT NULL,
    [PrePaid] decimal(18,2) NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [InvoiceId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Offers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Offers_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Invoices] (
    [Id] uniqueidentifier NOT NULL,
    [Year] int NOT NULL,
    [NumberOfInvoiceInYear] int NOT NULL,
    [InvoiceDate] datetime2 NOT NULL,
    [OfferId] uniqueidentifier NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [FileName] nvarchar(max) NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Invoices_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Invoices_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [WorkItem] (
    [Id] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NULL,
    [NettoPrice] decimal(18,2) NOT NULL,
    [MarginPercentage] decimal(18,2) NOT NULL,
    [InvoiceId] uniqueidentifier NULL,
    [OfferId] uniqueidentifier NULL,
    CONSTRAINT [PK_WorkItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkItem_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkItem_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_Clients_InfoId] ON [Clients] ([InfoId]);

GO

CREATE INDEX [IX_Clients_UserId] ON [Clients] ([UserId]);

GO

CREATE INDEX [IX_Invoices_ClientId] ON [Invoices] ([ClientId]);

GO

CREATE UNIQUE INDEX [IX_Invoices_OfferId] ON [Invoices] ([OfferId]);

GO

CREATE INDEX [IX_Offers_ClientId] ON [Offers] ([ClientId]);

GO

CREATE UNIQUE INDEX [IX_Users_PersonInfoId] ON [Users] ([PersonInfoId]);

GO

CREATE INDEX [IX_WorkItem_InvoiceId] ON [WorkItem] ([InvoiceId]);

GO

CREATE INDEX [IX_WorkItem_OfferId] ON [WorkItem] ([OfferId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201013153740_init', N'3.1.9');

GO