CREATE TABLE [dbo].[ResidentWasteCollection] (
    [ResidentWasteCollectionId] INT             IDENTITY (1, 1) NOT NULL,
    [Unit]                      VARCHAR (50)    NOT NULL,
    [Year]                      INT             NOT NULL,
    [ChargeAmount]              DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_ResidentWasteCollection] PRIMARY KEY CLUSTERED ([ResidentWasteCollectionId] ASC)
);

