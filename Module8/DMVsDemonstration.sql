select * from sys.views

select * from sys.tables

select * from sys.objects

select * from INFORMATION_SCHEMA.TABLES 
WHERE  
TABLE_TYPE='BASE TABLE'

select * from INFORMATION_SCHEMA.TABLES 
where 
TABLE_TYPE='VIEW'

select * from sys.dm_exec_connections

select * from sys.dm_exec_sessions

select * from sys.dm_exec_requests

select * from sys.dm_exec_query_stats 

select top 20  total_worker_time 
from sys.dm_exec_query_stats 
order by total_worker_time desc;