--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetRecordForDashbord') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetRecordForDashbord
GO
--truncate table tblMAC

CREATE PROCEDURE [dbo].GetRecordForDashbord
AS
begin
	SELECT COUNT(M.UserID) AS ActiveUsers,(select count(*) from tblUsers where ISActive<>'Active') AS DeactiveUsers
	 from tblMAC M
	Where [Status]=1
end
--select * from tblUsers
--exec GetRecordForDashbord
