USE Northwind
GO
--FROM clause as table source
--WHERE/Having clause as filter
--IN column List
SELECT c.CustomerID, c.CompanyName, c.Phone FROM
(SELECT *
FROM Customers) AS c
GO
SELECT * FROM Customers
WHERE CustomerID NOT IN (SELECT CustomerID FROM Orders)
GO
SELECT * FROM Customers
WHERE CustomerID <> ALL (SELECT CustomerID FROM Orders)
GO
SELECT ProductName, UnitPrice, (SELECT AVG(UnitPrice) FROM Products)
FROM Products
GO
SELECT CustomerID, CompanyName, 
(SELECT MAX(OrderDate) FROM Orders o WHERE o.CustomerID= CustomerID) 'Last Order date'
FROM Customers
GO
