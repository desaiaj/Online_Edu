--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'UpdatePassword') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE UpdatePassword
GO

CREATE PROCEDURE [dbo].UpdatePassword
@Email varchar(50)=NULL,
@UPassword varchar(30) = NULL

AS
BEGIN
	UPDATE tblUsers
	SET UPassword=@UPassword
	WHERE Email=@Email
END
--exec UpdateProfile 'Brij','Navadiya',7777777777,'brijesh@gmail.com','26-Aug-1997',1,null,'123'
--select * from tblUsers