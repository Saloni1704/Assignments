Use AdventureWorks2017
GO

select * from dbo.DatabaseLog;

SELECT d.DatabaseLogID,
Eventd.value('PostTime[1]','datetime2') As PostTime
FROM dbo.DatabaseLog AS d
CROSS APPLY
d.XmlEvent.nodes('/EVENT_INSTANCE') as EventInfo(Eventd);

DECLARE @xmldoc AS int, @xml AS xml;
SELECT @xml=XmlEvent FROM dbo.DatabaseLog;
EXEC sp_xml_preparedocument @xmldoc OUTPUT,@xml;

SELECT * FROM OPENXML(@xmldoc, 'EVENT_INSTANCE',3)
WITH (
PostTime datetime2
)
EXEC sp_xml_removedocument @xmldoc;
