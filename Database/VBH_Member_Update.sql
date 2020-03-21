SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vu.DM
-- Create date: 12/03/2020
-- Description:	VBH_Member_Update
-- =============================================

IF EXISTS ( SELECT 1 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[VBH_Member_Update]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_Member_Update]
END
GO

CREATE PROCEDURE [dbo].[VBH_Member_Update]
(
    @MemberId bigint output, 
	
	@FullName nvarchar(200),	
	@Email nvarchar(200),
	@Mobile varchar(50)
)
AS
BEGIN
	
		UPDATE [Member]
		SET FullName = @FullName,			
			Email = @Email, 
			Mobile = @Mobile
		WHERE MemberId = @MemberId	
END
GO
