
IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BlockUser') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].BlockUser
GO

CREATE PROCEDURE [dbo].BlockUser
@UserID numeric(5),
@Flag numeric(10)=null,
@BlockedDate date,
@tillDate datetime,
@Details varchar(500)

AS
BEGIN
if(@Flag=1)
	INSERT INTO tblBlock(UserID,
						 Flag,
						 BlockedDate,
						 tillDate,
						 Details)
	VALUES(@UserID,
		   @Flag,
		   @BlockedDate,
		   @tillDate,
		   @Details);
ELSE
	delete from tblBlock
	WHERE UserID=@UserID

	UPDATE tblMAC
	SET Status=0
	WHERE UserID=@UserID AND Status=1
		   		   
END

--exec BlockUser 3,,'30-may-2017','ssssss'