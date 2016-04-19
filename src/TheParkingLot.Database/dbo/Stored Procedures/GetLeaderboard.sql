-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 3/16/2016
-- Description:	Get Leaderboard/points list
-- =============================================
CREATE PROCEDURE [dbo].[GetLeaderboard] 
	@Season int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT	ROW_NUMBER() OVER (ORDER BY SUM(ISNULL(Points, 0)) DESC) AS Rank, 
		GolferId, Name AS GolferName, Alias, @Season AS Season,
		SUM(ISNULL(Par3sWon, 0)) AS Par3Wins,
		COUNT(CASE WHEN WonGame=1 THEN 1 ELSE NULL END) AS GameWins,
		AVG(Score - Par) AS AverageToPar,
		SUM(ISNULL(Points, 0)) AS TotalPoints,
		(SUM(ISNULL(Points, 0)) - 
			(SELECT	TOP 1 SUM(ISNULL(GolferRounds.Points, 0))
			FROM	GolferRounds
			WHERE	YEAR([Date]) = @Season
			GROUP BY GolferId
			ORDER BY SUM(ISNULL(GolferRounds.Points, 0)) DESC)) AS PointsBehind
FROM	GolferRounds
WHERE	YEAR([Date]) = @Season
GROUP BY GolferId, Name, Alias, YEAR([Date])
ORDER BY SUM(ISNULL(Points, 0)) DESC, Name

END
