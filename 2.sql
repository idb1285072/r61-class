USE Northwind
GO
/*
	% - 0 or more character
	_ - 1 character
	[] - any one in the set
	^ - except
*/
SELECT *
FROM Customers
WHERE CustomerID LIKE 'A%'
GO
SELECT *
FROM Customers
WHERE CustomerID LIKE '%A'
GO
SELECT *
FROM Customers
WHERE CustomerID LIKE '%A%'
GO
SELECT *
FROM Customers
WHERE CustomerID LIKE 'ALF_I'
GO
SELECT *
FROM Customers
WHERE CustomerID LIKE '[ADE]%'
GO
SELECT *
FROM Customers
WHERE CustomerID LIKE '[A-D]%'
GO
SELECT *
FROM Customers
WHERE CustomerID LIKE '[^A-D]%'
GO
SELECT *
FROM Customers
WHERE CustomerID LIKE '%[MPZ]'