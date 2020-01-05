CREATE TABLE [dbo].[Contact] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_Contact_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Email]    VARCHAR (255)    NOT NULL,
    [Email2]   VARCHAR (255)    NULL,
    [Phone]    VARCHAR (100)    NOT NULL,
    [Phone2]   VARCHAR (100)    NULL,
    [Language] VARCHAR (255)    NULL,
    [Customer] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contact_Customer] FOREIGN KEY ([Customer]) REFERENCES [dbo].[Customers] ([Id])
);

