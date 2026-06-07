CREATE DATABASE InventoryDb
ON
(
	name='ineventory_data_1',
	filename='C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\ineventory_data_1.mdf',
	size=25mb,
	maxsize=100mb,
	filegrowth=5%
)
LOG ON
(
	name='ineventory_log_1',
	filename='C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\ineventory_log_1.ldf',
	size=25mb,
	maxsize=50mb,
	filegrowth=1mb
)
GO
USE InventoryDb
GO
CREATE TABLE colors
(
	colorid INT PRIMARY KEY,
	colorname NVARCHAR(20) NOT NULL
)
GO
CREATE TABLE lots
(
	lotid INT PRIMARY KEY,
	lotno NVARCHAR(15) NOT NULL,
	quantity INT NOT NULL,
	unitprice MONEY NOT NULL,
	vat FLOAT NOT NULL
)
GO
CREATE TABLE items
(
	itemid INT PRIMARY KEY,
	itemno NVARCHAR(15) NOT NULL,
	itemname NVARCHAR(30) NOT NULL,
	colorid INT NOT NULL REFERENCES colors(colorid),
	lotid INT NOT NULL REFERENCES lots(lotid)
)
GO
BEGIN TRAN
BEGIN TRY
	INSERT INTO colors VALUES 
	(1, 'Red'),
	(2, 'Blue'),
	(3, 'Pink'),
	(4, 'Black'),
	(5, 'White')
	INSERT INTO lots VALUES
	(1, 'Lot 1', 6, 1200, .12),
	(2, 'Lot 2', 12, 1500, .15),
	(3, 'Lot 3', 6, 1350, .15),
	(4, 'Lot 4', 12, 1500, .15)

	INSERT INTO items VALUES
	(1, 'Item 1', 'T-Shirt', 1, 1),
	(2, 'Item 2', 'Camp-Shirt', 2, 2),
	(3, 'Item 3', 'Polo-Shirt', 2, 1),
	(4, 'Item 4', 'Dress-Shirt', 4, 2),
	(5, 'Item 5', 'Long sleeve-Shirt', 5, 2)
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN
	DECLARE @m VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR(@m, 16, 1)
END CATCH
GO
--index
CREATE NONCLUSTERED INDEX ix_itemname
ON items (itemname)
GO
EXEC sp_helpindex 'items'
GO
--7
--Show item name, item no, color, quantity, unitprice, vat
SELECT itemname, itemno, colorname, quantity, unitprice, CAST(vat*100 as VARCHAR)+'%' as vat
FROM items i 
INNER JOIN colors c ON i.colorid = c.colorid
INNER JOIN lots l ON i.lotid = l.lotid
GO
--8
--Show item name, item no, color, quantity, unitprice, vat, vat amount and net price
SELECT itemname, itemno, colorname, quantity, unitprice, vat, unitprice*quantity*vat 'vat amount', unitprice*quantity +unitprice*quantity*vat 'net price'
FROM items i 
INNER JOIN colors c ON i.colorid = c.colorid
INNER JOIN lots l ON i.lotid = l.lotid
GO
--show color, item name, lot no, qunatity, unitprice, vat
-- include all colors
SELECT colorname,itemname, itemno,  quantity, unitprice, CAST(vat*100 as VARCHAR)+'%' as vat
FROM colors c
LEFT OUTER JOIN items i ON i.colorid = c.colorid
LEFT OUTER JOIN lots l ON i.lotid = l.lotid
GO
--show color, item name, lot no, qunatity, unitprice, vat
-- include all lots
SELECT lotno, colorname,itemname, itemno,  quantity, unitprice, CAST(vat*100 as VARCHAR)+'%' as vat
FROM lots l
LEFT OUTER JOIN items i ON i.lotid = l.lotid
LEFT OUTER JOIN colors c ON c.colorid = i.colorid
GO
--show item name, item no, color, quantity, unitprice, vat
--for color Red
SELECT itemname, itemno, colorname, quantity, unitprice, CAST(vat*100 as VARCHAR)+'%' as vat
FROM items i 
INNER JOIN colors c ON i.colorid = c.colorid
INNER JOIN lots l ON i.lotid = l.lotid
WHERE c.colorname='Red'
GO
CREATE VIEW vItemsRed
WITH ENCRYPTION,SCHEMABINDING
AS
SELECT itemname, itemno, colorname, quantity, unitprice, CAST(vat*100 as VARCHAR)+'%' as vat
FROM dbo.items i 
INNER JOIN dbo.colors c ON i.colorid = c.colorid
INNER JOIN dbo.lots l ON i.lotid = l.lotid
WHERE c.colorname='Red'
GO
SELECT * FROM vItemsRed
GO
EXEC sp_helptext 'vItemsRed'
GO
--sub query
SELECT colorname, (SELECT (1+l1.vat)*l1.unitprice*l1.quantity FROM lots l1 WHERE l1.lotid = l.lotid) as 'Amount'
FROM dbo.items i 
INNER JOIN dbo.colors c ON i.colorid = c.colorid
INNER JOIN dbo.lots l ON i.lotid = l.lotid
--CTE
with amountcte
AS
(
	SELECT lotid, (1+vat)*unitprice*quantity 'netprice' FROM lots
)
SELECT colorname, netprice
FROM dbo.items i 
INNER JOIN dbo.colors c ON i.colorid = c.colorid
INNER JOIN amountcte l ON i.lotid = l.lotid
GO
CREATE PROC sInsertLot @no NVARCHAR(15), @q INT, @u MONEY, @v FLOAT = .15, @id INT OUTPUT
AS
SELECT @id=ISNULL(MAX(lotid),0)+1
FROM lots
BEGIN TRY
	INSERT INTO lots VALUES (@id, @no, @q, @u, @v)
	RETURN 0
