--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetSongs') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetSongs
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].GetSongs

AS
begin
	select * from tblSongs
end
