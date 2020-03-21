SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vu.DM
-- Create date: 19/03/2020
-- Description:	VBH_Member_GetByUsername
-- =============================================

IF EXISTS ( SELECT 1 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[VBH_Member_GetByEmail]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_Member_GetByEmail]
END
GO

CREATE PROCEDURE [dbo].[VBH_Member_GetByEmail]
(
    @Email nvarchar(200),
	@GetActivedUserOnly bit
)
AS
BEGIN	
	
	SELECT MemberId, ParentMemberId, Username, Password, Email, Mobile, FullName, OpenId, SourceOpenId, ActiveCode, 
		IsLocked, MemberBalance, CreatedDate, Status
	FROM [Member]
	WHERE Email = @Email AND (@GetActivedUserOnly = 0 OR (@GetActivedUserOnly = 1 AND Status = 1 AND IsLocked = 0))
END
GO
