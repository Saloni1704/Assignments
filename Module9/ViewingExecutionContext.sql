Use tempdb
Go

create procedure ViewingExecutionContext
as
SET NOCOUNT ON;
BEGIN
select * from sys.login_token;
select * from sys.user_token;
end

exec ViewingExecutionContext;

execute as user='SecureUser'
Go

exec ViewingExecutionContext;

Revert 
Go

alter procedure ViewingExecutionContext
with execute as owner
as
SET NOCOUNT ON;
BEGIN
select * from sys.login_token;
select * from sys.user_token;
end;
Go

execute as user='SecureUser';
Go

exec ViewingExecutionContext
Go

Revert 
Go

drop procedure ViewingExecutionContext
Go