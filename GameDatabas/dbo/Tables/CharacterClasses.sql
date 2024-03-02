CREATE TABLE [dbo].[CharacterClasses] (
    [CharacterClassId] INT IDENTITY (1, 1) NOT NULL,
    [CharacterId]      INT NULL,
    [ClassId]          INT NULL,
    CONSTRAINT [PK_CharacterClasses_CharacterClassId] PRIMARY KEY CLUSTERED ([CharacterClassId] ASC),
    CONSTRAINT [FK_Character_CharacterId] FOREIGN KEY ([CharacterId]) REFERENCES [dbo].[Character] ([CharacterId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Classes_ClassesId] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Classes] ([ClassId]) ON DELETE CASCADE ON UPDATE CASCADE
);

