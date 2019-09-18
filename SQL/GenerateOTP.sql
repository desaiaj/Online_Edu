--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[GenerateOTP]'))
	DROP TRIGGER [dbo].GenerateOTP

GO

-- =============================================
-- Author:		Desai Ajay
-- Create date: 25/03/2017
-- =============================================

CREATE TRIGGER GenerateOTP
ON tblUsers
AFTER INSERT,UPDATE
AS
BEGIN
	IF(old.UPassword!=new.Upassword)
		SELECT null
END
