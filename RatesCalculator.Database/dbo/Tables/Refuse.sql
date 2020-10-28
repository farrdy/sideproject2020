CREATE TABLE [dbo].[Refuse] (
    [RefuseId]           INT             IDENTITY (1, 1) NOT NULL,
    [Unit]               VARCHAR (50)    NOT NULL,
    [Year]               INT             NOT NULL,
    [ChargeAmountIncVat] DECIMAL (19, 4) NOT NULL,
    [ChargeAmountExVat]  DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_Refuse] PRIMARY KEY CLUSTERED ([RefuseId] ASC)
);

