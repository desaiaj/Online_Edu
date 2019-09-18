--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblBlock]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblBlock]
GO

CREATE TABLE [dbo].tblBlock
(BlockID numeric(10) primary key identity(1,1),
UserID numeric(15) References tblUsers(UserID),
Flag numeric(10),
BlockedDATE	datetime,
tillDATE datetime,
Details varchar(500))
