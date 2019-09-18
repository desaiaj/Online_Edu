
IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetTutorialsBySearch') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetTutorialsBySearch
GO
CREATE PROCEDURE [dbo].GetTutorialsBySearch
@Subject nvarchar(200) = null,
@Category nvarchar(200) = null,
@Keywords nvarchar(200) = null

AS
BEGIN
	select * from tblTutorials
	WHERE (@Subject is not null AND DocName LIKE '%'+@Subject+'%' OR [Subject] LIKE '%'+@Subject+'%' or Description LIKE '%'+@Subject+'%' )
	 OR (@Category is not null AND Category LIKE '%'+@Category+'%') 
	 OR (@Keywords is not null AND Description LIKE '%'+@Keywords+'%' OR DocName LIKE '%'+@Keywords+'%' OR [Subject] LIKE '%'+@Keywords+'%' OR Category LIKE '%'+@Keywords+'%')
END
--select * from tblTutorials
--EXEC GetTutorialsBySearch null,null,null