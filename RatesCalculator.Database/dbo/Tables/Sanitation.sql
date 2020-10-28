CREATE TABLE [dbo].[Sanitation] (
    [SanitationId]   INT             IDENTITY (1, 1) NOT NULL,
    [SanitationType] VARCHAR (50)    NOT NULL,
    [SanitationStep] INT             NOT NULL,
    [SanitationUnit] VARCHAR (50)    NOT NULL,
    [Min_Value]      INT             NOT NULL,
    [Max_Value]      INT             NOT NULL,
    [Year]           INT             NOT NULL,
    [ChargeAmount]   DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_Sanitation] PRIMARY KEY CLUSTERED ([SanitationId] ASC)
);

