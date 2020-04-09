 CREATE VIEW vwEmployeeList AS
SELECT Title, FirstName, MiddleName, LastName
FROM person.person
INNER JOIN HumanResources.Employee
ON Person.BusinessEntityID = Employee.BusinessEntityID
WHERE Employee.CurrentFlag = 1;
GO

select * from vwEmployeeList

select * from vwEmployeeList order by FirstName;

select OBJECT_DEFINITION(OBJECT_ID(N'Person.vwEmployeeList'))as [VIEW_DEFINITION]

ALTER VIEW vwEmployeeList
WITH ENCRYPTION
AS
SELECT 
 TItle,FirstName, MiddleName, LastName
FROM person.person
INNER JOIN HumanResources.Employee
ON Person.BusinessEntityID = Employee.BusinessEntityID
WHERE Title!=null;
GO

select OBJECT_DEFINITION(OBJECT_ID(N'Person.vwEmployeeList'))as [VIEW_DEFINITION]