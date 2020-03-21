SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:			Vu.DM
-- Create date:		05/03/2020
-- Description:		Get all Member + so goi Member dang quan ly
-- =============================================

-- Modified Date:	16/03/2020
-- Modified By:		Vu.DM
-- Reason:			Optimized query, thay cac cau lenh LEFT JOIN voi multy GROUP BY bang Subquery de tang Performance

IF EXISTS ( SELECT 1 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[VBH_MemberList_GetAll]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[VBH_MemberList_GetAll]
END
GO

CREATE PROCEDURE [dbo].[VBH_MemberList_GetAll]
(
@IsLocked int
)
AS
BEGIN	
	WITH m2 AS (SELECT MemberId, MemberBalance, ParentMemberId -- danh sach cong tac vien
				FROM Member
				WHERE MemberId IN (SELECT MemberId
								   FROM MemberHasPermission
								   WHERE MemberPermissionId > 1 )
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
		  FROM m2
		  WHERE m2.ParentMemberId = m.MemberId) CollaboratorCount
		,(SELECT ISNULL(SUM(m2.MemberBalance),0)
		  FROM m2
		  WHERE m2.ParentMemberId = m.MemberId) SumMemberBalance-- Tong so du cua CTV
		,(SELECT ISNULL(COUNT(mp.ID),0) FROM MemberPackage mp WHERE mp.MemberId = m.MemberId) OwnerPackageCount --so goi Member dang quan ly
	FROM Member m
	-- cac Dai ly bi khoa/ko khoa/tat ca
	WHERE (@IsLocked < 0 OR (@IsLocked >= 0 AND m.[Status] = 1 AND m.IsLocked = (CASE @IsLocked WHEN 0 THEN 0 ELSE 1 END)))
		AND EXISTS (SELECT 1  -- la dai ly
					FROM MemberHasPermission mhp
					WHERE mhp.MemberId = m.MemberId AND mhp.MemberPermissionId = 1) --hardcode de select nhanh, extend phai fix lai
	
END
GO
