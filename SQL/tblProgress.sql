--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblProgress]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblProgress
GO

CREATE TABLE [dbo].tblProgress
(UserID	numeric(15)	References tblUsers(UserID),
ExamTypeID numeric(10) References tblExamType(ExamTypeID),
GlobalGrade	varchar(50)	not null,
GlobalRank	numeric(5)	not null)