IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190211182658_InitialCreate')
BEGIN
    CREATE TABLE [reserva] (
        [reservaId] int NOT NULL IDENTITY,
        [nomeDono] nvarchar(max) NULL,
        [nomePet] nvarchar(max) NULL,
        [residencial] nvarchar(max) NULL,
        [celular] nvarchar(max) NULL,
        [email] nvarchar(max) NULL,
        [comentario] nvarchar(max) NULL,
        [fromDate] nvarchar(max) NULL,
        [toDate] nvarchar(max) NULL,
        CONSTRAINT [PK_reserva] PRIMARY KEY ([reservaId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190211182658_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190211182658_InitialCreate', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190212114814_UpdateReserva')
BEGIN
    ALTER TABLE [reserva] ADD [raca] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190212114814_UpdateReserva')
BEGIN
    ALTER TABLE [reserva] ADD [tipoPet] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190212114814_UpdateReserva')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190212114814_UpdateReserva', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190220173014_AlteracaoReserva')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'nomePet');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [nomePet] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190220173014_AlteracaoReserva')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'nomeDono');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [nomeDono] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190220173014_AlteracaoReserva')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'fromDate');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [fromDate] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190220173014_AlteracaoReserva')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'email');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [email] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190220173014_AlteracaoReserva')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'celular');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [celular] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190220173014_AlteracaoReserva')
BEGIN
    ALTER TABLE [reserva] ADD [ticket] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190220173014_AlteracaoReserva')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190220173014_AlteracaoReserva', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190221204200_AtualizacaoReserva')
BEGIN
    ALTER TABLE [reserva] ADD [estado] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190221204200_AtualizacaoReserva')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190221204200_AtualizacaoReserva', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190222152856_AlteracaoTipoPetReserva')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'tipoPet');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [tipoPet] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190222152856_AlteracaoTipoPetReserva')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'raca');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [raca] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190222152856_AlteracaoTipoPetReserva')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190222152856_AlteracaoTipoPetReserva', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190225131224_AlteracaoDateTimeReserva')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'toDate');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [toDate] datetime2 NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190225131224_AlteracaoDateTimeReserva')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[reserva]') AND [c].[name] = N'fromDate');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [reserva] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [reserva] ALTER COLUMN [fromDate] datetime2 NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190225131224_AlteracaoDateTimeReserva')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190225131224_AlteracaoDateTimeReserva', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190227134617_AnimaisAdocaoInitial')
BEGIN
    CREATE TABLE [adocao] (
        [AnimaisAdocaoId] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        [Raca] nvarchar(max) NOT NULL,
        [PathFoto] nvarchar(max) NOT NULL,
        [Detalhes] nvarchar(max) NOT NULL,
        [Adotado] int NOT NULL,
        CONSTRAINT [PK_adocao] PRIMARY KEY ([AnimaisAdocaoId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190227134617_AnimaisAdocaoInitial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190227134617_AnimaisAdocaoInitial', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190326135608_UserLogin')
BEGIN
    CREATE TABLE [user] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [Sobrenome] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [PasswordHash] varbinary(max) NULL,
        [PasswordSalt] varbinary(max) NULL,
        CONSTRAINT [PK_user] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190326135608_UserLogin')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190326135608_UserLogin', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190326200323_ReservaUserId')
BEGIN
    ALTER TABLE [reserva] ADD [userId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190326200323_ReservaUserId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190326200323_ReservaUserId', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190409172039_capa')
BEGIN
    ALTER TABLE [reserva] ADD [idadePet] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190409172039_capa')
BEGIN
    ALTER TABLE [reserva] ADD [portePet] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190409172039_capa')
BEGIN
    CREATE TABLE [capa] (
        [capaId] int NOT NULL IDENTITY,
        [path] nvarchar(max) NOT NULL,
        [titulo] nvarchar(max) NULL,
        [descricao] nvarchar(max) NULL,
        [link] nvarchar(max) NULL,
        [ativo] int NOT NULL,
        CONSTRAINT [PK_capa] PRIMARY KEY ([capaId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190409172039_capa')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190409172039_capa', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190415174631_entidadeApoio')
BEGIN
    CREATE TABLE [apoio] (
        [apoioId] int NOT NULL IDENTITY,
        [name] nvarchar(max) NULL,
        [img] nvarchar(max) NULL,
        [site] nvarchar(max) NULL,
        [ativo] int NOT NULL,
        CONSTRAINT [PK_apoio] PRIMARY KEY ([apoioId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190415174631_entidadeApoio')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190415174631_entidadeApoio', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    EXEC sp_rename N'[adocao].[Nome]', N'NomeAtual', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Adulto] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Castrado] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [CorPelagem] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Dose] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Especie] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Idade] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Microchip] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [NomeAntigo] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Porte] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Quadupla] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [RGA] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Raiva] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Sexo] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [V10] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    ALTER TABLE [adocao] ADD [Vermifugado] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190422155816_atualizacaoAnimaisAdocao')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190422155816_atualizacaoAnimaisAdocao', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190529161024_IntermediadoEAdotanteAdocao')
