
IF OBJECT_ID('dbo.[tblUsers]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblUsers]
GO

CREATE TABLE [dbo].tblUsers
(UserID Numeric(15) Primary key identity(1,1),
FName Varchar(30) Not Null,
LName Varchar(30) Not Null,
MobileNo Numeric(15) Not Null Unique,
Email Varchar(50) Not null,
Gender Varchar(7) Not null,
DoB date,
UserType Varchar(10) check (UserType in ('User','Expert','Admin')),
CityID Varchar(20) References tblCity(CityID),
ProfileImg Varchar(50),
RegDate Date,
ISActive Varchar(20) check (ISActive in ('Deleted','Active','InActive')),
UPassword Varchar(100) Not null,
SecQue Varchar(100) Not null,
SecAns Varchar(100) not null,
LearnedTime numeric(5),
LastLoginTime datetime);