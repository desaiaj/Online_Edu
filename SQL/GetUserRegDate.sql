--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetUserRegDate') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE GetUserRegDate
GO

CREATE PROCEDURE [dbo].GetUserRegDate
@UserID numeric(20)=null
AS
BEGIN
	SELECT RegDate from tblUsers where UserID=@UserID
END
