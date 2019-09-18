--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]
Use[megamindss_onlineeducation]
IF OBJECT_ID('dbo.[tblCity]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblCity]
GO

CREATE TABLE [dbo].tblCity
(CityID Varchar(20) Primary key,
CityName Varchar(50) Not Null,
StateID	Varchar(20) References tblState(StateID));