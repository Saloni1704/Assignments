
Use AdventureWorks2017;
Go

create procedure Production.GetAvailableModelsAsXml
as
begin
select p.ProductId,p.Name as ProductName,
p.ListPrice,p.Color,p.SellStartDate,
pm.ProductModelID,pm.Name as ProductModelName
from Production.Product as p
inner join 
Production.ProductModel as pm on
p.ProductModelID=pm.ProductModelID
where p.SellStartDate is not null and p.SellEndDate is null
order by
p.SellStartDate asc,p.Name desc
for xml raw('ProductModel'),root('ProductModels')
end
Go

exec Production.GetAvailableModelsAsXml

