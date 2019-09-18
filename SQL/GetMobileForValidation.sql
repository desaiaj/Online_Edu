--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetMobileForValidation') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetMobileForValidation
GO

CREATE PROCEDURE [dbo].GetMobileForValidation
    @Mobile numeric(20)=null
AS
BEGIN
	     SELECT MobileNo from tblUsers where MobileNo=@Mobile
END
