USE Northwind
GO
/*
	SELECT column-list
	FROM source
*/
SELECT *
FROM Customers
GO
SELECT CustomerID, CompanyName, Phone, Country
FROM Customers
GO
SELECT Customers.CustomerID, Customers.CompanyName
FROM Customers
GO
SELECT c.CustomerID, c.CompanyName, c.Fax
FROM Customers c
GO
SELECT CustomerID AS Id, 
CompanyName [Company Name], 
Phone, 
'From'=Country
FROM Customers
GO
SELECT CustomerID, CompanyName, Phone,City, Country
FROM Customers
WHERE Country = 'Finland'
GO
SELECT *
FROM Customers
WHERE City ='Helsinki'
GO
/*
=
>
>=
<
<=
<> OR !=
*/
SELECT CustomerID, CompanyName, Phone,City, Country
FROM Customers
WHERE Country <> 'Finland'
GO
SELECT *
FROM Products
WHERE UnitPrice >= 20
GO
/*
AND 
OR
NOT
*/
SELECT CustomerID, CompanyName, Phone,City, Country
FROM Customers
WHERE Country = 'Finland' OR Country = 'Germany'
GO
SELECT CustomerID, CompanyName, Phone,City, Country
FROM Customers
WHERE Country = 'Finland' OR Country = 'Germany' OR Country = 'UK'
GO
SELECT CustomerID, CompanyName, Phone,City, Country
FROM Customers
WHERE Country IN ('Finland', 'Germany', 'UK')
GO
SELECT CustomerID, CompanyName, Phone,City, Country
FROM Customers
WHERE Country IN ('Finland', 'Germany', 'UK')
GO
SELECT CustomerID, CompanyName, Phone,City, Country
FROM Customers
WHERE Country NOT IN ('Finland', 'Germany', 'UK')
GO
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice >= 20 AND UnitPrice <= 30
GO
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 20 AND 30
GO