USE [master]
GO
/****** Object:  Database [MSC]    Script Date: 03 Dec 2018 9:24:32 AM ******/
CREATE DATABASE [MSC]
GO
ALTER DATABASE [MSC] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MSC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MSC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MSC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MSC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MSC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MSC] SET ARITHABORT OFF 
GO
ALTER DATABASE [MSC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MSC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MSC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MSC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MSC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MSC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MSC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MSC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MSC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MSC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MSC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MSC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MSC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MSC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MSC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MSC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MSC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MSC] SET RECOVERY FULL 
GO
ALTER DATABASE [MSC] SET  MULTI_USER 
GO
ALTER DATABASE [MSC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MSC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MSC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MSC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MSC] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MSC', N'ON'
GO
ALTER DATABASE [MSC] SET QUERY_STORE = OFF
GO
USE [MSC]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MSC]
GO
/****** Object:  Schema [vx]    Script Date: 03 Dec 2018 9:24:33 AM ******/
CREATE SCHEMA [vx]
GO
/****** Object:  Table [vx].[ProjectRequests_AuditTrail]    Script Date: 03 Dec 2018 9:24:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vx].[ProjectRequests_AuditTrail](
	[ID] [uniqueidentifier] NOT NULL,
	[ProjectName] [varchar](1000) NULL,
	[Description] [varchar](max) NULL,
	[ClientName] [varchar](256) NULL,
	[StartDate] [datetime2](0) NULL,
	[ExpectedEndDate] [datetime2](0) NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedDate] [datetime2](0) NULL,
	[ModifiedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime2](0) NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [ix_ProjectRequests_AuditTrail]    Script Date: 03 Dec 2018 9:24:34 AM ******/
