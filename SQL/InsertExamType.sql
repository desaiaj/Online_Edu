--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'InsertExamType') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE InsertExamType
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].InsertExamType
@Examtype nvarchar(50)=null

AS
begin
if NOT EXISTS (SELECT * FROM tblExamType WHERE Subject=@Examtype)
begin
	insert into tblExamType(Subject)
	values(@Examtype)
end
end

--EXEC InsertExamType 'Aptitude'
