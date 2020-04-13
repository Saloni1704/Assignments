Use AdventureWorks2017
Go

create procedure Marketing.GetProductByColor
@Color nvarchar(16)
as
SET NOCOUNT ON;
BEGIN
select p.ProductId,
p.Name,p.ListPrice as Price,
p.Color,p.Size,p.SizeUnitMeasureCode as UnitOfMeasure
from
Production.Product as p
where(p.Color=@Color)OR (p.Color is NULL AND @Color is null);
end;

exec Marketing.GetProductByColor 'Blue';

exec Marketing.GetProductByColor Null;