CREATE TABLE [dbo].[Tokens] (
    [TokenId]     INT IDENTITY (1, 1) NOT NULL,
    [MapId]       INT NULL,
    [CharacterId] INT NULL,
    [XPosition]   INT NULL,
    [YPosition]   INT NULL,
    CONSTRAINT [PK_Tokens_TokenId] PRIMARY KEY CLUSTERED ([TokenId] ASC),
    CONSTRAINT [FK_TokenId_MapId] FOREIGN KEY ([MapId]) REFERENCES [dbo].[Maps] ([MapId]) ON DELETE CASCADE ON UPDATE CASCADE
);

