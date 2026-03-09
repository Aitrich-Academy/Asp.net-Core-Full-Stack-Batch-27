USE [master]
GO
/****** Object:  Database [NewDB]    Script Date: 07-05-2024 11:03:40 ******/
CREATE DATABASE [NewDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NewDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NewDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NewDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NewDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NewDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NewDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NewDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NewDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewDB] SET RECOVERY FULL 
GO
ALTER DATABASE [NewDB] SET  MULTI_USER 
GO
ALTER DATABASE [NewDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NewDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NewDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NewDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NewDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NewDB', N'ON'
GO
ALTER DATABASE [NewDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [NewDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NewDB]
GO
/****** Object:  User [soudha]    Script Date: 07-05-2024 11:03:40 ******/
CREATE USER [soudha] FOR LOGIN [soudha] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthUser]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthUser](
	[Id] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Role] [int] NULL,
	[ConnectionId] [varchar](50) NULL,
	[OnlineStatus] [bit] NULL,
 CONSTRAINT [PK_AuthUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyUser]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyUser](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Role] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Company] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CompanyUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupMember]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupMember](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ToUserId] [uniqueidentifier] NULL,
	[Email] [nvarchar](max) NOT NULL,
	[MessageGroupId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_GroupMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Industry]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Industry](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Industry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interviews]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interviews](
	[Id] [uniqueidentifier] NOT NULL,
	[JobId] [uniqueidentifier] NULL,
	[interviewee] [uniqueidentifier] NULL,
	[ApplicationId] [uniqueidentifier] NULL,
	[Date] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
	[SheduledBy] [uniqueidentifier] NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Interviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobApplications]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobApplications](
	[Id] [uniqueidentifier] NOT NULL,
	[JobPost_id] [uniqueidentifier] NOT NULL,
	[Applicant] [uniqueidentifier] NOT NULL,
	[Resume_id] [uniqueidentifier] NOT NULL,
	[CoverLetter] [nvarchar](max) NOT NULL,
	[Datesubmitted] [datetime2](7) NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_JobApplications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobCategory]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobCategory](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPost]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPost](
	[Id] [uniqueidentifier] NOT NULL,
	[JobTitle] [nchar](10) NOT NULL,
	[JobSummary] [nvarchar](50) NOT NULL,
	[LocationId] [uniqueidentifier] NOT NULL,
	[CompanyId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[IndustryId] [uniqueidentifier] NOT NULL,
	[PostedBy] [uniqueidentifier] NOT NULL,
	[PostedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_JobPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobProviderCompany]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobProviderCompany](
	[Id] [uniqueidentifier] NOT NULL,
	[LegalName] [varchar](50) NOT NULL,
	[Summary] [varchar](50) NOT NULL,
	[IndustryId] [uniqueidentifier] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [bigint] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Website] [varchar](50) NOT NULL,
	[Location] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_JobProviderCompany] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobResponsibility]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobResponsibility](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](10) NULL,
	[Description] [nchar](10) NULL,
	[JobPost] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_JobResponsibility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobSeekerProfile]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSeekerProfile](
	[Id] [uniqueidentifier] NOT NULL,
	[ResumeId] [uniqueidentifier] NULL,
	[JobSeekerId] [uniqueidentifier] NOT NULL,
	[ProfileName] [nvarchar](max) NULL,
	[ProfileSummary] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobSeekerProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobSeekerProfileSkill]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSeekerProfileSkill](
	[JobSeekerProfileId] [uniqueidentifier] NOT NULL,
	[SkillId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_JobSeekerProfileSkill] PRIMARY KEY CLUSTERED 
(
	[JobSeekerProfileId] ASC,
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobSeekers]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobSeekers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Role] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_JobSeekers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Discription] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageGroups]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageGroups](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[newCount] [int] NOT NULL,
	[IsNewMessages] [bit] NOT NULL,
	[Members] [nvarchar](max) NULL,
 CONSTRAINT [PK_MessageGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [uniqueidentifier] NOT NULL,
	[FromUserId] [uniqueidentifier] NULL,
	[ToUserId] [uniqueidentifier] NULL,
	[MessageGroupId] [uniqueidentifier] NULL,
	[From] [nvarchar](max) NULL,
	[To] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NOT NULL,
	[SentDate] [datetime2](7) NOT NULL,
	[ToGroup] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[Id] [uniqueidentifier] NOT NULL,
	[ProfileName] [varbinary](50) NOT NULL,
	[Gender] [nchar](10) NOT NULL,
	[Discription] [nvarchar](50) NOT NULL,
	[Image] [varbinary](50) NOT NULL,
	[User] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualification]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualification](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[JobseekerProfileId] [uniqueidentifier] NULL,
	[JobPostId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Qualification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resume]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resume](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[File] [varbinary](max) NULL,
 CONSTRAINT [PK_Resume] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [uniqueidentifier] NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SavedJobs]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SavedJobs](
	[Id] [uniqueidentifier] NOT NULL,
	[Job] [uniqueidentifier] NOT NULL,
	[SavedBy] [uniqueidentifier] NOT NULL,
	[DateSaved] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SavedJobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SignUpRequests]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SignUpRequests](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_SignUpRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkExperience]    Script Date: 07-05-2024 11:03:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkExperience](
	[Id] [uniqueidentifier] NOT NULL,
	[JobSeekerProfileId] [uniqueidentifier] NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[ServiceStart] [datetime2](7) NOT NULL,
	[ServiceEnd] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyUser_Company]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_CompanyUser_Company] ON [dbo].[CompanyUser]
