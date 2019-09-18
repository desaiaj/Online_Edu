--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetQuery') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetQuery
GO

CREATE PROCEDURE [dbo].GetQuery
@QueryID numeric(10)=null

AS
BEGIN

if(@QueryID is not null AND @QueryID!=0)
	Select Q.UserID,FName+' '+LName AS FullName,AnsID,Q.QueryID,Query,[Desc],Answer,AnswerTime as dtAnsTime,QueryTime As dtQueryDate,Q.Raise as QRaise,A.Raise As ARaise 
	from tblQuery Q
	left join tblAnswer A
	on Q.QueryID=A.QueryID
	left join tblUsers U
	on Q.UserID=U.UserID
	where Q.QueryID=@QueryID 
else
	select Q.QueryID,Query,[Desc],QueryTime as dtQueryDate,Q.Raise as QRaise ,FName+' '+LName As FullName,Q.UserID from tblQuery Q,tblUsers U
	WHERE Q.UserID=U.UserID
END
--select * from tblQuery
--exec GetQuery 2
--select F.Subjet from tblFeedBack F
