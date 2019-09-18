
IF OBJECT_ID('dbo.[tblResult]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblResult
GO

CREATE TABLE [dbo].tblResult
(ResultID numeric(10) Primary Key identity(1,1), 
UserID numeric(15) References tblUsers(UserID),
ExamTypeID numeric(10) References tblExamType(ExamTypeID),
Result varchar(50) not null,
TimeTaken datetime not null,
ObtainedMarks numeric(4) not null,
Grade varchar(50) not null,
[Rank] numeric(5) not null,
CreatedOn date not null)