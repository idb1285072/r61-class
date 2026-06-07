USE AP
GO
--1
SELECT TOP 10 *
FROM Invoices
WHERE InvoiceTotal = PaymentTotal+CreditTotal
ORDER BY InvoiceID DESC
GO
--2
SELECT *
FROM Invoices
WHERE InvoiceDate > '2016-01-01'
OR (InvoiceTotal > 500 AND InvoiceTotal> (PaymentTotal+CreditTotal))
GO
--3
SELECT i.*
FROM Invoices i
INNER JOIN Vendors v ON i.VendorID = v.VendorID
WHERE v.VendorState NOT IN ('CA','NA', 'OR')
AND CAST(i.InvoiceDate AS DATE) > '2016-01-01'
--4
SELECT *
FROM Invoices
WHERE InvoiceDate BETWEEN '2016-05-01' AND '2016-05-31'
GO
--5
SELECT *
FROM Vendors
WHERE VendorCity LIKE 'SAN%'
GO
--6
SELECT *
FROM Vendors
WHERE VendorContactFName LIKE '%[aeiou]%'
OR VendorContactLName LIKE '%[aeiou]%'
GO
--7
SELECT *
FROM Vendors
WHERE VendorState LIKE 'N[A-J]%'
GO
--8
SELECT *
FROM Vendors
WHERE VendorState LIKE 'N[^K-Y]%'
GO
--9
SELECT *
FROM Vendors
ORDER BY VendorID
OFFSET 10 ROWS
FETCH NEXT 10 ROWS ONLY
GO
--10
SELECT InvoiceID,AVG(InvoiceTotal) 'Avg. Inv. Total'
FROM Invoices
GROUP BY InvoiceID
HAVING AVG(InvoiceTotal) > 2000
GO
--11
SELECT InvoiceID, InvoiceDate, AVG(InvoiceTotal) 'Avg. Inv. Total'
FROM Invoices
GROUP BY InvoiceID,InvoiceDate
WITH CUBE
GO
--12
SELECT InvoiceID,InvoiceDate, AVG(InvoiceTotal) 'Avg. Inv. Total'
FROM Invoices
GROUP BY InvoiceID,InvoiceDate
WITH ROLLUP
GO
--13
SELECT InvoiceID,InvoiceDate, AVG(InvoiceTotal) 'Avg. Inv. Total'
FROM Invoices
GROUP BY GROUPING SETS(InvoiceID,InvoiceDate, ())
GO
--14
SELECT InvoiceID , 
AVG(InvoiceTotal) OVER (PARTITION BY InvoiceID) 'Avg. Inv. Total'
FROM Invoices
GO
--15
SELECT *
FROM Vendors
WHERE VendorID IN (SELECT DISTINCT VendorID  FROM Invoices)
GO
--16
SELECT *
FROM Vendors
WHERE VendorID = ANY(SELECT DISTINCT VendorID  FROM Invoices)
GO
--17
--Vendors with no ivoices
SELECT *
FROM Vendors
WHERE VendorID <> ALL(SELECT DISTINCT VendorID  FROM Invoices)
--18
SELECT *
FROM Vendors
WHERE VendorID = SOME(SELECT DISTINCT VendorID  FROM Invoices)
GO
--19
SELECT VendorID, (SELECT SUM(InvoiceTotal) FROM Invoices WHERE VendorID= v.VendorID) 'Sum'
FROM Vendors v
GO
--20 
IF EXISTS(SELECT 1 FROM Invoices i WHERE i.VendorID = 10 )
	print '10 has invoice'
ELSE
	print '10 has NO invoice'
GO
IF NOT EXISTS(SELECT 1 FROM sys.objects WHERE type= 'U' AND [name]='Vendors')
BEGIN
	PRINT 'Vendors table exists'
END
GO
--21
WITH CTE AS (
SELECT  VendorID  FROM Invoices
)
SELECT *
FROM Vendors
WHERE VendorID IN (SELECT VendorID FROM CTE)
GO
--22
INSERT INTO Vendors(VendorName, VendorCity, VendorState, VendorZipCode, DefaultTermsID, DefaultAccountNo)
VALUES('My Vendor','Pasadena','CA', '91186', 3, 565)
GO
--23
DELETE FROM Vendors WHERE VendorID=124
GO
--24
SELECT VendorID,
CASE
	WHEN VendorPhone IS NULL THEN 'NA'
	ELSE VendorPhone
END 'Phone'
FROM Vendors
GO
--25
SELECT FORMAT(CAST('01-June-2019 10:00 AM' AS DATE), 'yyyy-MM-dd')
GO
--26
SELECT FORMAT(CAST('01-June-2019 10:00 AM' AS DATETIME), 'hh:mm:ss')
GO
--27
SELECT VendorID,AVG(InvoiceTotal) OVER(ORDER BY VendorID) 'Net',
RANK() OVER(ORDER BY VendorID) 'RANK',
DENSE_RANK() OVER(ORDER BY VendorID) 'DENSE_RANK',
NTILE(3) OVER(ORDER BY VendorID) 'NTILE 3'
FROM Invoices
GO
--28
SELECT InvoiceID, InvoiceDate, AVG(InvoiceTotal) 'AvgInvoiceTotal'
INTO InvoiceAvg
FROM Invoices
GROUP BY InvoiceID,InvoiceDate
GO
--29
UPDATE
Vendors 
SET VendorContactFName='Mrs', VendorContactLName='T'
WHERE VendorID=124
GO
--30
DELETE
Vendors 
WHERE VendorContactFName='Mrs' AND VendorContactLName='T'
GO
--31
SELECT TOP 3 InvoiceID,  InvoiceTotal
FROM Invoices
ORDER BY InvoiceTotal DESC
GO
--32
SELECT  DISTINCT VendorID, InvoiceTotal
FROM Invoices
WHERE InvoiceTotal BETWEEN 500 AND 1000
GO

