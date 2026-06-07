USE R61
GO
CREATE TABLE sales
(
	id INT IDENTITY PRIMARY KEY,
	salesperson NVARCHAR(30) NOT NULL,
	item NVARCHAR(30) NOT NULL,
	[date] DATE NOT NULL,
	salesfigure MONEY NOT NULL
)
GO
INSERT INTO sales VALUES
('S Maruf','LED Bulb','2024-08-01',37000),
('M Islam','Room Heater','2024-08-02',44000),
('A Rahim','Iron','2024-08-03',31000),
('S Maruf','LED Bulb','2024-08-01',20000),
('M Islam','Room Heater','2024-08-02',22000),
('A Rahim','Iron','2024-08-03',19000),
('S Maruf','LED Bulb','2024-08-01',18000),
('M Islam','Room Heater','2024-08-02',17000),
('A Rahim','Iron','2024-08-03',21000)
GO
SELECT * from sales
GO
---
CREATE PROC spSalesOfPerson @sp NVARCHAR(30), @ts MONEY OUTPUT, @com MONEY OUTPUT
AS
SELECT * FROM sales
WHERE salesperson = @sp

SELECT @ts=SUM(salesfigure), @com = SUM(salesfigure)*.05
FROM sales
WHERE salesperson = @sp
---
GO
DECLARE @totalsales MONEY, @commission MONEY
EXEC spSalesOfPerson 'A Rahim', @totalsales OUTPUT, @commission OUTPUT
SELECT @totalsales, @commission
GO

