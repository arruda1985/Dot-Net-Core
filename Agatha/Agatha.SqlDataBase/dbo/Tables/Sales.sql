CREATE TABLE [dbo].[Sales] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_Sale_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [AddressId]  UNIQUEIDENTIFIER NOT NULL,
    [Created]    DATETIME2 (7)    NOT NULL,
    [Status]     VARCHAR (15)     NULL,
    CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sale_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    CONSTRAINT [FK_Sale_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);

