Use tempDb
Go

create function CalculateDate()
returns date
as begin
return DATEADD(DAY, -(DAY(GETDATE())), GETDATE())
end
Go


drop function CalculateDate

create function CalculateDate()
returns date
as begin
declare @Date date;
set @Date='2020/04/17'
return EOMONTH (@Date,-1)
end
Go

drop function CalculateDate
 