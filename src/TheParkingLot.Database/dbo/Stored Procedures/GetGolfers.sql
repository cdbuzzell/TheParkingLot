-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 4/9/2016
-- Description:	Get all golfers
-- =============================================
CREATE PROCEDURE [dbo].[GetGolfers] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT	GolferId, Alias, Name, FullName, Avatar, [Enabled], BringsBeer
FROM	Golfer
ORDER BY Name

END