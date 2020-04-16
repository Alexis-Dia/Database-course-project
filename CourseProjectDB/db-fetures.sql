GO
CREATE VIEW FullUserView([id], [last_name], [patronymic], [birthday], [login], [password], [money], [role_id], [status_id], [name]) AS
SELECT u.id, u.id, u.id, u.id, u.id, u.id, u.id, u.id, u.id, s.name FROM 
[carriages_system].[dbo].[user] AS u
left join
user_status AS s
ON u.status_id = s.id

SELECT * FROM FullUserView;
DROP VIEW FullUserView