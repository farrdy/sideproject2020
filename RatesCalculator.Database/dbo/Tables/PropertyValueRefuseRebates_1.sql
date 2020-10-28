CREATE TABLE [dbo].[PropertyValueRefuseRebates] (
    [PropertyValueRefuseRebatesId] INT             IDENTITY (1, 1) NOT NULL,
    [PropertyMinValue]             DECIMAL (18, 4) NOT NULL,
    [PropertyMaxValue]             DECIMAL (18, 4) NOT NULL,
    [Year]                         INT             NOT NULL,
    [Rebate_Percent]               DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_PropertyValueRefuseRebates] PRIMARY KEY CLUSTERED ([PropertyValueRefuseRebatesId] ASC)
);

