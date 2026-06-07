USE R61
GO
CREATE TABLE genres
(
	genreid INT PRIMARY KEY,
	genrename	VARCHAR(30) NOT NULL
)
GO
CREATE TABLE books
(
	bookid INT PRIMARY KEY,
	title VARCHAR(50) NOT NULL,
	genreid INT NOT NULL REFERENCES genres(genreid),
	publishdate DATE NOT NULL
)
GO
INSERT INTO genres VALUES (1, 'Novels'),(2,'Drama'),(3,'Classics')
GO
INSERT INTO books VALUES
(1, 'A Tale of two cities', 3, '2016-01-01')
GO
DELETE FROM genres WHERE genreid=3
GO
UPDATE genres
SET genreid =2
WHERE genreid =30
GO
SELECT * FROM genres
GO