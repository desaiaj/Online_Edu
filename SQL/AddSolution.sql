--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'AddSolution') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].AddSolution
GO
--truncate table tblMAC
CREATE PROCEDURE [dbo].AddSolution
@ComplaintID numeric(10)=null,
@Solution Nvarchar(MAX)=null,
@Date varchar(30)=null

AS
begin
	Update tblComplaints
	set Solution=@Solution,SolutionDate=@Date
	WHERE ComplaintID=@ComplaintID
end

--Update tblComplaints	set Solution=null,SolutionDate=null
--select * from tblComplaints