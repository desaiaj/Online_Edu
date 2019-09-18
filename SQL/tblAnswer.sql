--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblAnswer]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblAnswer
GO

CREATE TABLE [dbo].tblAnswer
(AnsID	numeric(12)	Primary Key identity(1,1),
QueryID	numeric(12)	References tblQuery(QueryID),
Answer	varchar(500),
UserID	numeric(15)	References tblUsers(UserID),
AnswerTime datetime,
Raise numeric(15))