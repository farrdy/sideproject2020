CREATE TABLE [dbo].[Water] (
    [WaterId]        INT             IDENTITY (1, 1) NOT NULL,
    [WaterType]      VARCHAR (50)    NOT NULL,
    [WaterStep]      INT             NOT NULL,
    [WaterUnit]      VARCHAR (50)    NOT NULL,
    [Min_value]      DECIMAL (18, 4) NOT NULL,
    [Max_value]      DECIMAL (18, 4) NOT NULL,
    [Year]           INT             NOT NULL,
    [ChargeAmount]   DECIMAL (18, 4) NOT NULL,
    [ProposedTariff] DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_Water] PRIMARY KEY CLUSTERED ([WaterId] ASC)
);

