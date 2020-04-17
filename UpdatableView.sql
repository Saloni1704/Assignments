Use Emp
Go

Create Trigger tr_InsteadOfUpdate  
on vEmployee  
instead of update  
as  
Begin   
declare @EmployeeId int=(select EmployeeId from inserted)
Update vEmployee set EmployeeName=(select EmployeeName from inserted) where EmployeeId=@EmployeeId
Update vEmployee set Email=(select Email from inserted) where EmployeeId=@EmployeeId
 End  


 Update vEmployee set 
 EmployeeName='abc',Email='abc@gmail.com' where EmployeeId=19

 select * from vEmployee
 select * from Employees
 select * from EmployeeD