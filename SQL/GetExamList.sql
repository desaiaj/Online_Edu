--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetExamList') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetExamList
GO

CREATE PROCEDURE [dbo].GetExamList
AS
BEGIN
	Select * from tblExamType
END

--exec GetExamList