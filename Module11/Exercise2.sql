Use AdventureWorks2017
Go

delete from Production.ProductionAudit ;

alter trigger tr_UpdateProductListPrice
on Production.Product
after update as begin
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
where d.ListPrice>10000 or i.ListPrice>10000;
end;
Go

Update Production.Product set ListPrice=100001.00 where ProductID=2;