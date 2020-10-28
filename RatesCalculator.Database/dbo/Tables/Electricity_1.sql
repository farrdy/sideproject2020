CREATE TABLE [dbo].[Electricity] (
    [ElectricityId]        INT             IDENTITY (1, 1) NOT NULL,
    [TypeOfElectricity]    VARCHAR (50)    NOT NULL,
    [Block]                INT             NOT NULL,
    [Unit]                 VARCHAR (50)    NOT NULL,
    [ConsumptionMinLevel]  DECIMAL (18, 4) NOT NULL,
    [ConstumptionMaxLevel] DECIMAL (18, 4) NOT NULL,
    [Year]                 INT             NOT NULL,
    [TariffAmount]         DECIMAL (18, 4) NOT NULL,
    [PropposedTariff]      DECIMAL (18, 4) NULL,
    [MinPropertyValue]     DECIMAL (18, 4) NULL,
    [MaxPropertyValue]     DECIMAL (18, 4) NULL,
    CONSTRAINT [PK_Electricity] PRIMARY KEY CLUSTERED ([ElectricityId] ASC)
);

