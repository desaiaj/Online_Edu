--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetMAC') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetMAC
GO
--truncate table tblMAC

CREATE PROCEDURE [dbo].GetMAC
@UserID numeric(5)=null

AS
begin
	SELECT MACAddress from tblMAC where UserID=@UserID AND Status=1
end

delete from tblMAC
where MacID=8
--exec GetMAC 6
--select * from tblMAC
select * from tblUsers