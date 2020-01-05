CREATE TABLE [dbo].[Address] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_Address_Id] DEFAULT (newid()) NOT NULL,
    [ZipCode]  VARCHAR (50)     NOT NULL,
    [Street]   VARCHAR (255)    NOT NULL,
    [Number]   VARCHAR (50)     NOT NULL,
    [District] VARCHAR (255)    NULL,
    [City]     VARCHAR (255)    NOT NULL,
    [Country]  VARCHAR (255)    NOT NULL,
    [Customer] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Address_Customer] FOREIGN KEY ([Customer]) REFERENCES [dbo].[Customers] ([Id])
);

