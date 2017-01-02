
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/30/2016 17:37:24
-- Generated from EDMX file: C:\Users\angelotm\Source\Repos\sistema9001\ProgettoCMA\ClassDiagram.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CMA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UtenteCommessa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommessaSet] DROP CONSTRAINT [FK_UtenteCommessa];
GO
IF OBJECT_ID(N'[dbo].[FK_RuoloUtente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UtenteSet] DROP CONSTRAINT [FK_RuoloUtente];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaAssociazione_Categoria_Fornitore]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Associazione_Categoria_FornitoreSet] DROP CONSTRAINT [FK_CategoriaAssociazione_Categoria_Fornitore];
GO
IF OBJECT_ID(N'[dbo].[FK_FornitoreAssociazione_Categoria_Fornitore]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Associazione_Categoria_FornitoreSet] DROP CONSTRAINT [FK_FornitoreAssociazione_Categoria_Fornitore];
GO
IF OBJECT_ID(N'[dbo].[FK_CommessaRDO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RDOSet] DROP CONSTRAINT [FK_CommessaRDO];
GO
IF OBJECT_ID(N'[dbo].[FK_RDORDO_Composizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RDO_ComposizioneSet] DROP CONSTRAINT [FK_RDORDO_Composizione];
GO
IF OBJECT_ID(N'[dbo].[FK_RDORDA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ODASet] DROP CONSTRAINT [FK_RDORDA];
GO
IF OBJECT_ID(N'[dbo].[FK_RDARDA_Composizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ODA_ComposizioneSet] DROP CONSTRAINT [FK_RDARDA_Composizione];
GO
IF OBJECT_ID(N'[dbo].[FK_RDO_ComposizioneRDA_Composizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ODA_ComposizioneSet] DROP CONSTRAINT [FK_RDO_ComposizioneRDA_Composizione];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaRDO_Composizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RDO_ComposizioneSet] DROP CONSTRAINT [FK_CategoriaRDO_Composizione];
GO
IF OBJECT_ID(N'[dbo].[FK_RDA_ComposizioneOrdine_Composizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ordine_ComposizioneSet] DROP CONSTRAINT [FK_RDA_ComposizioneOrdine_Composizione];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdineOrdine_Composizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ordine_ComposizioneSet] DROP CONSTRAINT [FK_OrdineOrdine_Composizione];
GO
IF OBJECT_ID(N'[dbo].[FK_OffertaOfferta_Composizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offerta_ComposizioneSet] DROP CONSTRAINT [FK_OffertaOfferta_Composizione];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaOfferta_Composizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Offerta_ComposizioneSet] DROP CONSTRAINT [FK_CategoriaOfferta_Composizione];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdineOfferta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffertaSet] DROP CONSTRAINT [FK_OrdineOfferta];
GO
IF OBJECT_ID(N'[dbo].[FK_Associazione_Offerta_ServizioServizio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServizioSet] DROP CONSTRAINT [FK_Associazione_Offerta_ServizioServizio];
GO
IF OBJECT_ID(N'[dbo].[FK_Associazione_Offerta_ServizioOfferta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffertaSet] DROP CONSTRAINT [FK_Associazione_Offerta_ServizioOfferta];
GO
IF OBJECT_ID(N'[dbo].[FK_OffertaMetodo_Pagamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Metodo_PagamentoSet] DROP CONSTRAINT [FK_OffertaMetodo_Pagamento];
GO
IF OBJECT_ID(N'[dbo].[FK_OffertaMetodo_Spedizione]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Metodo_SpedizioneSet] DROP CONSTRAINT [FK_OffertaMetodo_Spedizione];
GO
IF OBJECT_ID(N'[dbo].[FK_AziendaContatto_Azienda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AziendaContatto] DROP CONSTRAINT [FK_AziendaContatto_Azienda];
GO
IF OBJECT_ID(N'[dbo].[FK_AziendaContatto_Contatto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AziendaContatto] DROP CONSTRAINT [FK_AziendaContatto_Contatto];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteCommessa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommessaSet] DROP CONSTRAINT [FK_ClienteCommessa];
GO
IF OBJECT_ID(N'[dbo].[FK_Fornitore_inherits_Azienda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AziendaSet_Fornitore] DROP CONSTRAINT [FK_Fornitore_inherits_Azienda];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_inherits_Azienda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AziendaSet_Cliente] DROP CONSTRAINT [FK_Cliente_inherits_Azienda];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UtenteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UtenteSet];
GO
IF OBJECT_ID(N'[dbo].[CommessaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommessaSet];
GO
IF OBJECT_ID(N'[dbo].[RuoloSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RuoloSet];
GO
IF OBJECT_ID(N'[dbo].[RDOSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RDOSet];
GO
IF OBJECT_ID(N'[dbo].[RDO_ComposizioneSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RDO_ComposizioneSet];
GO
IF OBJECT_ID(N'[dbo].[ODA_ComposizioneSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ODA_ComposizioneSet];
GO
IF OBJECT_ID(N'[dbo].[ODASet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ODASet];
GO
IF OBJECT_ID(N'[dbo].[CategoriaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaSet];
GO
IF OBJECT_ID(N'[dbo].[Associazione_Categoria_FornitoreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Associazione_Categoria_FornitoreSet];
GO
IF OBJECT_ID(N'[dbo].[Ordine_ComposizioneSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ordine_ComposizioneSet];
GO
IF OBJECT_ID(N'[dbo].[OrdineSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdineSet];
GO
IF OBJECT_ID(N'[dbo].[OffertaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OffertaSet];
GO
IF OBJECT_ID(N'[dbo].[Offerta_ComposizioneSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Offerta_ComposizioneSet];
GO
IF OBJECT_ID(N'[dbo].[Associazione_Offerta_ServizioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Associazione_Offerta_ServizioSet];
GO
IF OBJECT_ID(N'[dbo].[Metodo_PagamentoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Metodo_PagamentoSet];
GO
IF OBJECT_ID(N'[dbo].[Metodo_SpedizioneSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Metodo_SpedizioneSet];
GO
IF OBJECT_ID(N'[dbo].[ServizioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServizioSet];
GO
IF OBJECT_ID(N'[dbo].[ContattoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContattoSet];
GO
IF OBJECT_ID(N'[dbo].[AziendaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AziendaSet];
GO
IF OBJECT_ID(N'[dbo].[AziendaSet_Fornitore]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AziendaSet_Fornitore];
GO
IF OBJECT_ID(N'[dbo].[AziendaSet_Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AziendaSet_Cliente];
GO
IF OBJECT_ID(N'[dbo].[AziendaContatto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AziendaContatto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UtenteSet'
CREATE TABLE [dbo].[UtenteSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Cognome] nvarchar(max)  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Ruolo_ID] int  NOT NULL
);
GO

-- Creating table 'CommessaSet'
CREATE TABLE [dbo].[CommessaSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Codice] nvarchar(max)  NOT NULL,
    [Creazione] nvarchar(max)  NOT NULL,
    [Chiusura] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [Utente_ID] int  NOT NULL,
    [Cliente_ID] int  NOT NULL
);
GO

-- Creating table 'RuoloSet'
CREATE TABLE [dbo].[RuoloSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RDOSet'
CREATE TABLE [dbo].[RDOSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Commessa_ID] int  NOT NULL
);
GO

-- Creating table 'RDO_ComposizioneSet'
CREATE TABLE [dbo].[RDO_ComposizioneSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RDO_Id] int  NOT NULL,
    [Categoria_Id] int  NOT NULL
);
GO

-- Creating table 'ODA_ComposizioneSet'
CREATE TABLE [dbo].[ODA_ComposizioneSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ODA_Id] int  NOT NULL,
    [RDO_Composizione_Id] int  NOT NULL
);
GO

-- Creating table 'ODASet'
CREATE TABLE [dbo].[ODASet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RDO_Id] int  NOT NULL
);
GO

-- Creating table 'CategoriaSet'
CREATE TABLE [dbo].[CategoriaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Associazione_Categoria_FornitoreSet'
CREATE TABLE [dbo].[Associazione_Categoria_FornitoreSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Categoria_Id] int  NOT NULL,
    [Fornitore_ID] int  NOT NULL
);
GO

-- Creating table 'Ordine_ComposizioneSet'
CREATE TABLE [dbo].[Ordine_ComposizioneSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RDA_Composizione_Id] int  NOT NULL,
    [Ordine_Id] int  NOT NULL
);
GO

-- Creating table 'OrdineSet'
CREATE TABLE [dbo].[OrdineSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'OffertaSet'
CREATE TABLE [dbo].[OffertaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ordine_Id] int  NOT NULL,
    [Associazione_Offerta_Servizio_Id] int  NOT NULL
);
GO

-- Creating table 'Offerta_ComposizioneSet'
CREATE TABLE [dbo].[Offerta_ComposizioneSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Offerta_Id] int  NOT NULL,
    [Categoria_Id] int  NOT NULL
);
GO

-- Creating table 'Associazione_Offerta_ServizioSet'
CREATE TABLE [dbo].[Associazione_Offerta_ServizioSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Metodo_PagamentoSet'
CREATE TABLE [dbo].[Metodo_PagamentoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Offerta_Id] int  NOT NULL
);
GO

-- Creating table 'Metodo_SpedizioneSet'
CREATE TABLE [dbo].[Metodo_SpedizioneSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Offerta_Id] int  NOT NULL
);
GO

-- Creating table 'ServizioSet'
CREATE TABLE [dbo].[ServizioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Associazione_Offerta_Servizio_Id] int  NOT NULL
);
GO

-- Creating table 'ContattoSet'
CREATE TABLE [dbo].[ContattoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Cognome] nvarchar(max)  NOT NULL,
    [Descrizione] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AziendaSet'
CREATE TABLE [dbo].[AziendaSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Ragione] nvarchar(max)  NOT NULL,
    [Indirizzo_Civico] nvarchar(max)  NOT NULL,
    [Indirizzo_Provincia] nvarchar(max)  NOT NULL,
    [Indirizzo_Cap] nvarchar(max)  NULL,
    [Indirizzo_Citta] nvarchar(max)  NULL,
    [Indirizzo_Via] nvarchar(max)  NOT NULL,
    [Indirizzo_Nazione] nvarchar(max)  NOT NULL,
    [Piva] nvarchar(max)  NULL,
    [CodFisc] nvarchar(max)  NULL,
    [Telefono] nvarchar(max)  NULL,
    [Mail] nvarchar(max)  NULL,
    [Note] nvarchar(max)  NULL,
    [Creazione] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AziendaSet_Fornitore'
CREATE TABLE [dbo].[AziendaSet_Fornitore] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'AziendaSet_Cliente'
CREATE TABLE [dbo].[AziendaSet_Cliente] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'AziendaContatto'
CREATE TABLE [dbo].[AziendaContatto] (
    [Azienda_ID] int  NOT NULL,
    [Contatto_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'UtenteSet'
ALTER TABLE [dbo].[UtenteSet]
ADD CONSTRAINT [PK_UtenteSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CommessaSet'
ALTER TABLE [dbo].[CommessaSet]
ADD CONSTRAINT [PK_CommessaSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RuoloSet'
ALTER TABLE [dbo].[RuoloSet]
ADD CONSTRAINT [PK_RuoloSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'RDOSet'
ALTER TABLE [dbo].[RDOSet]
ADD CONSTRAINT [PK_RDOSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RDO_ComposizioneSet'
ALTER TABLE [dbo].[RDO_ComposizioneSet]
ADD CONSTRAINT [PK_RDO_ComposizioneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ODA_ComposizioneSet'
ALTER TABLE [dbo].[ODA_ComposizioneSet]
ADD CONSTRAINT [PK_ODA_ComposizioneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ODASet'
ALTER TABLE [dbo].[ODASet]
ADD CONSTRAINT [PK_ODASet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriaSet'
ALTER TABLE [dbo].[CategoriaSet]
ADD CONSTRAINT [PK_CategoriaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Associazione_Categoria_FornitoreSet'
ALTER TABLE [dbo].[Associazione_Categoria_FornitoreSet]
ADD CONSTRAINT [PK_Associazione_Categoria_FornitoreSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ordine_ComposizioneSet'
ALTER TABLE [dbo].[Ordine_ComposizioneSet]
ADD CONSTRAINT [PK_Ordine_ComposizioneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrdineSet'
ALTER TABLE [dbo].[OrdineSet]
ADD CONSTRAINT [PK_OrdineSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OffertaSet'
ALTER TABLE [dbo].[OffertaSet]
ADD CONSTRAINT [PK_OffertaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Offerta_ComposizioneSet'
ALTER TABLE [dbo].[Offerta_ComposizioneSet]
ADD CONSTRAINT [PK_Offerta_ComposizioneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Associazione_Offerta_ServizioSet'
ALTER TABLE [dbo].[Associazione_Offerta_ServizioSet]
ADD CONSTRAINT [PK_Associazione_Offerta_ServizioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Metodo_PagamentoSet'
ALTER TABLE [dbo].[Metodo_PagamentoSet]
ADD CONSTRAINT [PK_Metodo_PagamentoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Metodo_SpedizioneSet'
ALTER TABLE [dbo].[Metodo_SpedizioneSet]
ADD CONSTRAINT [PK_Metodo_SpedizioneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServizioSet'
ALTER TABLE [dbo].[ServizioSet]
ADD CONSTRAINT [PK_ServizioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContattoSet'
ALTER TABLE [dbo].[ContattoSet]
ADD CONSTRAINT [PK_ContattoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'AziendaSet'
ALTER TABLE [dbo].[AziendaSet]
ADD CONSTRAINT [PK_AziendaSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AziendaSet_Fornitore'
ALTER TABLE [dbo].[AziendaSet_Fornitore]
ADD CONSTRAINT [PK_AziendaSet_Fornitore]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AziendaSet_Cliente'
ALTER TABLE [dbo].[AziendaSet_Cliente]
ADD CONSTRAINT [PK_AziendaSet_Cliente]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Azienda_ID], [Contatto_Id] in table 'AziendaContatto'
ALTER TABLE [dbo].[AziendaContatto]
ADD CONSTRAINT [PK_AziendaContatto]
    PRIMARY KEY CLUSTERED ([Azienda_ID], [Contatto_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Utente_ID] in table 'CommessaSet'
ALTER TABLE [dbo].[CommessaSet]
ADD CONSTRAINT [FK_UtenteCommessa]
    FOREIGN KEY ([Utente_ID])
    REFERENCES [dbo].[UtenteSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UtenteCommessa'
CREATE INDEX [IX_FK_UtenteCommessa]
ON [dbo].[CommessaSet]
    ([Utente_ID]);
GO

-- Creating foreign key on [Ruolo_ID] in table 'UtenteSet'
ALTER TABLE [dbo].[UtenteSet]
ADD CONSTRAINT [FK_RuoloUtente]
    FOREIGN KEY ([Ruolo_ID])
    REFERENCES [dbo].[RuoloSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RuoloUtente'
CREATE INDEX [IX_FK_RuoloUtente]
ON [dbo].[UtenteSet]
    ([Ruolo_ID]);
GO

-- Creating foreign key on [Categoria_Id] in table 'Associazione_Categoria_FornitoreSet'
ALTER TABLE [dbo].[Associazione_Categoria_FornitoreSet]
ADD CONSTRAINT [FK_CategoriaAssociazione_Categoria_Fornitore]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[CategoriaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaAssociazione_Categoria_Fornitore'
CREATE INDEX [IX_FK_CategoriaAssociazione_Categoria_Fornitore]
ON [dbo].[Associazione_Categoria_FornitoreSet]
    ([Categoria_Id]);
GO

-- Creating foreign key on [Fornitore_ID] in table 'Associazione_Categoria_FornitoreSet'
ALTER TABLE [dbo].[Associazione_Categoria_FornitoreSet]
ADD CONSTRAINT [FK_FornitoreAssociazione_Categoria_Fornitore]
    FOREIGN KEY ([Fornitore_ID])
    REFERENCES [dbo].[AziendaSet_Fornitore]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FornitoreAssociazione_Categoria_Fornitore'
CREATE INDEX [IX_FK_FornitoreAssociazione_Categoria_Fornitore]
ON [dbo].[Associazione_Categoria_FornitoreSet]
    ([Fornitore_ID]);
GO

-- Creating foreign key on [Commessa_ID] in table 'RDOSet'
ALTER TABLE [dbo].[RDOSet]
ADD CONSTRAINT [FK_CommessaRDO]
    FOREIGN KEY ([Commessa_ID])
    REFERENCES [dbo].[CommessaSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommessaRDO'
CREATE INDEX [IX_FK_CommessaRDO]
ON [dbo].[RDOSet]
    ([Commessa_ID]);
GO

-- Creating foreign key on [RDO_Id] in table 'RDO_ComposizioneSet'
ALTER TABLE [dbo].[RDO_ComposizioneSet]
ADD CONSTRAINT [FK_RDORDO_Composizione]
    FOREIGN KEY ([RDO_Id])
    REFERENCES [dbo].[RDOSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RDORDO_Composizione'
CREATE INDEX [IX_FK_RDORDO_Composizione]
ON [dbo].[RDO_ComposizioneSet]
    ([RDO_Id]);
GO

-- Creating foreign key on [RDO_Id] in table 'ODASet'
ALTER TABLE [dbo].[ODASet]
ADD CONSTRAINT [FK_RDORDA]
    FOREIGN KEY ([RDO_Id])
    REFERENCES [dbo].[RDOSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RDORDA'
CREATE INDEX [IX_FK_RDORDA]
ON [dbo].[ODASet]
    ([RDO_Id]);
GO

-- Creating foreign key on [ODA_Id] in table 'ODA_ComposizioneSet'
ALTER TABLE [dbo].[ODA_ComposizioneSet]
ADD CONSTRAINT [FK_RDARDA_Composizione]
    FOREIGN KEY ([ODA_Id])
    REFERENCES [dbo].[ODASet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RDARDA_Composizione'
CREATE INDEX [IX_FK_RDARDA_Composizione]
ON [dbo].[ODA_ComposizioneSet]
    ([ODA_Id]);
GO

-- Creating foreign key on [RDO_Composizione_Id] in table 'ODA_ComposizioneSet'
ALTER TABLE [dbo].[ODA_ComposizioneSet]
ADD CONSTRAINT [FK_RDO_ComposizioneRDA_Composizione]
    FOREIGN KEY ([RDO_Composizione_Id])
    REFERENCES [dbo].[RDO_ComposizioneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RDO_ComposizioneRDA_Composizione'
CREATE INDEX [IX_FK_RDO_ComposizioneRDA_Composizione]
ON [dbo].[ODA_ComposizioneSet]
    ([RDO_Composizione_Id]);
GO

-- Creating foreign key on [Categoria_Id] in table 'RDO_ComposizioneSet'
ALTER TABLE [dbo].[RDO_ComposizioneSet]
ADD CONSTRAINT [FK_CategoriaRDO_Composizione]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[CategoriaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaRDO_Composizione'
CREATE INDEX [IX_FK_CategoriaRDO_Composizione]
ON [dbo].[RDO_ComposizioneSet]
    ([Categoria_Id]);
GO

-- Creating foreign key on [RDA_Composizione_Id] in table 'Ordine_ComposizioneSet'
ALTER TABLE [dbo].[Ordine_ComposizioneSet]
ADD CONSTRAINT [FK_RDA_ComposizioneOrdine_Composizione]
    FOREIGN KEY ([RDA_Composizione_Id])
    REFERENCES [dbo].[ODA_ComposizioneSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RDA_ComposizioneOrdine_Composizione'
CREATE INDEX [IX_FK_RDA_ComposizioneOrdine_Composizione]
ON [dbo].[Ordine_ComposizioneSet]
    ([RDA_Composizione_Id]);
GO

-- Creating foreign key on [Ordine_Id] in table 'Ordine_ComposizioneSet'
ALTER TABLE [dbo].[Ordine_ComposizioneSet]
ADD CONSTRAINT [FK_OrdineOrdine_Composizione]
    FOREIGN KEY ([Ordine_Id])
    REFERENCES [dbo].[OrdineSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdineOrdine_Composizione'
CREATE INDEX [IX_FK_OrdineOrdine_Composizione]
ON [dbo].[Ordine_ComposizioneSet]
    ([Ordine_Id]);
GO

-- Creating foreign key on [Offerta_Id] in table 'Offerta_ComposizioneSet'
ALTER TABLE [dbo].[Offerta_ComposizioneSet]
ADD CONSTRAINT [FK_OffertaOfferta_Composizione]
    FOREIGN KEY ([Offerta_Id])
    REFERENCES [dbo].[OffertaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OffertaOfferta_Composizione'
CREATE INDEX [IX_FK_OffertaOfferta_Composizione]
ON [dbo].[Offerta_ComposizioneSet]
    ([Offerta_Id]);
GO

-- Creating foreign key on [Categoria_Id] in table 'Offerta_ComposizioneSet'
ALTER TABLE [dbo].[Offerta_ComposizioneSet]
ADD CONSTRAINT [FK_CategoriaOfferta_Composizione]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[CategoriaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaOfferta_Composizione'
CREATE INDEX [IX_FK_CategoriaOfferta_Composizione]
ON [dbo].[Offerta_ComposizioneSet]
    ([Categoria_Id]);
GO

-- Creating foreign key on [Ordine_Id] in table 'OffertaSet'
ALTER TABLE [dbo].[OffertaSet]
ADD CONSTRAINT [FK_OrdineOfferta]
    FOREIGN KEY ([Ordine_Id])
    REFERENCES [dbo].[OrdineSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdineOfferta'
CREATE INDEX [IX_FK_OrdineOfferta]
ON [dbo].[OffertaSet]
    ([Ordine_Id]);
GO

-- Creating foreign key on [Associazione_Offerta_Servizio_Id] in table 'ServizioSet'
ALTER TABLE [dbo].[ServizioSet]
ADD CONSTRAINT [FK_Associazione_Offerta_ServizioServizio]
    FOREIGN KEY ([Associazione_Offerta_Servizio_Id])
    REFERENCES [dbo].[Associazione_Offerta_ServizioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Associazione_Offerta_ServizioServizio'
CREATE INDEX [IX_FK_Associazione_Offerta_ServizioServizio]
ON [dbo].[ServizioSet]
    ([Associazione_Offerta_Servizio_Id]);
GO

-- Creating foreign key on [Associazione_Offerta_Servizio_Id] in table 'OffertaSet'
ALTER TABLE [dbo].[OffertaSet]
ADD CONSTRAINT [FK_Associazione_Offerta_ServizioOfferta]
    FOREIGN KEY ([Associazione_Offerta_Servizio_Id])
    REFERENCES [dbo].[Associazione_Offerta_ServizioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Associazione_Offerta_ServizioOfferta'
CREATE INDEX [IX_FK_Associazione_Offerta_ServizioOfferta]
ON [dbo].[OffertaSet]
    ([Associazione_Offerta_Servizio_Id]);
GO

-- Creating foreign key on [Offerta_Id] in table 'Metodo_PagamentoSet'
ALTER TABLE [dbo].[Metodo_PagamentoSet]
ADD CONSTRAINT [FK_OffertaMetodo_Pagamento]
    FOREIGN KEY ([Offerta_Id])
    REFERENCES [dbo].[OffertaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OffertaMetodo_Pagamento'
CREATE INDEX [IX_FK_OffertaMetodo_Pagamento]
ON [dbo].[Metodo_PagamentoSet]
    ([Offerta_Id]);
GO

-- Creating foreign key on [Offerta_Id] in table 'Metodo_SpedizioneSet'
ALTER TABLE [dbo].[Metodo_SpedizioneSet]
ADD CONSTRAINT [FK_OffertaMetodo_Spedizione]
    FOREIGN KEY ([Offerta_Id])
    REFERENCES [dbo].[OffertaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OffertaMetodo_Spedizione'
CREATE INDEX [IX_FK_OffertaMetodo_Spedizione]
ON [dbo].[Metodo_SpedizioneSet]
    ([Offerta_Id]);
GO

-- Creating foreign key on [Azienda_ID] in table 'AziendaContatto'
ALTER TABLE [dbo].[AziendaContatto]
ADD CONSTRAINT [FK_AziendaContatto_Azienda]
    FOREIGN KEY ([Azienda_ID])
    REFERENCES [dbo].[AziendaSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Contatto_Id] in table 'AziendaContatto'
ALTER TABLE [dbo].[AziendaContatto]
ADD CONSTRAINT [FK_AziendaContatto_Contatto]
    FOREIGN KEY ([Contatto_Id])
    REFERENCES [dbo].[ContattoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AziendaContatto_Contatto'
CREATE INDEX [IX_FK_AziendaContatto_Contatto]
ON [dbo].[AziendaContatto]
    ([Contatto_Id]);
GO

-- Creating foreign key on [Cliente_ID] in table 'CommessaSet'
ALTER TABLE [dbo].[CommessaSet]
ADD CONSTRAINT [FK_ClienteCommessa]
    FOREIGN KEY ([Cliente_ID])
    REFERENCES [dbo].[AziendaSet_Cliente]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteCommessa'
CREATE INDEX [IX_FK_ClienteCommessa]
ON [dbo].[CommessaSet]
    ([Cliente_ID]);
GO

-- Creating foreign key on [ID] in table 'AziendaSet_Fornitore'
ALTER TABLE [dbo].[AziendaSet_Fornitore]
ADD CONSTRAINT [FK_Fornitore_inherits_Azienda]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[AziendaSet]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'AziendaSet_Cliente'
ALTER TABLE [dbo].[AziendaSet_Cliente]
ADD CONSTRAINT [FK_Cliente_inherits_Azienda]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[AziendaSet]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------