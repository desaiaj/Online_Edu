--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'DelMAC') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE DelMAC
GO
--truncate table tblMAC

CREATE PROCEDURE DelMAC
@UserID numeric(5)=null

AS
begin
	delete from tblMAC where UserID=@UserID
end

--exec DelMAC 1
