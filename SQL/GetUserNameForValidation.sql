--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetUserNameForValidation') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE[dbo].GetUserNameForValidation
GO

CREATE PROCEDURE [dbo].GetUserNameForValidation
    @UserName NVARCHAR(50)=null
AS
BEGIN
      If(@UserName='')
	  BEGIN
	      SELECT NULL
	  END
      ELSE IF(ISNUMERIC(@UserName)=1)
	  BEGIN
	      SELECT Email from tblUsers where MobileNo=CONVERT(numeric,@UserName)
      END
	  ELSE
	  BEGIN
	     SELECT Email from tblUsers where Email=@UserName
	  END
END
