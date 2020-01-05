CREATE TABLE [dbo].[Products] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Product_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Name]        VARCHAR (255)    NOT NULL,
    [Description] VARCHAR (MAX)    NULL,
    [StoreId]     UNIQUEIDENTIFIER NOT NULL,
    [Categories]  VARCHAR (MAX)    NULL,
    [Tags]        VARCHAR (MAX)    NULL,
    [Price]       MONEY            NOT NULL,
    [SKU]         VARCHAR (255)    NULL,
    [Quantity]    INT              NOT NULL,
    [Created]     DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Stores] ([Id])
);

