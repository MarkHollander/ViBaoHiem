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
            WHERE  id = object_id(N'[dbo].[VBH_Member_LockMember]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_Member_LockMember]
END
GO

CREATE PROCEDURE [dbo].[VBH_Member_LockMember]
(
@MemberId bigint
)
AS
BEGIN	
	
	UPDATE Member
	SET IsLocked = 1
	WHERE MemberId = @MemberId
END
GO
