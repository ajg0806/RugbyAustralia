
SELECT p.Player_Name, TOP_TACKLER.Successful_Tackles FROM
(
	SELECT TOP(1) e.Player_Id, COUNT(*) Successful_Tackles
	FROM Event e 
	INNER JOIN Fixture f
	ON f.Fixture_Mid = e.Fixture_Id
	WHERE e.EvEnt = 'Tackle' 
	AND e.Eventresult != 'Missed'
	AND f.Fixture_Round = 4
	GROUP BY Player_Id
	ORDER BY Successful_Tackles DESC
) TOP_TACKLER
INNER JOIN Player p
ON p.Player_Mid = TOP_TACKLER.Player_Id;

SELECT p.Player_Name, TOP_TRY_SCORER.Tries FROM
(
	SELECT TOP(1) Player_Id, COUNT(*) Tries
	FROM Event 
	WHERE Event = 'Try'
	AND Position_Number = 13
	GROUP BY Player_Id 
	ORDER BY Tries DESC
) TOP_TRY_SCORER
INNER JOIN Player p
ON p.Player_Mid = TOP_TRY_SCORER.Player_Id;

SELECT p.Player_Name, TOP_RUNNER.Total_Distance FROM 
	( SELECT TOP(1) Player_Id , SUM(Value) Total_Distance
	FROM Event e
	INNER JOIN Fixture f
	ON e.Fixture_Id = f.Fixture_Mid
	WHERE Event = 'Carry'
	AND f.Fixture_Round = 10
	GROUP BY Player_Id )
TOP_RUNNER
INNER JOIN Player p
ON p.Player_Mid = TOP_RUNNER.Player_Id;

SELECT PASSES.Player_Name, COMPLETE_PASSES.Complete_Passes / PASSES.Total_Passes Pass_Completetion_Percentage
FROM
	( SELECT Player_Name, Try_convert(float, COUNT(*)) Total_Passes
	FROM Player p
	INNER JOIN Event e
	ON p.Player_Mid = e.Player_Id
	WHERE p.Player_Name = 'Tate McDermott'
	AND e.EvEnt = 'Pass'
	GROUP BY p.Player_Name )
PASSES
INNER JOIN 
	( SELECT Player_Name, Try_convert(float, COUNT(*)) Complete_Passes
	FROM Player p
	INNER JOIN Event e
	ON p.Player_Mid = e.Player_Id
	WHERE p.Player_Name = 'Tate McDermott'
	AND e.EvEnt = 'Pass'
	AND e.Eventtype = 'Complete Pass'
	GROUP BY p.Player_Name )
COMPLETE_PASSES
ON PASSES.Player_Name = COMPLETE_PASSES.Player_Name

SELECT TOP(1) HOME_TEAM_PASSES.Team, COUNT(HOME_TEAM_PASSES.EvEnt) Complete_Passes FROM
	( SELECT e.Team, e.EvEnt
	FROM Fixture f
	INNER JOIN Event e
	ON e.Fixture_Id = f.Fixture_Mid
	AND e.Team = f.Home_Team
	WHERE e.EvEnt = 'Pass'
	AND e.Eventtype = 'Complete Pass' )
HOME_TEAM_PASSES
GROUP BY HOME_TEAM_PASSES.Team
ORDER BY Complete_Passes DESC