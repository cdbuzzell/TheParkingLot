-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 4/8/2016
-- Description:	Get a golfer's rounds for a specific season + aggregated totals for all seasons
-- =============================================
CREATE PROCEDURE [dbo].[GetGolferTotals] 
	@Golfer nvarchar(50)--,
	--@Season int NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--EXECUTE dbo.GetGolferRounds @Golfer, @Season
	
-- get an aggregate of all rounds per year for every season
SELECT	S.Season,
		GR.GolferId, GR.Name AS GolferName, GR.Alias, GR.Name,
		SUM(ISNULL(GR.Par3sWon, 0)) AS Par3Wins, 
		COUNT(CASE WHEN GR.WonGame=1 THEN 1 ELSE NULL END) AS GameWins,
		SUM(ISNULL(GR.Points, 0)) AS TotalPoints,
		AVG(GR.Score - GR.Par) AS AverageToPar
FROM	Seasons S
		LEFT OUTER JOIN GolferRounds GR ON S.Season = YEAR(GR.[Date]) AND GR.Alias = @Golfer
GROUP BY S.Season, GR.GolferId, GR.Alias, GR.Name
ORDER BY Season

END