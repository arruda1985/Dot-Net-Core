CREATE TABLE [dbo].[Customers] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_Table_1_id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [FirstName]  VARCHAR (255)    NOT NULL,
    [MiddleName] VARCHAR (255)    NULL,
    [LastName]   VARCHAR (255)    NOT NULL,
    [StoreId]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Stores] ([Id])
);

