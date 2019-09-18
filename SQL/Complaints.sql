--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'FeedBackandComplaints') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].FeedBackandComplaints
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].FeedBackandComplaints
@EmailID nvarchar(500)=null,
@Name nvarchar(50)=null,
@Subjet nvarchar(50)=null,
@Description nvarchar(max)=null,
@Date varchar(30)=null,
@check varchar(5)

AS
begin
if(@check='C')
	insert into tblComplaints(EmailID,Name,Subjet,[Description],ComplainDate)
	values(@EmailID,@Name,@Subjet,@Description,@Date)
ELSE
	insert into tblFeedBack(EmailID,Name,Subjet,[Description],FeedBackDate)
	values(@EmailID,@Name,@Subjet,@Description,@Date)
end

--EXEC InsertQuestions'What is php','Nothing','not','ts','st',1,1
--truncate table tblQuestion
--select * from tblComplaints
--select * from tblFeedBack