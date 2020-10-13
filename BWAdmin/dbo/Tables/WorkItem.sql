CREATE TABLE [dbo].[WorkItem] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Description]      NVARCHAR (MAX)   NULL,
    [NettoPrice]       DECIMAL (18, 2)  NOT NULL,
    [MarginPercentage] DECIMAL (18, 2)  NOT NULL,
    [InvoiceId]        UNIQUEIDENTIFIER NULL,
    [OfferId]          UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_WorkItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorkItem_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([Id]),
    CONSTRAINT [FK_WorkItem_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [dbo].[Offers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_WorkItem_InvoiceId]
    ON [dbo].[WorkItem]([InvoiceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_WorkItem_OfferId]
    ON [dbo].[WorkItem]([OfferId] ASC);

