--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'TutorialsViews') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE TutorialsViews
GO

CREATE PROCEDURE [dbo].TutorialsViews
@TutorialsID numeric(10)=null,
@UserID Numeric(5)=null

AS
BEGIN
	
	SELECT TotalViews from tblTutorials
	where TutorialsID=@TutorialsID

	if(NOT EXISTS (SELECT *  FROM tblAttendedTutorials where UserID=@UserID AND TutorialsID=@TutorialsID))
	begin
		insert into tblAttendedTutorials(TutorialsID,UserID,StartedTime,FinishTime)
		values(@TutorialsID,@UserID,SYSDATETIME(),SYSDATETIME())
		
		UPDATE tblTutorials
		SET TotalViews+=1
		WHERE TutorialsID=@TutorialsID
	
	end
END
--select * from tblFavourites
--select * from tblAttendedTutorials
--EXEC TutorialsViews 2,16
--delete from tblAttendedTutorials where UserID=16