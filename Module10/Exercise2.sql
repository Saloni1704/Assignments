Use Emp
Go

create function StringList()
returns varchar(100)
as begin
return (
select STRING_AGG(EmployeeName,'-') from Employees)
end
Go

select dbo.StringList()
Go