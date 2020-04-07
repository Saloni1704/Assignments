
declare @db_id smallint,@object_id int;

set @db_id=DB_ID(N'HumanResources');
set @object_id=OBJECT_ID(N'TimeSheet');

if @db_id is null
begin;
print N'Invalid database';
end;
else if @object_id is null
begin;
print N'Invalid Object';
end;
else
begin;
select * from sys.dm_db_index_physical_stats(@db_id,@object_id,null,null,null);
end


