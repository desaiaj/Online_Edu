IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetTutorials') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetTutorials
GO
CREATE PROCEDURE [dbo].GetTutorials
@Keywords nvarchar(200)=null

AS
BEGIN
	select DocName,TutorialsID,TotalViews,Likes,[Subject],[Description],UploadDate,Category
	from tblTutorials
	WHERE @Keywords is not null AND DocName LIKE '%'+@Keywords+'%' OR Subject LIKE '%'+@Keywords+'%' OR Category LIKE '%'+@Keywords+'%' OR Description LIKE '%'+@Keywords+'%'
END
--select * from tblTutorials
--EXEC GetTutorials null