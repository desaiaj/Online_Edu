Use[megamindss_onlineeducation]
IF OBJECT_ID('dbo.[tblCountry]', N'U') IS NOT NULL
	DROP TABLE [dbo].[tblCountry]
GO

CREATE TABLE [dbo].tblCountry
(CountryID varchar(20) Primary key,
CountryName Varchar(50) Not Null);
