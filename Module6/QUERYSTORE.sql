create database QueryStore;

create table Employees(
EmployeeId int Identity(1,1) not null,
Name varchar(30) not null,
Salary int not null,
ContactNumber varchar(20));

create table EmpDetail(
EmpDetailId int Identity not null,
EmployeeId int not null,
Email varchar(30));

CREATE VIEW vEmployee 
WITH SCHEMABINDING AS    
SELECT e.EmployeeId,e.Name,e.Salary,e.ContactNumber    
FROM dbo.Employees e    
WHERE e.Name LIKE '[A-P]%' 

create unique clustered index ix_Employee on vEmployee(EmployeeId);

alter database QueryStore set QUERY_STORE CLEAR;

SELECT * from vEmployee;

select e.Name as 'Employees',d.Email as'EmpDetail'
from
Employees as e
inner join EmpDetail as d
on
d.EmployeeId=e.EmployeeId;

update statistics vEmployee with ROWCOUNT=6000,PAGECOUNT=2000;
