IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210615195841_init')
BEGIN
    CREATE TABLE [Dishes] (
        [Id] int NOT NULL IDENTITY,
        [NameOfDish] nvarchar(50) NOT NULL,
        [Category] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Dishes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210615195841_init')
BEGIN
    CREATE TABLE [ShoppingCarts] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [DishId] int NOT NULL,
        [UserId] int NOT NULL,
        [NumberOfItems] int NOT NULL,
        [Price] float NOT NULL,
        [PriceOfOneDish] float NOT NULL,
        CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210615195841_init')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [UserName] nvarchar(50) NOT NULL,
        [Password] nvarchar(50) NOT NULL,
        [Salt] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(50) NOT NULL,
        [IsAdmin] bit NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210615195841_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210615195841_init', N'5.0.6');
END;
GO

COMMIT;
GO

