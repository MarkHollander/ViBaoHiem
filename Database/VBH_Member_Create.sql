SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vu.DM
-- Create date: 12/03/2020
-- Description:	VBH_Member_LockMember
-- =============================================

IF EXISTS ( SELECT 1 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[VBH_Member_Create]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_Member_Create]
END
GO

CREATE PROCEDURE [dbo].[VBH_Member_Create]
(
    @MemberId bigint output,
    @ParentMemberId bigint,
    @Username varchar(50),
	@Password nvarchar(200),
	@FullName nvarchar(200),	
	@Email nvarchar(200),
	@Mobile varchar(50),
	@IsLocked bit,	
	@Status int)
AS
BEGIN	
	
	INSERT INTO [Member] (ParentMemberId, Username, Password, FullName,  Email, Mobile, 
		IsLocked,  Status, CreatedDate)
	VALUES (@ParentMemberId,@Username,@Password,@FullName,@Email,@Mobile,
		@IsLocked,@Status, GETDATE())
	SET @MemberId = SCOPE_IDENTITY()
END
GO
