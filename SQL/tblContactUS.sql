--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblContactUS]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblContactUS
GO

CREATE TABLE [dbo].tblContactUS
(Email varchar(10) Primary Key,
Phone numeric(15) not null,
[Address]	varchar(100) not null,
[Status] varchar(10) not null)