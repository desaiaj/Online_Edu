--USE [C:\USERS\JAY HANUMAN DADA\DOCUMENTS\ONLINE EDUCATION SYSTEM.MDF]

IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[OperateGlobalGR]'))
	DROP TRIGGER [dbo].OperateGlobalGR

GO

-- =============================================
-- Author:		Desai Ajay
-- Create date: 25/03/2017
-- =============================================

CREATE TRIGGER [dbo].OperateGlobalGR
ON tblResult
AFTER INSERT,UPDATE
AS
BEGIN
declare
	@data nvarchar(20),
	@cnt numeric(5)
	DECLARE c1 CURSOR FOR select UserID,COUNT(*) AS "total exams Given by user" from tblResult where Result='Fail' group By UserID order by COUNT(*) Desc;
	open c1
	fetch NEXT from c1 INTO @data,@Cnt
	while @@fetch_status=0
	begin	
		IF (EXISTS (SELECT * FROM inserted) AND NOT EXISTS(SELECT * FROM deleted))
		begin
		select @data
			if(@cnt>=30)			
				insert into tblProgress(GlobalGrade,GlobalRank,UserID)
				Values('A',1,@data)			
			else if(@cnt>=20)
				insert into tblProgress(GlobalGrade,GlobalRank,UserID)
				Values('B',2,@data)
			else if(@cnt>=10)
				insert into tblProgress(GlobalGrade,GlobalRank,UserID)
				Values('C',3,@data)
			else
				insert into tblProgress(GlobalGrade,GlobalRank,UserID)
				Values('D',4,@data)						
		end
		ELSE
		begin
			if(@cnt>=30)			
				update tblProgress
				Set GlobalGrade='A',GlobalRank=1
				WHERE UserID=@data

			else if(@cnt>=20)
				update tblProgress
				Set GlobalGrade='B',GlobalRank=2
				WHERE UserID=@data

			else if(@cnt>=10)
				update tblProgress
				Set GlobalGrade='C',GlobalRank=3
				WHERE UserID=@data
			else		
				update tblProgress
				Set GlobalGrade='D',GlobalRank=4
				WHERE UserID=@data
		END
		fetch NEXT from c1 INTO @data,@Cnt
	end
	close c1
	deallocate c1
END
--truncate table tblProgress
--select * from tblProgress
--select * from tblResult
--delete from tblResult where UserID=10018
--exec GenerateResult 10018,1,'Fail','00',5,'A',2,'4/04/2017'