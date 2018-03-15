
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/15/2018 15:35:20
-- Generated from EDMX file: D:\文档\WebAPI\服务端\WebAPI\Models\FormulaModel1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Formual];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CircuitRace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceSet] DROP CONSTRAINT [FK_CircuitRace];
GO
IF OBJECT_ID(N'[dbo].[FK_RaceResultRace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceResultSet] DROP CONSTRAINT [FK_RaceResultRace];
GO
IF OBJECT_ID(N'[dbo].[FK_RaceResultRacer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RaceResultSet] DROP CONSTRAINT [FK_RaceResultRacer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CircuitSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CircuitSet];
GO
IF OBJECT_ID(N'[dbo].[RaceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RaceSet];
GO
IF OBJECT_ID(N'[dbo].[RaceResultSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RaceResultSet];
GO
IF OBJECT_ID(N'[dbo].[RacerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RacerSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CircuitSet'
CREATE TABLE [dbo].[CircuitSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RaceSet'
CREATE TABLE [dbo].[RaceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CircuitId] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Circuit_Id] int  NOT NULL
);
GO

-- Creating table 'RaceResultSet'
CREATE TABLE [dbo].[RaceResultSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RaceId] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [Grid] nvarchar(max)  NOT NULL,
    [Point] nvarchar(max)  NOT NULL,
    [RacerId] nvarchar(max)  NOT NULL,
    [TeamId] nvarchar(max)  NOT NULL,
    [Race_Id] int  NOT NULL,
    [Racer_Id] int  NOT NULL
);
GO

-- Creating table 'RacerSet'
CREATE TABLE [dbo].[RacerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Start] nvarchar(max)  NOT NULL,
    [Win] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CircuitSet'
ALTER TABLE [dbo].[CircuitSet]
ADD CONSTRAINT [PK_CircuitSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RaceSet'
ALTER TABLE [dbo].[RaceSet]
ADD CONSTRAINT [PK_RaceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RaceResultSet'
ALTER TABLE [dbo].[RaceResultSet]
ADD CONSTRAINT [PK_RaceResultSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RacerSet'
ALTER TABLE [dbo].[RacerSet]
ADD CONSTRAINT [PK_RacerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Circuit_Id] in table 'RaceSet'
ALTER TABLE [dbo].[RaceSet]
ADD CONSTRAINT [FK_CircuitRace]
    FOREIGN KEY ([Circuit_Id])
    REFERENCES [dbo].[CircuitSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CircuitRace'
CREATE INDEX [IX_FK_CircuitRace]
ON [dbo].[RaceSet]
    ([Circuit_Id]);
GO

-- Creating foreign key on [Race_Id] in table 'RaceResultSet'
ALTER TABLE [dbo].[RaceResultSet]
ADD CONSTRAINT [FK_RaceResultRace]
    FOREIGN KEY ([Race_Id])
    REFERENCES [dbo].[RaceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RaceResultRace'
CREATE INDEX [IX_FK_RaceResultRace]
ON [dbo].[RaceResultSet]
    ([Race_Id]);
GO

-- Creating foreign key on [Racer_Id] in table 'RaceResultSet'
ALTER TABLE [dbo].[RaceResultSet]
ADD CONSTRAINT [FK_RaceResultRacer]
    FOREIGN KEY ([Racer_Id])
    REFERENCES [dbo].[RacerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RaceResultRacer'
CREATE INDEX [IX_FK_RaceResultRacer]
ON [dbo].[RaceResultSet]
    ([Racer_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------