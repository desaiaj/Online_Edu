--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Registration') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].Registration
GO

CREATE PROCEDURE [dbo].[Registration]

@FName Varchar(50),
@LName Varchar(50),
@MobileNo Numeric(15),
@Email Varchar(50),
@Gender Varchar(7),
@UserType Varchar(10),
@ProfImg varchar(50),
@RegDate Date,
@ISActive Varchar(20),
@UPassword Varchar(100),
@SecQue	Varchar(100),
@SecAns	Varchar(100),
@LearnedTime numeric(5)

AS
begin
	insert into tblUsers (FName,LName,MobileNo,Email,Gender,UserType,RegDate,ISActive,UPassword,SecQue,SecAns,LearnedTime)
	values(@FName,@LName,@MobileNo,@Email,@Gender,@UserType,@RegDate,@ISActive,@UPassword,@SecQue,@SecAns,@LearnedTime);
end
--exec Registration 'ajay','desai','8888888888','Ajay@123','male','6-may-1997','Admin','1','16-feb-2017','Active','88888','Test','gujarat','150'
