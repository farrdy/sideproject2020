CREATE TABLE [dbo].[WaterMeter] (
    [WaterMeterId] INT             IDENTITY (1, 1) NOT NULL,
    [Year]         INT             NOT NULL,
    [ValueExclVat] DECIMAL (18, 4) NOT NULL,
    [ValueWithVat] DECIMAL (18, 4) NOT NULL,
    [PersonTypeId] INT             NOT NULL,
    CONSTRAINT [PK_WaterMeter] PRIMARY KEY CLUSTERED ([WaterMeterId] ASC)
);

