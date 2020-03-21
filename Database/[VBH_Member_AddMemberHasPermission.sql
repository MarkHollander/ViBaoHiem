SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:			Vu.DM
-- Create date:		20/03/2020
-- Description:		Tao Permission cho Member
-- =============================================


IF EXISTS ( SELECT 1 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[VBH_Member_AddMemberHasPermission]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_Member_AddMemberHasPermission]
END
GO

CREATE PROCEDURE [dbo].[VBH_Member_AddMemberHasPermission]
(
@MemberId bigint,
@MemberPermissionId int
)
AS
BEGIN	
	INSERT INTO MemberHasPermission(MemberId,MemberPermissionId)
	VALUES (@MemberId,@MemberPermissionId);
END
GO
