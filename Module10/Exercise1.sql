CREATE FUNCTION dbo.FormatPhoneNumber(@PhoneNo VARCHAR(20))
RETURNS VARCHAR(20)
AS
BEGIN
DECLARE @Formatted VARCHAR(20)

IF (LEN(@PhoneNo) <> 10)
    SET @Formatted ='invalid phone no.'
ELSE
    SET @Formatted = LEFT(@PhoneNo, 3) + '-' + SUBSTRING(@PhoneNo, 4, 3)+ '-' + SUBSTRING(@PhoneNo, 7, 4)

RETURN @Formatted
END
GO

drop function
FormatPhoneNumber

select  dbo.FormatPhoneNumber('34537786544434') ;