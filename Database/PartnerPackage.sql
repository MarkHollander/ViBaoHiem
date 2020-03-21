--Project: PSO_VBH
--Created By: Vu.DM
--Created Date: 03/03/2020
--Description: Tao cac table thong tin acc

-------------------
--Tao 2 table Package va Partner
IF  NOT EXISTS (SELECT 1 FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Package]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Package] (
		ID [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		PackageCode varchar(50) NOT NULL,
		PackageName nvarchar(150) NOT NULL,
		[Status] int NOT NULL,
		[IsDeleted] bit NOT NULL,
		CreatedDate datetime,
		CreatedBy [bigint]
	);
END

IF  NOT EXISTS (SELECT 1 FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Partner]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Partner] (
		ID [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		PartnerCode varchar(50) NOT NULL,
		PartnerName nvarchar(150) NOT NULL,
		[Status] int NOT NULL,
		[IsDeleted] bit NOT NULL,
		CreatedDate datetime,
		CreatedBy [bigint]
	);
END

GO

-------------------
--Tao 2 table PartnerPackage : Partner cung cap Package nao?
IF  NOT EXISTS (SELECT 1 FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[PartnerPackage]') AND type in (N'U'))
BEGIN
	CREATE TABLE PartnerPackage (
		ID [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		PartnerID bigint NOT NULL,
		PackageID bigint NOT NULL,
		TotalCommissionRate float, -- % hoa hong giua Vi va Partner 
		[Status] int NOT NULL,
		[IsDeleted] bit NOT NULL,
		CreatedDate datetime, -- lich su sua chua
		CreatedBy [bigint]
	);
END

GO

IF  NOT EXISTS (SELECT 1 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='FK_PartnerPackage_Partner')
BEGIN
	ALTER TABLE PartnerPackage
	ADD CONSTRAINT FK_PartnerPackage_Partner
	FOREIGN KEY (PartnerID) REFERENCES [Partner](ID);
END;

IF  NOT EXISTS (SELECT 1 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='FK_PartnerPackage_Package')
BEGIN
	ALTER TABLE PartnerPackage
	ADD CONSTRAINT FK_PartnerPackage_Package
	FOREIGN KEY (PackageID) REFERENCES [Package](ID);
END;

GO


--------------------------------------------------------
--Tao 2 table MemberPackage : Member ban Package nao?
IF  NOT EXISTS (SELECT 1 FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[MemberPackage]') AND type in (N'U'))
BEGIN
	CREATE TABLE MemberPackage (
		ID [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		MemberID bigint NOT NULL,
		PartnerPackageID bigint NOT NULL,
		TotalCommissionRate float, -- % hoa hong giua Vi va Partner, tao them de truy van nhanh
		PrimaryCommissionRate float, -- % hoa hong giua Vi trich cho member
		SubCommissionRate float, -- chua biet la gi
		[Status] int NOT NULL,
		[IsDeleted] bit NOT NULL,
		CreatedDate datetime, -- lich su sua chua
		CreatedBy [bigint]
	);
END;

GO


IF  NOT EXISTS (SELECT 1 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='FK_MemberPackage_PartnerPackage')
BEGIN
	ALTER TABLE MemberPackage
	ADD CONSTRAINT FK_MemberPackage_PartnerPackage
	FOREIGN KEY (PartnerPackageID) REFERENCES [PartnerPackage](ID);
END;


IF  NOT EXISTS (SELECT 1 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
    WHERE CONSTRAINT_NAME='FK_MemberPackage_PartnerPackage')
BEGIN
	ALTER TABLE MemberPackage
	ADD CONSTRAINT FK_MemberPackage_Member
	FOREIGN KEY (MemberID) REFERENCES [Member](MemberId);
END;

GO