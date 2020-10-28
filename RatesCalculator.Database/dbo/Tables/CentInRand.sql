CREATE TABLE [dbo].[CentInRand] (
    [CentInRandId] INT             IDENTITY (1, 1) NOT NULL,
    [Year]         INT             NOT NULL,
    [Value]        DECIMAL (18, 5) NOT NULL,
    CONSTRAINT [PK_CentInRand] PRIMARY KEY CLUSTERED ([CentInRandId] ASC)
);

