--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF OBJECT_ID('dbo.[tblQuery]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblQuery
GO

CREATE TABLE [dbo].tblQuery
(QueryID numeric(12) Primary Key identity(1,1),
UserID numeric(15) References tblUsers(UserID),
Query varchar(500) not null,
QueryTime datetime,
Raise	numeric(15),
[Desc] nvarchar(MAX))
