--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'UpdateTutorials') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE UpdateTutorials
GO

CREATE PROCEDURE [dbo].UpdateTutorials

@UserID numeric(10)=null,
@TutorialsID numeric(15)=null,
@FileName varchar(50)=null,
@path varchar(50)=null,
@Subject varchar(50)=null,
@Category varchar(50)=null,
@Description varchar(500)=null,
@UploadDate DATE=null

AS
BEGIN
	Update tblTutorials
	SET UserID=@UserID ,DocName=@FileName,[Path]=@path, [Subject]=@Subject,Category=@Category,[Description]=@Description,UploadDate=@UploadDate
	WHERE TutorialsID=@TutorialsID
END

--exec EditTutorial 1,16,"cc","vv","dd","sss","dddd"