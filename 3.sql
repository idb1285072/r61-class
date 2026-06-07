USE R61
GO
CREATE TABLE trainees
(
	id CHAR(7) PRIMARY KEY CHECK(id LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	[name] VARCHAR(30) NOT NULL
)
GO
EXEC sp_help trainees
GO
INSERT INTO trainees ([name]) VALUES ('T1')
INSERT INTO trainees  VALUES ('1234567', 'T1')
INSERT INTO trainees  VALUES ('1234567', 'T2')
GO
CREATE TABLE attendances
(
	traineeid INT NOT NULL ,
	[date] DATE NOT NULL,
	intime TIME NOT NULL,
	PRIMARY KEY (traineeid, [date])
)
GO
INSERT INTO attendances VALUES (1, '2024-07-06', '8:45')
INSERT INTO attendances VALUES (2, GETDATE(), '8:49')
INSERT INTO attendances VALUES (1, GETDATE(), '8:39')