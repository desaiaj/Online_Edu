--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]
--USE [C:\XAMPP\HTDOCS\MYWEB\ONLINEEDUCATION\ONLINEEDUCATION\APP_DATA\ONLINE EDUCATION SYSTEM.MDF]
IF OBJECT_ID('dbo.[tblFavourites]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblFavourites
GO

CREATE TABLE [dbo].tblFavourites
(UserID numeric(15) references tblUsers(UserID),
TutorialsID numeric(10) references tblTutorials(TutorialsID))