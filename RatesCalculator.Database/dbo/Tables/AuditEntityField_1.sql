CREATE TABLE [dbo].[AuditEntityField] (
    [AuditEntityFieldId] INT            IDENTITY (1, 1) NOT NULL,
    [AuditEntityId]      INT            NOT NULL,
    [FieldName]          NVARCHAR (50)  NOT NULL,
    [OldValue]           NVARCHAR (MAX) NULL,
    [NewValue]           NVARCHAR (MAX) NULL,
    [Timestamp]          DATETIME2 (7)  NOT NULL,
    PRIMARY KEY CLUSTERED ([AuditEntityFieldId] ASC),
    CONSTRAINT [FK_AuditEntityField_ToAuditEntity] FOREIGN KEY ([AuditEntityId]) REFERENCES [dbo].[AuditEntity] ([AuditEntityId])
);

