
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/15/2017 15:59:16
-- Generated from EDMX file: D:\Projects\jinhe\EFClasses\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JinHe];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'JH_CategorysSet1'
CREATE TABLE [dbo].[JH_CategorysSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreateTime] nvarchar(max)  NOT NULL,
    [UpdateTime] nvarchar(max)  NOT NULL,
    [DelTime] nvarchar(max)  NOT NULL,
    [Del] bit  NOT NULL
);
GO

-- Creating table 'JH_GoodsSet1'
CREATE TABLE [dbo].[JH_GoodsSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CId] int  NOT NULL,
    [CreateTime] nvarchar(max)  NOT NULL,
    [UpdateTime] nvarchar(max)  NOT NULL,
    [DelTime] nvarchar(max)  NOT NULL,
    [Del] bit  NOT NULL,
    [Category_Id] int  NOT NULL
);
GO

-- Creating table 'JH_ReviewsSet'
CREATE TABLE [dbo].[JH_ReviewsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [GId] int  NOT NULL,
    [CreateTime] nvarchar(max)  NOT NULL,
    [UpdateTime] nvarchar(max)  NOT NULL,
    [DelTime] nvarchar(max)  NOT NULL,
    [Del] bit  NOT NULL,
    [Goods_Id] int  NOT NULL
);
GO

-- Creating table 'JH_DetailSet'
CREATE TABLE [dbo].[JH_DetailSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [MainPic] nvarchar(max)  NOT NULL,
    [GId] nvarchar(max)  NOT NULL,
    [CreateTime] nvarchar(max)  NOT NULL,
    [UpdateTime] nvarchar(max)  NOT NULL,
    [DelTime] nvarchar(max)  NOT NULL,
    [Del] nvarchar(max)  NOT NULL,
    [Goods_Id] int  NOT NULL
);
GO

-- Creating table 'JH_BackGroundUserSet'
CREATE TABLE [dbo].[JH_BackGroundUserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [CreateTime] nvarchar(max)  NOT NULL,
    [UpdateTime] nvarchar(max)  NOT NULL,
    [DelTime] nvarchar(max)  NOT NULL,
    [Del] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'JH_UserInfoSet'
CREATE TABLE [dbo].[JH_UserInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [PassWord] nvarchar(max)  NOT NULL,
    [UnionId] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'JH_CategorysSet1'
ALTER TABLE [dbo].[JH_CategorysSet1]
ADD CONSTRAINT [PK_JH_CategorysSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JH_GoodsSet1'
ALTER TABLE [dbo].[JH_GoodsSet1]
ADD CONSTRAINT [PK_JH_GoodsSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JH_ReviewsSet'
ALTER TABLE [dbo].[JH_ReviewsSet]
ADD CONSTRAINT [PK_JH_ReviewsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JH_DetailSet'
ALTER TABLE [dbo].[JH_DetailSet]
ADD CONSTRAINT [PK_JH_DetailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JH_BackGroundUserSet'
ALTER TABLE [dbo].[JH_BackGroundUserSet]
ADD CONSTRAINT [PK_JH_BackGroundUserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JH_UserInfoSet'
ALTER TABLE [dbo].[JH_UserInfoSet]
ADD CONSTRAINT [PK_JH_UserInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Category_Id] in table 'JH_GoodsSet1'
ALTER TABLE [dbo].[JH_GoodsSet1]
ADD CONSTRAINT [FK_CategoryGoods]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[JH_CategorysSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryGoods'
CREATE INDEX [IX_FK_CategoryGoods]
ON [dbo].[JH_GoodsSet1]
    ([Category_Id]);
GO

-- Creating foreign key on [Goods_Id] in table 'JH_ReviewsSet'
ALTER TABLE [dbo].[JH_ReviewsSet]
ADD CONSTRAINT [FK_GoodsReviews]
    FOREIGN KEY ([Goods_Id])
    REFERENCES [dbo].[JH_GoodsSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsReviews'
CREATE INDEX [IX_FK_GoodsReviews]
ON [dbo].[JH_ReviewsSet]
    ([Goods_Id]);
GO

-- Creating foreign key on [Goods_Id] in table 'JH_DetailSet'
ALTER TABLE [dbo].[JH_DetailSet]
ADD CONSTRAINT [FK_GoodsDetail]
    FOREIGN KEY ([Goods_Id])
    REFERENCES [dbo].[JH_GoodsSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsDetail'
CREATE INDEX [IX_FK_GoodsDetail]
ON [dbo].[JH_DetailSet]
    ([Goods_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------