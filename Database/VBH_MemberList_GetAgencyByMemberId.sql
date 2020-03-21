SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:			Vu.DM
-- Create date:		16/03/2020
-- Description:		Get Agency + so goi Member dang quan ly
-- =============================================

IF EXISTS ( SELECT 1 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[VBH_MemberList_GetAgencyByMemberId]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_MemberList_GetAgencyByMemberId]
END
GO

CREATE PROCEDURE [dbo].[VBH_MemberList_GetAgencyByMemberId]
(
@MemberId bigint
)
AS
BEGIN	
	WITH m2 AS (SELECT MemberId, MemberBalance, ParentMemberId -- danh sach cong tac vien
				FROM Member
				WHERE MemberId IN  (SELECT MemberId
								    FROM MemberHasPermission
								    WHERE MemberPermissionId > 1)
					AND ParentMemberId = @MemberId
			   )
	SELECT m.MemberId
		,m.ParentMemberId
		,m.Username
		--,m.[Password]
		,m.Email
		,m.Mobile
		,m.FullName
		,m.OpenId
		,m.SourceOpenId
		,m.ActiveCode
		,m.SecretKey
		,m.IsLocked
		,m.VoucherCode
		,m.InviteCode
		,m.MemberBalance -- so du cua dai ly
		,m.PrimaryCommissionRate
		,m.SubCommissionRate
		,m.CreatedDate
		,m.LastModifiedDate
		,m.LastLoginDate
		,m.LastLoginIp
		,m.LastVisitDate
		,m.LastVisitIp
		,m.Note
		,m.[Status]
		,(SELECT m4.Username
		  FROM Member m4
		  WHERE m4.MemberId = m.ParentMemberId) DirectManagerUsername
		,(SELECT ISNULL(COUNT(m2.MemberId),0)
		  FROM m2) CollaboratorCount
		,(SELECT ISNULL(SUM(m2.MemberBalance),0)
		  FROM m2) SumMemberBalance-- Tong so du cua CTV
		,(SELECT ISNULL(COUNT(mp.ID),0) FROM MemberPackage mp WHERE mp.MemberId = @MemberId) OwnerPackageCount --so goi Member dang quan ly
	FROM Member m	
	WHERE m.MemberId = @MemberId
	-- ko check MemberPermission = Agency do ham duoc goi trong cac view co danh sach la cac Agency
	-- nen Id dau vao la Id cua Agency
END
GO
