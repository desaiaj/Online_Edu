--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblFeedBack]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblFeedBack
GO

CREATE TABLE [dbo].tblFeedBack		
(FeedBackID numeric(10) Primary Key identity(1,1),
EmailID Nvarchar(100),
Name varchar(100),
Subjet varchar(50) not null,
[Description] varchar(500) not null,
FeedBackDate date not null)