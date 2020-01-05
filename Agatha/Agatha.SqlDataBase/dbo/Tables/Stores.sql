﻿CREATE TABLE [dbo].[Stores] (
    [Id]   UNIQUEIDENTIFIER CONSTRAINT [DF_Store1_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Name] VARCHAR (255)    NOT NULL,
    CONSTRAINT [PK_Store1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

