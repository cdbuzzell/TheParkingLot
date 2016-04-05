CREATE TABLE [dbo].[RoundWinner] (
    [RoundWinnerId] UNIQUEIDENTIFIER NOT NULL,
    [RoundId]       UNIQUEIDENTIFIER NOT NULL,
    [GolferId]      UNIQUEIDENTIFIER NOT NULL,
    [WinTypeId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_RoundWinner] PRIMARY KEY CLUSTERED ([RoundWinnerId] ASC),
    CONSTRAINT [FK_RoundWinner_Golfer] FOREIGN KEY ([GolferId]) REFERENCES [dbo].[Golfer] ([GolferId]),
    CONSTRAINT [FK_RoundWinner_Round] FOREIGN KEY ([RoundId]) REFERENCES [dbo].[Round] ([RoundId]),
    CONSTRAINT [FK_RoundWinner_WinType] FOREIGN KEY ([WinTypeId]) REFERENCES [dbo].[WinType] ([WinTypeId])
);

