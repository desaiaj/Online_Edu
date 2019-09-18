--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GenerateExam') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE GenerateExam
GO

CREATE PROCEDURE [dbo].GenerateExam
@ExamTypeID numeric(10)
AS
BEGIN
	SELECT top(3)*
	FROM tblQuestion,(select [Subject] from tblExamType)Sub
	where ExamTypeID=@ExamTypeID
	order by ABS(CAST(
	(BINARY_CHECKSUM(*) *
	RAND()) as int))% 100
END

--exec GenerateExam 1 
--select * from tblMAC
--update tblMAC
--set Status=1
--where MacID=8
--select * from tblUsers