(
	[Company] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interviews_ApplicationId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_Interviews_ApplicationId] ON [dbo].[Interviews]
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interviews_CompanyId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_Interviews_CompanyId] ON [dbo].[Interviews]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interviews_interviewee]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_Interviews_interviewee] ON [dbo].[Interviews]
(
	[interviewee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interviews_JobId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_Interviews_JobId] ON [dbo].[Interviews]
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interviews_SheduledBy]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_Interviews_SheduledBy] ON [dbo].[Interviews]
(
	[SheduledBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobApplications_Applicant]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobApplications_Applicant] ON [dbo].[JobApplications]
(
	[Applicant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobApplications_JobPost_id]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobApplications_JobPost_id] ON [dbo].[JobApplications]
(
	[JobPost_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobApplications_Resume_id]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobApplications_Resume_id] ON [dbo].[JobApplications]
(
	[Resume_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobPost_JobLocation]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobPost_JobLocation] ON [dbo].[JobPost]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobProviderCompany_IndustryId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobProviderCompany_IndustryId] ON [dbo].[JobProviderCompany]
(
	[IndustryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobProviderCompany_Location]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobProviderCompany_Location] ON [dbo].[JobProviderCompany]
(
	[Location] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobResponsibility_JobPost]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobResponsibility_JobPost] ON [dbo].[JobResponsibility]
(
	[JobPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobSeekerProfile_JobSeekerId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobSeekerProfile_JobSeekerId] ON [dbo].[JobSeekerProfile]
(
	[JobSeekerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobSeekerProfile_ResumeId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobSeekerProfile_ResumeId] ON [dbo].[JobSeekerProfile]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobSeekerProfileSkill_SkillId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_JobSeekerProfileSkill_SkillId] ON [dbo].[JobSeekerProfileSkill]
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Qualification_JobPostId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_Qualification_JobPostId] ON [dbo].[Qualification]
(
	[JobPostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Qualification_JobseekerProfileId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_Qualification_JobseekerProfileId] ON [dbo].[Qualification]
(
	[JobseekerProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SavedJobs_Job]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_SavedJobs_Job] ON [dbo].[SavedJobs]
(
	[Job] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SavedJobs_SavedBy]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_SavedJobs_SavedBy] ON [dbo].[SavedJobs]
