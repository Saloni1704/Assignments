Use InternetSales
Go

alter database InternetSales
add filegroup SaleFG contains
MEMORY_OPTIMIZED_DATA
Go

ALTER DATABASE InternetSales   
ADD FILE   
(  
    NAME = SalesData,  
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SalesData.ndf' 

)  
TO FILEGROUP SaleFG;  

create table dbo.ShoppingCart
(
SessionId int not null,
TimeAdded datetime not null,
CustomerKey int not null,
ProductKey int not null,
Quantity int not null
primary key nonclustered(SessionId,ProductKey)
)
with(MEMORY_OPTIMIZED=ON,DURABILITY=SCHEMA_AND_DATA)

INSERT INTO
dbo.ShoppingCart values(1,SYSDATETIME(),2,3,1)

INSERT INTO
dbo.ShoppingCart values(1,SYSDATETIME(),2,4,1)

SELECT * from dbo.ShoppingCart

