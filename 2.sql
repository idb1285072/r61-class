DECLARE @count INT
SET @count = 14
SET @count = @count +1
SELECT @count
GO
DECLARE @n INT, @d DATE
SET @n = 15
SET @d = GETDATE()
SELECT @n, @d
GO
DECLARE @n INT, @d DATE
SELECT @n = 15, @d = GETDATE()
SELECT @n, @d
GO
DECLARE @n INT, @d DATE
SELECT @n = COUNT(*), @d = GETDATE() FROM Customers
SELECT @n, @d
GO
DECLARE @tbl TABLE (
	id NVARCHAR(5),
	company NVARCHAR(80)

)
INSERT INTO @tbl
SELECT CustomerID, CompanyName
FROM Customers
WHERE Country='Brazil'
SELECT * FROM @tbl