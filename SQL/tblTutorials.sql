--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]
--USE [C:\XAMPP\HTDOCS\MYWEB\ONLINEEDUCATION\ONLINEEDUCATION\APP_DATA\ONLINE EDUCATION SYSTEM.MDF]
IF OBJECT_ID('dbo.[tblTutorials]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblTutorials]
GO

CREATE TABLE [dbo].tblTutorials
(TutorialsID numeric(10) Primary Key identity(1,1),
UserID numeric(15) References tblUsers(UserID),
DocName varchar(50),
Path varchar(500),
Subject varchar(50),
Category varchar(250),
Description varchar(250),
Likes int,
TotalViews int default(0),
UploadDate date)