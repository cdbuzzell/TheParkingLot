-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 4/5/2016
-- Description:	Get a golfer's rounds for a specific season
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
SELECT	R.RoundId, R.[Date], R.CourseId, R.Details, R.Game, R.Name AS RoundName,
		C.CourseId, C.Name AS CourseName, C.Url, C.Par, C.Rating, C.Slope,
		GR.GolferRoundId, GR.GolferId, GR.Alias, GR.Name AS GolferName, GR.Points, GR.Par3sWon, GR.WonGame, GR.Score, GR.Details, GR.Comments
FROM	[Round] R
		INNER JOIN Course C ON R.CourseId = C.CourseId
		LEFT OUTER JOIN GolferRounds GR ON R.RoundId = GR.RoundId AND GR.Alias = @Golfer
WHERE	YEAR(R.[Date]) = @Season
ORDER BY R.[Date]


END