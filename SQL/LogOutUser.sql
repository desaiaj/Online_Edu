--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'LogOutUser') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE LogOutUser
GO
--truncate table tblMAC

CREATE PROCEDURE [dbo].LogOutUser
@UserID numeric(5)=null,
@Email varchar(50)=null,
@pass nvarchar(50)=null
AS
begin
if(@Email is null AND @pass is null)
	UPDATE tblMAC
	SET Status=0
	WHERE UserID=@UserID AND Status=1
else
	UPDATE tblMAC
	SET Status=0
	where UserID=(select UserID from tblUsers where Email=@Email AND UPassword=@pass)
	--delete from tblMAC where UserID=@UserID
end

--exec LogOutUser null,'testhost157144@gmail.com','12345678'
--select * from tblMAC
--select * from tblUsers