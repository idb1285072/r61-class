USE R61
GO
CREATE TABLE customers
(
	customerid NCHAR(5) PRIMARY KEY,
	companyname NVARCHAR(40) NOT NULL,
	phone NVARCHAR(24) NULL,
	fax NVARCHAR(24) NULL
)
GO
CREATE VIEW vCustWithFax
AS
SELECT *
FROM customers
WHERE fax IS NOT NULL
GO
SELECT * FROM vCustWithFax
GO
EXEC sp_helptext vCustWithFax
GO
CREATE VIEW vCustWithoutFax
WITH ENCRYPTION
AS
SELECT *
FROM customers
WHERE fax IS NULL
GO
EXEC sp_helptext vCustWithoutFax