-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 3/31/2016
-- Description:	Get beer duty rotation based on previous year's standings
-- =============================================
CREATE PROCEDURE [dbo].[GetBeerDutyRotation] 
	@Season int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT	ROW_NUMBER() OVER (ORDER BY SUM(ISNULL(GR.Points, 0)) DESC), G.GolferId, G.Name
FROM	GolferRounds GR
		INNER JOIN Golfer G ON 
		GR.GolferId = G.GolferId
WHERE	YEAR(GR.[Date]) = (@Season-1) AND 
		G.BringsBeer = 1
GROUP BY G.GolferId, G.Name
ORDER BY SUM(ISNULL(GR.Points, 0)) DESC, G.Name

END
