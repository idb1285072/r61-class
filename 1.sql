USE R61
GO
CREATE FUNCTION fnCommission(@salesfigure MONEY) RETURNS MONEY
AS
BEGIN
 DECLARE @com MONEY
 IF @salesfigure> 20000
	SET @com = @salesfigure*.07
 ELSE
	SET @com = @salesfigure*.04

 RETURN @com
END
GO
SELECT dbo.fnCommission(23000)
SELECT salesperson, dbo.fnCommission(salesfigure) 'commision earned'
FROM sales
GO
CREATE FUNCTION fnSalesOfItem(@item NVARCHAR(30)) RETURNS TABLE
AS
RETURN (
	SELECT * 
	FROM sales
	WHERE item = @item
)
GO
SELECT * FROM fnSalesOfItem('LED Bulb')
GO
CREATE FUNCTION fnSalesSummary(@item NVARCHAR(30)) RETURNS TABLE
AS
RETURN (
	SELECT salesperson, SUM(salesfigure) 'TotalSale'
	FROM sales
	WHERE item = @item
	GROUP BY salesperson
)
GO
SELECT * FROM fnSalesSummary('LED Bulb')
GO
CREATE FUNCTION fnSalesByPerson(@person NVARCHAR(30)) RETURNS TABLE
AS
RETURN (
	SELECT *, dbo.fnCommission(salesfigure) 'Commission'
	FROM sales
	WHERE salesperson = @person
)
GO
SELECT * FROM fnSalesByPerson('S Maruf')
GO
CREATE FUNCTION fnSalesSummaryMulti(@item NVARCHAR(30)) RETURNS @tbl TABLE
(
	salesperson NVARCHAR(30),
	TotalSale MONEY
)
AS
BEGIN
	INSERT INTO @tbl
	SELECT salesperson, SUM(salesfigure) 
	FROM sales
	WHERE item = @item
	GROUP BY salesperson
	
	RETURN
END
GO
SELECT * FROM fnSalesSummaryMulti('LED Bulb')