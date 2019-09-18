IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetFeedBacksAndComplaints') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetFeedBacksAndComplaints
GO
CREATE PROCEDURE [dbo].GetFeedBacksAndComplaints
@ComplaintID Numeric(10)
AS
BEGIN
if(@ComplaintID is null OR @ComplaintID=0)
	select COUNT(FeedBackID) as TotalFeedBacks,(select COUNT(ComplaintID) FROM tblComplaints C ) AS TotalComplaints,(SELECT count(*) from tblComplaints WHERE Solution is not null) AS SolvedComplaints
	FROM tblFeedBack
else	
	SELECT * from tblComplaints
	WHERE ComplaintID=@ComplaintID
END
--exec GetFeedBacksAndComplaints 1
--select * from tblComplaints
--delete from tblComplaints where ComplaintID=7