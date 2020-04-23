go
if not exists (select * from sysobjects where name='audit_report_data' and xtype='U')
CREATE TABLE [carriages_system].[dbo].[audit_report_data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idOld] INT,
	[idNew] INT,
	[recdate] SMALLDATETIME,
	[departureOld] SMALLDATETIME,
	[departureNew] SMALLDATETIME ,
	[weightOld] DECIMAL(18, 2),
	[weightNew] DECIMAL(18, 2) ,
	[distanceOld] DECIMAL(18, 2),
	[distanceNew] DECIMAL(18, 2) ,
	[arrivalNew] SMALLDATETIME,
	[arrivalOld] SMALLDATETIME,
	CONSTRAINT [audit_reports] PRIMARY KEY CLUSTERED
	(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--1. Создать представление, содержащее полную информацию о водителе. 
GO
CREATE VIEW FullUserView([id], [first_name], [last_name], [patronymic], [birthday], [login], [password], [money], [role_id], [status_id], [name]) AS
SELECT u.id, u.first_name, u.last_name, u.patronymic, u.birthday, u.login, u.password, u.money, u.role_id, u.status_id, s.name FROM
[carriages_system].[dbo].[user] AS u
left join
user_status AS s
ON u.status_id = s.id

--SELECT * FROM FullUserView;
--DROP VIEW FullUserView


--2. Создать представление, содержащее информацию о среднем километраже выездов
--каждого водителя за два года. С помощью созданного представления определить фамилии
--водителей, имеющих наименьший километраж и наибольший средний километраж.

GO
CREATE VIEW cariages_min_max_distance_view ([driverId], [distance])
AS SELECT (driver1.last_name + ' ' + driver1.first_name + ' ' + driver1.patronymic), AVG(distance)
FROM
	(SELECT * FROM
	task as t
	LEFT JOIN
	(SELECT departure, distance, arrival, task_id, reports_id FROM
	report AS r
	LEFT JOIN
	task_report AS tr
	ON tr.reports_id = r.id) AS rtr
	ON rtr.task_id = t.id) AS journal1
INNER JOIN
[carriages_system].[dbo].[user] AS driver1
ON journal1.driver_id = driver1.id
WHERE getdate() >  DATEPART(m, DATEADD(m, -24, getdate())) GROUP BY (driver1.last_name + ' ' + driver1.first_name + ' ' + driver1.patronymic);

--SELECT * FROM cariages_min_max_distance_view ORDER BY distance DESC;
--GO
--DROP VIEW cariages_min_max_distance_view

--3. Создать представление, содержащее информацию об использовании автомобилей за
--за два года. С помощью созданного представления определить автомобиль,
--который имеет максимальное число выездов.

GO
CREATE VIEW cariages_car_count_view ([name], departureCount)
AS
SELECT (b.brand + ' ' + b.model + ' ' + result2.number), COUNT(departure) as departureCount FROM [carriages_system].[dbo].[Brand] AS b
INNER JOIN
(SELECT car1.brand_id, car1.number, journal1.*
FROM
	(SELECT * FROM
	task as t
	LEFT JOIN
	(SELECT departure, distance, arrival, task_id, reports_id FROM
	report AS r
	LEFT JOIN
	task_report AS tr
	ON tr.reports_id = r.id) AS rtr
	ON rtr.task_id = t.id) AS journal1
LEFT JOIN
[carriages_system].[dbo].[Car] AS car1
ON journal1.car_id = car1.id) AS result2
ON result2.brand_id = b.id
WHERE getdate() > DATEPART(m, DATEADD(m, -24, getdate()))  GROUP BY (b.brand + ' ' + b.model + ' ' + result2.number)

--GO
--DROP VIEW cariages_car_count_view
--SELECT * FROM cariages_car_count_view;
--SELECT * FROM cariages_car_count_view WHERE departureCount = (SELECT MAX(departureCount) FROM cariages_car_count_view);

GO
CREATE FUNCTION GetFreeTasks()
RETURNS TABLE
AS
RETURN
SELECT *
FROM [task] AS t
WHERE t.status_id = 1

--DROP FUNCTION GetFreeTasks
--GO
--SELECT * FROM dbo.GetFreeTasks()

GO
CREATE FUNCTION GetMineFinishedTasks(@driver_id int)
RETURNS TABLE
AS
RETURN
SELECT *
FROM [task] AS t
WHERE t.driver_id = @driver_id AND t.status_id = 5

--DROP FUNCTION GetMineFinishedTasks
--GO
--SELECT * FROM dbo.GetMineFinishedTasks(2)

GO
CREATE FUNCTION GetMineCurrentTasks(@driver_id int)
RETURNS TABLE
AS
RETURN
SELECT *
FROM [task] AS t
WHERE t.driver_id = @driver_id AND t.status_id = 2

--DROP FUNCTION GetMineCurrentTasks
--GO
--SELECT * FROM dbo.GetMineCurrentTasks(2)

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

--DROP FUNCTION GetReportsByDrivarIdAndTaskId
--GO
--SELECT * FROM dbo.GetReportsByDrivarIdAndTaskId(3, 2)

GO
CREATE FUNCTION GetReportsForActiveTask(@driver_id int)
RETURNS TABLE
AS
RETURN
SELECT * FROM report WHERE id IN 
(SELECT reports_id FROM task_report where task_id = (SELECT top 1 id FROM task WHERE driver_id = @driver_id AND status_id = 2))

--DROP FUNCTION GetReportsForActiveTask
--GO
--SELECT * FROM dbo.GetReportsForActiveTask(2)

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
SELECT * FROM dbo.GetReportsForActiveTask(@current_user_id)  ORDER BY id
END

--GO
--DROP PROCEDURE ADD_REPORT
--GO
--EXECUTE ADD_REPORT @current_task_id=3, @current_user_id=2, @departure='1/15/2020 7:00 AM', @weight=3, @distance=99, @arrival='1/15/2020 7:00 AM'

GO
CREATE PROCEDURE TAKE_TASK
(@chosen_task_id int OUTPUT, @current_user_id int OUTPUT)
AS
BEGIN
DECLARE @random_free_car_id int;
SET @random_free_car_id = (SELECT TOP 1 id FROM car WHERE status_id = 1);
UPDATE task SET status_id = 2, car_id = @random_free_car_id, driver_id = @current_user_id WHERE id = @chosen_task_id;
UPDATE [carriages_system].[dbo].[user] SET status_id = 2 WHERE id = @current_user_id;
SELECT * FROM dbo.GetFreeTasks() ORDER BY id;
END

--GO
--DROP PROCEDURE TAKE_TASK

GO
CREATE PROCEDURE SEND_TO_VALIDATION_TASK
(@chosen_task_id int OUTPUT)
AS
BEGIN
UPDATE task SET status_id = 3 WHERE id = @chosen_task_id;
SELECT * FROM dbo.GetFreeTasks() ORDER BY id;
END

--DROP PROCEDURE SEND_TO_VALIDATION_TASK

GO
CREATE PROCEDURE VALIDATE_TASK_TO_REJECTED
(@chosen_task_id int OUTPUT)
AS
BEGIN
DECLARE @current_user_id int;
SET @current_user_id = (SELECT TOP 1 driver_id FROM task WHERE id = @chosen_task_id);
UPDATE task SET status_id = 4 WHERE id = @chosen_task_id;
UPDATE [carriages_system].[dbo].[user] SET status_id = 1 WHERE id = @current_user_id;
SELECT * FROM task ORDER BY id;
END
--DROP PROCEDURE VALIDATE_TASK_TO_REJECTED

GO
CREATE PROCEDURE VALIDATE_TASK_TO_FINISHED
(@chosen_task_id int OUTPUT)
AS
BEGIN
DECLARE @reward float;
DECLARE @adminAmount float;
DECLARE @driverAmount float;
DECLARE @newAdminAmount float;
DECLARE @newDriverAmount float;
DECLARE @current_user_id int;
SET @current_user_id = (SELECT TOP 1 driver_id FROM task WHERE id = @chosen_task_id);
SET @reward = (SELECT t.reward FROM task as t WHERE t.id = @chosen_task_id);
SET @adminAmount = (SELECT u.money FROM [carriages_system].[dbo].[user] as u WHERE u.id = 1);
SET @driverAmount = (SELECT u.money FROM [carriages_system].[dbo].[user] as u WHERE u.id = @current_user_id);
SET @newAdminAmount = @adminAmount - @reward;
SET @newDriverAmount = @driverAmount + @reward;
UPDATE task SET status_id = 5 WHERE id = @chosen_task_id;
UPDATE [carriages_system].[dbo].[user] SET money = @newAdminAmount WHERE id = 1;
UPDATE [carriages_system].[dbo].[user] SET status_id = 1, money = @newDriverAmount WHERE id = @current_user_id;
SELECT * FROM task ORDER BY id;
END

--DROP PROCEDURE VALIDATE_TASK_TO_FINISHED



--1. Триггер аудита изменения отчетов
GO
CREATE Trigger auditReport ON [dbo].[report] AFTER
UPDATE, DELETE
AS
BEGIN
DECLARE @idOld INT, @idNew INT
DECLARE @carIdOld INT, @carIdNew INT
DECLARE @driverIdOld INT, @driverIdNew INT
DECLARE @departureOld SMALLDATETIME, @departureNew SMALLDATETIME
DECLARE @weightOld DECIMAL(18, 2), @weightNew DECIMAL(18, 2)
DECLARE @distanceOld DECIMAL(18, 2), @distanceNew DECIMAL(18, 2)
DECLARE @arrivalOld SMALLDATETIME, @arrivalNew SMALLDATETIME
SET @idOld = (select [id] from deleted)
SET @idNew = (select [id] from inserted)
SET @departureOld = (select [departure] from deleted)
SET @departureNew = (select [departure] from inserted)
SET @weightOld = (select [weight] from deleted)
SET @weightNew = (select [weight] from inserted)
SET @distanceOld = (select [distance] from deleted)
SET @distanceNew = (select [distance] from inserted)
SET @arrivalOld = (select [arrival] from deleted)
SET @arrivalNew = (select [arrival] from inserted);
INSERT INTO [carriages_system].[dbo].[audit_report_data] VALUES
(@idOld, @idNew, GETDATE(), @departureOld, @departureNew,
@weightOld, @weightNew, @distanceOld, @distanceNew, @arrivalOld, @arrivalNew)
END

--DROP TRIGGER auditReport

--UPDATE [dbo].[report]
--SET [arrival] = '2020-01-30 18:59:00'
--WHERE [id] = 43


--2. Триггер для корректировки ввода даты
GO
CREATE TRIGGER checkArrival ON [dbo].[report] AFTER INSERT
AS
BEGIN
DECLARE @insertedId INT
DECLARE @departure SMALLDATETIME
DECLARE @arrival SMALLDATETIME
SET @insertedId = (SELECT id FROM inserted)
SET @departure = (SELECT departure FROM inserted)
SET @arrival = (SELECT arrival FROM inserted)
if @departure > @arrival
begin
UPDATE [dbo].[report]
SET arrival = @departure WHERE id = @insertedId
end
END


--USE carriages_system
--GO
--INSERT INTO [dbo].[report]([departure],[weight],[distance],[arrival])
--     VALUES ('2022-11-15 11:00:00.000',399.0,199.0,'2021-11-17 11:00:00.000')
--GO

--3. Триггер для невозможности добавления отчета в день дальнобойщика - 08.31.2019
GO
CREATE TRIGGER checkDeparture ON [dbo].[report]
AFTER INSERT, UPDATE
AS
BEGIN
DECLARE @departure SMALLDATETIME
SET @departure = (SELECT departure FROM inserted)
IF (8 = datepart(m, @departure) AND 31 = datepart(d, @departure))
BEGIN
ROLLBACK TRANSACTION
PRINT 'День дальнобойщика, вы не можете задавать в БД запись на этот день!'
END
ELSE PRINT 'Строка вставлена/изменена'
END









