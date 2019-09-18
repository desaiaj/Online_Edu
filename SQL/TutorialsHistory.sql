--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'TutorialsHistory') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE TutorialsHistory
GO

CREATE PROCEDURE [dbo].TutorialsHistory
@UserID Numeric(5)=null,
@s varchar(2)=null

AS
BEGIN	
if(@s='H')	
	SELECT top(10)A.*,T.Category,T.[Description],T.Likes,T.TotalViews,T.[Subject],T.UploadDate,T.DocName AS "DocName",(SELECT COUNT(A.TutorialsID) from tblAttendedTutorials A
											  where UserID=@UserID) AS "TotalViewed" 
	FROM tblAttendedTutorials A,tblTutorials T
	where A.UserID=@UserID AND A.TutorialsID=T.TutorialsID 
	order by StartedTime desc;

else
	select Tut.TutorialsID as FavTutorialsID,Tut.DocName AS "FavouriteDoc",Tut.[Subject] AS FavSubject,Tut.Category AS FavCategory,Tut.[Description] AS FavDescription,Tut.Likes AS FavLikes,Tut.TotalViews AS FavTotalViews,Tut.UploadDate AS FavUploadDate
	FROM tblFavourites Fav,tblTutorials Tut
	where Fav.UserID=@UserID AND Tut.TutorialsID=Fav.TutorialsID
END 

--EXEC TutorialsHistory 16,'H'
--select * from tblAttendedTutorials