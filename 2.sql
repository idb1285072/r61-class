USE AP
GO
--3
SELECT i.*
FROM Invoices i 
INNER JOIN Vendors v  ON i.VendorID= v.VendorID
WHERE v.VendorState NOT IN ('CA', 'NV', 'OR') AND
i.InvoiceDate <= '2016-01-01'
