--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'RequestExpert') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE RequestExpert
GO

CREATE PROCEDURE [dbo].RequestExpert
@UserID Numeric(10)=null,
@Expertise Varchar(255)=null,
@Qualification Varchar(500)=null,
@Remarks Varchar(150)=null,
@Likes numeric(10)=null,
@Status Varchar(250)=null,
@CreatedON Date=null

AS
begin
	insert into tblExpert(UserID,Expertise,Qualification,Remarks,Likes,Status,CreatedON)
	values(@UserID,@Expertise,@Qualification,@Remarks,@Likes,@Status,@CreatedON);
end
-- exec RequestExpert 1,'Coding','BCA','I m Professional Coder',1,'A Google','6-may-1997'
