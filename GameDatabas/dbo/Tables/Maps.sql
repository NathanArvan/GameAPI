CREATE TABLE [dbo].[Maps] (
    [MapId]      INT         IDENTITY (1, 1) NOT NULL,
    [CampaignId] INT         NULL,
    [Image]      NCHAR (200) NULL,
    [Length]     INT         NULL,
    [Width]      INT         NULL
);

