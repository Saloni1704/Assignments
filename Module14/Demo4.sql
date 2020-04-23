use Emp
Go

select * from dbo.Employees for xml auto;
select * from dbo.Employees for xml raw;
select * from dbo.Employees for xml raw('Employee');
select * from dbo.Employees for xml path;
select * from dbo.Employees for xml path('Employee') ,root('Employees');
select EmployeeId as [@EmployeeId] from dbo.Employees  for xml path('Employee') ,root('Employees');


SELECT  EmployeeId AS '@EmployeeID',EmployeeName,ContactNumber,
(SELECT Email
FROM dbo.EmployeeD as EmployeeDetails
WHERE EmployeeDetails.EmployeeId = Employees.EmployeeId
FOR XML AUTO, type, ELEMENTS)
FROM dbo.Employees 
FOR XML PATH ('Employee'), ROOT ('Employees'), ELEMENTS;