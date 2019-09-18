--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'InsertTutorials') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE InsertTutorials
GO

CREATE PROCEDURE [dbo].InsertTutorials

@UserID numeric(15)=null,
@FileName varchar(50)=null,
@path varchar(50)=null,
@Subject varchar(50)=null,
@Category varchar(50)=null,
@Description varchar(500)=null,
@UploadDate DATE=null

AS
BEGIN
	INSERT INTO tblTutorials(UserID,DocName,Path,Subject,Category,Description,UploadDate,Likes)
	VALUES(@UserID,
		   @FileName,
		   @path,
		   @Subject,
		   @Category,
		   @Description,
		   @UploadDate,
		   0)
END

--exec InsertTutorials 1,"cc","vv","dd","sss","dddd",'14-apr-2017'
--select * from tblTutorials
--update tblTutorials set UploadDate='14-apr-2017'