Use InternetSales
Go

create procedure dbo.AddItemToCart
@SessionId int,
@TimeAdded datetime,
@CustomerKey int,
@ProductKey int,
@Quantity int
with NATIVE_COMPILATION,SCHEMABINDING,EXECUTE AS OWNER
AS
begin atomic
WITH(TRANSACTION ISOLATION LEVEL = SNAPSHOT,
LANGUAGE = 'us_English')
Insert into dbo.ShoppingCart values(@SessionId,@TimeAdded,@CustomerKey,@ProductKey,
@Quantity)
end
go


create procedure dbo.DeleteItemFromCart
@SessionId int,
@ProductKey int
with NATIVE_COMPILATION,SCHEMABINDING,EXECUTE AS OWNER
AS
begin atomic
WITH(TRANSACTION ISOLATION LEVEL = SNAPSHOT,
LANGUAGE = 'us_English')
Delete from dbo.ShoppingCart where SessionId=@SessionId and ProductKey=@ProductKey
end
go

create procedure dbo.EmptyCart
@SessionId int
with NATIVE_COMPILATION,SCHEMABINDING,EXECUTE AS OWNER
AS
begin atomic
WITH(TRANSACTION ISOLATION LEVEL = SNAPSHOT,
LANGUAGE = 'us_English')
Delete from dbo.ShoppingCart where SessionId=@SessionId
end
Go

Declare @sysdatetime datetime=SYSDATETIME()
exec dbo.AddItemToCart @SessionId=1,@CustomerKey=2,@ProductKey=9,@Quantity=1,@TimeAdded=@sysdatetime;

Select * from dbo.ShoppingCart

exec dbo.DeleteItemFromCart 1,4

Select * from dbo.ShoppingCart

exec dbo.EmptyCart 1

Select * from dbo.ShoppingCart