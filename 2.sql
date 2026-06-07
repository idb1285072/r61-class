SELECT LEN('Habib')
SELECT CompanyName, LEN(CompanyName)
FROM Customers
SELECT UPPER(CompanyName), LOWER(CompanyName)
FROM Customers
SELECT LTRIM('                     Habib                  ')
SELECT RTRIM('Habib                  ') + ' '+ LTRIM('                 Haq')
SELECT RTRIM('Habib                  ') + SPACE(1)+ LTRIM('                 Haq')
SELECT FirstName + SPACE(1) + LastName as 'Full Name'
FROM Employees
SELECT LEFT(FirstName, 1) + SPACE(1) + LastName as 'Full Name'
FROM Employees
SELECT LEFT(Phone, 2) +'********' + RIGHT(Phone, 2)
FROM Customers
SELECT SUBSTRING('Habibul', 3, 3)
SELECT '**' + SUBSTRING(Fax,3, 4)
FROM Customers
SELECT REPLACE('Habibul Haq','Ha', 'La')
SELECT REPLICATE('O', 5) +'ff'
SELECT REVERSE('habib')
SELECT CHARINDEX('bi', 'Habibul')
SELECT PATINDEX('%b_%', 'Habibul')
SELECT CONCAT(FirstName, ' ', LastName)
FROM Employees
SELECT CONCAT_WS(' ', FirstName, LastName)
FROM Employees
SELECT CONCAT_WS('-', '1', '2', '3')
FROM Employees