CREATE CLUSTERED INDEX [ix_ProjectRequests_AuditTrail] ON [vx].[ProjectRequests_AuditTrail]
(
	[EndTime] ASC,
	[StartTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [vx].[ProjectRequests]    Script Date: 03 Dec 2018 9:24:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vx].[ProjectRequests](
	[ID] [uniqueidentifier] NOT NULL,
	[ProjectName] [varchar](1000) NULL,
	[Description] [varchar](max) NULL,
	[ClientName] [varchar](256) NULL,
	[StartDate] [datetime2](0) NULL,
	[ExpectedEndDate] [datetime2](0) NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedDate] [datetime2](0) NULL,
	[ModifiedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime2](0) NULL,
	[StartTime] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[EndTime] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([StartTime], [EndTime])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON ( HISTORY_TABLE = [vx].[ProjectRequests_AuditTrail] )
)
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 03 Dec 2018 9:24:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [vx].[Users]    Script Date: 03 Dec 2018 9:24:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [vx].[Users](
	[ID] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[PasswordHash] [varchar](1000) NULL,
 CONSTRAINT [PK_vx.Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [vx].[ProjectRequests] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'5b5a27f3-1fa7-4e79-9026-26396461eb25', N'SAS', N'This is a Sensory Administration Report Project', N'HM Sampoerna', CAST(N'2018-11-14T00:00:00.0000000' AS DateTime2), CAST(N'2020-04-23T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:08:23.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T17:53:07.0000000' AS DateTime2), CAST(N'2018-11-29T10:53:06.5336087' AS DateTime2), CAST(N'9999-12-31T23:59:59.9999999' AS DateTime2))
INSERT [vx].[ProjectRequests] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'00dac33d-ad3f-449b-afcc-6b01f3a7a9d2', N'DFIS Project', N'Distribution Facility Information System', N'Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:26:02.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T17:22:33.0000000' AS DateTime2), CAST(N'2018-11-29T10:22:32.8457854' AS DateTime2), CAST(N'9999-12-31T23:59:59.9999999' AS DateTime2))
INSERT [vx].[ProjectRequests] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'c3cb630e-3696-4af6-a0ba-d3ee63d12879', N'Crypto Projects', N'Crypto Projects', N'Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), N'MirzaEvolution', CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:35:00.0000000' AS DateTime2), CAST(N'2018-11-29T09:34:59.9618724' AS DateTime2), CAST(N'9999-12-31T23:59:59.9999999' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'c3cb630e-3696-4af6-a0ba-d3ee63d12879', N'Test Project', N'This is just a test', N'Sampoerna', CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), N'MirzaEvolution', CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), N'MirzaEvolution', CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), CAST(N'2018-11-29T09:02:51.8744648' AS DateTime2), CAST(N'2018-11-29T09:21:49.2898294' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'00dac33d-ad3f-449b-afcc-6b01f3a7a9d2', N'DFIS', N'This is just a test', N'Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:26:02.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:26:02.0000000' AS DateTime2), CAST(N'2018-11-29T09:26:02.3372552' AS DateTime2), CAST(N'2018-11-29T09:29:37.7975137' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'00dac33d-ad3f-449b-afcc-6b01f3a7a9d2', N'DFIS', N'This is just a test', N'Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:26:02.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:26:02.0000000' AS DateTime2), CAST(N'2018-11-29T09:29:37.7975137' AS DateTime2), CAST(N'2018-11-29T09:34:33.0705930' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'c3cb630e-3696-4af6-a0ba-d3ee63d12879', N'Test Project', N'This is just a test', N'Sampoerna', CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), N'MirzaEvolution', CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), N'MirzaEvolution', CAST(N'2018-11-29T16:02:52.0000000' AS DateTime2), CAST(N'2018-11-29T09:21:49.2898294' AS DateTime2), CAST(N'2018-11-29T09:34:59.9618724' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'00dac33d-ad3f-449b-afcc-6b01f3a7a9d2', N'DFIS', N'DFIS', N'Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:26:02.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:34:33.0000000' AS DateTime2), CAST(N'2018-11-29T09:34:33.0705930' AS DateTime2), CAST(N'2018-11-29T09:53:16.0622354' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'00dac33d-ad3f-449b-afcc-6b01f3a7a9d2', N'DFIS', N'Distribution Facility Information System', N'Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:26:02.0000000' AS DateTime2), N'admin', CAST(N'2018-11-29T16:53:16.0000000' AS DateTime2), CAST(N'2018-11-29T09:53:16.0622354' AS DateTime2), CAST(N'2018-11-29T10:22:05.3338045' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'00dac33d-ad3f-449b-afcc-6b01f3a7a9d2', N'DFIS', N'Distribution Facility Information System', N'HM Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:26:02.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T17:22:05.0000000' AS DateTime2), CAST(N'2018-11-29T10:22:05.3338045' AS DateTime2), CAST(N'2018-11-29T10:22:32.8457854' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'5b5a27f3-1fa7-4e79-9026-26396461eb25', N'SAS', N'Sensory Administration Report', N'Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2019-05-17T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:08:23.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:08:23.0000000' AS DateTime2), CAST(N'2018-11-29T09:08:23.4164494' AS DateTime2), CAST(N'2018-11-29T10:26:41.6490786' AS DateTime2))
INSERT [vx].[ProjectRequests_AuditTrail] ([ID], [ProjectName], [Description], [ClientName], [StartDate], [ExpectedEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [StartTime], [EndTime]) VALUES (N'5b5a27f3-1fa7-4e79-9026-26396461eb25', N'SAS Project', N'Sensory Administration Report Project', N'Sampoerna', CAST(N'2018-11-29T00:00:00.0000000' AS DateTime2), CAST(N'2019-11-16T00:00:00.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T16:08:23.0000000' AS DateTime2), N'mirzaevolution', CAST(N'2018-11-29T17:26:42.0000000' AS DateTime2), CAST(N'2018-11-29T10:26:41.6490786' AS DateTime2), CAST(N'2018-11-29T10:53:06.5336087' AS DateTime2))
INSERT [vx].[Users] ([ID], [UserName], [PasswordHash]) VALUES (N'424e1ac1-8e39-47e4-8166-4d1e330c1b0e', N'MirzaEvolution', N'67Peij2aQDZhMutd61r0TkyWwRaW+Pw06iwdi9g5kXE=')
INSERT [vx].[Users] ([ID], [UserName], [PasswordHash]) VALUES (N'f90ec444-f7ca-4eb9-9f88-e2570c10bc1a', N'Admin', N'/bmHu1gcirk9QpUigkO6jC7UwPwUJB/zEKl1TiPdpAc=')
/****** Object:  StoredProcedure [vx].[ProjectRequests_Insert]    Script Date: 03 Dec 2018 9:24:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [vx].[ProjectRequests_Insert]
(
	@ID UNIQUEIDENTIFIER,
	@ProjectName VARCHAR(1000),
	@Description VARCHAR(2000),
	@ClientName VARCHAR(256),
	@StartDate DATETIME2(0),
	@ExpectedEndDate DATETIME2(0),
	@CreatedBy VARCHAR(100),
	@CreatedDate DATETIME2(0),
	@ModifiedBy VARCHAR(100),
	@ModifiedDate DATETIME2(0),
	@Status VARCHAR(MAX) OUTPUT
)
AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		INSERT INTO vx.ProjectRequests
		VALUES
		(@ID,@ProjectName,@Description,@ClientName,@StartDate,@ExpectedEndDate,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate);
		COMMIT TRAN
		SET @Status = 'Success';
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SET @Status = CONCAT(ERROR_MESSAGE(),' - ',ERROR_LINE());
		SELECT @Status
	END CATCH
END
GO
/****** Object:  StoredProcedure [vx].[QueryHistoryByID]    Script Date: 03 Dec 2018 9:24:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [vx].[QueryHistoryByID]

	(
		@TableName NVARCHAR(256),
		@ID UNIQUEIDENTIFIER,
		@ShowAll BIT = 1
	)
	AS
	BEGIN

		DECLARE @IDName NVARCHAR(100);

		SELECT @IDName=B.COLUMN_NAME
		FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS A
		INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE B
		ON	A.CONSTRAINT_TYPE = 'PRIMARY KEY' AND
			A.CONSTRAINT_NAME = B.CONSTRAINT_NAME
		WHERE A.TABLE_NAME = @TableName
		ORDER BY A.TABLE_NAME, B.ORDINAL_POSITION;
		
		DECLARE @Query NVARCHAR(1000);

		IF(@ShowAll=1)
		BEGIN
			SET @Query = 'SELECT *, StartTime, EndTime FROM vx.' + @TableName + ' FOR SYSTEM_TIME ALL WHERE ' + @IDName + ' = @Value ORDER BY ID,EndTime DESC';
		END
		ELSE
		BEGIN
			SET @Query = 'SELECT TOP(2) *, StartTime, EndTime FROM vx.' + @TableName + ' FOR SYSTEM_TIME ALL WHERE ' + @IDName + ' = @Value ORDER BY ID,EndTime DESC';
		END

		EXEC sp_executesql @Query,N'@Value UNIQUEIDENTIFIER',@ID
	END

GO
USE [master]
GO
ALTER DATABASE [MSC] SET  READ_WRITE 
GO
