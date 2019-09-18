--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetEmailForValidation') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetEmailForValidation
GO

CREATE PROCEDURE [dbo].GetEmailForValidation
    @EmailID NVARCHAR(50)=null
AS
BEGIN
	      SELECT Email from tblUsers where Email=@EmailID
END