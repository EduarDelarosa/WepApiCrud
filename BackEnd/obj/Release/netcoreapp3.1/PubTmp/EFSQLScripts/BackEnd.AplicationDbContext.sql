IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213033922_Inicial')
BEGIN
    CREATE TABLE [TarjetaCredito] (
        [Id] int NOT NULL IDENTITY,
        [NombreTitular] varchar(100) NOT NULL,
        [NumeroTarjeta] varchar(16) NOT NULL,
        [FechaExpiracion] varchar(5) NOT NULL,
        [Cvv] varchar(3) NOT NULL,
        CONSTRAINT [PK_TarjetaCredito] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220213033922_Inicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220213033922_Inicial', N'3.1.4');
END;

GO

