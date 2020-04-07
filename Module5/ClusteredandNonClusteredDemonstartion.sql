create table PhoneLog(
PhoneLogId int primary key Identity(1,1) not null,
ContactName varchar(40) not null,
PhoneTime datetime not null,
ContactNumber varchar(20) not null
);

SELECT * FROM sys.indexes 
where 
object_id=(select object_id from sys.objects where name='PhoneLog');

insert into PhoneLog values('piyu','2020-04-07 10:10:00:00','8998399976')


declare @ob_id int,@db_id smallint;

set @db_id=DB_ID(N'tempDb')
print @db_id;
set @ob_id=OBJECT_ID(N'PhoneLog');
print @ob_id;
SELECT * FROM sys.dm_db_index_physical_stats (@db_id,@ob_id,null,null,null);
SELECT avg_page_space_used_in_percent FROM sys.dm_db_index_physical_stats (@db_id,@ob_id,null,null,null);

update PhoneLog set ContactName='priyanka' 
where PhoneLogId=1;

ALTER TABLE dbo.PhoneLog  REBUILD;
ALTER INDEX PK__PhoneLog__A8E44E5288C1E03D 
ON PhoneLog REBUILD;

set SHOWPLAN_XML ON
SELECT * FROM PhoneLog;
set SHOWPLAN_XML OFF 

CREATE NONCLUSTERED INDEX IDX_PHONELOG_COVERING ON PHONELOG (PhoneLogId)
INCLUDE(ContactName,ContactNumber,PhoneTime)


