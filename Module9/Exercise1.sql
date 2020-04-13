
create Procedure Reports.spGetProductColors
as 
SET NOCOUNT ON;
BEGIN
select DISTINCT p.Color from Production.Product as p
where p.Color is not null;
end
Go

exec Reports.spGetProductColors;

create procedure Reports.GetProductsandModels
as
SET NOCOUNT ON;
BEGIN
SELECT p.ProductID,p.ProductName,p.ProductNumber,p.SellStartDate,
p.SellEndDate,p.Color,m.ProductModelID,
COALESCE(ed.Description,id.Description,p.ProductName) AS EnglishDescription,
COALESCE(fd.Description,id.Description,p.ProductName) AS FrenchDescription,
COALESCE(cd.Description,id.Description,p.ProductName) AS ChineseDescription
	FROM Marketing.Product AS p
	LEFT OUTER JOIN Marketing.ProductModel AS m ON p.ProductModelID = m.ProductModelID
	LEFT OUTER JOIN Marketing.ProductDescription AS ed 
	ON m.ProductModelID = ed.ProductModelID AND ed.LanguageID = 'en'
	LEFT OUTER JOIN Marketing.ProductDescription AS fd
	ON pm.ProductModelID = fd.ProductModelID AND fd.LanguageID = 'fr'
	LEFT OUTER JOIN Marketing.ProductDescription AS cd
	ON pm.ProductModelID = cd.ProductModelID AND cd.LanguageID = 'zh-cht'
	LEFT OUTER JOIN Marketing.ProductDescription AS id
	ON pm.ProductModelID = id.ProductModelID AND id.LanguageID = ''
END

EXEC Reports.GetProductsandModels;
GO
