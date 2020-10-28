CREATE TABLE [dbo].[PropertyRebates] (
    [PropertyRebatesId] INT             IDENTITY (1, 1) NOT NULL,
    [IncomeLevel]       INT             NOT NULL,
    [MinIncome]         DECIMAL (18, 4) NOT NULL,
    [MaxIncome]         DECIMAL (18, 4) NOT NULL,
    [Year]              INT             NOT NULL,
    [Rebate_Percent]    DECIMAL (18, 4) NOT NULL,
    [PersonTypeId]      INT             NOT NULL,
    CONSTRAINT [PK_PropertyRebates] PRIMARY KEY CLUSTERED ([PropertyRebatesId] ASC),
    CONSTRAINT [FK_PropertyRebates_PersonType] FOREIGN KEY ([PropertyRebatesId]) REFERENCES [dbo].[PersonType] ([PersonTypeId])
);

