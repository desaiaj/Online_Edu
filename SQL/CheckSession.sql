IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'CheckSession') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE CheckSession
GO

CREATE PROCEDURE [dbo].CheckSession
@UserID nvarchar(100) = NULL

AS
BEGIN
	select MACAddress from tblMAC where UserID=@UserID AND [Status]=1
END

--select * from tblUsers
--exec login 'abc@gmail.com'

