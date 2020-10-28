CREATE TABLE [dbo].[RefuseResidentialType] (
    [RefuseResidentialTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [ResidentialType]         VARCHAR (50) NOT NULL,
    [RefuseFrequency_weekly]  INT          NOT NULL,
    CONSTRAINT [PK_RefuseResidentialType] PRIMARY KEY CLUSTERED ([RefuseResidentialTypeId] ASC)
);

