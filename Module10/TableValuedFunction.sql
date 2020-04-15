Use Emp
Go

create function getemployees(@EmployeeId int)
returns table
as
return
(
Select * from Employees
where
EmployeeId=@EmployeeId
)

Select 
e.EmployeeName,
e.ContactNumber,
ed.EmployeeId,
ed.Email,
from Employees as e
cross apply
getEmployees(e.EmployeeId) as ed
