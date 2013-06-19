USE [DBIntegration];

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'Organization' AND T.TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [Organization]	(
										OrganizationId BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
										OrganizationCode NVARCHAR(50) NOT NULL,
										OrganizationName NVARCHAR(100) NOT NULL,
										PhoneNumber NVARCHAR(50) NULL,
										FaxNumber NVARCHAR(50) NULL,
										ParentOrganizationCode NVARCHAR(50) NULL,
										Theme NVARCHAR(50) NOT NULL,
										Skin NVARCHAR(50) NOT NULL,
										Active BIT DEFAULT	(0) NOT NULL,
										DELETED BIT DEFAULT (0) NOT NULL,
										CreatedDateTime DATETIME2 DEFAULT (GETDATE()) NOT NULL,
										CreatedBy NVARCHAR(100) DEFAULT (SUSER_SNAME()) NOT NULL,
										ModifiedDateTime DATETIME2 NULL,
										ModifiedBy NVARCHAR(100) NULL
									)
	END
	
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'SiteType' AND T.TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [SiteType]		(
										SiteTypeId BIGINT PRIMARY KEY NOT NULL,
										SiteTypeName NVARCHAR(100) NOT NULL,
										CreatedDateTime DATETIME2 DEFAULT (GETDATE()) NOT NULL,
										CreatedBy NVARCHAR(100) DEFAULT (SUSER_SNAME()) NOT NULL,
										ModifiedDateTime DATETIME2 NULL,
										ModifiedBy NVARCHAR(100) NULL									
									)
	END

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'Site' AND T.TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [Site]			(
										SiteId BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
										OrganizationId BIGINT NOT NULL,
										SiteTypeId BIGINT NOT NULL,
										SiteName NVARCHAR(100) NOT NULL,
										SiteCode NVARCHAR(50) NULL,
										TimeZoneId BIGINT NOT NULL,
										CreatedDateTime DATETIME2 DEFAULT (GETDATE()) NOT NULL,
										CreatedBy NVARCHAR(100) DEFAULT (SUSER_SNAME()) NOT NULL,
										ModifiedDateTime DATETIME2 NULL,
										ModifiedBy NVARCHAR(100) NULL,
									)
	END

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'Address' AND T.TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [Address]		(
										AddressId BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
										SiteId BIGINT NOT NULL,
										AddressTypeId BIGINT NOT NULL,
										AddressLine1 NVARCHAR(200) NULL,
										AddressLine2 NVARCHAR(200) NULL,
										AddressLine3 NVARCHAR(200) NULL,
										City NVARCHAR(100) NULL,
										StateProvinceRegionId BIGINT NULL,
										PostalCode NVARCHAR(50) NULL,
										CountryRegionId BIGINT NULL,
										CreatedDateTime DATETIME2 DEFAULT (GETDATE()) NOT NULL,
										CreatedBy NVARCHAR(100) DEFAULT (SUSER_SNAME()) NOT NULL,
										ModifiedDateTime DATETIME2 NULL,
										ModifiedBy NVARCHAR(100) NULL,

									)
	END

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'UserType' AND T.TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [UserType]	(
										UserTypeId BIGINT PRIMARY KEY NOT NULL,
										UserTypeName NVARCHAR(100) NOT NULL,
										CreatedDateTime DATETIME2 DEFAULT (GETDATE()) NOT NULL,
										CreatedBy NVARCHAR(100) DEFAULT (SUSER_SNAME()) NOT NULL,
										ModifiedDateTime DATETIME2 NULL,
										ModifiedBy NVARCHAR(100) NULL						
									)
	END

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'Person' AND T.TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [Person]		(
										UserId BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
										OrganizationId BIGINT NOT NULL,
										UserTypeId BIGINT NOT NULL,
										FirstName NVARCHAR(50) NOT NULL,
										LastName NVARCHAR(50) NOT NULL,
										PhoneNumber NVARCHAR(50) NULL,
										EmailAddress NVARCHAR(50) NULL,
										UnitName NVARCHAR(50) NULL,
										UnitNumber NVARCHAR(25) NULL,
										Department NVARCHAR(50) NULL,
										CreatedDateTime DATETIME2 DEFAULT (GETDATE()) NOT NULL,
										CreatedBy NVARCHAR(100) DEFAULT (SUSER_SNAME()) NOT NULL,
										ModifiedDateTime DATETIME2 NULL,
										ModifiedBy NVARCHAR(100) NULL,
									)
	END

GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_NAME = 'Rules' AND T.TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [Rules]		(
										RuleId BIGINT PRIMARY KEY NOT NULL,
										ValueTypeId BIGINT NOT NULL,
										RuleName NVARCHAR(50) NOT NULL,
										RuleDescription NVARCHAR(100) NULL,
										CreatedDateTime DATETIME2 DEFAULT (GETDATE()) NOT NULL,
										CreatedBy NVARCHAR(100) DEFAULT (SUSER_SNAME()) NOT NULL,
										ModifiedDateTime DATETIME2 NULL,
										ModifiedBy NVARCHAR(100) NULL,					
									)
	END

GO
