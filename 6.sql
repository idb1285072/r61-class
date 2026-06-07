USE AP
GO
/*
1. Write a query to retrieve last 5 those invoices record whose invoice total is equal to the sum of
payment total & credit total. – 3
2. Write a query to retrieve those invoices record whose date is later than 01/01/2016 or invoice
total is more than 500 and invoice total must be greater than sum of payment total and credit
total. – 3
3. Write a query to retrieve those invoices whose vendor states are all except ‘CA’, ‘NV’, ‘OR’ and
invoice dates are later than 01/01/2016. – 3
4. Write a query to retrieve invoices from 01/05/2016 to 31/05/2016. – 2
5. Write a query to retrieve vendors whose vendor city starts with ‘SAN’. – 1
6. Write a query to retrieve vendors whose contact name has one of the following characters: a, e,
i, o, u. – 1
7. Write a query to find all vendors whose first letter of state starts with N and the next letter is
one of A through J. – 1
8. Write a query to find all vendors whose first letter of state starts with N and the next letter is
not in K through Y. – 1
9. Write a query to retrieve 11 through 20 records of vendors. – 2
10. Write a group query to retrieve invoices those average of invoice total is more than 2000. – 5
*/
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

