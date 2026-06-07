/*
 * Analytic Function: 
 * FIRST_VALUE, LAST_VALUE, LEAD, LAG, PERCENT_RANK, CUME_DIST, 
 * PERCENTILE_CONT and PERCENTILE_DISC
 */
USE AP
GO
SELECT VendorID, InvoiceTotal,
FIRST_VALUE(InvoiceTotal) OVER (ORDER BY InvoiceTotal ASC) 'f value',
LAST_VALUE(InvoiceTotal) OVER (ORDER BY InvoiceTotal ASC) 'l value',
LEAD(VendorID) OVER (ORDER BY InvoiceTotal ASC) 'lead',
LAG(VendorID) OVER (ORDER BY InvoiceTotal ASC) 'lag',
PERCENT_RANK() OVER (ORDER BY InvoiceTotal ASC) 'perc rank',
CUME_DIST() OVER (ORDER BY InvoiceTotal ASC) 'cume dist'
FROM Invoices
GO
SELECT VendorID, InvoiceTotal,
PERCENTILE_CONT (0.5) WITHIN GROUP(ORDER BY InvoiceTotal) OVER (PARTITION BY InvoiceTotal ) 'per cont',
PERCENTILE_DISC(0.5) WITHIN GROUP(ORDER BY InvoiceTotal) OVER (PARTITION BY InvoiceTotal) 'per dist'
FROM Invoices
GO