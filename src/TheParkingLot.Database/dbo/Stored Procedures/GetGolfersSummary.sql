-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 9/2/2016
-- Description:	Get all Golfers + their current season and career totals
-- =============================================
CREATE PROCEDURE GetGolfersSummary
	@Season int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT	G.GolferId, G.Alias, G.Name, G.Avatar, G.[Enabled], G.BringsBeer, 
			ST.AverageToPar AS CurrentAverage, ST.Par3Wins AS CurrentPar3Wins, ST.GameWins AS CurrentGameWins,
			CT.AverageToPar AS CareerAverage, CT.Par3Wins AS CareerPar3Wins, CT.GameWins AS CareerGameWins
	FROM	Golfer G
			LEFT OUTER JOIN SeasonTotals ST ON G.GolferId = ST.GolferId AND ST.Season = @Season
			LEFT OUTER JOIN CareerTotals CT ON G.GolferId = CT.GolferId
	ORDER BY G.[Enabled] DESC, G.Name
END