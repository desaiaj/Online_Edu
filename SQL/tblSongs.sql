--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblSongs]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblSongs
GO

CREATE TABLE [dbo].tblSongs
(SongsID int identity(1,1) Primary key,
Song Varchar(100) Not Null);

--insert into tblSongs(Song)
--values('(R)03 - Chahun Main Ya Naa.mp3');