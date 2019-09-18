--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetUserBySearch') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetUserBySearch
GO
--truncate table tblMAC

CREATE PROCEDURE [dbo].GetUserBySearch
@Name varchar(20) = null,
@Email varchar(50) = null,
@Mobile varchar(15) =null,
@Status Varchar(10) = null

AS
begin
	if(@Name is null AND @Email is null AND @Mobile is null AND @Status is null)
		SELECT * from tblUsers WHERE UserID<>1
	else
	SELECT * from tblUsers
	WHERE UserID<>1 AND ((@Name is not null AND  FName LIKE '%'+@Name+'%' OR LName LIKE '%'+@Name+'%') OR (@Email is not null AND Email LIKE '%'+@Email+'%') OR (@Mobile is not null AND  CONVERT(varchar,MobileNo) LIKE '%'+@Mobile+'%') OR (@Status is not null AND ISActive = @Status ))
end

--exec GetUserBySearch 'ajay',null,'1111111111','Active'
--exec GetUserBySearch null,null,null,null