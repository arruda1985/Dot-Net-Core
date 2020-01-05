CREATE TABLE [dbo].[Enderecos] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Logradouro]  VARCHAR (250)    NOT NULL,
    [Numero]      VARCHAR (50)     NOT NULL,
    [Complemento] VARCHAR (250)    NULL,
    [Principal]   BIT              DEFAULT ((0)) NOT NULL,
    [PacienteId]  UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Enderecos_ToPacientes] FOREIGN KEY ([PacienteId]) REFERENCES [dbo].[Pacientes] ([Id])
);

