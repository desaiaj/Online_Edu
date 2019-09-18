--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetResult') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE GetResult
GO

CREATE PROCEDURE [dbo].GetResult
@UserID numeric(10)
AS
BEGIN
	Select E.[Subject],R.*,P.GlobalGrade,P.GlobalRank from tblResult R,tblExamType E,tblProgress P
	WHERE R.UserID=@UserID AND P.UserID=@UserID AND E.ExamTypeID=R.ExamTypeID AND P.UserID=R.UserID
END

--select * from tblResult
--select * from tblProgress
--select * from tblExamType
-- exec GetResult 10019
