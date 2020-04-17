create database MemoryOptimizedDb
Go

Use MemoryOptimizedDb
Go

alter database MemoryOptimizedDb
add filegroup MemFG contains
MEMORY_OPTIMIZED_DATA
Go

ALTER DATABASE MemoryOptimizedDb   
ADD FILE   
(  
    NAME = MemData,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MemData.ndf' 

)  
TO FILEGROUP MemFG;  
GO 

create table MemoryOptimizedOrder
(OrderId INTEGER NOT NULL PRIMARY KEY  NONCLUSTERED,
OrderDate DATETIME NOT NULL,
ProductCode INTEGER NULL,
Quantity INTEGER NULL)
WITH (MEMORY_OPTIMIZED = ON, DURABILITY = SCHEMA_AND_DATA
)
Go

create table DiskBasedOrdertable
(
OrderId INTEGER NOT NULL PRIMARY KEY ,
OrderDate DATETIME NOT NULL,
ProductCode INTEGER NULL,
Quantity INTEGER NULL
)

begin tran
declare @count int=1;
while @count<=1000
begin
insert into DiskBasedOrdertable values(@count,'2020-04-17',657,87);
set @count=@count+1
end

delete from MemoryOptimizedOrder
set statistics time on;
begin tran
declare @count int=1;
while @count<=1000
begin
insert into MemoryOptimizedOrder values(@count,'2020-04-17',657,87);
set @count=@count+1
end
set statistics time off;

delete  from MemoryOptimizedOrder
delete from DiskBasedOrdertable

select * from sys.dm_db_xtp_table_memory_stats


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

