create database MemoryOptimizedDb
Go

Use MemoryOptimizedDb
Go

create procedure dbo.spInsertMemoData
with NATIVE_COMPILATION, SCHEMABINDING, EXECUTE AS OWNER
AS
BEGIN ATOMIC WITH
(TRANSACTION ISOLATION LEVEL = SNAPSHOT,
LANGUAGE = 'us_English')
DECLARE @count int =1;
while @count<=1000
begin
insert into dbo.MemoryOptimizedOrder values(@count,'2020-04-17',657,87);
set @count=@count+1;
end
END

exec dbo.spInsertMemoData



select count(*) from dbo.MemoryOptimizedOrder


