--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'InsertUpdateMAC') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE InsertUpdateMAC
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].InsertUpdateMAC
@MACID nvarchar(12),
@UserID numeric(5)=null

AS
begin
if NOT EXISTS (SELECT * FROM tblMAC WHERE UserID=@UserID AND MACAddress=@MACID)
begin
	insert into tblMAC(MACAddress,UserID,Status)
	values(@MACID,@UserID,1)
end
else
begin
	Update tblUsers
	SET LastLoginTime = SYSDATETIME()
	where UserID=@UserID

	UPDATE tblMAC
	SET Status=1
	WHERE UserID=@UserID AND MACAddress=@MACID
end
end
--exec InsertUpdateMAC '25g57d5q52dx',1
