CREATE TABLE [dbo].[Character] (
    [CharacterId]      INT            NOT NULL,
    [Name]             VARCHAR (100)  NULL,
    [CarryingCapacity] DECIMAL (4, 1) NULL,
    [HitPoints]        INT            NULL,
    [ManaPoints]       INT            NULL,
    [StaminaPoints]    INT            NULL,
    [Poise]            INT            NULL,
    [Movement]         INT            NULL,
    [MartialVision]    INT            NULL,
    [ArcaneVision]     INT            NULL,
    [Actions]          INT            NULL,
    [Accuracy]         INT            NULL,
    [Evasion]          INT            NULL,
    PRIMARY KEY CLUSTERED ([CharacterId] ASC)
);

