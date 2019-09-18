--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'AddFavourite') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].AddFavourite
GO

CREATE PROCEDURE [dbo].AddFavourite

@UserID numeric(15)=null,
@TutorialsID numeric(5)=null,
@s int=null
AS
BEGIN
if(@s=1 AND Not Exists(select * from tblFavourites where UserID=@UserID AND TutorialsID=@TutorialsID))
	INSERT INTO tblFavourites(TutorialsID,UserID)
	VALUES(@TutorialsID,@UserID)
else
	delete from tblFavourites
	WHERE UserID=@UserID AND TutorialsID=@TutorialsID
select count(*) AS TotFav from tblFavourites
END	

--select * from tblFavourites
--exec AddFavourite 16,2,1
--delete from tblFavourites where UserID=16