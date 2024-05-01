--------------------------------------
--      Insert  the First Role      --
--------------------------------------

SET IDENTITY_INSERT [Roles] ON;


INSERT INTO [Roles] ([id], [description], [access], [isActive])
VALUES (1, 'Admin', 100, '1');

SET IDENTITY_INSERT [Roles] OFF;


--------------------------------------
--      Insert  the First User      --
--------------------------------------

SET IDENTITY_INSERT [User] ON;

INSERT INTO [User] ([id], [login], [email], [password], [name], [surname], [image], [phone], [isActive], [idRole])
VALUES (1, 'admin', 'admin@admin.com', 'admin', 'adminName', 'adminSurname', 'img', '(00) 90000-0000', '1', '1');

SET IDENTITY_INSERT [User] OFF;


-----------------------------------------------------------------

-- Results --
SELECT * FROM [User]
SELECT * FROM [Roles]