(
	[SavedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkExperience_JobSeekerProfileId]    Script Date: 07-05-2024 11:03:40 ******/
CREATE NONCLUSTERED INDEX [IX_WorkExperience_JobSeekerProfileId] ON [dbo].[WorkExperience]
(
	[JobSeekerProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Interviews] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [CompanyId]
GO
ALTER TABLE [dbo].[CompanyUser]  WITH CHECK ADD  CONSTRAINT [FK_CompanyUser_JobProviderCompany] FOREIGN KEY([Company])
REFERENCES [dbo].[JobProviderCompany] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompanyUser] CHECK CONSTRAINT [FK_CompanyUser_JobProviderCompany]
GO
ALTER TABLE [dbo].[GroupMember]  WITH CHECK ADD  CONSTRAINT [FK_GroupMember_MessageGroups_MessageGroupId] FOREIGN KEY([MessageGroupId])
REFERENCES [dbo].[MessageGroups] ([Id])
GO
ALTER TABLE [dbo].[GroupMember] CHECK CONSTRAINT [FK_GroupMember_MessageGroups_MessageGroupId]
GO
ALTER TABLE [dbo].[Interviews]  WITH CHECK ADD  CONSTRAINT [FK_Interviews_CompanyUser_SheduledBy] FOREIGN KEY([SheduledBy])
REFERENCES [dbo].[CompanyUser] ([Id])
GO
ALTER TABLE [dbo].[Interviews] CHECK CONSTRAINT [FK_Interviews_CompanyUser_SheduledBy]
GO
ALTER TABLE [dbo].[Interviews]  WITH CHECK ADD  CONSTRAINT [FK_Interviews_JobApplications_ApplicationId] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[JobApplications] ([Id])
GO
ALTER TABLE [dbo].[Interviews] CHECK CONSTRAINT [FK_Interviews_JobApplications_ApplicationId]
GO
ALTER TABLE [dbo].[Interviews]  WITH CHECK ADD  CONSTRAINT [FK_Interviews_JobPost_JobId] FOREIGN KEY([JobId])
REFERENCES [dbo].[JobPost] ([Id])
GO
ALTER TABLE [dbo].[Interviews] CHECK CONSTRAINT [FK_Interviews_JobPost_JobId]
GO
ALTER TABLE [dbo].[Interviews]  WITH CHECK ADD  CONSTRAINT [FK_Interviews_JobProviderCompany_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[JobProviderCompany] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interviews] CHECK CONSTRAINT [FK_Interviews_JobProviderCompany_CompanyId]
GO
ALTER TABLE [dbo].[Interviews]  WITH CHECK ADD  CONSTRAINT [FK_Interviews_JobSeekers_interviewee] FOREIGN KEY([interviewee])
REFERENCES [dbo].[JobSeekers] ([Id])
GO
ALTER TABLE [dbo].[Interviews] CHECK CONSTRAINT [FK_Interviews_JobSeekers_interviewee]
GO
ALTER TABLE [dbo].[JobApplications]  WITH CHECK ADD  CONSTRAINT [FK_JobApplications_JobPost_JobPost_id] FOREIGN KEY([JobPost_id])
REFERENCES [dbo].[JobPost] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobApplications] CHECK CONSTRAINT [FK_JobApplications_JobPost_JobPost_id]
GO
ALTER TABLE [dbo].[JobApplications]  WITH CHECK ADD  CONSTRAINT [FK_JobApplications_JobSeekers_Applicant] FOREIGN KEY([Applicant])
REFERENCES [dbo].[JobSeekers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobApplications] CHECK CONSTRAINT [FK_JobApplications_JobSeekers_Applicant]
GO
ALTER TABLE [dbo].[JobApplications]  WITH CHECK ADD  CONSTRAINT [FK_JobApplications_Resume_Resume_id] FOREIGN KEY([Resume_id])
REFERENCES [dbo].[Resume] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobApplications] CHECK CONSTRAINT [FK_JobApplications_Resume_Resume_id]
GO
ALTER TABLE [dbo].[JobPost]  WITH CHECK ADD  CONSTRAINT [FK_JobPost_Industry] FOREIGN KEY([PostedBy])
REFERENCES [dbo].[CompanyUser] ([Id])
GO
ALTER TABLE [dbo].[JobPost] CHECK CONSTRAINT [FK_JobPost_Industry]
GO
ALTER TABLE [dbo].[JobPost]  WITH CHECK ADD  CONSTRAINT [FK_JobPost_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[JobPost] CHECK CONSTRAINT [FK_JobPost_Location]
GO
ALTER TABLE [dbo].[JobProviderCompany]  WITH CHECK ADD  CONSTRAINT [FK_JobProviderCompany_Industry_IndustryId] FOREIGN KEY([IndustryId])
REFERENCES [dbo].[Industry] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobProviderCompany] CHECK CONSTRAINT [FK_JobProviderCompany_Industry_IndustryId]
GO
ALTER TABLE [dbo].[JobProviderCompany]  WITH CHECK ADD  CONSTRAINT [FK_JobProviderCompany_Location] FOREIGN KEY([Location])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[JobProviderCompany] CHECK CONSTRAINT [FK_JobProviderCompany_Location]
GO
ALTER TABLE [dbo].[JobResponsibility]  WITH CHECK ADD  CONSTRAINT [FK_JobResponsibility_JobPost] FOREIGN KEY([JobPost])
REFERENCES [dbo].[JobPost] ([Id])
GO
ALTER TABLE [dbo].[JobResponsibility] CHECK CONSTRAINT [FK_JobResponsibility_JobPost]
GO
ALTER TABLE [dbo].[JobSeekerProfile]  WITH CHECK ADD  CONSTRAINT [FK_JobSeekerProfile_JobSeekers_JobSeekerId] FOREIGN KEY([JobSeekerId])
REFERENCES [dbo].[JobSeekers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobSeekerProfile] CHECK CONSTRAINT [FK_JobSeekerProfile_JobSeekers_JobSeekerId]
GO
ALTER TABLE [dbo].[JobSeekerProfile]  WITH CHECK ADD  CONSTRAINT [FK_JobSeekerProfile_Resume_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resume] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobSeekerProfile] CHECK CONSTRAINT [FK_JobSeekerProfile_Resume_ResumeId]
GO
ALTER TABLE [dbo].[JobSeekerProfileSkill]  WITH CHECK ADD  CONSTRAINT [FK_JobSeekerProfileSkill_JobSeekerProfile_JobSeekerProfileId] FOREIGN KEY([JobSeekerProfileId])
REFERENCES [dbo].[JobSeekerProfile] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobSeekerProfileSkill] CHECK CONSTRAINT [FK_JobSeekerProfileSkill_JobSeekerProfile_JobSeekerProfileId]
GO
ALTER TABLE [dbo].[JobSeekerProfileSkill]  WITH CHECK ADD  CONSTRAINT [FK_JobSeekerProfileSkill_Skill_SkillId] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JobSeekerProfileSkill] CHECK CONSTRAINT [FK_JobSeekerProfileSkill_Skill_SkillId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_MessageGroups_MessageGroupId] FOREIGN KEY([MessageGroupId])
REFERENCES [dbo].[MessageGroups] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_MessageGroups_MessageGroupId]
GO
ALTER TABLE [dbo].[Qualification]  WITH CHECK ADD  CONSTRAINT [FK_Qualification_JobSeekerProfile] FOREIGN KEY([JobPostId])
REFERENCES [dbo].[JobPost] ([Id])
GO
ALTER TABLE [dbo].[Qualification] CHECK CONSTRAINT [FK_Qualification_JobSeekerProfile]
GO
ALTER TABLE [dbo].[Qualification]  WITH CHECK ADD  CONSTRAINT [FK_Qualification_JobSeekerProfile_JobseekerProfileId] FOREIGN KEY([JobseekerProfileId])
REFERENCES [dbo].[JobSeekerProfile] ([Id])
GO
ALTER TABLE [dbo].[Qualification] CHECK CONSTRAINT [FK_Qualification_JobSeekerProfile_JobseekerProfileId]
GO
ALTER TABLE [dbo].[SavedJobs]  WITH CHECK ADD  CONSTRAINT [FK_SavedJobs_JobPost_Job] FOREIGN KEY([Job])
REFERENCES [dbo].[JobPost] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SavedJobs] CHECK CONSTRAINT [FK_SavedJobs_JobPost_Job]
GO
ALTER TABLE [dbo].[SavedJobs]  WITH CHECK ADD  CONSTRAINT [FK_SavedJobs_JobSeekers_SavedBy] FOREIGN KEY([SavedBy])
REFERENCES [dbo].[JobSeekers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SavedJobs] CHECK CONSTRAINT [FK_SavedJobs_JobSeekers_SavedBy]
GO
ALTER TABLE [dbo].[WorkExperience]  WITH CHECK ADD  CONSTRAINT [FK_WorkExperience_JobSeekerProfile] FOREIGN KEY([JobSeekerProfileId])
REFERENCES [dbo].[JobSeekerProfile] ([Id])
GO
ALTER TABLE [dbo].[WorkExperience] CHECK CONSTRAINT [FK_WorkExperience_JobSeekerProfile]
GO
USE [master]
GO
ALTER DATABASE [NewDB] SET  READ_WRITE 
GO
