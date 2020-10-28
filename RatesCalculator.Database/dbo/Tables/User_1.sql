CREATE TABLE [dbo].[User] (
    [UserId]    INT          IDENTITY (1, 1) NOT NULL,
    [Firstname] VARCHAR (50) NOT NULL,
    [Lastname]  VARCHAR (50) NOT NULL,
    [roleid]    INT          NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

