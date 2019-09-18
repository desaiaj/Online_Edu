--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblExamType]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblExamType]
GO

CREATE TABLE [dbo].tblExamType
(ExamTypeID	numeric(10) Primary Key identity(1,1),
[Subject]	varchar(20)	not null)