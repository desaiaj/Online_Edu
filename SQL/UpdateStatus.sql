

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'UpdateTutorials') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].UpdateTutorials
GO

CREATE PROCEDURE [dbo].UpdateStatus
@Email varchar(100)=NULL

AS
BEGIN
	UPDATE tblUsers
	SET ISActive='Active'
	WHERE Email=@Email;
END
--exec UpdateStatus 'brijesh@gmail.com'