BEGIN
    EXEC sp_rename N'[adocao].[Quadupla]', N'Quadrupla', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190529161024_IntermediadoEAdotanteAdocao')
BEGIN
    CREATE TABLE [adotante] (
        [AdotanteId] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [DtNascimento] datetime2 NOT NULL,
        [RG] int NOT NULL,
        [CPF] int NOT NULL,
        [CEP] int NOT NULL,
        [Endereco] nvarchar(max) NULL,
        [NroEndereco] int NOT NULL,
        [Bairro] nvarchar(max) NULL,
        [Cidade] nvarchar(max) NULL,
        [UF] nvarchar(max) NULL,
        [Profissao] nvarchar(max) NULL,
        [TelRes] nvarchar(max) NULL,
        [TelCel] nvarchar(max) NULL,
        CONSTRAINT [PK_adotante] PRIMARY KEY ([AdotanteId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190529161024_IntermediadoEAdotanteAdocao')
BEGIN
    CREATE TABLE [intermediador] (
        [IntermediadorAdocaoId] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [Endereco] nvarchar(max) NULL,
        [NroEndereco] int NOT NULL,
        [TelRes] nvarchar(max) NULL,
        [TelCel] nvarchar(max) NULL,
        [Ativo] int NOT NULL,
        CONSTRAINT [PK_intermediador] PRIMARY KEY ([IntermediadorAdocaoId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190529161024_IntermediadoEAdotanteAdocao')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190529161024_IntermediadoEAdotanteAdocao', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190603170432_AtualizacaoUser')
BEGIN
    ALTER TABLE [user] ADD [TelCel] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190603170432_AtualizacaoUser')
BEGIN
    ALTER TABLE [user] ADD [TelRes] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190603170432_AtualizacaoUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190603170432_AtualizacaoUser', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190603180814_AtualizacaoAdotante')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[adotante]') AND [c].[name] = N'RG');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [adotante] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [adotante] ALTER COLUMN [RG] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190603180814_AtualizacaoAdotante')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[adotante]') AND [c].[name] = N'CPF');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [adotante] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [adotante] ALTER COLUMN [CPF] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190603180814_AtualizacaoAdotante')
BEGIN
    ALTER TABLE [adotante] ADD [Complemento] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190603180814_AtualizacaoAdotante')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190603180814_AtualizacaoAdotante', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604141731_AtualizacaoAdotanteCep')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[adotante]') AND [c].[name] = N'CEP');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [adotante] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [adotante] ALTER COLUMN [CEP] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604141731_AtualizacaoAdotanteCep')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190604141731_AtualizacaoAdotanteCep', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604145955_AlteracaoUserParaUsers')
BEGIN
    ALTER TABLE [user] DROP CONSTRAINT [PK_user];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604145955_AlteracaoUserParaUsers')
BEGIN
    EXEC sp_rename N'[user]', N'users';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604145955_AlteracaoUserParaUsers')
BEGIN
    ALTER TABLE [users] ADD CONSTRAINT [PK_users] PRIMARY KEY ([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604145955_AlteracaoUserParaUsers')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190604145955_AlteracaoUserParaUsers', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604180216_AdotanteAnimalAdocao')
BEGIN
    CREATE TABLE [adotanteAnimalAdocao] (
        [AdotanteAnimalAdocaoId] int NOT NULL IDENTITY,
        [AdotanteId] int NOT NULL,
        [AnimaisAdocaoId] int NOT NULL,
        CONSTRAINT [PK_adotanteAnimalAdocao] PRIMARY KEY ([AdotanteAnimalAdocaoId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604180216_AdotanteAnimalAdocao')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190604180216_AdotanteAnimalAdocao', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605174941_AdotanteAnimalEstado')
BEGIN
    ALTER TABLE [adotanteAnimalAdocao] ADD [Estado] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605174941_AdotanteAnimalEstado')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190605174941_AdotanteAnimalEstado', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605183840_Settings')
BEGIN
    CREATE TABLE [settings] (
        [SettingsId] int NOT NULL IDENTITY,
        [Key] nvarchar(max) NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_settings] PRIMARY KEY ([SettingsId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605183840_Settings')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190605183840_Settings', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605184204_SettingsChaveValor')
BEGIN
    EXEC sp_rename N'[settings].[Value]', N'Valor', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605184204_SettingsChaveValor')
BEGIN
    EXEC sp_rename N'[settings].[Key]', N'Chave', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605184204_SettingsChaveValor')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190605184204_SettingsChaveValor', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618162303_RemovidoDetalhesAnimais')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[adocao]') AND [c].[name] = N'Detalhes');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [adocao] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [adocao] DROP COLUMN [Detalhes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618162303_RemovidoDetalhesAnimais')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190618162303_RemovidoDetalhesAnimais', N'2.2.4-servicing-10062');
END;

GO

