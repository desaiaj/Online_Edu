--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetUserData') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetUserData
GO
--truncate table tblMAC

CREATE PROCEDURE [dbo].GetUserData
@UserID varchar(50)=null
AS
begin
if ((select CityID from tblUsers where UserID=@UserID)is not null)
begin
	SELECT FName,LName,MobileNo,Email,Gender,DoB,CityName as City,StateName as State,CountryName as Country,ProfileImg as ProfImg,UPassword
	FROM tblUsers as U,tblCity as C,tblState as S,tblCountry as CN
	WHERE UserID=@UserID AND U.CityID=C.CityID AND C.StateID=S.StateID AND S.CountryID=CN.CountryID
end
else
begin
	SELECT FName,LName,MobileNo,Email,Gender,DoB,ProfileImg as profImg,UPassword
	FROM tblUsers
	WHERE UserID=@UserID
end
end
--exec GetUserData 16