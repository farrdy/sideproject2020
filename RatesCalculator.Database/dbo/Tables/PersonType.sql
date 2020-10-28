CREATE TABLE [dbo].[PersonType] (
    [PersonTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PersonType] PRIMARY KEY CLUSTERED ([PersonTypeId] ASC)
);

