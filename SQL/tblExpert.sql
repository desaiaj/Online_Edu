--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblExpert]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblExpert
GO

CREATE TABLE [dbo].tblExpert		
(UserID	numeric(15)	References tblUsers(UserID),
Expertise varchar(100) not null,
Qualification varchar(50) not null,
Remarks	varchar(50),
Likes numeric(10),
Status varchar(50),	 
CreatedON Date)