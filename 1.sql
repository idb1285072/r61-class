USE R61
GO
CREATE TABLE products
(
	id INT PRIMARY KEY,
	productname NVARCHAR(30) NOT NULL,
	price MONEY NOT NULL,
	retaildiscountrate MONEY NOT NULL,
	instock BIT NOT NULL
)
GO
CREATE PROC spInsertProduct	@n NVARCHAR(30), 
							@p MONEY,
							@d MONEY = .05,
							@s BIT = 0
AS
DECLARE @id INT
SELECT @id=ISNULL(MAX(id), 0)+1 FROM products
BEGIN TRY
	INSERT INTO products VALUES (@id, @n, @p, @d, @s)
END TRY
BEGIN CATCH
	DECLARE @msg NVARCHAR(200)= ERROR_MESSAGE()
	RAISERROR(@msg, 16, 1)
END CATCH
GO
EXEC spInsertProduct 'LED Bulb', 100, .07, 1
EXEC spInsertProduct 'E Iron', 700
EXEC spInsertProduct @n='LED Bulb', @p=100,  @s=1
GO
SELECT * FROM products
GO
CREATE PROC spInsertProductV1	@n NVARCHAR(30), 
							@p MONEY,
							@d MONEY = .05,
							@s BIT = 0
AS
DECLARE @id INT
SELECT @id=ISNULL(MAX(id), 0)+1 FROM products
BEGIN TRY
	INSERT INTO products VALUES (@id, @n, @p, @d, @s)
	RETURN @id
END TRY
BEGIN CATCH
	DECLARE @msg NVARCHAR(200)= ERROR_MESSAGE()
	RAISERROR(@msg, 16, 1)
	RETURN 0
END CATCH
GO
DECLARE @i INT
EXEC @i=spInsertProductV1 'RAT Killer', 20, .07, 1
SELECT @i 'new product id'
GO
CREATE PROC spUpdateProduct	@id INT,
							@n NVARCHAR(30) = NULL, 
							@p MONEY = NULL,
							@d MONEY = NULL,
							@s BIT = NULL
AS

BEGIN TRY
	UPDATE  products
	SET productname=ISNULL(@n, productname), price = ISNULL(@p, price), retaildiscountrate=ISNULL(@d, retaildiscountrate),
	instock = ISNULL(@s, instock)
	WHERE id=@id
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	DECLARE @msg NVARCHAR(200)= ERROR_MESSAGE()
	RAISERROR(@msg, 16, 1)
	RETURN 0
END CATCH
GO
SELECT * FROM products
GO
EXEC spUpdateProduct @id=2, @s=1
GO
DECLARE @ret INT
EXEC @ret=spUpdateProduct @id=3, @d=.05
IF @ret > 0
	PRINT 'Updated'
GO

