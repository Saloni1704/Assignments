CREATE TABLE FactProductInventory(

   ProductId INT NOT NULL,
   ProductName VARCHAR(30) NOT NULL,
   Quantity DATETIME NOT NULL,
   TotalCost MONEY NOT NULL,
    ModifiedDate datetime NOT NULL,
   );

   ALTER TABLE FactProductInventory 
   ADD CONSTRAINT FPI_CONSTRAINT 
   UNIQUE CLUSTERED(ProductId);

   CREATE NONCLUSTERED COLUMNSTORE INDEX NCC_FactProductInventory 
   ON
   FactProductInventory (ProductId,ModifiedDate,TotalCost,Quantity)

   CREATE TABLE FactInternetSales(
   InternetSalesId INT NOT NULL,
   ProductId INT NOT NULL,
   SalesDate DATETIME NOT NULL,
   Feedback INT,
   );

   CREATE NONCLUSTERED COLUMNSTORE INDEX NCI_FactInternetSales
   ON
   FactInternetSales
   (
   InternetSalesId,
   ProductId,
   SalesDate
   );

   DROP INDEX NCI_FactInternetSales ON FactInternetSales;

   DROP INDEX NCC_FactProductInventory ON FactInternetSales;