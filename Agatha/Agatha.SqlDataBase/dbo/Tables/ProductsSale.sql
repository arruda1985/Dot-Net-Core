CREATE TABLE [dbo].[ProductsSale] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_ProductsSale_Id] DEFAULT (newid()) NOT NULL,
    [SaleId]    UNIQUEIDENTIFIER NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [UnitPrice] INT              NOT NULL,
    [Quantity]  INT              NOT NULL,
    CONSTRAINT [PK_ProductsSale] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductSale_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_ProductSale_Sale] FOREIGN KEY ([SaleId]) REFERENCES [dbo].[Sales] ([Id])
);

