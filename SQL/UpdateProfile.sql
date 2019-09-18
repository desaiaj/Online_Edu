--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'UpdateProfile') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE UpdateProfile
GO

CREATE PROCEDURE [dbo].[UpdateProfile]

@FName varchar(10)=NULL,
@LName varchar(10)=NULL,
@MobileNo numeric(12)=NULL,
@Email varchar(100)=NULL,
@DoB DATE = NULL,
@City varchar(20)=null,
@profileImg varchar(20) = NULL,
@UPassword varchar(30) = NULL

AS
BEGIN
DECLARE
@CityID numeric(5) = null

select @CityID = CityID from tblCity where CityName=@City
	
	UPDATE tblUsers
	SET FName=@FName, LName=@LName, MobileNo=@MobileNo, Email=@Email, DoB=@DoB, CityID=@CityID, ProfileImg=@profileImg, UPassword=@UPassword
	WHERE MobileNo=@MobileNo;
END
--exec UpdateProfile 'Brij','Navadiya',7777777777,'brijesh@gmail.com','26-Aug-1997',1,null,'123'
