--USE []

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'login') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [login]
GO

CREATE PROCEDURE [dbo].[login]

@LoginID nvarchar(100) = NULL

AS

declare 
@MobNo numeric(12)=0
BEGIN
IF (ISNUMERIC(@LoginID)=1)
	Select @MobNo=CONVERT(numeric,@LoginID)
IF EXISTS(SELECT B.* FROM tblBlock as B,tblUsers as U WHERE B.UserID=U.UserID AND (U.Email=@LoginID or U.MobileNo=@MobNo))
	SELECT B.* FROM tblBlock as B,tblUsers as U WHERE U.UserID=B.UserID AND (U.Email=@LoginID or U.MobileNo=@MobNo)
ELSE IF EXISTS(SELECT MobileNo FROM tblUsers WHERE Email=@LoginID OR MobileNo=@MobNo)
	SELECT UserID,ISActive,Email,MobileNo,UPassword,ProfileImg AS ProfImg,FName+LName AS FullName FROM tblUsers WHERE Email=@LoginID OR MobileNo=@MobNo
ELSE
	SELECT NULL;
END

--select * from tblUsers
--exec login 'abc@gmail.com'
--exec login 'testhost157144@gmail.com' select * from tblUsers