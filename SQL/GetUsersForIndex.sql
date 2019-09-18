--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetUsersForIndex') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE GetUsersForIndex
GO
--truncate table tblMAC

CREATE PROCEDURE [dbo].GetUsersForIndex
AS
begin
	SELECT top(100)count(R.UserID) AS TotalExams,U.UserID,FName+' '+LName AS FullName,ProfileImg,GlobalGrade,GlobalRank
	from tblUsers U,tblResult R,tblProgress P
	where U.UserID=R.UserID AND U.UserID=P.UserID
	group by R.UserID,FName,LName,U.UserID,ProfileImg,GlobalGrade,GlobalRank
	order by Count(R.UserID) desc
end
--select * from tblResult
--exec GetUsersForIndex
--