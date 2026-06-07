USE R61
GO
CREATE TABLE diets
(
	id INT IDENTITY PRIMARY KEY,
	nutrition NVARCHAR(30) NOT NULL,
	category NVARCHAR(30) NOT NULL,
	maxintake FLOAT NOT NULL
)
GO
INSERT INTO diets VALUES 
('Protein', 'High', 400),
('Protien', 'Moderate', 300),
('Protien', 'Low', 100),
('Fat', 'High', 100),
('Fat', 'High', 70),
('Fat', 'Moderate', 30),
('Fat', 'Low', 10),
('CarboH', 'High', 700),
('CarboH', 'Moderate', 500),
('CarboH', 'Low', 400)
GO
SELECT * FROM diets
GO
CREATE VIEW vHighDiets
WITH ENCRYPTION, SCHEMABINDING
AS
SELECT nutrition, maxintake
FROM dbo.diets
GO
DROP TABLE diets  --fails
GO
ALTER TABLE diets
ALTER COLUMN category NVARCHAR(20) NOT NULL
GO
ALTER TABLE diets
ALTER COLUMN nutrition NVARCHAR(20) NOT NULL
GO
CREATE VIEW vLowDiets
AS
SELECT id, nutrition, category, maxintake
FROM diets
WHERE category='Low'
WITH CHECK OPTION
GO
SELECT  * FROM vLowDiets
GO
UPDATE vLowDiets
SET maxintake = 90
WHERE id=3
GO
UPDATE vLowDiets
SET category = 'High'
WHERE id=3
GO




