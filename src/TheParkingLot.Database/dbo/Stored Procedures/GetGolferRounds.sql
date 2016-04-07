-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 4/5/2016
-- Description:	Get a golfer's rounds for a specific season + aggregated all seasons
-- =============================================
CREATE PROCEDURE [dbo].[GetGolferRounds] 
	@Golfer nvarchar(50),
	@Season int NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- get golfer rounds for the provided season
SELECT	R.[Date], R.CourseId, R.Details, R.Game, R.Name,
		C.CourseId, C.Name AS CourseName, C.Par, C.Rating, C.Slope,
		GR.Alias, GR.Name, GR.Points, GR.Par3sWon, GR.WonGame, GR.Score, GR.Details, GR.Comments
FROM	[Round] R
		INNER JOIN Course C ON R.CourseId = C.CourseId
		LEFT OUTER JOIN GolferRounds GR ON R.RoundId = GR.RoundId AND GR.Alias = @Golfer
WHERE	YEAR(R.[Date]) = @Season
ORDER BY R.[Date]

-- get an aggregate of all rounds per year for every season
SELECT	S.Season,
		GR.GolferId, GR.Alias, GR.Name,
		SUM(ISNULL(GR.Par3sWon, 0)) AS Par3s, 
		COUNT(CASE WHEN GR.WonGame=1 THEN 1 ELSE NULL END) AS GameWins,
		SUM(ISNULL(GR.Points, 0)) AS Points,
		AVG(GR.Score - GR.Par) AS AvgToPar
FROM	Seasons S
		LEFT OUTER JOIN GolferRounds GR ON S.Season = YEAR(GR.[Date]) AND GR.Alias = @Golfer
GROUP BY S.Season, GR.GolferId, GR.Alias, GR.Name
ORDER BY Season

END