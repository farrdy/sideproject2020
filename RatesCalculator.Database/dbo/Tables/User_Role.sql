CREATE TABLE [dbo].[User_Role] (
    [UserRoleId] INT IDENTITY (1, 1) NOT NULL,
    [role_id]    INT NOT NULL,
    [user_id]    INT NOT NULL,
    CONSTRAINT [PK_User_Role] PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [FK_User_Role_Role] FOREIGN KEY ([UserRoleId]) REFERENCES [dbo].[Role] ([RoleId]),
    CONSTRAINT [FK_User_Role_User] FOREIGN KEY ([UserRoleId]) REFERENCES [dbo].[User] ([UserId])
);

