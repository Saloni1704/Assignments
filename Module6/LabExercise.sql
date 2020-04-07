create database ClusterVSHeap;
use ClusterVSHeap;
CREATE TABLE Employee
  (EmployeeId INT NOT NULL IDENTITY(1,1),
   EmployeeName VARCHAR(30) NOT NULL,
   ContactNumber VARCHAR(20) NOT NULL,
    Address VARCHAR(100) NOT NULL,
   
  );
 
CREATE TABLE EmlployeeDetails
  (EmployeeetailId INT primary key  NOT NULL IDENTITY(1,1),EmployeeId int not null,
	EmailId varchar(50) not null,Age int not null);

SET STATISTICS TIME ON;
SET STATISTICS XML ON;
SET STATISTICS IO ON;
select * from Employee;

select * from EmlployeeDetails;
 
 --*************************
SELECT * FROM Employee ORDER BY EmployeeId  DESC;

SELECT * FROM EmlployeeDetails ORDER BY Age  DESC;
--***************************
select * from Employee where EmployeeId=3;

select * from EmlployeeDetails where Age=4;

--****************************
select * from Employee where EmployeeName='saloni' order by EmployeeId;

select * from EmlployeeDetails where Age=4 order by EmployeeId

--*****************************
Insert into Employee vALUES('ishika','8788','sdsss');
Insert into EmlployeeDetails VALUES(5,'ghvgkhj',50);

SET STATISTICS TIME OFF;
SET STATISTICS XML OFF;
SET STATISTICS IO OFF;