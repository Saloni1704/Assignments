create database HumanResourcesDb;

alter database HumanResourcesDb add FILEGROUP  FG0;
alter database HumanResourcesDb add FILEGROUP  FG1;
alter database HumanResourcesDb add FILEGROUP  FG2;
alter database HumanResourcesDb add FILEGROUP  FG3;

ALTER DATABASE HumanResourcesDb   
ADD FILE   
(  
    NAME = file1,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\file1.ndf',  
    SIZE = 5MB,  
    MAXSIZE = 100MB,  
    FILEGROWTH = 5MB  
)  
TO FILEGROUP FG0;  
GO 


ALTER DATABASE HumanResourcesDb   
ADD FILE   
(  
    NAME = file2,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\file2.ndf',  
    SIZE = 5MB,  
    MAXSIZE = 100MB,  
    FILEGROWTH = 5MB  
)  
TO FILEGROUP FG1;  
GO 


ALTER DATABASE HumanResourcesDb   
ADD FILE   
(  
    NAME = file3,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\file3.ndf',  
    SIZE = 5MB,  
    MAXSIZE = 100MB,  
    FILEGROWTH = 5MB  
)  
TO FILEGROUP FG3;  
GO 


ALTER DATABASE HumanResourcesDb   
ADD FILE   
(  
    NAME = file4,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\file4.ndf',  
    SIZE = 5MB,  
    MAXSIZE = 100MB,  
    FILEGROWTH = 5MB  
)  
TO FILEGROUP FG3;  
GO 
create  partition function pfHumanResourcesDates(smalldatetime)
as range left
for values('2011-01-01 00:00','2012-01-01 00:00','2013-01-01 00:00')


create partition scheme psHumanResources as partition pfHumanResourcesDates
to(FG0,FG1,FG2,FG3);
Go

CREATE TABLE TimeSheet (TimeSheetId int Identity(1,1), TimeSheetDate smalldatetime)  
    ON psHumanResources (TimeSheetDate) ;  
GO 

select * from TimeSheet;

SELECT $PARTITION.pfHumanResourcesDates('2011-01-01 00:00') FROM TimeSheet 

DECLARE @p int = $PARTITION.pfHumanResourcesDates('2011-02-06 00:00');
print(@p);
 

 CREATE TABLE TimeSheetStaging(
 RegisteredStartTime smalldatetime
 
) ON FG0


alter table TimeSheetStaging drop constraint CHK_datetime;

ALTER TABLE TimeSheetStaging
ADD CONSTRAINT CHK_date CHECK (RegisteredStartTime<'2015-02-07 00:00' and RegisteredStartTime>='2015-01-01 00:00');


DECLARE @p int = $PARTITION.pfHumanResourcesDates('2010-10-10 00:00');
print @p;
ALTER TABLE TimeSheet
SWITCH PARTITION @p TO TimeSheetStaging;

select pstats.partition_number as PartitionNumber,
pstats.row_count as PartitionRowCount
from sys.dm_db_partition_stats as pstats where
pstats.object_id=OBJECT_ID('TimeSheet')
Order by PartitionNumber;