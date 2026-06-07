USE Northwind
GO
SELECT COUNT(*)
FROM Customers

SELECT COUNT(CustomerID) 'Total Customer'
FROM Customers

SELECT COUNT(Fax)
FROM Customers
GO
SELECT Country, COUNT(*) 'Customer count'
FROM Customers
GROUP BY Country

SELECT Country,City, COUNT(*) 'Customer count'
FROM Customers
GROUP BY Country, City
GO
SELECT Country, COUNT(*) 'Customer count'
FROM Customers
GROUP BY Country
HAVING Country = 'USA'
GO
SELECT Country, COUNT(*) 'Customer count'
FROM Customers
WHERE Country = 'USA'
GROUP BY Country
GO
SELECT Country, COUNT(*) 'Customer count'
FROM Customers
WHERE Country = 'USA'
GROUP BY Country
GO
SELECT Country, COUNT(*) 'Customer count'
FROM Customers
WHERE City = 'Albuquerque'
GROUP BY Country
GO
SELECT Country, COUNT(*) 'Customer count'
FROM Customers
GROUP BY Country
HAVING Count(*) > 2
GO
SELECT AVG(UnitPrice)
FROM Products
GO
SELECT *
FROM Products
WHERE UnitPrice> (SELECT AVG(UnitPrice) FROM Products)
GO
SELECT *
FROM Products
WHERE UnitPrice= (SELECT MAX(UnitPrice) FROM Products)
GO
SELECT *
FROM Products
WHERE UnitPrice= (SELECT MIN(UnitPrice) FROM Products)
GO
SELECT o.OrderID, SUM(UnitPrice*Quantity*(1-Discount)) Amount
FROM Orders o
INNER JOIN [Order Details] od ON o.OrderID=od.OrderID
GROUP BY o.OrderID
GO
SELECT DISTINCT	Country , 
		COUNT(*) OVER (PARTITION BY Country) AS 'Customer count'	
FROM Customers
GO
SELECT Country, COUNT(*) 'Customer count'
FROM Customers
GROUP BY Country
WITH CUBE
GO
SELECT Country, COUNT(*) 'Customer count'
FROM Customers
GROUP BY Country
WITH ROLLUP
GO
SELECT Country,City, COUNT(*) 'Customer count'
FROM Customers
GROUP BY Country, City
WITH CUBE
GO
SELECT Country,City, COUNT(*) 'Customer count'
FROM Customers
GROUP BY GROUPING SETS(Country, City)
GO
SELECT Country,City, COUNT(*) 'Customer count'
FROM Customers
GROUP BY GROUPING SETS(Country, City, ())

