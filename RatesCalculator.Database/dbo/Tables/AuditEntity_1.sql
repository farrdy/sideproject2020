CREATE TABLE [dbo].[AuditEntity] (
    [AuditEntityId] INT             IDENTITY (1, 1) NOT NULL,
    [Reference]     NVARCHAR (3072) NULL,
    [Timestamp]     DATETIME        NOT NULL,
    [EntityName]    NVARCHAR (128)  NOT NULL,
    [UserName]      NVARCHAR (256)  NOT NULL,
    [Action]        NVARCHAR (64)   NOT NULL,
    [ProjectId]     INT             NULL,
    CONSTRAINT [PK__AuditEnt__FF2CE5B94DAB18EE] PRIMARY KEY CLUSTERED ([AuditEntityId] ASC)
);