END TRY
BEGIN CATCH
	DECLARE @m VARCHAR(500) = ERROR_MESSAGE(), @n INT = ERROR_NUMBER()
	RAISERROR(50001, @m, 16, 1)
	RETURN @n
END CATCH
GO
DECLARE @i INT 
EXEC sInsertLot @no='Lot 6', @q =12, @u = 1400, @id= @i OUTPUT
SELECT @i
EXEC sInsertLot 'Lot 7', 12, 1400, .10, @i OUTPUT
SELECT @i
GO
SELECT * FROM lots
GO

SELECT * FROM items
GO
CREATE PROC sUpdateLot @li INT, @no NVARCHAR(15), @q INT, @u MONEY, @v FLOAT
AS
BEGIN TRY
	UPDATE lots
	SET lotno = @no, quantity=@q, unitprice=@u, vat=@v
	WHERE lotid = @li
END TRY
BEGIN CATCH
	DECLARE @m VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR(50001, @m, 16, 1)
	RETURN 0
END CATCH
GO
CREATE PROC sDeleteLot @li INT
AS
BEGIN TRY
	DELETE lots	
	WHERE lotid = @li
END TRY
BEGIN CATCH
	DECLARE @m VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR(50001, @m, 16, 1)
	RETURN 0
END CATCH
GO
EXEC sDeleteLot 6
GO
CREATE FUNCTION fnNetPriceOfLot( @lid INT ) RETURNS MONEY
AS
BEGIN
	DECLARE @m MONEY
	SELECT @m=(1+vat)*unitprice*quantity
	FROM lots
	WHERE lotid = @lid
	RETURN @m
END 
GO
SELECT dbo.fnNetPriceOfLot (2)
GO
CREATE FUNCTION fnNetPriceOfColor (@c NVARCHAR(20) ) RETURNS MONEY
AS
BEGIN
	DECLARE @m MONEY
	SELECT @m=SUM((1+vat)*unitprice*quantity)
	FROM lots l
	INNER JOIN items i ON i.lotid = l.lotid
	INNER JOIN colors c ON c.colorid = i.colorid
	WHERE c.colorname = @c
	
	RETURN @m
