USE R61
GO
CREATE TABLE books
(
	id VARCHAR(4) NOT NULL CHECK(id LIKE 'B[0-9][0-9][0-9]'),
	title VARCHAR(30) NOT NULL,
	price MONEY NOT NULL CHECK(price > 0)
)
GO
INSERT INTO books VALUES ('B123', 'SQL', 500)
INSERT INTO books VALUES ('B124', 'C#', 600)
GO
SELECT * FROM books
GO
CREATE TABLE orders
(
	id INT IDENTITY,
	customer VARCHAR(30) NOT NULL,
	orderdate DATE NOT NULL,
	deliverydate DATE NULL,
	ordervalue MONEY NOT NULL,
	CHECK(deliverydate >= orderdate)
	
)
GO
EXEC sp_helpconstraint orders
GO
INSERT INTO orders VALUES ('Someone', '2024-7-5', '2017-7-4', 540)
INSERT INTO orders VALUES ('Someone', '2024-7-5', '2024-7-5', 540)
INSERT INTO orders VALUES ('Someone', '2024-7-5', '2024-7-6', 540)
INSERT INTO orders VALUES ('Someone', '2024-7-5', NULL, 540)
