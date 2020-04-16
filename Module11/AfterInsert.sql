alter trigger tr_Employee_Insert
on dbo.Employees
after insert
as begin
set nocount on
select * from inserted;
select * from deleted;
end
go

insert into Employees values('saloni','234'),('ishi','879');

delete from Employees;

update Employees set EmployeeName='pu' where EmployeeId=19;


create trigger tr_EmployeeData
on dbo.Employees
after insert 
as begin
set nocount on
insert into dbo.EmployeeAudit(EmployeeId,EmployeeName,ContactNumber)(select e.EmployeeId,e.EmployeeName,e.ContactNumber from inserted as e);
end
go

insert into Employees values('hhjhjkh','6766');

Select * from EmployeeAudit;

