CREATE TABLE [dbo].[Vat] (
    [VatId]           INT             IDENTITY (1, 1) NOT NULL,
    [year]            INT             NOT NULL,
    [PercentageValue] DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_Vat] PRIMARY KEY CLUSTERED ([VatId] ASC)
);

