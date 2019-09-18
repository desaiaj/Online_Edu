--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblState]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblState]
GO

CREATE TABLE [dbo].tblState		
(StateID Varchar(20) Primary key,
StateName Varchar(50) Not Null,
CountryID Varchar(20) References tblCountry(CountryID));
