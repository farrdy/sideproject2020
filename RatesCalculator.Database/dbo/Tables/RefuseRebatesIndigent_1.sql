CREATE TABLE [dbo].[RefuseRebatesIndigent] (
    [RefuseRebatesIndigentId] INT             IDENTITY (1, 1) NOT NULL,
    [IncomeLevel]             INT             NOT NULL,
    [MinIncome]               DECIMAL (19, 2) NOT NULL,
    [MaxIncome]               DECIMAL (19, 2) NOT NULL,
    [RebatePercentage]        DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_RefuseRebatesIndigent] PRIMARY KEY CLUSTERED ([RefuseRebatesIndigentId] ASC)
);

