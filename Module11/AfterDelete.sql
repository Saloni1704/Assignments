create trigger tr_AfterDeleteEmp
on dbo.EmployeeD
after delete
as begin
set nocount on
update e set e.ModifiedDate=SYSDATETIME()
from dbo.Employees as e
where exists(select 18 from deleted as d where e.EmployeeId=d.EmployeeId);
end;
go

delete from EmployeeD where EmployeeId=18

select * from Employees


create trigger trAfterDeleteEmp
on dbo.EmployeeD
after delete
as begin
set nocount on
delete
from dbo.Employees
where exists(select 18 from deleted as d where Employees.EmployeeId=d.EmployeeId);
select * from deleted
end;
go

delete from EmployeeD where EmployeeId=18

select * from Employees