SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vu.DM
-- Create date: 11/03/2020
-- Description:	Get Member by MemberId
-- =============================================

IF EXISTS ( SELECT 1 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[VBH_Member_GetByMemberId]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_Member_GetByMemberId]
END
GO

CREATE PROCEDURE [dbo].[VBH_Member_GetByMemberId]
(
@MemberId bigint,
@GetActivedUserOnly bit
)
AS
BEGIN	
	
	SELECT MemberId, ParentMemberId, Username, Password, Email, Mobile, FullName, OpenId, SourceOpenId, ActiveCode, 
		IsLocked, MemberBalance, CreatedDate, Status
	FROM [Member]
	WHERE MemberId = @MemberId AND (@GetActivedUserOnly = 0 OR (@GetActivedUserOnly = 1 AND Status = 1 AND IsLocked = 0))
END
GO
