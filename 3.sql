USE R61
GO
CREATE TABLE products
(
	id INT IDENTITY,
	productnaame VARCHAR(30) NOT NULL,
	price MONEY NOT NULL
)
GO
INSERT INTO products VALUES ('Alu', 20)
INSERT INTO products VALUES
('Ata', 50), ('Flour', 80)
GO
SELECT * FROM products
GO
CREATE TABLE workers
(
	id UNIQUEIDENTIFIER NOT NULL,
	[name] VARCHAR(30) NOT NULL,
	payrate MONEY NOT NULL
)
GO
INSERT INTO workers VALUES
(NEWID(), 'W1', 1500), (NEWID(), 'W2', 1250)
GO
SELECT * FROM workers 
GO
DROP TABLE products
GO
CREATE TABLE products
(
	id INT IDENTITY,
	productname VARCHAR(30) NOT NULL,
	price MONEY NOT NULL,
	discountrate MONEY NOT NULL,
	discountedprice as price*(1-discountrate)
)
GO
INSERT INTO products (productname, price, discountrate)
VALUES ('P1', 1200, .05), ('P2', 1500, .10)
GO
SELECT * FROM products