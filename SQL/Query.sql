--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Query') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE Query
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].Query
@UserID numeric(10)=null,
@Query nvarchar(MAX)=null,
@Desc nvarchar(MAX)=null,
@QueryTime Date=null,
@Raise numeric(10)=null

AS
begin
	insert into tblQuery(UserID,Query,[Desc],QueryTime,Raise)
	values(@UserID,@Query,@Desc,@QueryTime,@Raise)
end

--EXEC InsertQuestions'What is php','Nothing','not','ts','st',1,1
--truncate table tblQuestion
--select * from tblQuery