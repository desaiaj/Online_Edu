IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'GetComplaintsList') AND TYPE IN (N'P',N'PC')) 
	DROP PROCEDURE [dbo].GetComplaintsList
GO
CREATE PROCEDURE [dbo].GetComplaintsList
@id varchar(50) = null,
@status varchar(10)=null
AS
BEGIN
if(@id is null AND @status is null)
	SELECT ComplaintID,EmailID,Name AS UserName,Subjet,[Description],ComplainDate AS ComplaintDate,Solution,SolutionDate from tblComplaints
else
	select ComplaintID,EmailID,Name AS UserName,Subjet,[Description],ComplainDate AS ComplaintDate,Solution,SolutionDate 
	from tblComplaints
	where (@id is not null AND ComplaintID Like @id OR EmailID = @id ) or ((@status = 'Active' AND Solution is null) or (@status!= 'Active' AND Solution is not null))
END
--select * from tblComplaints
--EXEC GetComplaintsList '1',null
