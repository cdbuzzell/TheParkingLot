CREATE TABLE [dbo].[GolferRound] (
    [GolferRoundId] UNIQUEIDENTIFIER NOT NULL,
    [RoundId]       UNIQUEIDENTIFIER NOT NULL,
    [GolferId]      UNIQUEIDENTIFIER NOT NULL,
    [Score]         SMALLINT         NULL,
    [Points]        FLOAT (53)       NULL,
    [Comments]      NVARCHAR (250)   NULL,
    [Par3sWon]      INT              NULL,
    [WonGame]       BIT              CONSTRAINT [DF_GolferRound_WonGame] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_GolferRound] PRIMARY KEY CLUSTERED ([GolferRoundId] ASC),
    CONSTRAINT [FK_GolferRound_Golfer] FOREIGN KEY ([GolferId]) REFERENCES [dbo].[Golfer] ([GolferId]),
    CONSTRAINT [FK_GolferRound_Round] FOREIGN KEY ([RoundId]) REFERENCES [dbo].[Round] ([RoundId])
);





