CREATE TABLE [dbo].[RefuseRebates] (
    [RefuseRebatesId]    INT             IDENTITY (1, 1) NOT NULL,
    [Property_Min_Value] DECIMAL (18)    NOT NULL,
    [Property_Max_Value] DECIMAL (18)    NOT NULL,
    [Year]               INT             NOT NULL,
    [RebatePercent]      DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_RefuseRebates] PRIMARY KEY CLUSTERED ([RefuseRebatesId] ASC)
);

