--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetUsers') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetUsers
GO
--truncate table tblMAC

CREATE PROCEDURE [dbo].GetUsers
AS
begin
	SELECT  B.UserID as BlockID,U.UserID,FName,LName,MobileNo,Email,RegDate,ISActive,(select count(*) from tblUsers where ISActive<>'Active') AS DeactiveUsers,(SELECT COUNT(M.UserID) From tblMAC M Where [Status]=1) AS ActiveUsers,(select COUNT(*) from tblBlock) As TotalBlocked
	from tblUsers U
	left join tblBlock B
	on U.UserID=B.UserID
	where U.UserID<>1
end
--select U.* from tblUsers U
--exec GetUsers