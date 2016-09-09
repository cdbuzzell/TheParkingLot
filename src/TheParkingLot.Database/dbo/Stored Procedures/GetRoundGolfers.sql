-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 9/8/2016
-- Description:	Get all golfers stats for a specific round
-- =============================================
CREATE PROCEDURE [dbo].[GetRoundGolfers] 
	@RoundId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT	G.GolferId, G.Alias, G.Name, G.[Enabled], V.*
FROM	Golfer G
		LEFT OUTER JOIN (
			SELECT	R.RoundId, R.[Date], R.Details, R.Game, R.Name AS RoundName,
					C.CourseId, C.Name AS CourseName, C.Url, C.Par, C.Rating, C.Slope,
					GR.GolferRoundId, GR.GolferId, GR.Alias, GR.Name AS GolferName, GR.Points, GR.Par3sWon, GR.WonGame, GR.Score, GR.Comments
			FROM	[Round] R
					INNER JOIN Course C ON R.CourseId = C.CourseId
					LEFT OUTER JOIN GolferRounds GR ON R.RoundId = GR.RoundId
			WHERE	R.RoundId = @RoundId
		) V ON G.GolferId = V.GolferId
ORDER BY G.[Enabled], G.Name DESC

END