USE R61
GO
CREATE TABLE tbl
(
	C1 INT
)
GO
CREATE TRIGGER trTblInsert
ON tbl
FOR INSERT
AS
BEGIN
	PRINT 'Tigger fired'
	ROLLBACK TRAN
END
GO
INSERT INTO tbl VALUES (30)
SELECT * FROM tbl
GO
CREATE TABLE members
(
	id INT PRIMARY KEY,
	[name] NVARCHAR(30) NOT NULL,
	credit MONEY NOT NULL
)
GO
INSERT INTO members 
VALUES
(1, 'M1', 700),(2, 'M2', 800),(3, 'M3', 500)
GO
CREATE TABLE clubservices
(
	id INT IDENTITY PRIMARY KEY,
	servicetime DATETIME2 NOT NULL,
	servicename NVARCHAR(30) NOT NULL,
	memberid INT NOT NULL REFERENCES members(id),
	charge MONEY NOT NULL
)
GO
CREATE TRIGGER trServiceTaken
ON clubservices
FOR INSERT
AS
BEGIN
	--find memberid and charge
	DECLARE @mid INT, @c MONEY
	SELECT @mid=memberid, @c=charge FROM inserted
	--subtract charge from credit for the member
	UPDATE members
	SET credit = credit-@c
	WHERE id=@mid
END
GO
SELECT * FROM members
INSERT INTO clubservices VALUES (GETDATE(), 'Cold coffee', 2, 100)
SELECT * FROM members
SELECT * FROM clubservices
GO
CREATE TRIGGER trServiceTakenV2
ON clubservices
FOR INSERT
AS
BEGIN
	
	DECLARE @mid INT, @c MONEY, @credit MONEY
	--find memberid and charge
	SELECT @mid=memberid, @c=charge FROM inserted
	--find credit
	SELECT @credit = credit FROM members WHERE id=@mid
	--subtract charge from credit for the member if sufficient credit
	IF @credit>=@c
		UPDATE members
		SET credit = credit-@c
		WHERE id=@mid
	ELSE
	BEGIN
		RAISERROR ('Insufficient credit', 16, 1)
		ROLLBACK TRAN
	END
END
GO
