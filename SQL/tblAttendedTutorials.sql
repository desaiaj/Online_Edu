USE[megamindss_onlineeducation]

IF OBJECT_ID('dbo.[tblAttendedTutorials]', N'U') IS NOT NULL
	DROP TABLE [dbo].tblAttendedTutorials
GO

CREATE TABLE [dbo].tblAttendedTutorials		
(TutorialsID numeric(10) References tblTutorials(TutorialsID),
UserID numeric(15) References tblUsers(UserID),
StartedTime datetime not null,
FinishTime datetime not null)