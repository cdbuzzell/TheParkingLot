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

SELECT	ROW_NUMBER() OVER (ORDER BY SUM(ISNULL(GR.Points, 0)) DESC) AS Rank, 
		G.GolferId, G.Name AS GolferName, G.Username, 
		SUM(ISNULL(GR.Points, 0)) AS TotalPoints,
		(SUM(ISNULL(GR.Points, 0)) - 
			(SELECT	TOP 1 SUM(ISNULL(GolferRounds.Points, 0))
			FROM	GolferRounds
			WHERE	YEAR([Date]) = @Season
			GROUP BY GolferId
			ORDER BY SUM(ISNULL(GolferRounds.Points, 0)) DESC)) AS PointsBehind
FROM	GolferRounds GR
		INNER JOIN Golfer G ON 
		GR.GolferId = G.GolferId
WHERE	YEAR(GR.[Date]) = @Season
GROUP BY G.GolferId, G.Name, G.Username
ORDER BY SUM(ISNULL(GR.Points, 0)) DESC, G.Name

END
