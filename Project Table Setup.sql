USE [DBIntegration]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 6/30/2013 9:47:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Organization](
	[OrganizationId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrganizationCode] [nvarchar](50) NOT NULL,
	[OrganizationName] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[FaxNumber] [nvarchar](50) NULL,
	[ParentOrganizationCode] [nvarchar](50) NULL,
	[Theme] [nvarchar](50) NOT NULL,
	[Skin] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[DELETED] [bit] NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Organization] ADD  DEFAULT ((0)) FOR [Active]
GO

ALTER TABLE [dbo].[Organization] ADD  DEFAULT ((0)) FOR [DELETED]
GO

ALTER TABLE [dbo].[Organization] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[Organization] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

CREATE TABLE [dbo].[UserType](
	[UserTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [nvarchar](100) NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserType] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[UserType] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO


CREATE TABLE [dbo].[Person](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [bigint] NOT NULL,
	[UserTypeId] [bigint] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[UnitName] [nvarchar](50) NULL,
	[UnitNumber] [nvarchar](25) NULL,
	[Department] [nvarchar](50) NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Person] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[Person] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
GO

ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Organization]
GO

ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_UserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([UserTypeId])
GO


CREATE TABLE [dbo].[SiteType](
	[SiteTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[SiteTypeName] [nvarchar](100) NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[SiteTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SiteType] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[SiteType] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO



CREATE TABLE [dbo].[Site](
	[SiteId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [bigint] NOT NULL,
	[SiteTypeId] [bigint] NOT NULL,
	[SiteName] [nvarchar](100) NOT NULL,
	[SiteCode] [nvarchar](50) NULL,
	[TimeZoneId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Site] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[Site] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

ALTER TABLE [dbo].[Site]  WITH CHECK ADD  CONSTRAINT [FK_Site_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
GO

ALTER TABLE [dbo].[Site] CHECK CONSTRAINT [FK_Site_Organization]
GO

ALTER TABLE [dbo].[Site]  WITH CHECK ADD  CONSTRAINT [FK_Site_SiteType] FOREIGN KEY([SiteTypeId])
REFERENCES [dbo].[SiteType] ([SiteTypeId])
GO

ALTER TABLE [dbo].[Site] CHECK CONSTRAINT [FK_Site_SiteType]
GO



CREATE TABLE [dbo].[Address](
	[AddressId] [bigint] IDENTITY(1,1) NOT NULL,
	[SiteId] [bigint] NOT NULL,
	[AddressTypeId] [bigint] NOT NULL,
	[AddressLine1] [nvarchar](200) NULL,
	[AddressLine2] [nvarchar](200) NULL,
	[AddressLine3] [nvarchar](200) NULL,
	[City] [nvarchar](100) NULL,
	[StateProvinceRegionId] [bigint] NULL,
	[PostalCode] [nvarchar](50) NULL,
	[CountryRegionId] [bigint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Address] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[Address] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO

ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Site]
GO


CREATE TABLE [dbo].[Rules](
	[RuleId] [bigint] IDENTITY(1,1) NOT NULL,
	[ValueTypeId] [bigint] NOT NULL,
	[RuleName] [nvarchar](50) NOT NULL,
	[RuleDescription] [nvarchar](100) NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[ModifiedDateTime] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Rules] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[Rules] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO


