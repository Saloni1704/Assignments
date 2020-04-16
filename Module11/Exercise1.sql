Use AdventureWorks2017
Go

create table Production.ProductionAudit
(
AuditID int primary key Identity(1,1)not null,
ProductID int not null,
UpdateTime datetime2 not null,
ModifyingUser varchar(30) not null,
OriginalListPrice money not null,
NewListPrice money not null
)

create trigger tr_UpdateProductListPrice
on Production.Product
after update
as begin
set nocount on;
Insert Production.ProductionAudit(
ProductID,UpdateTime,ModifyingUser,
OriginalListPrice,NewListPrice
)
select i.ProductID,SYSDATETIME(),ORIGINAL_LOGIN(),d.ListPrice,i.ListPrice
from deleted as d
inner join inserted as i
on
d.ProductID=i.ProductID
where d.ListPrice>1000 or i.ListPrice>1000;
end;
Go

Update Production.Product set ListPrice=1000.00 where ProductID=842;

Update Production.Product set ListPrice=2000.00 where ProductID=1;

select * from Production.ProductionAudit