USE AP
GO
SELECT InvoiceID, AVG(InvoiceTotal) 'Avg. Inv. Total'
FROM Invoices
GROUP BY InvoiceID
HAVING AVG(InvoiceTotal)> 2000