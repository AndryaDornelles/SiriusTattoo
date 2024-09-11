/*
Script de implantação para SiriusTattoo

Este código foi gerado por uma ferramenta.
As alterações feitas nesse arquivo poderão causar comportamento incorreto e serão perdidas se
o código for gerado novamente.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SiriusTattoo"
:setvar DefaultFilePrefix "SiriusTattoo"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detecta o modo SQLCMD e desabilita a execução do script se o modo SQLCMD não tiver suporte.
Para reabilitar o script após habilitar o modo SQLCMD, execute o comando a seguir:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'O modo SQLCMD deve ser habilitado para executar esse script com êxito.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'A operação de refatoração Renomear com chave  foi ignorada; o elemento [dbo].[Compras].[ClienteId] (SqlSimpleColumn) não será renomeado para Cliente_Id';


GO
PRINT N'A operação de refatoração Renomear com chave  foi ignorada; o elemento [dbo].[Compras].[TatuagemId] (SqlSimpleColumn) não será renomeado para Tatuagem_Id';


GO
PRINT N'A operação de refatoração Renomear com chave  foi ignorada; o elemento [dbo].[Orcamentos].[PrecoEstimado] (SqlSimpleColumn) não será renomeado para Preco_Estimado';


GO
PRINT N'A operação de refatoração Renomear com chave  foi ignorada; o elemento [dbo].[Orcamentos].[DataSolicitacao] (SqlSimpleColumn) não será renomeado para Data_Solicitacao';


GO
PRINT N'Removendo Restrição Padrão restrição sem nome em [dbo].[Compras]...';


GO
ALTER TABLE [dbo].[Compras] DROP CONSTRAINT [DF__Compras__DataCom__60A75C0F];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Removendo Chave Estrangeira restrição sem nome em [dbo].[Orcamentos]...';


GO
ALTER TABLE [dbo].[Orcamentos] DROP CONSTRAINT [FK__Orcamento__Clien__5441852A];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Removendo Chave Estrangeira restrição sem nome em [dbo].[Orcamentos]...';


GO
ALTER TABLE [dbo].[Orcamentos] DROP CONSTRAINT [FK__Orcamento__Tatua__59FA5E80];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
/*
O tipo para a coluna Data_Solicitacao na tabela [dbo].[Orcamentos] é atualmente  ROWVERSION NOT NULL, mas está sendo alterado para  DATETIMEOFFSET (7) NOT NULL. Não há conversão implícita ou explícita.
*/
GO
PRINT N'Iniciando a recompilação da tabela [dbo].[Orcamentos]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Orcamentos] (
    [Id]               BIGINT             IDENTITY (1, 1) NOT NULL,
    [Cliente_Id]       BIGINT             NOT NULL,
    [Tatuador_Id]      BIGINT             NOT NULL,
    [Descricao]        NVARCHAR (MAX)     NULL,
    [Preco_Estimado]   MONEY              NOT NULL,
    [Data_Solicitacao] DATETIMEOFFSET (7) DEFAULT SYSDATETIMEOFFSET() NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Orcamentos])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Orcamentos] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Orcamentos] ([Id], [Cliente_Id], [Tatuador_Id], [Descricao], [Preco_Estimado], [Data_Solicitacao])
        SELECT   [Id],
                 [Cliente_Id],
                 [Tatuador_Id],
                 CAST ([Descricao] AS NVARCHAR (MAX)),
                 [Preco_Estimado],
                 [Data_Solicitacao]
        FROM     [dbo].[Orcamentos]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Orcamentos] OFF;
    END

DROP TABLE [dbo].[Orcamentos];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Orcamentos]', N'Orcamentos';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Criando Restrição Padrão restrição sem nome em [dbo].[Compras]...';


GO
ALTER TABLE [dbo].[Compras]
    ADD DEFAULT SYSDATETIMEOFFSET() FOR [DataCompra];


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Criando Chave Estrangeira restrição sem nome em [dbo].[Orcamentos]...';


GO
ALTER TABLE [dbo].[Orcamentos] WITH NOCHECK
    ADD FOREIGN KEY ([Cliente_Id]) REFERENCES [dbo].[Clientes] ([Id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Criando Chave Estrangeira restrição sem nome em [dbo].[Orcamentos]...';


GO
ALTER TABLE [dbo].[Orcamentos] WITH NOCHECK
    ADD FOREIGN KEY ([Tatuador_Id]) REFERENCES [dbo].[Tatuadores] ([Id]);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF OBJECT_ID(N'tempdb..#tmpErrors') IS NULL
    CREATE TABLE [#tmpErrors] (
        Error INT
    );

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'A parte transacionada da atualização do banco de dados obteve êxito.'
COMMIT TRANSACTION
END
ELSE PRINT N'A parte transacionada da atualização do banco de dados falhou.'
GO
IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
GO
PRINT N'Verificando os dados existentes em restrições recém-criadas';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.Orcamentos'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Verificando restrição: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Falha na verificação de restrição:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'Erro ao verificar restrições', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Atualização concluída.';


GO
