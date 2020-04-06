

create sequence Customer.CustomerId int start with 1 increment by 1;


create table Customer.Customers(CustomerId int not null,CustomerName varchar(30) not null);

create table Customer.CustomerDetails(CustomerDetailId int primary key Identity(1,1)not null,
Address varchar(30) not null,ContactNumber varchar(20) not null,CustomerId int not null);

create table Customer.Orders(OrderId int primary key Identity(1,1) not null,CustomerId int not null)


INSERT INTO Customer.Customers(CustomerId,CustomerName) 
VALUES
(NEXT VALUE FOR Customer.CustomerId, 'saloni')
GO


INSERT INTO Customer.CustomerDetails(Address,ContactNumber,CustomerId) 
VALUES
('mds', '123',NEXT VALUE FOR Customer.CustomerId)
GO

INSERT INTO Customer.Orders(CustomerId) 
VALUES
(NEXT VALUE FOR Customer.CustomerId)
GO