END
GO
SELECT dbo.fnNetPriceOfColor ('Red')
GO
CREATE FUNCTION fnItemSummuary(@c VARCHAR(20)) RETURNS TABLE
AS
RETURN
(
SELECT itemname, itemno, colorname, quantity, unitprice, vat, unitprice*quantity*vat 'vat amount', unitprice*quantity +unitprice*quantity*vat 'net price'
FROM items i 
INNER JOIN colors c ON i.colorid = c.colorid
INNER JOIN lots l ON i.lotid = l.lotid
WHERE c.colorname = @c
)
GO
SELECT * FROM fnItemSummuary('Red')
GO
CREATE FUNCTION fnItemSummuaryM(@c VARCHAR(20)) RETURNS @tbl TABLE (
	itemname VARCHAR(30),
	itemno VARCHAR(30),
	colorname VARCHAR(20),
	quantity INT,
	unitprice MONEY,
	vat FLOAT,
	[vat amount] MONEY,
	[net price] MONEY
)
AS
BEGIN
INSERT INTO @tbl
SELECT itemname, itemno, colorname, quantity, unitprice, vat, unitprice*quantity*vat 'vat amount', unitprice*quantity +unitprice*quantity*vat 'net price'
FROM items i 
INNER JOIN colors c ON i.colorid = c.colorid
INNER JOIN lots l ON i.lotid = l.lotid
WHERE c.colorname = @c
RETURN
END
GO
SELECT * FROM fnItemSummuaryM('Red')
GO
CREATE TRIGGER trInsertLot
ON Lots
INSTEAD OF INSERT
AS
DECLARE @q INT
SELECT @q=quantity FROM inserted
IF @q < 6
BEGIN
	RAISERROR('Qunitity must be 6 or more', 16, 1)
END
ELSE
BEGIN
	INSERT INTO lots
	SELECT * FROM inserted
END
GO
INSERT INTO lots
VALUES (5, 'Lot 5', 5, 1500, .15)
GO
CREATE TRIGGER trLotUpdate
ON lots
FOR UPDATE
AS
BEGIN
	DECLARE @oq INT, @nq INT
	SELECT @oq = quantity FROM deleted
	SELECT @nq = quantity FROM inserted
	IF @nq < @oq /2
	BEGIN
		ROLLBACK
		RAISERROR('Quantity cannot be lowered mor tah half', 16, 1)
	END
END
GO
SELECT * FROM lots
UPDATE lots
SET quantity = 5
WHERE lotid = 2
SELECT * FROM lots
GO
CREATE TRIGGER trDelLot
ON lots
FOR DELETE
AS
BEGIN
IF @@ROWCOUNT > 1 
BEGIN
	ROLLBACK
	RAISERROR('Cannot delete multiple', 16, 1)
END
END
GO
SELECT c.colorname, 
COUNT(i.itemid) OVER (PARTITION BY c.colorname) 'count',
ROW_NUMBER() OVER (ORDER BY c.colorname) 'row number',
RANK() OVER (ORDER BY c.colorname) 'rank',
DENSE_RANK() OVER (ORDER BY c.colorname) 'dense rank',
NTILE(2) OVER (ORDER BY c.colorname) 'ntile'
FROM dbo.items i
INNER JOIN dbo.colors c ON i.colorid = c.colorid
GO
--vi
SELECT i.itemname, l.lotno, l.quantity, l.unitprice, l.unitprice*(1+vat) 'price+vat',
FIRST_VALUE(i.itemname) OVER (ORDER BY l.unitprice ASC) 'f value',
LAST_VALUE(i.itemname) OVER (ORDER BY l.unitprice ASC) 'l value',
LEAD(i.itemname) OVER (ORDER BY l.unitprice ASC) 'lead',
LAG(i.itemname) OVER (ORDER BY l.unitprice ASC) 'lag',
PERCENT_RANK() OVER (ORDER BY l.unitprice ASC) 'perc rank',
CUME_DIST() OVER (ORDER BY l.unitprice ASC) 'cume dist'
FROM dbo.items i
INNER JOIN dbo.lots l ON l.lotid = i.lotid
GO
SELECT i.itemname, l.lotno, l.quantity, l.unitprice, l.unitprice*(1+vat) 'price+vat',
PERCENTILE_CONT (0.5) WITHIN GROUP(ORDER BY l.unitprice) OVER (PARTITION BY l.unitprice ) 'per cont',
PERCENTILE_DISC(0.5) WITHIN GROUP(ORDER BY l.unitprice) OVER (PARTITION BY l.unitprice ) 'per dist'
FROM dbo.items i
INNER JOIN dbo.lots l ON l.lotid = i.lotid
GO