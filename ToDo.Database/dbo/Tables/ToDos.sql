CREATE TABLE [dbo].[ToDos] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (500) NOT NULL,
    [IsComplete]  BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

