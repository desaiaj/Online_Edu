--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblMAC]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblMAC]
GO

CREATE TABLE [dbo].tblMAC
(MacID numeric(10) primary key identity(1,1),
MACAddress nvarchar(12) not null,
UserID numeric(15) references tblUsers(UserID),
Status int)