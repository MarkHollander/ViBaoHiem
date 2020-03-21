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
            WHERE  id = object_id(N'[dbo].[VBH_Member_Delete]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_Member_Delete]
END
GO

CREATE PROCEDURE [dbo].[VBH_Member_Delete]
(
    @MemberId bigint )
AS
BEGIN		
	DELETE FROM [dbo].[Member]
	WHERE MemberId = @MemberId;
END
GO
