USE Northwind
GO
WITH COUNTBYCOUTRY AS
(
SELECT Country, COUNT(*) AS 'CNT'
FROM Customers
GROUP BY Country
)
SELECT Country, COUNT(*) AS 'COUNT'
FROM Customers
GROUP BY Country
HAVING COUNT(*)=(SELECT MAX(CNT) FROM COUNTBYCOUTRY)
GO
WITH cte AS
(
SELECT o.CustomerID, SUM(UnitPrice*Quantity*(1-Discount)) AS 'Amount'
FROM Orders o
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.CustomerID
)
SELECT *, cte.Amount
FROM Customers c
INNER JOIN cte ON c.CustomerID=cte.CustomerID
ORDER BY cte.Amount
GO
WITH cte AS
(
SELECT o.CustomerID, SUM(UnitPrice*Quantity*(1-Discount)) AS 'Amount'
FROM Orders o
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.CustomerID
)
SELECT *, (SELECT TOP 1 Amount FROM cte WHERE cte.CustomerID = c.CustomerID) AS 'Amount'
FROM Customers c
ORDER BY Amount
GO

