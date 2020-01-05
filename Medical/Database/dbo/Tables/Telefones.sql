CREATE TABLE [dbo].[Telefones] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [DDD]        VARCHAR (3)      NOT NULL,
    [Numero]     VARCHAR (10)     NOT NULL,
    [Descricao]  VARCHAR (15)     NULL,
    [PacienteId] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Telefones_ToPacientes] FOREIGN KEY ([PacienteId]) REFERENCES [dbo].[Pacientes] ([Id])
);

