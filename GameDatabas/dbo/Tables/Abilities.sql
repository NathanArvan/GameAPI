CREATE TABLE [dbo].[Abilities] (
    [Name]        NCHAR (50)  NULL,
    [Description] NCHAR (300) NULL,
    [Target]      INT         NULL,
    [Effect]      INT         NULL,
    [Range]       INT         NULL,
    [Duration]    INT         NULL,
    [Requirments] INT         NULL,
    [AbilityId]   INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([AbilityId] ASC)
);

