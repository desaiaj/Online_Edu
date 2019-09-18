--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GenerateResult') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE GenerateResult
GO

CREATE PROCEDURE [dbo].GenerateResult
@UserID Numeric(10),
@ExamTypeID numeric(10),
@Result Varchar(10),
@Time varchar(10),
@Marks Numeric(10),
@Grade Varchar(5),
@Rank numeric(5),
@CreatedOn date

AS
BEGIN

if(EXISTS(select * from tblResult where ExamTypeID=@ExamTypeID AND UserID=@UserID))
	Update tblResult
	SET Result=@Result,TimeTaken=@Time,ObtainedMarks=@Marks,Grade=@grade,[Rank]=@Rank,CreatedOn=@CreatedOn
	WHERE UserID=@UserID AND ExamTypeID=ExamTypeID
ELSE
	Insert INTO tblResult(UserID,ExamTypeID,Result,TimeTaken,ObtainedMarks,Grade,[Rank],CreatedOn)
	Values(@UserID,@ExamTypeID,@Result,@Time,@Marks,@grade,@Rank,@CreatedOn)
END

--exec GenerateResult 6,1,'pass','00',2,'A',2,'4/04/2017'

--select * from tblResult
