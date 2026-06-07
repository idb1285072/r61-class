USE R61
GO
CREATE PROC spDiets
AS
SELECT * FROM diets
GO
EXEC spDiets
GO
CREATE PROC spDietsOfCategory @c NVARCHAR(20)
AS
SELECT * FROM diets
WHERE category = @c
GO
EXEC spDietsOfCategory 'High'
EXEC spDietsOfCategory @c='Low'
EXEC spDietsOfCategory 'Moderate'
GO
CREATE PROC spInsertDiet @n NVARCHAR(20), @c NVARCHAR(20), @mi FLOAT
AS
IF @c IN ('High', 'Low', 'Moderate')
BEGIN
INSERT INTO diets (nutrition,category, maxintake) VALUES (@n,@c, @mi)
END
ELSE
BEGIN
	RAISERROR('Category should be High or Low or moderate', 16, 1)
END
GO
EXEC spInsertDiet 'Minerals', 'High1', .5
EXEC spInsertDiet @n='Minerals', @c='Low', @mi=.1
EXEC spInsertDiet @c='Moderate', @mi=.2, @n='Minerals'
GO
SELECT * FROM diets
GO