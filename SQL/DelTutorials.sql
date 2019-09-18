--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'DelTutorial') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].DelTutorial
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].DelTutorial
@TutorialsID numeric(5)=null

AS
begin
	delete from tblTutorials
	where TutorialsID=@TutorialsID
	select * from tblTutorials
end

--EXEC InsertQuestions'What is php','Nothing','not','ts','st',1,1
--truncate table tblQuestion
--select * from tblComplaints
--select * from tblFeedBack