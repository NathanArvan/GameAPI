﻿CREATE TABLE [Character] (
    [CharacterId] int NOT NULL IDENTITY,
    [BattleId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [TokenId] int NULL,
    [CarryingCapacity] decimal(18,2) NOT NULL,
    [HitPoints] int NOT NULL,
    [ManaPoints] int NOT NULL,
    [StaminaPoints] int NOT NULL,
    [Poise] int NOT NULL,
    [Movement] int NOT NULL,
    [MartialVision] int NOT NULL,
    [ArcaneVision] int NOT NULL,
    [Actions] int NOT NULL,
    [Accuracy] int NOT NULL,
    [Evasion] int NOT NULL,
    CONSTRAINT [PK_Character] PRIMARY KEY ([CharacterId]),
    CONSTRAINT [FK_Character_Batttles_BattleId] FOREIGN KEY ([BattleId]) REFERENCES [Batttles] ([BattleId]),
    CONSTRAINT [FK_Character_Tokens_TokenId] FOREIGN KEY ([TokenId]) REFERENCES [Tokens] ([TokenId])
);
