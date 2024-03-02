CREATE TABLE [dbo].[Classes] (
    [ClassId]      INT        IDENTITY (1, 1) NOT NULL,
    [Name]         NCHAR (50) NULL,
    [Requirements] INT        NULL,
    CONSTRAINT [PK_Classes_ClassId] PRIMARY KEY CLUSTERED ([ClassId] ASC)
);

