GO
CREATE VIEW FullUserView([id], [last_name], [patronymic], [birthday], [login], [password], [money], [role_id], [status_id], [name]) AS
SELECT u.id, u.id, u.id, u.id, u.id, u.id, u.id, u.id, u.id, s.name FROM 
[carriages_system].[dbo].[user] AS u
left join
user_status AS s
ON u.status_id = s.id
SELECT * FROM FullUserView;
DROP VIEW FullUserView

USE [carriages_system]
GO
CREATE PROCEDURE GetFreeTasks
AS
SELECT *
FROM [task] AS t
WHERE t.status_id = 1
DROP PROCEDURE GetFreeTasks
GO
EXECUTE GetFreeTasks

GO
CREATE FUNCTION GetMineFinishedTasks(@driver_id int)
RETURNS TABLE
AS
RETURN
SELECT *
FROM [task] AS t
WHERE t.driver_id = @driver_id AND t.status_id = 5
DROP FUNCTION GetMineFinishedTasks
GO
SELECT * FROM dbo.GetMineFinishedTasks(2)

GO
CREATE FUNCTION GetMineCurrentTasks(@driver_id int)
RETURNS TABLE
AS
RETURN
SELECT *
FROM [task] AS t
WHERE t.driver_id = @driver_id AND t.status_id = 2
DROP FUNCTION GetMineCurrentTasks
GO
SELECT * FROM dbo.GetMineCurrentTasks(2)

GO
CREATE FUNCTION GetReportsByDrivarIdAndTaskId(@driver_id int, @task_id int)
RETURNS TABLE
AS
RETURN
SELECT *
FROM [task_report] AS tr
LEFT JOIN
[task] as t
ON t.id = tr.task_id
WHERE t.driver_id = @driver_id AND t.id = @task_id
DROP FUNCTION GetReportsByDrivarIdAndTaskId
GO
SELECT * FROM dbo.GetReportsByDrivarIdAndTaskId(3, 2)
