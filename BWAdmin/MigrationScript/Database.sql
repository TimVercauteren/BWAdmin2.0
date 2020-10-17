IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DeviceCodes] (
    [UserCode] nvarchar(200) NOT NULL,
    [DeviceCode] nvarchar(200) NOT NULL,
    [SubjectId] nvarchar(200) NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [Expiration] datetime2 NOT NULL,
    [Data] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DeviceCodes] PRIMARY KEY ([UserCode])
);

GO

CREATE TABLE [PersistedGrants] (
    [Key] nvarchar(200) NOT NULL,
    [Type] nvarchar(50) NOT NULL,
    [SubjectId] nvarchar(200) NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [Expiration] datetime2 NULL,
    [Data] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_PersistedGrants] PRIMARY KEY ([Key])
);

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

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AppUsers] (
    [Id] uniqueidentifier NOT NULL,
    [Username] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    [PersonInfoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AppUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AppUsers_PersonInfo_PersonInfoId] FOREIGN KEY ([PersonInfoId]) REFERENCES [PersonInfo] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Clients] (
    [Id] uniqueidentifier NOT NULL,
    [ClientReference] int NOT NULL,
    [IsDeleted] bit NOT NULL,
    [AccountNumber] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    [InfoId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clients_PersonInfo_InfoId] FOREIGN KEY ([InfoId]) REFERENCES [PersonInfo] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Clients_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id])
);

GO

CREATE TABLE [Offers] (
    [Id] uniqueidentifier NOT NULL,
    [OfferNumber] nvarchar(max) NULL,
    [ExperationDate] datetime2 NOT NULL,
    [Date] datetime2 NOT NULL,
    [FileName] nvarchar(max) NULL,
    [IsDeleted] bit NOT NULL,
    [VatPercentage] decimal(18,2) NOT NULL,
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
    CONSTRAINT [FK_Invoices_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id])
);

GO

CREATE TABLE [WorkItem] (
    [Id] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NULL,
    [NettoPrice] decimal(18,2) NOT NULL,
    [MarginPercentage] decimal(18,2) NOT NULL,
    [OfferId] uniqueidentifier NOT NULL,
    [InvoiceId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_WorkItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkItem_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([Id]),
    CONSTRAINT [FK_WorkItem_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id])
);

GO

CREATE UNIQUE INDEX [IX_AppUsers_PersonInfoId] ON [AppUsers] ([PersonInfoId]);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_Clients_InfoId] ON [Clients] ([InfoId]);

GO

CREATE INDEX [IX_Clients_UserId] ON [Clients] ([UserId]);

GO

CREATE UNIQUE INDEX [IX_DeviceCodes_DeviceCode] ON [DeviceCodes] ([DeviceCode]);

GO

CREATE INDEX [IX_DeviceCodes_Expiration] ON [DeviceCodes] ([Expiration]);

GO

CREATE INDEX [IX_Invoices_ClientId] ON [Invoices] ([ClientId]);

GO

CREATE UNIQUE INDEX [IX_Invoices_OfferId] ON [Invoices] ([OfferId]);

GO

CREATE INDEX [IX_Offers_ClientId] ON [Offers] ([ClientId]);

GO

CREATE INDEX [IX_PersistedGrants_Expiration] ON [PersistedGrants] ([Expiration]);

GO

CREATE INDEX [IX_PersistedGrants_SubjectId_ClientId_Type] ON [PersistedGrants] ([SubjectId], [ClientId], [Type]);

GO

CREATE INDEX [IX_WorkItem_InvoiceId] ON [WorkItem] ([InvoiceId]);

GO

CREATE INDEX [IX_WorkItem_OfferId] ON [WorkItem] ([OfferId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201017101651_init', N'3.1.6');

GO