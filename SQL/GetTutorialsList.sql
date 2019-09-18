IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetTutorialsList') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetTutorialsList
GO
CREATE PROCEDURE [dbo].GetTutorialsList

AS
BEGIN
	select * from tblTutorials	
END