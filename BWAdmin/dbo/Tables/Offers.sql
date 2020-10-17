CREATE TABLE [dbo].[Offers] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [OfferNumber]    NVARCHAR (MAX)   NULL,
    [ExperationDate] DATETIME2 (7)    NOT NULL,
    [Date]           DATETIME2 (7)    NOT NULL,
    [FileName]       NVARCHAR (MAX)   NULL,
    [IsDeleted]      BIT              NOT NULL,
    [VatPercentage]  DECIMAL (18, 2)  NOT NULL,
    [PrePaid]        DECIMAL (18, 2)  NOT NULL,
    [ClientId]       UNIQUEIDENTIFIER NOT NULL,
    [InvoiceId]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Offers_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Offers_ClientId]
    ON [dbo].[Offers]([ClientId] ASC);

