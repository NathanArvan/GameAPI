CREATE TABLE [dbo].[Character] (
    [CharacterId]      INT  IDENTITY(1,1)          NOT NULL,
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
    [TokenId] INT NULL, 
    PRIMARY KEY CLUSTERED  ([CharacterId] ASC),
    CONSTRAINT [FK_CharacterId_TokenId] FOREIGN KEY ([TokenId]) REFERENCES [dbo].[Tokens] ([TokenId]) ON DELETE CASCADE ON UPDATE CASCADE,
);

