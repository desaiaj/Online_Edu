--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblQuestion]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblQuestion]
GO

CREATE TABLE [dbo].tblQuestion
(QueNumber numeric(5) Primary Key identity(1,1),
Question varchar(500) not null,
Answer varchar(100) not null,
option1	varchar(100) not null,
option2	varchar(100) not null,
option3	varchar(100) not null,
ExamTypeID numeric(10) References tblExamType(ExamTypeID),
TutorialsID	numeric(10)	References tblTutorials(TutorialsID))