--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'RemoveFavourite') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE RemoveFavourite
GO

CREATE PROCEDURE [dbo].RemoveFavourite

@UserID numeric(15)=null,
@TutorialsID numeric(5)=null
AS
BEGIN
	delete from tblFavourites
	WHERE UserID=@UserID AND TutorialsID=@TutorialsID
END	

--select * from tblFavourites
--exec AddFavourite 16,2,1
--delete from tblFavourites where UserID=16