Use Emp;

create trigger tr_InsteadEmpDelete 
on dbo.Employees
instead of delete as
begin
set nocount on;
update e set e.ContactNumber='123456789'
from dbo.Employees as e inner join deleted as d on e.EmployeeId=d.EmployeeId
end;
go

delete from Employees where EmployeeId=22

select * from Employees
