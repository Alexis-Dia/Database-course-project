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
CREATE FUNCTION GetFreeTasks()
RETURNS TABLE
AS
RETURN
SELECT *
FROM [task] AS t
WHERE t.status_id = 1
DROP FUNCTION GetMineFinishedTasks
GO
SELECT * FROM dbo.GetFreeTasks()

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
CREATE PROCEDURE GetMineFinishedTasks
(@driver_id int OUTPUT)
AS
SELECT *
FROM [task] AS t
WHERE t.driver_id = @driver_id AND t.status_id = 5
GO
DROP PROCEDURE GetMineFinishedTasks
GO
EXECUTE GetMineFinishedTasks @driver_id=2

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

GO
CREATE FUNCTION GetReportsForActiveTask(@driver_id int)
RETURNS TABLE
AS
RETURN
SELECT * FROM report WHERE id IN 
(SELECT reports_id FROM task_report where task_id = (SELECT top 1 id FROM task WHERE driver_id = @driver_id AND status_id = 2))
DROP FUNCTION GetReportsForActiveTask
GO
SELECT * FROM dbo.GetReportsForActiveTask(2)

GO
CREATE PROCEDURE ADD_REPORT
(@current_task_id int OUTPUT, @current_user_id int OUTPUT, @departure DATETIME OUTPUT,  @weight int OUTPUT,  @distance int OUTPUT, @arrival DATETIME OUTPUT)
AS
BEGIN
DECLARE @current_report_id int;
SET @current_report_id = (SELECT IDENT_CURRENT('report') + 1);
SET IDENTITY_INSERT report ON;
INSERT INTO [dbo].[report] ([id],[departure],[weight],[distance], [arrival])
     VALUES (@current_report_id, @departure, @weight, @distance, @arrival);
INSERT INTO [dbo].[task_report] ([task_id],[reports_id])
VALUES (@current_task_id, @current_report_id);
SET IDENTITY_INSERT report OFF ;
SELECT * FROM dbo.GetReportsForActiveTask(@current_user_id)
END
GO
DROP PROCEDURE ADD_REPORT
GO
EXECUTE ADD_REPORT @current_task_id=3, @current_user_id=2, @departure='1/15/2020 7:00 AM', @weight=3, @distance=99, @arrival='1/15/2020 7:00 AM'
