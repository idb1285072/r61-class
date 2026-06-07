CREATE DATABASE R61
GO
USE R61
GO
/*
	string - char, nchar, varchar, nvarchar
	numbers integers - int, bigint, tinyint
	numbers floats - float, decimal, money
	boolean - bit [0/1]
	temporal - date, datetime
	binary - varbinary
*/
CREATE TABLE trainees
(
	id INT,
	[name] varchar(40)
)
GO
EXEC sp_help trainees
GO
INSERT INTO trainees (id, [name]) VALUES (1, 'Haq')
INSERT INTO trainees ([name], id) VALUES ('Haq2', 2)
INSERT INTO trainees VALUES (3, 'Haq3')
GO 
SELECT * FROM trainees
GO
CREATE TABLE books
(
	id INT NOT NULL,
	title VARCHAR(50) NOT NULL
)
GO
EXEC sp_help books
GO
INSERT INTO books  VALUES
(1, 'SQL'), (2, 'C#'), (3, 'HTML')
GO
SELECT * FROM books
GO