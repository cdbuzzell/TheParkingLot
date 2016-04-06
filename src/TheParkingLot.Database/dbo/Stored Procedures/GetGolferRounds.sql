-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 4/5/2016
-- Description:	Get a golfer's rounds for a specific season or all seasons (null)
-- =============================================
CREATE PROCEDURE [dbo].[GetGolferRounds] 
	@Golfer nvarchar(50),
	@Season int NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT	*
FROM	GolferRounds
WHERE	Alias = @Golfer
		AND YEAR([Date]) = COALESCE(@Season, YEAR([Date]))
ORDER BY [Date]

END