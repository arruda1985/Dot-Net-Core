CREATE TABLE [dbo].[ProductImages] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_ProductImages_Id] DEFAULT (newid()) NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NOT NULL,
    [Url]       VARCHAR (150)    NOT NULL,
    CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

