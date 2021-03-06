--Project: PSO_VBH
--Created By: Vu.DM
--Created Date: 16/03/2020
--Description: Modified 2 table UserHasPermission và MemberHasPermission

-------------------

IF EXISTS (SELECT 1 FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[UserHasPermission]') AND type in (N'U'))
BEGIN
	DROP TABLE [dbo].[UserHasPermission]	
END
CREATE TABLE [dbo].[UserHasPermission] (
		ID [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		UserPermissionId int NOT NULL,
		UserId bigint NOT NULL		
	);

IF EXISTS (SELECT 1 FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[MemberHasPermission]') AND type in (N'U'))
BEGIN
	DROP TABLE [dbo].[MemberHasPermission]	
END
CREATE TABLE [dbo].[MemberHasPermission] (
		ID [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		MemberPermissionId int NOT NULL,
		MemberId bigint	NOT NULL	
	);