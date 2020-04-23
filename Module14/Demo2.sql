create xml schema collection BookSchemaCollection
as
N'<?xml version="1.0"?>
<xsd:schema xmlns:xsd="http://www.w3.org/2001/XMLSchema">
<xsd:element name="Book">
<xsd:complexType>
<xsd:sequence>
<xsd:element name="title" type="xsd:string"/>
<xsd:element name="author" type="xsd:string"/>
<xsd:element name="published" type="xsd:date"/>
<xsd:element name="version" type="xsd:decimal"/>
</xsd:sequence>
</xsd:complexType>
</xsd:element>
</xsd:schema>';

SELECT *  FROM sys.xml_schema_collections; 
SELECT *  FROM sys.xml_schema_namespaces; 


CREATE TABLE XmlUntypedata (
SessionID int PRIMARY KEY,
WindowSettings xml
);

CREATE TABLE XmlTypeData (
SessionID int PRIMARY KEY,
WindowSettings xml (BookSchemaCollection)
);

Insert into XmlUntypeData(SessionID,WindowSettings) values(1,'
<order id="ord123457">
		<customer id="cust0067">
			<first-name>Shai</first-name>
			<last-name>Bassli</last-name>
		</customer>
</order>');


Insert into XmlTypeData(SessionID,WindowSettings) values(2,'
<Book>
	<title>Titanic</title>
	<author>Ishika</author>
	<published>2002-09-24</published>
	<version>3.0</version>
	
</Book>
<Book>
	<title>Titanic</title>
	<author>Ishika</author>
	<published>2002-09-24</published>
	<version>3.0</version>
	
</Book>');

select * from XmlTypeData
select * from XmlUntypedata