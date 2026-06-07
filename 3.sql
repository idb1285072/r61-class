CREATE DATABASE CollegeDb
ON
(
	name='collegedb_data_1',
	filename='C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\collegedb_data_1.mdf',
	size=25mb,
	maxsize=100mb,
	filegrowth=5%
)
LOG ON
(
	name='collegedb_log_1',
	filename='C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\collegedb_log_1.ldf',
	size=2mb,
	maxsize=50mb,
	filegrowth=1%
)
GO
USE collegedb
GO
CREATE TABLE teachers
(
	teacherid INT IDENTITY  PRIMARY KEY,
	teachername NVARCHAR(30) NOT NULL
)
GO
CREATE TABLE semesters
(
	semesterid INT IDENTITY PRIMARY KEY,
	semsetername NVARCHAR(30) NOT NULL
)
GO
CREATE TABLE subjects
(
	subjectid INT IDENTITY PRIMARY KEY,
	subjectname NVARCHAR(30) NOT NULL,
	teacherid INT NOT NULL REFERENCES teachers(teacherid)
)
GO
CREATE TABLE students
(
	studentid INT IDENTITY PRIMARY KEY,
	studentname NVARCHAR(30) NOT NULL,
	semesterid INT NOT NULL REFERENCES semesters(semesterid)
)
GO
CREATE TABLE studentsubjects
(
	studentid INT NOT NULL REFERENCES students(studentid),
	subjectid INT NOT NULL REFERENCES subjects (subjectid),
	PRIMARY KEY (studentid, subjectid)
)
GO

INSERT INTO teachers VALUES ('T1'),('T2'),('T3'),('T4'),('T5')
INSERT INTO semesters VALUES ('Summer'),('Fall')
INSERT INTO subjects VALUES ('S1', 1), ('S2', 3),('S3', 2),('S4', 5), ('S4', 1), ('S5', 5)
INSERT INTO students VALUES ('ST1', 1), ('ST2', 1), ('ST3', 1), ('ST4', 2), ('ST5', 2)
INSERT INTO studentsubjects VALUES
(1, 1), (1, 3),
(2, 3),(2, 5),
(3, 2),(3, 1),(3, 3),
(4, 5),
(5, 5), (5, 2)
GO
CREATE NONCLUSTERED INDEX ixStudentName ON students (studentname)
GO
EXEC sp_helpindex students
GO
SELECT teachername, studentname, semsetername, subjectname
FROM semesters sm
INNER JOIN students st ON sm.semesterid = st.semesterid
INNER JOIN studentsubjects sb ON st.studentid = sb.studentid
INNER JOIN subjects s ON sb.subjectid = s.subjectid
INNER JOIN teachers t ON s.teacherid = t.teacherid
GO
CREATE VIEW vSubjectSemesterwiseStudents
WITH ENCRYPTION, SCHEMABINDING
AS
SELECT sb.subjectname, st.studentname, sm.semsetername, t.teachername 
FROM dbo.semesters sm
INNER JOIN dbo.students st ON sm.semesterid = st.semesterid
INNER JOIN dbo.studentsubjects stb ON stb.studentid = st.studentid
INNER JOIN dbo.subjects sb ON sb.subjectid = stb.subjectid
INNER JOIN dbo.teachers t ON sb.teacherid = t.teacherid
GO
SELECT * FROM vSubjectSemesterwiseStudents
EXEC sp_helptext vSubjectSemesterwiseStudents
GO
CREATE PROC sInsertStudent @name NVARCHAR(30), @smid INT, @id INT OUTPUT
AS
BEGIN TRANSACTION
BEGIN TRY
	INSERT INTO students VALUES (@name, @smid)
	SELECT @id = SCOPE_IDENTITY()
	COMMIT TRANSACTION
	RETURN 0
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	DECLARE @m VARCHAR(500) = ERROR_MESSAGE(), @n INT = ERROR_NUMBER()
	RAISERROR(@m, 16, 1)
	--;
	--THROW 50001, @m, 16
	RETURN @n
END CATCH
GO
DECLARE @newid INT, @ret INT
EXEC @ret = sInsertStudent 'S6', 1, @newid OUTPUT
IF @ret = 0
	SELECT @newid 'Inserted with id'
ELSE
	PRINT 'Insert failed'
GO
CREATE PROC sUpdateStudent @id INT, @name NVARCHAR(30), @smid INT
AS
BEGIN TRY
	UPDATE students SET studentname= @name,semesterid= @smid
	WHERE studentid= @id
	
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	
	DECLARE @m VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR(@m, 16, 1)
	--;
	--THROW 50001, @m, 16
	RETURN 0

END CATCH
GO
DECLARE @r INT
EXEC @r= sUpdateStudent 6, 'S66', 2
IF @r > 0
	PRINT 'Data updated'
ELSE
	PRINT 'Update failed'
GO
CREATE PROC sDeleteStudent @id INT
AS
BEGIN TRY
	DELETE students 
	WHERE studentid= @id
	
	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	
	DECLARE @m VARCHAR(500) = ERROR_MESSAGE()
	RAISERROR(@m, 16, 1)
	--;
	--THROW 50001, @m, 16
	RETURN 0

END CATCH
GO
EXEC sDeleteStudent 6 --ok
EXEC sDeleteStudent 1 --fails, has child
GO


