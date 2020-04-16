alter trigger tr_AfterUpdateEmp
on dbo.Employees
after update 
as begin 
set nocount on;
 update e set e.ModifiedDate=SYSDATETIME()
from dbo.Employees as e inner join inserted as I
on i.EmployeeId=e.EmployeeId;
select * from inserted
select * from deleted
end;
Go

update Employees set EmployeeName='richa' where EmployeeId=17

select * from Employees;