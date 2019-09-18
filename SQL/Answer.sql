--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Answer') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].Answer
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].Answer
@QueryID numeric(10)=null,
@Answer Nvarchar(MAX)=null,
@UserID numeric(10)=null,
@AnswerTime Date=null,
@Raise numeric(10)=null

AS
begin
	insert into tblAnswer(QueryID,Answer,UserID,AnswerTime,Raise)
	values(@QueryID,@Answer,@UserID,@AnswerTime,@Raise)
end

--EXEC InsertQuestions'What is php','Nothing','not','ts','st',1,1
--truncate table tblQuestion
--select * from tblQuery
--select * from tblAnswer