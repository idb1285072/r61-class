USE Northwind
GO
SELECT c.CustomerID, CompanyName, OrderDate, ShippedDate
FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
ORDER BY c.CustomerID
GO
SELECT c.CustomerID, o.OrderID, o.OrderDate,od.ProductID, od.Quantity
FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
ORDER BY c.CustomerID
GO
SELECT c.CustomerID, o.OrderID, o.OrderDate, p.ProductName, od.Quantity
FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID
ORDER BY c.CustomerID
GO
SELECT c.CustomerID, o.OrderID, o.OrderDate, p.ProductName, od.Quantity,od.UnitPrice, od.Discount, od.UnitPrice*od.Quantity *(1- od.Discount) 'Amount'
FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID
ORDER BY c.CustomerID
GO
SELECT c.CustomerID, CompanyName,OrderID, OrderDate, ShippedDate
FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.Country = 'Finland'
ORDER BY c.CustomerID
GO
SELECT c.CustomerID, CompanyName,OrderID, OrderDate, ShippedDate
FROM Customers c
LEFT OUTER JOIN Orders o ON c.CustomerID = o.CustomerID
ORDER BY c.CustomerID
GO
SELECT c.CustomerID, CompanyName,OrderID, OrderDate, ShippedDate
FROM Customers c
LEFT OUTER JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE OrderID IS NULL
ORDER BY c.CustomerID
GO
SELECT c.CustomerID, CompanyName,OrderID, OrderDate, ShippedDate
FROM Orders o
RIGHT OUTER JOIN Customers c ON c.CustomerID = o.CustomerID
ORDER BY c.CustomerID
GO
SELECT e.EmployeeID, e.City 'Emp. City', c.CustomerID, c.City 'Cust. City'
FROM Employees e
FULL OUTER JOIN Customers c ON e.City = c.City
GO
SELECT c.CustomerID, o.OrderID
FROM Customers c CROSS JOIN Orders o