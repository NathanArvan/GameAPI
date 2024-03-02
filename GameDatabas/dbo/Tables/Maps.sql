CREATE TABLE [dbo].[Maps] (
    [MapId]      INT         IDENTITY (1, 1) NOT NULL,
    [CampaignId] INT         NULL,
    [Image]      NCHAR (200) NULL,
    [Length]     INT         NULL,
    [Width]      INT         NULL,
    CONSTRAINT [PK_Maps_MapId] PRIMARY KEY CLUSTERED ([MapId] ASC),
    CONSTRAINT [FK_MapId_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [dbo].[Campaigns] ([CampaignId]) ON DELETE CASCADE ON UPDATE CASCADE
);

