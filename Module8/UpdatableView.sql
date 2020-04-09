create table 

CREATE VIEW Sales.vNewCustomer
AS
SELECT CustomerID, FirstName, LastName FROM Sales.CustomerPII;
GO

SELECT * FROM Sales.vNewCustomer ;

INSERT INTO Sales.vNewCustomer(CustomerID,FirstName,LastName)
VALUES(2000,'abc', 'def');
GO
SELECT * from Sales.CustomerPII ;