CREATE TABLE [dbo].[Invoices] (
    [Id]                    UNIQUEIDENTIFIER NOT NULL,
    [Year]                  INT              NOT NULL,
    [NumberOfInvoiceInYear] INT              NOT NULL,
    [InvoiceDate]           DATETIME2 (7)    NOT NULL,
    [OfferId]               UNIQUEIDENTIFIER NOT NULL,
    [ClientId]              UNIQUEIDENTIFIER NOT NULL,
    [FileName]              NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Invoices_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Invoices_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [dbo].[Offers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoices_ClientId]
    ON [dbo].[Invoices]([ClientId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Invoices_OfferId]
    ON [dbo].[Invoices]([OfferId] ASC);

