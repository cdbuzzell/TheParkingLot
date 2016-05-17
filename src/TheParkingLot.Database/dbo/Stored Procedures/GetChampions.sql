-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 5/3/2016
-- Description:	Get Champions list (top 3 finishers from each season)
-- =============================================
CREATE PROCEDURE [dbo].[GetChampions] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT	Leaderboard.*, Golfer.Avatar
FROM	(SELECT	ROW_NUMBER() OVER (PARTITION BY YEAR([Date]) ORDER BY SUM(ISNULL(Points, 0)) DESC) AS [Rank],
				YEAR([Date]) AS Season, GolferId, Name AS GolferName, Alias,
				SUM(ISNULL(Par3sWon, 0)) AS Par3Wins,
				COUNT(CASE WHEN WonGame=1 THEN 1 ELSE NULL END) AS GameWins,
				AVG(Score - Par) AS AverageToPar,
				SUM(ISNULL(Points, 0)) AS TotalPoints
		FROM	GolferRounds
		GROUP BY YEAR([Date]), GolferId, Name, Alias) Leaderboard
		LEFT OUTER JOIN Golfer ON Leaderboard.GolferId = Golfer.GolferId
WHERE	[Rank] < 4
ORDER BY Season DESC, TotalPoints DESC, GolferName

END