USE [wirelesssms]

IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[BankAudit_InsertUpdate]'))
	DROP TRIGGER [dbo].[BankAudit_InsertUpdate]

GO

-- =============================================
-- Author:		Desai Ajay
-- Create date: 03/03/2017
-- Description:	Bank Audit Insert Update
-- =============================================

CREATE TRIGGER BankAudit_InsertUpdate
ON tblBank
AFTER INSERT,UPDATE
AS
BEGIN
	DECLARE
		@inBankID INT = NULL,
		@inBranchID INT = NULL,
		@stAccountNumber NVARCHAR(20) = NULL,
		@stAccountHolderName NVARCHAR(50) = NULL,
		@stBankName NVARCHAR(50) = NULL,
		@stBankBranchName NVARCHAR(50) = NULL,
		@stAddress NVARCHAR(500) = NULL,
		@stIFSC NVARCHAR(20) = NULL,
		@dcChequeClear DECIMAL(10) = NULL,
		@dcChequePending DECIMAL(10) = NULL,
		@flgIsActive BIT = NULL,
		@flgIsDeleted BIT = NULL,
		@dtCreatedOn DATETIME = NULL,
		@dtModifiedOn DATETIME = NULL,
		@inCreatedBy INT = NULL,
		@inModifiedBy INT = NULL
	SELECT 
		@inBankID = inBankID
		,@inBranchID = inBranchID
		,@stAccountNumber = stAccountNumber
		,@stAccountHolderName = stAccountHolderName
		,@stBankName = stBankName
		,@stBankBranchName = stBankBranchName
		,@stAddress = stAddress
		,@stIFSC = stIFSC
		,@dcChequeClear = dcChequeClear
		,@dcChequePending = dcChequePending
		,@flgIsActive = flgIsActive
		,@flgIsDeleted = flgIsDeleted
		,@dtCreatedOn = dtCreatedOn
		,@dtModifiedOn = dtModifiedOn
		,@inCreatedBy = inCreatedBy
		,@inModifiedBy = inModifiedBy
	FROM INSERTED

IF (EXISTS (SELECT * FROM INSERTED) AND NOT EXISTS(SELECT * FROM DELETED))
BEGIN
	INSERT INTO tblBankAudit
		(
		inBankID
		,inOperation
		,inBranchID
		,stAccountNumber
		,stAccountHolderName
		,stBankName
		,stBankBranchName
		,stAddress
		,stIFSC
		,dcChequeClear
		,dcChequePending
		,flgIsActive
		,flgIsDeleted
		,dtCreatedOn
		,inCreatedBy
		)
	VALUES
		(
		@inBankID
		,1
		,@inBranchID
		,@stAccountNumber
		,@stAccountHolderName
		,@stBankName
		,@stBankBranchName
		,@stAddress
		,@stIFSC
		,@dcChequeClear
		,@dcChequePending
		,@flgIsActive
		,@flgIsDeleted
		,@dtCreatedOn
		,@inCreatedBy
		)
END
ELSE
BEGIN
	INSERT INTO tblBankAudit
		(
		inBankID
		,inOperation
		,inBranchID
		,stAccountNumber
		,stAccountHolderName
		,stBankName
		,stBankBranchName
		,stAddress
		,stIFSC
		,dcChequeClear
		,dcChequePending
		,flgIsActive
		,flgIsDeleted
		,dtCreatedOn
		,inCreatedBy
		)
	VALUES
		(
		@inBankID
		,0
		,@inBranchID
		,@stAccountNumber
		,@stAccountHolderName
		,@stBankName
		,@stBankBranchName
		,@stAddress
		,@stIFSC
		,@dcChequeClear
		,@dcChequePending
		,@flgIsActive
		,@flgIsDeleted
		,@dtModifiedOn
		,@inModifiedBy
		)
END
END
