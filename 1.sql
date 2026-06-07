USE R61
GO
CREATE TABLE products
(
	productid INT PRIMARY KEY,
	[name] NVARCHAR(30) NOT NULL,
	price MONEY NOT NULL
)
GO
DECLARE @i INT =1
WHILE @i <=10
BEGIN
	INSERT INTO products VALUES (@i, 'P' +CAST(@i AS VARCHAR), CEILING(RAND()*1000))
	SET @i += 1 --@i = @i +1
END
GO
CREATE TABLE tproducts
(
	productid INT PRIMARY KEY,
	[name] NVARCHAR(30) NOT NULL,
	price MONEY NOT NULL
)
INSERT INTO tproducts
VALUES (1, 'P1', 100), (11, 'P11', 100), (7, 'P7', 100)
GO
SELECT * FROM tproducts
SELECT * FROM products
GO
MERGE products AS t
USING tproducts AS s
ON t.productid = s.productid

WHEN MATCHED THEN
	UPDATE  SET 
	t.[name]=s.[name], t.price=s.price
WHEN NOT MATCHED BY TARGET THEN
	INSERT (productid, [name], price) VALUES (s.productid, s.[name], s.price)
--WHEN NOT MATCHED BY SOURCE THEN
--	DELETE
;
GO
SELECT * FROM products