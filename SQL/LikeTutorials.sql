--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LikeTutorials') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE LikeTutorials
GO

CREATE PROCEDURE [dbo].LikeTutorials

@TutorialID numeric(15)=null,
@s int=1
AS
BEGIN

	UPDATE tblTutorials
	SET Likes+=@s
	WHERE TutorialsID=@TutorialID
	
	Select Likes from tblTutorials
	Where TutorialsID=@TutorialID
END
--select * from tblTutorials
---exec LikeTutorials 1,-1