--Primary Index
CREATE PRIMARY XML INDEX PXmlIndex
ON XmlTypeData (WindowSettings);


--Secondary Index
CREATE  XML INDEX SXmlIndex_Path
ON XmlTypeData (WindowSettings)
using  xml Index PXmlIndex for path

--Show Indexes
select * from sys.xml_indexes

---Create Index on Table that has not Primary Key 

Create table ProEx(
Id int,
data xml
);

Create Primary xml Index PIndex on ProEx(data)--error must have Primary Key on table

