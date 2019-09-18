--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblComplaints]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblComplaints
GO

CREATE TABLE [dbo].tblComplaints
(ComplaintID numeric(10) Primary Key identity(1,1),
EmailID varchar(100),
Name nvarchar(50),
Subjet varchar(50) not null,
Description text not null,
ComplainDate varchar(20) not null,
Solution varchar(500),
SolutionDate varchar(20))
