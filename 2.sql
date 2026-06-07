USE R61
GO
CREATE TABLE products
(
	id INT IDENTITY PRIMARY KEY,
	[name] NVARCHAR(30) NOT NULL,
	stock INT NOT NULL DEFAULT 0
)
GO
INSERT INTO products ([name]) VALUES ('P1'),('P2'), ('P3')
GO
CREATE TABLE stockin
(
	id INT IDENTITY PRIMARY KEY,
	[date] DATETIME2 NOT NULL,
	productid INT NOT NULL REFERENCES products(id),
	quantity INT NOT NULL
)
GO
SELECT * FROM products
GO
CREATE TRIGGER trInsertStock
ON stockin
AFTER INSERT
AS
BEGIN
	DECLARE @pid INT, @q INT
	SELECT @pid=productid, @q=quantity FROM inserted
	UPDATE products
	SET stock += @q
	WHERE id=@pid
END
GO
SELECT * FROM products
INSERT INTO stockin ([date], productid, quantity) VALUES (GETDATE(), 2, 200)
SELECT * FROM products
GO
CREATE TRIGGER trUpdateStock
ON stockin
AFTER UPDATE
AS
BEGIN
	DECLARE @opid INT, @oq INT, @npid INT, @nq INT
	SELECT @opid=productid, @oq=quantity FROM deleted
	SELECT @npid=productid, @nq=quantity FROM inserted
	IF UPDATE(productid)
	BEGIN
		UPDATE products
		SET stock -= @oq
		WHERE id=@opid
		UPDATE products
		SET stock += @nq
		WHERE id=@npid
	END
	IF UPDATE(quantity)
	BEGIN
		UPDATE products
		SET stock += (@nq -@oq)
		WHERE id=@npid
	END
END
GO
SELECT * FROM products
SELECT * FROM stockin
UPDATE stockin
SET productid = 1
WHERE id=15
SELECT * FROM products
SELECT * FROM stockin
UPDATE stockin
SET quantity = 100
WHERE id=14
SELECT * FROM products
SELECT * FROM stockin
GO