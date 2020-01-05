CREATE TABLE [dbo].[Emails] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Endereco]   VARCHAR (250)    NOT NULL,
    [Descricao]  VARCHAR (250)    NULL,
    [PacienteId] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Emails_ToPacientes] FOREIGN KEY ([PacienteId]) REFERENCES [dbo].[Pacientes] ([Id])
);

