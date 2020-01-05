CREATE TABLE [dbo].[Exames] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [descricao]  VARCHAR (500)    NULL,
    [Realizacao] DATE             NULL,
    [Exame]      VARCHAR (MAX)    NOT NULL,
    [PacienteId] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Exames_Pacientes] FOREIGN KEY ([PacienteId]) REFERENCES [dbo].[Pacientes] ([Id])
);

