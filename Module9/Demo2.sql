Use AdventureWorks2017
Go

create procedure Production.spGetBlueProducts
as 
SET NOCOUNT ON;
BEGIN
select p.Name,p.ProductNumber,p.ListPrice
from Production.Product as p
where p.Color='Blue';
end;
Go

exec Production.spGetBlueProducts;

create procedure Production.spGetBlueProductsandModels
as 
SET NOCOUNT ON;
BEGIN
select p.ProductNumber,p.ListPrice,m.Name as ModelName
from Production.Product as p
inner join Production.ProductModel as m
on p.ProductModelID=m.ProductModelID
end;

exec Production.spGetBlueProductsandModels
Go

alter procedure Production.spGetBlueProductsandModels
as 
SET NOCOUNT ON;
BEGIN
select p.Name as ProductName,p.ProductNumber,m.Name as ModelName
from Production.Product as p
inner join Production.ProductModel as m
on p.ProductModelID=m.ProductModelID
where p.Color='Blue'
end;


exec spGetBlueProductsandModels;

select * from sys.procedures;
