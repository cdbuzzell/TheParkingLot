CREATE VIEW dbo.SeasonTotals AS
SELECT	S.Season,
		GR.GolferId, GR.Alias, GR.Name,
		SUM(ISNULL(GR.Par3sWon, 0)) AS Par3Wins, 
		COUNT(CASE WHEN GR.WonGame=1 THEN 1 ELSE NULL END) AS GameWins,
		SUM(ISNULL(GR.Points, 0)) AS TotalPoints,
		AVG(GR.Score - GR.Par) AS AverageToPar
FROM	Seasons S
		LEFT OUTER JOIN GolferRounds GR ON S.Season = YEAR(GR.[Date])
GROUP BY S.Season, GR.GolferId, GR.Alias, GR.Name