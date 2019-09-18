USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblLog]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblLog
GO

CREATE TABLE tblLog
(LogID numeric(10) Primary Key identity(1,1),
UserID numeric(15) References tblUsers(UserID),
Operation varchar(10) not null,
LogDate date not null)