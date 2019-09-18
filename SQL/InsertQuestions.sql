--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'InsertQuestions') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE InsertQuestions
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].InsertQuestions
@Question nvarchar(500)=null,
@Answer nvarchar(50)=null,
@option1 nvarchar(50)=null,
@option2 nvarchar(50)=null,
@option3 nvarchar(50)=null,
@ExamTypeID numeric(10)=null,
@TutorialsID numeric(10)=null

AS
begin
	insert into tblQuestion(Question,Answer,option1,option2,option3,ExamTypeID,TutorialsID)
	values(@Question,@Answer,@option1,@option2,@option3,@ExamTypeID,@TutorialsID)
end

--EXEC InsertQuestions'What is php','Nothing','not','ts','st',1,1
--truncate table tblQuestion
--select * from tblQuestion