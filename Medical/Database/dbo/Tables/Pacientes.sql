CREATE TABLE [dbo].[Pacientes] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_Pacientes_Id] DEFAULT (newid()) NOT NULL,
    [Nome]       VARCHAR (250)    NOT NULL,
    [CPF]        VARCHAR (11)     NOT NULL,
    [Nascimento] DATE             NULL,
    [Sexo]       CHAR (1)         NOT NULL,
    [Cadastro]   DATE             NOT NULL,
    CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

