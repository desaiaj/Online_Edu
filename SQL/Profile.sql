--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Profile') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [Profile]
GO

CREATE PROCEDURE [dbo].[Profile]

@UserID numeric(10)=null
AS
BEGIN	
if(@UserID is not null AND @UserID!=0)
	Select U.UserID,FName+' '+LName AS FullName, Gender,UserType,ProfileImg,QueryID,Query,QueryTime,Raise AS QRaises,CityName,StateName,CountryName,E.[Subject],R.CreatedOn,r.ExamTypeID,R.Grade,R.ObtainedMarks,R.[Rank],R.Result,R.ResultID,R.TimeTaken,P.GlobalGrade,P.GlobalRank ,(select COUNT(TutorialsID) from tblAttendedTutorials where UserID=@UserID) as Tutorials ,(select count(*) from tblAnswer where UserID=@UserID) AS AnswersGiven
	from tblUsers U
	left join tblCity C
	on U.CityID=C.CityID
	left join tblState S
	on C.StateID=S.StateID 
	left join tblCountry CO
	on S.CountryID=CO.CountryID
	left join tblQuery Q
	on Q.UserID=@UserID
	left join  tblResult R
	on R.UserID=@UserID
	left join tblProgress P
	on P.UserID=@UserID
	left join tblExamType E
	on E.ExamTypeID=R.ExamTypeID
	Where U.UserID=@UserID
else
	select null	
END

--exec Profile 16

