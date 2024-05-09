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

CREATE TABLE [Category] (
    [id] int NOT NULL IDENTITY,
    [code] varchar(255) NULL,
    [description] varchar(255) NULL,
    [isActive] bit NULL,
    CONSTRAINT [PK__Category__3213E83F89EE8816] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Roles] (
    [id] int NOT NULL IDENTITY,
    [description] varchar(255) NULL,
    [access] int NOT NULL,
    [isActive] bit NULL,
    CONSTRAINT [PK__Roles__3213E83FD2A0C535] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Product] (
    [id] int NOT NULL IDENTITY,
    [code] varchar(255) NULL,
    [description] varchar(255) NULL,
    [price] decimal(10,2) NULL,
    [hasStock] bit NULL,
    [isActive] bit NULL,
    [idCategory] int NULL,
    CONSTRAINT [PK__Product__3213E83FE8651353] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([idCategory]) REFERENCES [Category] ([id])
);
GO

CREATE TABLE [User] (
    [id] int NOT NULL IDENTITY,
    [login] varchar(255) NULL,
    [email] varchar(255) NULL,
    [password] varchar(255) NULL,
    [name] varchar(255) NULL,
    [surname] varchar(255) NULL,
    [image] varchar(1000) NULL,
    [phone] varchar(255) NULL,
    [isActive] bit NULL,
    [idRole] int NULL,
    CONSTRAINT [PK__User__3213E83F93B1F8BB] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([idRole]) REFERENCES [Roles] ([id])
);
GO

CREATE TABLE [Address] (
    [id] int NOT NULL IDENTITY,
    [city] varchar(255) NULL,
    [state] varchar(255) NULL,
    [country] varchar(255) NULL,
    [postalCode] varchar(255) NULL,
    [isActive] bit NULL,
    [idUser] int NULL,
    CONSTRAINT [PK__Address__3213E83F9BF396CD] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Addresses_Users] FOREIGN KEY ([idUser]) REFERENCES [User] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Cart] (
    [id] int NOT NULL IDENTITY,
    [totalValue] decimal(10,2) NULL,
    [isActive] bit NULL,
    [idUser] int NULL,
    CONSTRAINT [PK__Cart__3213E83FC0727DE4] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Carts_Users] FOREIGN KEY ([idUser]) REFERENCES [User] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Order] (
    [id] int NOT NULL IDENTITY,
    [status] int NULL,
    [orderDate] datetime NULL,
    [paymentMethod] int NULL,
    [totalValue] decimal(10,2) NULL,
    [idUser] int NULL,
    CONSTRAINT [PK__Order__3213E83F9A3D929F] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([idUser]) REFERENCES [User] ([id])
);
GO

CREATE TABLE [CartDetail] (
    [id] int NOT NULL IDENTITY,
    [quantity] int NULL,
    [price] decimal(10,2) NULL,
    [idCart] int NULL,
    [idProduct] int NULL,
    CONSTRAINT [PK__CartDeta__3213E83F29BC9089] PRIMARY KEY ([id]),
    CONSTRAINT [FK_CartDetails_Carts] FOREIGN KEY ([idCart]) REFERENCES [Cart] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CartDetails_Products] FOREIGN KEY ([idProduct]) REFERENCES [Product] ([id])
);
GO

CREATE TABLE [OrderDetail] (
    [id] int NOT NULL IDENTITY,
    [quantity] int NULL,
    [price] decimal(10,2) NULL,
    [idOrder] int NULL,
    [idProduct] int NULL,
    [idAddress] int NULL,
    CONSTRAINT [PK__OrderDet__3213E83FD22EA4EA] PRIMARY KEY ([id]),
    CONSTRAINT [FK_OrderDetails_Addresses] FOREIGN KEY ([idAddress]) REFERENCES [Address] ([id]),
    CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY ([idOrder]) REFERENCES [Order] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY ([idProduct]) REFERENCES [Product] ([id])
);
GO

CREATE INDEX [IX_Address_idUser] ON [Address] ([idUser]);
GO

CREATE INDEX [IX_Cart_idUser] ON [Cart] ([idUser]);
GO

CREATE INDEX [IX_CartDetail_idCart] ON [CartDetail] ([idCart]);
GO

CREATE INDEX [IX_CartDetail_idProduct] ON [CartDetail] ([idProduct]);
GO

CREATE INDEX [IX_Order_idUser] ON [Order] ([idUser]);
GO

CREATE INDEX [IX_OrderDetail_idAddress] ON [OrderDetail] ([idAddress]);
GO

CREATE INDEX [IX_OrderDetail_idOrder] ON [OrderDetail] ([idOrder]);
GO

CREATE INDEX [IX_OrderDetail_idProduct] ON [OrderDetail] ([idProduct]);
GO

CREATE INDEX [IX_Product_idCategory] ON [Product] ([idCategory]);
GO

CREATE INDEX [IX_User_idRole] ON [User] ([idRole]);
GO

CREATE UNIQUE INDEX [UQ__User__7838F272EEAE83E7] ON [User] ([login]) WHERE [login] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240509101759_Changing_Role_Property', N'8.0.4');
GO

COMMIT;
GO

