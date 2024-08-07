USE [master]
GO
/****** Object:  Database [SWP391DB]    Script Date: 7/23/2024 9:16:50 AM ******/
CREATE DATABASE [SWP391DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SWP391DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SWP391DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SWP391DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SWP391DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SWP391DB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SWP391DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SWP391DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SWP391DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SWP391DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SWP391DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SWP391DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SWP391DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SWP391DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SWP391DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SWP391DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SWP391DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SWP391DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SWP391DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SWP391DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SWP391DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SWP391DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SWP391DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SWP391DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SWP391DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SWP391DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SWP391DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SWP391DB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SWP391DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SWP391DB] SET RECOVERY FULL 
GO
ALTER DATABASE [SWP391DB] SET  MULTI_USER 
GO
ALTER DATABASE [SWP391DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SWP391DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SWP391DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SWP391DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SWP391DB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SWP391DB', N'ON'
GO
ALTER DATABASE [SWP391DB] SET QUERY_STORE = OFF
GO
USE [SWP391DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SWP391DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/23/2024 9:16:50 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/23/2024 9:16:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/23/2024 9:16:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/23/2024 9:16:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/23/2024 9:16:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/23/2024 9:16:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/23/2024 9:16:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConnectionId] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](10) NULL,
	[ManagerId] [nvarchar](450) NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/23/2024 9:16:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BasementTypes]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasementTypes](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[AreaFactor] [decimal](4, 2) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_BasementTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComboMaterials]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComboMaterials](
	[CombosId] [nvarchar](10) NOT NULL,
	[MaterialsId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_ComboMaterials] PRIMARY KEY CLUSTERED 
(
	[CombosId] ASC,
	[MaterialsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Combos]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Combos](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Status] [bit] NOT NULL,
	[ConstructionId] [nvarchar](10) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Combos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComboTasks]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComboTasks](
	[CombosId] [nvarchar](10) NOT NULL,
	[TasksId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_ComboTasks] PRIMARY KEY CLUSTERED 
(
	[CombosId] ASC,
	[TasksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConstructDetails]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConstructDetails](
	[QuotationId] [nvarchar](10) NOT NULL,
	[Width] [decimal](6, 2) NOT NULL,
	[Length] [decimal](6, 2) NOT NULL,
	[Facade] [int] NOT NULL,
	[Alley] [nvarchar](50) NOT NULL,
	[Floor] [int] NOT NULL,
	[Room] [int] NOT NULL,
	[Mezzanine] [decimal](6, 2) NOT NULL,
	[RooftopFloor] [decimal](6, 2) NOT NULL,
	[Balcony] [bit] NOT NULL,
	[Garden] [decimal](6, 2) NOT NULL,
	[ConstructionId] [nvarchar](10) NOT NULL,
	[InvestmentId] [nvarchar](10) NOT NULL,
	[FoundationId] [nvarchar](10) NOT NULL,
	[RooftopId] [nvarchar](10) NOT NULL,
	[BasementId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_ConstructDetails] PRIMARY KEY CLUSTERED 
(
	[QuotationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConstructionTypes]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConstructionTypes](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ConstructionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomQuotations]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomQuotations](
	[Id] [nvarchar](10) NOT NULL,
	[Date] [datetime2](7) NULL,
	[Acreage] [nvarchar](30) NULL,
	[Location] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[RequestId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_CustomQuotations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoundationTypes]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoundationTypes](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[AreaFactor] [decimal](4, 2) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_FoundationTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvestmentTypes]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestmentTypes](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_InvestmentTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialCategories]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialCategories](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MaterialCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialDetails]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuotationId] [nvarchar](10) NOT NULL,
	[MaterialId] [nvarchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_MaterialDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Materials]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Unit] [nvarchar](30) NOT NULL,
	[Status] [bit] NOT NULL,
	[CategoryId] [nvarchar](10) NOT NULL,
	[ImageUrl] [nvarchar](200) NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pricings]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pricings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConstructTypeId] [nvarchar](10) NOT NULL,
	[InvestmentTypeId] [nvarchar](10) NOT NULL,
	[UnitPrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Pricings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectImages]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](200) NOT NULL,
	[ProjectId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_ProjectImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Location] [nvarchar](200) NOT NULL,
	[Scale] [nvarchar](200) NOT NULL,
	[Size] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Overview] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[CustomerId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RejectionReports]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RejectionReports](
	[Id] [nvarchar](10) NOT NULL,
	[RejectedQuotationId] [nvarchar](10) NOT NULL,
	[EngineerId] [nvarchar](450) NOT NULL,
	[ManagerId] [nvarchar](450) NOT NULL,
	[Reason] [nvarchar](500) NULL,
	[ReceiveDay] [datetime2](7) NULL,
	[RejectedDay] [datetime2](7) NULL,
	[SubmitDay] [datetime2](7) NULL,
 CONSTRAINT [PK_RejectionReports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequestForms]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestForms](
	[Id] [nvarchar](10) NOT NULL,
	[GenerateDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ConstructType] [nvarchar](30) NULL,
	[Acreage] [nvarchar](30) NULL,
	[Location] [nvarchar](200) NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
	[CustomerId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_RequestForms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RooftopTypes]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RooftopTypes](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[AreaFactor] [decimal](4, 2) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_RooftopTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaskCategories]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskCategories](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TaskCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaskDetails]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [nvarchar](10) NOT NULL,
	[QuotationId] [nvarchar](10) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TaskDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Status] [bit] NOT NULL,
	[CategoryId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkingReports]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingReports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StaffId] [nvarchar](450) NOT NULL,
	[RequestId] [nvarchar](10) NOT NULL,
	[ReceiveDate] [datetime2](7) NULL,
	[SubmitDate] [datetime2](7) NULL,
 CONSTRAINT [PK_WorkingReports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240303061532_UpdateDb', N'6.0.27')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240303090243_FixBug', N'6.0.27')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240303120319_AddIdentityTables', N'6.0.27')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240306205417_UpdateApplicationUser', N'6.0.27')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2623431e-b62a-4959-8577-cd79815ef403', N'Customer', N'CUSTOMER', N'd3132637-8e37-4891-a6f3-5c849bb1cc7c')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'625c8d38-f6a4-47b3-9a5e-0d5a05cad818', N'Manager', N'MANAGER', N'1f0cfabf-3702-48bf-ba06-19fceefe3705')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6781560d-a480-4bde-9f27-5f9f50ef9fec', N'Engineer', N'ENGINEER', N'74ba9688-40ba-4b00-983c-837d960b3688')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8e6f036f-8276-4e42-9577-1c7e8bcb9951', N'Admin', N'ADMIN', N'e741319d-f62c-403e-be71-5958f47d4db7')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b987e311-236d-4dff-b476-4d4807c829d1', N'Seller', N'SELLER', N'9b3bd1aa-03ad-4a35-b24f-8c4ecd213596')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'185b799f-c0ad-4be9-849c-b96d2547e15c', N'2623431e-b62a-4959-8577-cd79815ef403')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6f1de662-b815-4306-b660-fcad4c14fc0d', N'625c8d38-f6a4-47b3-9a5e-0d5a05cad818')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d5ee810-7721-4615-accd-60f055c73979', N'6781560d-a480-4bde-9f27-5f9f50ef9fec')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eeab2f60-6fe9-436f-afec-8eae12ca8289', N'6781560d-a480-4bde-9f27-5f9f50ef9fec')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'119a71e7-e25f-4614-bfbc-345ca2e34b69', N'8e6f036f-8276-4e42-9577-1c7e8bcb9951')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3c27bd76-c9c6-4723-8c6a-541ddd6e91c2', N'b987e311-236d-4dff-b476-4d4807c829d1')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ConnectionId], [Discriminator], [Gender], [ManagerId], [Name]) VALUES (N'119a71e7-e25f-4614-bfbc-345ca2e34b69', N'vudat.dev@gmail.com', N'VUDAT.DEV@GMAIL.COM', N'vudat.dev@gmail.com', N'VUDAT.DEV@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOui/JKmXfip/BNo/pzWDg+miqPPlWR4RNUoXWmpkX3m9VIqjhjGk167dxarAA3uvg==', N'TLZ63IPMR5Q5DQCXJRUNQIRZPSL3WXU3', N'f8b3b837-4d35-434f-8100-d6339d15ffe1', N'1283012830', 0, 0, CAST(N'2024-03-13T12:05:54.3325687+07:00' AS DateTimeOffset), 1, 0, NULL, N'ApplicationUser', N'Nam', NULL, N'Tuan H')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ConnectionId], [Discriminator], [Gender], [ManagerId], [Name]) VALUES (N'185b799f-c0ad-4be9-849c-b96d2547e15c', N'minhkhoi.dev@gmail.com', N'MINHKHOI.DEV@GMAIL.COM', N'minhkhoi.dev@gmail.com', N'MINHKHOI.DEV@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHQh3j4hy1C3W+cw7cPp2O2+nVGcbIN9zbZKTjI9RgWFcMzCorUttzNRLbHczVj2XA==', N'OVCSQHAIY5DTPWN4CI4JGTNLKCMXPNA6', N'2cf88318-876a-4ff3-8062-c6681dd68360', N'1283012830', 0, 0, CAST(N'2024-03-13T12:05:51.1502367+07:00' AS DateTimeOffset), 1, 0, NULL, N'ApplicationUser', N'Nam', NULL, N'Uhio43')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ConnectionId], [Discriminator], [Gender], [ManagerId], [Name]) VALUES (N'2d5ee810-7721-4615-accd-60f055c73979', N'datsung.dev2@gmail.com', N'DATSUNG.DEV2@GMAIL.COM', N'datsung.dev2@gmail.com', N'DATSUNG.DEV2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJh4/dEuYRpKqCQGBI03X4PXKIsPH0llsh7wltqSfDg7M8R1tOuKZkxjyM6C0z6wfw==', N'E5EMLQBF65GFMYN3AB6MMLWAGNKKSREN', N'7b4e11d9-4f10-48f3-b5c6-70470e1f1e2f', NULL, 0, 0, CAST(N'2024-03-29T01:17:55.0118142+07:00' AS DateTimeOffset), 1, 0, NULL, N'ApplicationUser', NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ConnectionId], [Discriminator], [Gender], [ManagerId], [Name]) VALUES (N'3c27bd76-c9c6-4723-8c6a-541ddd6e91c2', N'minhduc.dev@gmail.com', N'MINHDUC.DEV@GMAIL.COM', N'minhduc.dev@gmail.com', N'MINHDUC.DEV@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOao4tQL7zw+W57cx1pc/pNLnx2vGDENsxTn9NeTe/DtTaeZaUqSFn0/2RIf4EgEBg==', N'IYDGCK74CRKUV6BQC3Q6SJQUYFTX7CZJ', N'3ce2a0e9-1d62-4983-b370-8318ccf6625b', NULL, 0, 0, NULL, 1, 0, NULL, N'ApplicationUser', NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ConnectionId], [Discriminator], [Gender], [ManagerId], [Name]) VALUES (N'6f1de662-b815-4306-b660-fcad4c14fc0d', N'xuandat.dev@gmail.com', N'XUANDAT.DEV@GMAIL.COM', N'xuandat.dev@gmail.com', N'XUANDAT.DEV@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENyk71BBexo/sSUII0V75mxDrcHBfGGlB6W//AP5uV77sci7qiyArcCjTYkGx6mlug==', N'KPFAQC2U5RJ5B5OQJJBSZLDSQD26QDNH', N'2f4e6486-bd81-43b4-9c28-d068a90bf431', N'1283012830', 0, 0, CAST(N'2024-03-13T12:05:45.3401061+07:00' AS DateTimeOffset), 1, 0, NULL, N'ApplicationUser', N'Nam', NULL, N'Uhio43')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [ConnectionId], [Discriminator], [Gender], [ManagerId], [Name]) VALUES (N'eeab2f60-6fe9-436f-afec-8eae12ca8289', N'datsung.dev@gmail.com', N'DATSUNG.DEV@GMAIL.COM', N'datsung.dev@gmail.com', N'DATSUNG.DEV@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEC2fFIBDnqgAUgTDe/P7MzqeeErKtOrsgRKEet6ZA7zze+cpg1EpMVNUIMr/Fb8qcg==', N'NYHZTLVUQ2MIVHIMGJWZO5RHFNFAU4VD', N'c133dd9a-e1dd-46e5-993f-a9e576481b4d', N'0339315466', 0, 0, NULL, 1, 0, NULL, N'ApplicationUser', N'Nam', NULL, N'Nguyễn Thành Đạt')
GO
INSERT [dbo].[BasementTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'BT1', N'Không Hầm', CAST(0.00 AS Decimal(4, 2)), N'Không có h?m')
GO
INSERT [dbo].[BasementTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'BT2', N'Độ Sâu 1.0 - 1.3', CAST(1.50 AS Decimal(4, 2)), N'H?m Ð? Sâu 1.0 - 1.3 m')
GO
INSERT [dbo].[BasementTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'BT3', N'Độ Sâu 1.3 - 1.7', CAST(1.70 AS Decimal(4, 2)), N'H?m Ð? Sâu 1.3 - 1.7 m')
GO
INSERT [dbo].[BasementTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'BT4', N'Độ sâu 1.7 - 2.0', CAST(2.00 AS Decimal(4, 2)), N'H?m Ð? Sâu 1.7 - 2.0 m')
GO
INSERT [dbo].[BasementTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'BT5', N'Độ Sâu >2.0', CAST(2.50 AS Decimal(4, 2)), N'H?m Ð? sâu L?n Hon 2.0 m')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0002', N'VT1001')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0003', N'VT1001')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0005', N'VT1001')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0006', N'VT1001')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0002', N'VT1002')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0003', N'VT1002')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0004', N'VT1002')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0005', N'VT1002')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0006', N'VT1002')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0003', N'VT1003')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0004', N'VT1003')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0005', N'VT1003')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0006', N'VT1003')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0002', N'VT1004')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0004', N'VT1004')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0006', N'VT1004')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0004', N'VT1005')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0006', N'VT1005')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0004', N'VT1006')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0004', N'VT1007')
GO
INSERT [dbo].[ComboMaterials] ([CombosId], [MaterialsId]) VALUES (N'CB0002', N'VT1010')
GO
INSERT [dbo].[Combos] ([Id], [Name], [Description], [Price], [Status], [ConstructionId], [ImageUrl]) VALUES (N'CB0002', N'Nhà cấp 4 sang trọng', N'abc', CAST(10000000.00 AS Decimal(18, 2)), 1, N'CT1', N'\images\combo\df52a3d8-b7a2-433f-9255-2c59a8866f3a.jpg')
GO
INSERT [dbo].[Combos] ([Id], [Name], [Description], [Price], [Status], [ConstructionId], [ImageUrl]) VALUES (N'CB0003', N'Nhà phố 3 mặt tiền', N'có sân vườn có 1 trệt 4 lầu có hầm có ban công', CAST(10000000.00 AS Decimal(18, 2)), 1, N'CT1', N'\images\combo\9615a561-9bec-4184-b19d-83a61d0a6af1.jpg')
GO
INSERT [dbo].[Combos] ([Id], [Name], [Description], [Price], [Status], [ConstructionId], [ImageUrl]) VALUES (N'CB0004', N'Nhà biệt thự 4 lầu', N'Nhà to đẹp', CAST(400000000.00 AS Decimal(18, 2)), 1, N'CT2', N'\images\combo\603aa003-0a5c-4d2e-8733-c123b30b1515.jpg')
GO
INSERT [dbo].[Combos] ([Id], [Name], [Description], [Price], [Status], [ConstructionId], [ImageUrl]) VALUES (N'CB0005', N'Nhà biệt thự 3 lầu', N'sang trọng quý phái, có sân và có ban công, không gian rộng rãi thoáng mát', CAST(450000000.00 AS Decimal(18, 2)), 1, N'CT2', N'\images\combo\e2db8e61-af66-433a-a9f5-a22d91aceed0.jpg')
GO
INSERT [dbo].[Combos] ([Id], [Name], [Description], [Price], [Status], [ConstructionId], [ImageUrl]) VALUES (N'CB0006', N'Nhà phố 1 mặt tiền', N'Nhà có thiết kế vintage', CAST(200000000.00 AS Decimal(18, 2)), 1, N'CT1', N'\images\combo\8dd28a8b-4486-40e0-85b1-e356574cf2ba.jpg')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0002', N'TSK001')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0003', N'TSK001')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0004', N'TSK001')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0005', N'TSK001')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0006', N'TSK001')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0002', N'TSK002')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0003', N'TSK002')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0004', N'TSK002')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0005', N'TSK002')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0006', N'TSK002')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0002', N'TSK003')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0003', N'TSK003')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0004', N'TSK003')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0005', N'TSK003')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0004', N'TSK004')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0005', N'TSK004')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0004', N'TSK005')
GO
INSERT [dbo].[ComboTasks] ([CombosId], [TasksId]) VALUES (N'CB0002', N'TSK007')
GO
INSERT [dbo].[ConstructDetails] ([QuotationId], [Width], [Length], [Facade], [Alley], [Floor], [Room], [Mezzanine], [RooftopFloor], [Balcony], [Garden], [ConstructionId], [InvestmentId], [FoundationId], [RooftopId], [BasementId]) VALUES (N'CQ001', CAST(20.00 AS Decimal(6, 2)), CAST(30.00 AS Decimal(6, 2)), 3, N'3', 3, 8, CAST(30.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), 1, CAST(20.00 AS Decimal(6, 2)), N'CT1', N'IT1', N'FT2', N'RT3', N'BT2')
GO
INSERT [dbo].[ConstructDetails] ([QuotationId], [Width], [Length], [Facade], [Alley], [Floor], [Room], [Mezzanine], [RooftopFloor], [Balcony], [Garden], [ConstructionId], [InvestmentId], [FoundationId], [RooftopId], [BasementId]) VALUES (N'CQ004', CAST(10.00 AS Decimal(6, 2)), CAST(10.00 AS Decimal(6, 2)), 1, N'Lớn hơn 5m', 4, 3, CAST(10.00 AS Decimal(6, 2)), CAST(10.00 AS Decimal(6, 2)), 1, CAST(10.00 AS Decimal(6, 2)), N'CT1', N'IT1', N'FT1', N'RT1', N'BT1')
GO
INSERT [dbo].[ConstructionTypes] ([Id], [Name], [Description]) VALUES (N'CT1', N'Nhà Phố', N'Nhà ở thành phố đông đúc, diện tích đất hẹp.')
GO
INSERT [dbo].[ConstructionTypes] ([Id], [Name], [Description]) VALUES (N'CT2', N'Biệt thự', N'Quy mô lớn, kiến trúc đẹp, đất rộng.')
GO
INSERT [dbo].[ConstructionTypes] ([Id], [Name], [Description]) VALUES (N'CT3', N'Nhà cấp bốn', N'Nhà cơ bản, chi phí rẻ, thông dụng, đất dài.')
GO
INSERT [dbo].[CustomQuotations] ([Id], [Date], [Acreage], [Location], [Status], [Description], [Total], [RequestId]) VALUES (N'CQ001', CAST(N'2024-03-08T19:37:29.1170935' AS DateTime2), N'10x10', N'Ho Chi Minh', 2, N'I wana build a house', CAST(13192036000.00 AS Decimal(18, 2)), N'RF001')
GO
INSERT [dbo].[CustomQuotations] ([Id], [Date], [Acreage], [Location], [Status], [Description], [Total], [RequestId]) VALUES (N'CQ004', CAST(N'2024-03-29T03:06:35.8029787' AS DateTime2), N'90 x 100', N'phường bến nghé quận 1', 2, N'Nhà to cần có sân thoáng đãng cho trẻ em vui chơi giải trí', CAST(0.00 AS Decimal(18, 2)), N'RF004')
GO
INSERT [dbo].[FoundationTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'FT1', N'Móng Đơn', CAST(0.30 AS Decimal(4, 2)), N'Móng don')
GO
INSERT [dbo].[FoundationTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'FT2', N'Móng Bằng', CAST(0.65 AS Decimal(4, 2)), N'Móng b?ng')
GO
INSERT [dbo].[FoundationTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'FT3', N'Móng Đài Cọc', CAST(0.50 AS Decimal(4, 2)), N'Móng dài c?c')
GO
INSERT [dbo].[InvestmentTypes] ([Id], [Name], [Description]) VALUES (N'IT1', N'Xây nhà phần thô', N'Xây nhà ph?n thô')
GO
INSERT [dbo].[InvestmentTypes] ([Id], [Name], [Description]) VALUES (N'IT2', N'Xây nhà trọn gói', N'Xây nhà tr?n gói')
GO
INSERT [dbo].[InvestmentTypes] ([Id], [Name], [Description]) VALUES (N'IT3', N'Mức TB', N'M?c trung bình')
GO
INSERT [dbo].[InvestmentTypes] ([Id], [Name], [Description]) VALUES (N'IT4', N'Mức Khá', N'M?c khá')
GO
INSERT [dbo].[InvestmentTypes] ([Id], [Name], [Description]) VALUES (N'IT5', N'Mức Khá +', N'M?c khá +')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT1', N'Vật tư thô')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT2', N'Sơn nước sơn dầu')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT3', N'Điện')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT4', N'Vệ sinh')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT5', N'Bếp')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT6', N'Cầu thang')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT7', N'Cửa')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT8', N'Gạch ốp lát')
GO
INSERT [dbo].[MaterialCategories] ([Id], [Name]) VALUES (N'VT9', N'Trần')
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1001', N'Sắt thép Việt Nhật', CAST(36000.00 AS Decimal(18, 2)), N'm', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1002', N'Xi măng đổ bê tông Holcim', CAST(90000.00 AS Decimal(18, 2)), N'bao', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1003', N'Xi măng xây tô tường Hà Tiên', CAST(85000.00 AS Decimal(18, 2)), N'bao', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1004', N'Bê tông tươi Lê Phan - Hoàng Sở M250', CAST(10200000.00 AS Decimal(18, 2)), N'm3', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1005', N'Cát hạt lớn', CAST(120000.00 AS Decimal(18, 2)), N'm3', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1006', N'Cát hạt vàng trung', CAST(200000.00 AS Decimal(18, 2)), N'm3', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1007', N'Đá xanh Đồng Nai', CAST(1500000.00 AS Decimal(18, 2)), N'ton', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1008', N'Gạch đinh 8x8x18 Tuynel Bình Dương', CAST(1090.00 AS Decimal(18, 2)), N'viên', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1009', N'Gạch đinh 4x8x18 Tuynel Bình Dương', CAST(920.00 AS Decimal(18, 2)), N'viên', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1010', N'Cáp TV Sino', CAST(5000.00 AS Decimal(18, 2)), N'm', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1011', N'Cáp TV Sino (Panasonic)', CAST(5000.00 AS Decimal(18, 2)), N'm', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1012', N'Cáp mạng Sino', CAST(15000.00 AS Decimal(18, 2)), N'm', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1013', N'Cáp mạng Sino (Panasonic)', CAST(17000.00 AS Decimal(18, 2)), N'm', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1014', N'Đế âm tường Sino', CAST(4000.00 AS Decimal(18, 2)), N'cái', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1015', N'Đường ống nóng âm tường Vesbo', CAST(67000.00 AS Decimal(18, 2)), N'm', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1016', N'Đường ống cấp nước, thoát nước Bình Minh', CAST(46000.00 AS Decimal(18, 2)), N'm', 1, N'VT1', NULL)
GO
INSERT [dbo].[Materials] ([Id], [Name], [UnitPrice], [Unit], [Status], [CategoryId], [ImageUrl]) VALUES (N'VT1017', N'Hóa chất chống thấm ban công, sân thượng, WC Kova CF-11A, Sika - 1F', CAST(1100000.00 AS Decimal(18, 2)), N'thùng', 1, N'VT1', NULL)
GO
SET IDENTITY_INSERT [dbo].[Pricings] ON 

GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (1, N'CT1', N'IT1', CAST(3200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (2, N'CT1', N'IT2', CAST(5800000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (3, N'CT1', N'IT3', CAST(4600000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (4, N'CT1', N'IT4', CAST(5200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (5, N'CT1', N'IT5', CAST(5800000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (6, N'CT2', N'IT1', CAST(3400000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (7, N'CT2', N'IT2', CAST(6200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (8, N'CT2', N'IT3', CAST(4800000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (9, N'CT2', N'IT4', CAST(5500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (10, N'CT2', N'IT5', CAST(6200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (11, N'CT3', N'IT1', CAST(2200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (12, N'CT3', N'IT2', CAST(4500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (13, N'CT3', N'IT3', CAST(4500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (14, N'CT3', N'IT4', CAST(4500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Pricings] ([Id], [ConstructTypeId], [InvestmentTypeId], [UnitPrice]) VALUES (15, N'CT3', N'IT5', CAST(4500000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Pricings] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectImages] ON 

GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (1, N'\images\project\project-PJ0002\78f58685-6164-4fe3-926c-e8934ae4b893.jpg', N'PJ0002')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (2, N'\images\project\project-PJ0002\88d6bff1-6608-46d3-8cc3-23a5d00f7a60.jpg', N'PJ0002')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (3, N'\images\project\project-PJ0003\52670ae0-f44f-479a-bb56-9304df5e9313.jpg', N'PJ0003')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (4, N'\images\project\project-PJ0003\8db6ab20-f630-4ff3-a5a5-1ab849563bc4.jpg', N'PJ0003')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (5, N'\images\project\project-PJ0003\343a054c-5e44-43e6-9beb-de14feb0ab02.jpg', N'PJ0003')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (6, N'\images\project\project-PJ0004\37179f93-0d95-49e0-af75-8e6f6c4b48ef.jpg', N'PJ0004')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (7, N'\images\project\project-PJ0005\6ead99fc-7997-410a-86f1-a6f6e307ee94.jpg', N'PJ0005')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (8, N'\images\project\project-PJ0005\6a1409a0-1e21-4d40-9625-9172eb3c7710.jpg', N'PJ0005')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (9, N'\images\project\project-PJ0005\d7810843-f114-4817-975e-2c3c119fa2cd.jpg', N'PJ0005')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (10, N'\images\project\project-PJ0005\322f8c52-26d1-4f4f-95b9-39c39593bd59.jpg', N'PJ0005')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (11, N'\images\project\project-PJ0006\f311a76a-0d78-457d-a6d8-a4dafd22c71a.jpg', N'PJ0006')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (12, N'\images\project\project-PJ0006\6348c577-4d9e-4eed-92d7-3c0ee9df479e.jpg', N'PJ0006')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (13, N'\images\project\project-PJ0006\ae85d96b-8aa3-481a-a90d-c2de9fc13781.jpg', N'PJ0006')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (14, N'\images\project\project-PJ0007\912234a5-3e92-4d56-88eb-ec9790140c72.jpg', N'PJ0007')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (15, N'\images\project\project-PJ0007\7b6b6c7f-50ea-4b2a-b013-e381fab389f1.jpg', N'PJ0007')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (16, N'\images\project\project-PJ0007\4f7eecf7-66bd-4e48-b497-964aa945418a.jpg', N'PJ0007')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (17, N'\images\project\project-PJ0008\48cd8916-6324-482f-8878-fcff611e9aa9.jpg', N'PJ0008')
GO
INSERT [dbo].[ProjectImages] ([Id], [ImageUrl], [ProjectId]) VALUES (18, N'\images\project\project-PJ0008\f96c1ee4-8d39-45f5-bab7-23f4f1b3794d.jpg', N'PJ0008')
GO
SET IDENTITY_INSERT [dbo].[ProjectImages] OFF
GO
INSERT [dbo].[Projects] ([Id], [Name], [Location], [Scale], [Size], [Description], [Overview], [Status], [Date], [CustomerId]) VALUES (N'PJ0002', N'Nhà của Khôi', N'tô hiến thành quận 10', N'3 trệt 1 lầu', N'40m x 50m', N'Nhà to cấp 4 5 người ở có nhiều phòng ngủ và có sân', N'Nhà đẹp', 1, CAST(N'2024-03-29T01:12:00.0000000' AS DateTime2), N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[Projects] ([Id], [Name], [Location], [Scale], [Size], [Description], [Overview], [Status], [Date], [CustomerId]) VALUES (N'PJ0003', N'Nhà của Dưc', N'sư vạn hạnh quận 10', N'1 trệt 3 lầu', N'40m x 70m', N'Nhà to có sân cho trẻ em, thiết kế sang trọng không có hầm', N'Nhà đẹp có nhiều tầng', 1, CAST(N'2024-04-06T01:15:00.0000000' AS DateTime2), N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[Projects] ([Id], [Name], [Location], [Scale], [Size], [Description], [Overview], [Status], [Date], [CustomerId]) VALUES (N'PJ0004', N'Nhà của Dat Xung', N'phường bến nghé quận 1', N'1 trệt 1 hầm 4 lầu', N'30m x 100m', N'Biệt thự, có sân có lầu cho trẻ em, nhà có ban công có lửng ', N'Nhà đẹp', 1, CAST(N'2024-03-29T02:34:00.0000000' AS DateTime2), N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[Projects] ([Id], [Name], [Location], [Scale], [Size], [Description], [Overview], [Status], [Date], [CustomerId]) VALUES (N'PJ0005', N'Nhà của Đạt Vũ', N'tô hiến thành quận 10', N'5 lầu 10 phòng ngủ', N'40m x 70m', N'Nhà to đẹp', N'Nhà ấm cúng', 1, CAST(N'2024-03-02T02:37:00.0000000' AS DateTime2), N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[Projects] ([Id], [Name], [Location], [Scale], [Size], [Description], [Overview], [Status], [Date], [CustomerId]) VALUES (N'PJ0006', N'Nhà của Xuân Đạt', N'tô hiến thành quận 10', N'5 lầu 10 phòng ngủ', N'40m x 70m', N'Nhà đẹp', N'Nhà cao', 1, CAST(N'2024-03-29T02:38:00.0000000' AS DateTime2), N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[Projects] ([Id], [Name], [Location], [Scale], [Size], [Description], [Overview], [Status], [Date], [CustomerId]) VALUES (N'PJ0007', N'Nhà của Anthony', N'tô hiến thành quận 10', N'5 lầu 10 phòng ngủ', N'40m x 70m', N'Nhà cao', N'Nhà đẹp', 1, CAST(N'2024-03-29T02:39:00.0000000' AS DateTime2), N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[Projects] ([Id], [Name], [Location], [Scale], [Size], [Description], [Overview], [Status], [Date], [CustomerId]) VALUES (N'PJ0008', N'Nhà của Tim', N'tô hiến thành quận 10', N'5 lầu 10 phòng ngủ', N'40m x 70m', N'Nhà đẹp ', N'Nhà cao', 1, CAST(N'2024-04-06T02:39:00.0000000' AS DateTime2), N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[RejectionReports] ([Id], [RejectedQuotationId], [EngineerId], [ManagerId], [Reason], [ReceiveDay], [RejectedDay], [SubmitDay]) VALUES (N'RCQ001', N'CQ001', N'2d5ee810-7721-4615-accd-60f055c73979', N'6f1de662-b815-4306-b660-fcad4c14fc0d', N'Retake this again', CAST(N'2024-03-08T19:41:05.0000000' AS DateTime2), CAST(N'2024-03-08T19:41:15.5744549' AS DateTime2), CAST(N'2024-03-08T19:40:48.0000000' AS DateTime2))
GO
INSERT [dbo].[RejectionReports] ([Id], [RejectedQuotationId], [EngineerId], [ManagerId], [Reason], [ReceiveDay], [RejectedDay], [SubmitDay]) VALUES (N'RCQ002', N'CQ001', N'2d5ee810-7721-4615-accd-60f055c73979', N'6f1de662-b815-4306-b660-fcad4c14fc0d', N'Retake this again', CAST(N'2024-03-08T19:42:15.0000000' AS DateTime2), CAST(N'2024-03-08T19:42:23.4502865' AS DateTime2), CAST(N'2024-03-08T19:41:50.0000000' AS DateTime2))
GO
INSERT [dbo].[RequestForms] ([Id], [GenerateDate], [Description], [ConstructType], [Acreage], [Location], [Status], [CustomerId]) VALUES (N'RF001', CAST(N'2024-03-08T19:36:55.3969728' AS DateTime2), N'I wana build a house', N'Nhà Phố', N'10x10', N'Ho Chi Minh', N'Approved', N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[RequestForms] ([Id], [GenerateDate], [Description], [ConstructType], [Acreage], [Location], [Status], [CustomerId]) VALUES (N'RF002', CAST(N'2024-03-29T02:58:28.9540426' AS DateTime2), N'nhà đẹp to cao', N'Nhà Phố', N'90 x 100', N'sư vạn hạnh quận 10', N'Đang xử lí', N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[RequestForms] ([Id], [GenerateDate], [Description], [ConstructType], [Acreage], [Location], [Status], [CustomerId]) VALUES (N'RF003', CAST(N'2024-03-29T02:58:46.7796106' AS DateTime2), N'Nhà đẹp rộng mặt phố', N'Nhà Phố', N'90 x 100', N'tô hiến thành quận 10', N'Đang xử lí', N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[RequestForms] ([Id], [GenerateDate], [Description], [ConstructType], [Acreage], [Location], [Status], [CustomerId]) VALUES (N'RF004', CAST(N'2024-03-29T02:59:11.6656978' AS DateTime2), N'Nhà to cần có sân thoáng đãng cho trẻ em vui chơi giải trí', N'Biệt thự', N'90 x 100', N'phường bến nghé quận 1', N'Đã gửi cho kỹ sư', N'185b799f-c0ad-4be9-849c-b96d2547e15c')
GO
INSERT [dbo].[RooftopTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'RT1', N'Mái tôn', CAST(0.30 AS Decimal(4, 2)), N'Mái tôn')
GO
INSERT [dbo].[RooftopTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'RT2', N'Mái BTCT', CAST(0.40 AS Decimal(4, 2)), N'Mái BTCT')
GO
INSERT [dbo].[RooftopTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'RT3', N'Mái ngói + Xà gồ', CAST(0.70 AS Decimal(4, 2)), N'Mái ngói + Xà g?')
GO
INSERT [dbo].[RooftopTypes] ([Id], [Name], [AreaFactor], [Description]) VALUES (N'RT4', N'Mái ngói + BTCT', CAST(1.00 AS Decimal(4, 2)), N'Mái ngói + BTCT')
GO
INSERT [dbo].[TaskCategories] ([Id], [Name]) VALUES (N'TKB', N'Đầu mục cơ bản')
GO
INSERT [dbo].[TaskCategories] ([Id], [Name]) VALUES (N'TKC', N'Đầu mục hoàn thiện')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK001', N'Tổ chức công trường', N'Tổ chức công trường, làm lán trại cho công nhân', CAST(48000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK002', N'Vệ sinh mặt bằng', N'Vệ sinh mặt bằng thi công, định vị móng, cột', CAST(24800.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK003', N'Đào móng', N'Đào đất hố móng', CAST(120000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK004', N'Thi công phần trên', N'Thi công theo bản vẽ thiết kế', CAST(280000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK005', N'Thi công coffa, cốt thép, đổ bê tông móng', N'Thi công coffa, cốt thép, đổ bê tông móng, đà kiềng, dầm sàn các lầu, cột,... theo bản thiết kế', CAST(180000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK006', N'Xây tường gạch', N'Xây tường gạch 100mm, 8x8x18 theo bản thiết kế', CAST(250000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK007', N'Cán nền', N'Cán nền các nền lầu, sân thượng, mái và nhà vệ sinh', CAST(480000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK008', N'Thi công chống thấm', N'Thi công chống thấm Sê nô, sàn mái, sàn vệ sinh, sân thượng,...', CAST(180000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK009', N'Lắp đặt ống nước', N'Lắp đặt hệ thống đường ống cấp và thoát nước nóng lạnh', CAST(140000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK010', N'Lắp đặt đường dây điện', N'Lắp đặt hệ thống đường dây diện chiếu sáng, đế âm, hộp nối', CAST(250000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK011', N'Lắp đặt đường dây cáp', N'Lắp đặt hệ thống đường dây truyền hình cáp, internet', CAST(33500.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK012', N'Vệ sinh công trình', N'Vệ sinh công trình', CAST(110000.00 AS Decimal(18, 2)), 1, N'TKB')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK013', N'Ốp gạch sàn nhà, bếp, tường', N'Ốp lát gạch toàn bộ sàn của nhà, phòng bếp, tường bếp vệ sinh theo bản thiết kế', CAST(320000.00 AS Decimal(18, 2)), 1, N'TKC')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK014', N'Ốp gạch trang trí', N'Ốp gạch, đá trang trí', CAST(260000.00 AS Decimal(18, 2)), 1, N'TKC')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK015', N'Lắp đặt hệ thống điện và chiếu sáng', N'Lắp đặt hệ thống điện và chiếu sáng: công tắc, ổ cắm, bóng đèn', CAST(190000.00 AS Decimal(18, 2)), 1, N'TKC')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK016', N'Lắp đặt thiết bị vệ sinh', N'Lắp đặt thiết bị vệ sinh: bàn cầu, lavabo, vòi nước,...', CAST(310000.00 AS Decimal(18, 2)), 1, N'TKC')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK017', N'Dựng cửa', N'Dựng bao cửa gỗ, cửa sắt', CAST(170000.00 AS Decimal(18, 2)), 1, N'TKC')
GO
INSERT [dbo].[Tasks] ([Id], [Name], [Description], [UnitPrice], [Status], [CategoryId]) VALUES (N'TSK018', N'Trét mát tít và sơn nước', N'Trét mát tít và sơn nước toàn bộ bên trong và bên ngoài nhà', CAST(130000.00 AS Decimal(18, 2)), 1, N'TKC')
GO
SET IDENTITY_INSERT [dbo].[WorkingReports] ON 

GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (12, N'3c27bd76-c9c6-4723-8c6a-541ddd6e91c2', N'RF001', NULL, NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (13, N'2d5ee810-7721-4615-accd-60f055c73979', N'RF001', CAST(N'2024-03-08T19:39:48.7079394' AS DateTime2), CAST(N'2024-03-08T19:42:32.2226968' AS DateTime2))
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (14, N'6f1de662-b815-4306-b660-fcad4c14fc0d', N'RF001', NULL, CAST(N'2024-03-08T19:42:35.9368176' AS DateTime2))
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (15, N'3c27bd76-c9c6-4723-8c6a-541ddd6e91c2', N'RF002', NULL, NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (16, N'2d5ee810-7721-4615-accd-60f055c73979', N'RF002', NULL, NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (17, N'6f1de662-b815-4306-b660-fcad4c14fc0d', N'RF002', NULL, NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (18, N'3c27bd76-c9c6-4723-8c6a-541ddd6e91c2', N'RF003', NULL, NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (19, N'eeab2f60-6fe9-436f-afec-8eae12ca8289', N'RF003', NULL, NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (20, N'6f1de662-b815-4306-b660-fcad4c14fc0d', N'RF003', NULL, NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (21, N'3c27bd76-c9c6-4723-8c6a-541ddd6e91c2', N'RF004', NULL, NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (22, N'2d5ee810-7721-4615-accd-60f055c73979', N'RF004', CAST(N'2024-07-20T17:14:56.3962018' AS DateTime2), NULL)
GO
INSERT [dbo].[WorkingReports] ([Id], [StaffId], [RequestId], [ReceiveDate], [SubmitDate]) VALUES (23, N'6f1de662-b815-4306-b660-fcad4c14fc0d', N'RF004', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[WorkingReports] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AspNetUsers_ManagerId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_ManagerId] ON [dbo].[AspNetUsers]
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ComboMaterials_MaterialsId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_ComboMaterials_MaterialsId] ON [dbo].[ComboMaterials]
(
	[MaterialsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Combos_ConstructionId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_Combos_ConstructionId] ON [dbo].[Combos]
(
	[ConstructionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ComboTasks_TasksId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_ComboTasks_TasksId] ON [dbo].[ComboTasks]
(
	[TasksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ConstructDetails_BasementId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_ConstructDetails_BasementId] ON [dbo].[ConstructDetails]
(
	[BasementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ConstructDetails_ConstructionId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_ConstructDetails_ConstructionId] ON [dbo].[ConstructDetails]
(
	[ConstructionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ConstructDetails_FoundationId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_ConstructDetails_FoundationId] ON [dbo].[ConstructDetails]
(
	[FoundationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ConstructDetails_InvestmentId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_ConstructDetails_InvestmentId] ON [dbo].[ConstructDetails]
(
	[InvestmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ConstructDetails_RooftopId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_ConstructDetails_RooftopId] ON [dbo].[ConstructDetails]
(
	[RooftopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CustomQuotations_RequestId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_CustomQuotations_RequestId] ON [dbo].[CustomQuotations]
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MaterialDetails_MaterialId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_MaterialDetails_MaterialId] ON [dbo].[MaterialDetails]
(
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MaterialDetails_QuotationId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_MaterialDetails_QuotationId] ON [dbo].[MaterialDetails]
(
	[QuotationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Materials_CategoryId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_Materials_CategoryId] ON [dbo].[Materials]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Pricings_ConstructTypeId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_Pricings_ConstructTypeId] ON [dbo].[Pricings]
(
	[ConstructTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Pricings_InvestmentTypeId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_Pricings_InvestmentTypeId] ON [dbo].[Pricings]
(
	[InvestmentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ProjectImages_ProjectId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectImages_ProjectId] ON [dbo].[ProjectImages]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Projects_CustomerId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_Projects_CustomerId] ON [dbo].[Projects]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RejectionReports_EngineerId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_RejectionReports_EngineerId] ON [dbo].[RejectionReports]
(
	[EngineerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RejectionReports_ManagerId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_RejectionReports_ManagerId] ON [dbo].[RejectionReports]
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RejectionReports_RejectedQuotationId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_RejectionReports_RejectedQuotationId] ON [dbo].[RejectionReports]
(
	[RejectedQuotationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RequestForms_CustomerId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_RequestForms_CustomerId] ON [dbo].[RequestForms]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TaskDetails_QuotationId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_TaskDetails_QuotationId] ON [dbo].[TaskDetails]
(
	[QuotationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TaskDetails_TaskId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_TaskDetails_TaskId] ON [dbo].[TaskDetails]
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Tasks_CategoryId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_CategoryId] ON [dbo].[Tasks]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_WorkingReports_RequestId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_WorkingReports_RequestId] ON [dbo].[WorkingReports]
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_WorkingReports_StaffId]    Script Date: 7/23/2024 9:16:51 AM ******/
CREATE NONCLUSTERED INDEX [IX_WorkingReports_StaffId] ON [dbo].[WorkingReports]
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_AspNetUsers_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_AspNetUsers_ManagerId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ComboMaterials]  WITH CHECK ADD  CONSTRAINT [FK_ComboMaterials_Combos_CombosId] FOREIGN KEY([CombosId])
REFERENCES [dbo].[Combos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComboMaterials] CHECK CONSTRAINT [FK_ComboMaterials_Combos_CombosId]
GO
ALTER TABLE [dbo].[ComboMaterials]  WITH CHECK ADD  CONSTRAINT [FK_ComboMaterials_Materials_MaterialsId] FOREIGN KEY([MaterialsId])
REFERENCES [dbo].[Materials] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComboMaterials] CHECK CONSTRAINT [FK_ComboMaterials_Materials_MaterialsId]
GO
ALTER TABLE [dbo].[Combos]  WITH CHECK ADD  CONSTRAINT [FK_Combos_ConstructionTypes_ConstructionId] FOREIGN KEY([ConstructionId])
REFERENCES [dbo].[ConstructionTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Combos] CHECK CONSTRAINT [FK_Combos_ConstructionTypes_ConstructionId]
GO
ALTER TABLE [dbo].[ComboTasks]  WITH CHECK ADD  CONSTRAINT [FK_ComboTasks_Combos_CombosId] FOREIGN KEY([CombosId])
REFERENCES [dbo].[Combos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComboTasks] CHECK CONSTRAINT [FK_ComboTasks_Combos_CombosId]
GO
ALTER TABLE [dbo].[ComboTasks]  WITH CHECK ADD  CONSTRAINT [FK_ComboTasks_Tasks_TasksId] FOREIGN KEY([TasksId])
REFERENCES [dbo].[Tasks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComboTasks] CHECK CONSTRAINT [FK_ComboTasks_Tasks_TasksId]
GO
ALTER TABLE [dbo].[ConstructDetails]  WITH CHECK ADD  CONSTRAINT [FK_ConstructDetails_BasementTypes_BasementId] FOREIGN KEY([BasementId])
REFERENCES [dbo].[BasementTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConstructDetails] CHECK CONSTRAINT [FK_ConstructDetails_BasementTypes_BasementId]
GO
ALTER TABLE [dbo].[ConstructDetails]  WITH CHECK ADD  CONSTRAINT [FK_ConstructDetails_ConstructionTypes_ConstructionId] FOREIGN KEY([ConstructionId])
REFERENCES [dbo].[ConstructionTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConstructDetails] CHECK CONSTRAINT [FK_ConstructDetails_ConstructionTypes_ConstructionId]
GO
ALTER TABLE [dbo].[ConstructDetails]  WITH CHECK ADD  CONSTRAINT [FK_ConstructDetails_CustomQuotations_QuotationId] FOREIGN KEY([QuotationId])
REFERENCES [dbo].[CustomQuotations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConstructDetails] CHECK CONSTRAINT [FK_ConstructDetails_CustomQuotations_QuotationId]
GO
ALTER TABLE [dbo].[ConstructDetails]  WITH CHECK ADD  CONSTRAINT [FK_ConstructDetails_FoundationTypes_FoundationId] FOREIGN KEY([FoundationId])
REFERENCES [dbo].[FoundationTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConstructDetails] CHECK CONSTRAINT [FK_ConstructDetails_FoundationTypes_FoundationId]
GO
ALTER TABLE [dbo].[ConstructDetails]  WITH CHECK ADD  CONSTRAINT [FK_ConstructDetails_InvestmentTypes_InvestmentId] FOREIGN KEY([InvestmentId])
REFERENCES [dbo].[InvestmentTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConstructDetails] CHECK CONSTRAINT [FK_ConstructDetails_InvestmentTypes_InvestmentId]
GO
ALTER TABLE [dbo].[ConstructDetails]  WITH CHECK ADD  CONSTRAINT [FK_ConstructDetails_RooftopTypes_RooftopId] FOREIGN KEY([RooftopId])
REFERENCES [dbo].[RooftopTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConstructDetails] CHECK CONSTRAINT [FK_ConstructDetails_RooftopTypes_RooftopId]
GO
ALTER TABLE [dbo].[CustomQuotations]  WITH CHECK ADD  CONSTRAINT [FK_CustomQuotations_RequestForms_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[RequestForms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomQuotations] CHECK CONSTRAINT [FK_CustomQuotations_RequestForms_RequestId]
GO
ALTER TABLE [dbo].[MaterialDetails]  WITH CHECK ADD  CONSTRAINT [FK_MaterialDetails_CustomQuotations_QuotationId] FOREIGN KEY([QuotationId])
REFERENCES [dbo].[CustomQuotations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MaterialDetails] CHECK CONSTRAINT [FK_MaterialDetails_CustomQuotations_QuotationId]
GO
ALTER TABLE [dbo].[MaterialDetails]  WITH CHECK ADD  CONSTRAINT [FK_MaterialDetails_Materials_MaterialId] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Materials] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MaterialDetails] CHECK CONSTRAINT [FK_MaterialDetails_Materials_MaterialId]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_MaterialCategories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[MaterialCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_MaterialCategories_CategoryId]
GO
ALTER TABLE [dbo].[Pricings]  WITH CHECK ADD  CONSTRAINT [FK_Pricings_ConstructionTypes_ConstructTypeId] FOREIGN KEY([ConstructTypeId])
REFERENCES [dbo].[ConstructionTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pricings] CHECK CONSTRAINT [FK_Pricings_ConstructionTypes_ConstructTypeId]
GO
ALTER TABLE [dbo].[Pricings]  WITH CHECK ADD  CONSTRAINT [FK_Pricings_InvestmentTypes_InvestmentTypeId] FOREIGN KEY([InvestmentTypeId])
REFERENCES [dbo].[InvestmentTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pricings] CHECK CONSTRAINT [FK_Pricings_InvestmentTypes_InvestmentTypeId]
GO
ALTER TABLE [dbo].[ProjectImages]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImages_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectImages] CHECK CONSTRAINT [FK_ProjectImages_Projects_ProjectId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_AspNetUsers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_AspNetUsers_CustomerId]
GO
ALTER TABLE [dbo].[RejectionReports]  WITH CHECK ADD  CONSTRAINT [FK_RejectionReports_AspNetUsers_EngineerId] FOREIGN KEY([EngineerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RejectionReports] CHECK CONSTRAINT [FK_RejectionReports_AspNetUsers_EngineerId]
GO
ALTER TABLE [dbo].[RejectionReports]  WITH CHECK ADD  CONSTRAINT [FK_RejectionReports_AspNetUsers_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[RejectionReports] CHECK CONSTRAINT [FK_RejectionReports_AspNetUsers_ManagerId]
GO
ALTER TABLE [dbo].[RejectionReports]  WITH CHECK ADD  CONSTRAINT [FK_RejectionReports_CustomQuotations_RejectedQuotationId] FOREIGN KEY([RejectedQuotationId])
REFERENCES [dbo].[CustomQuotations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RejectionReports] CHECK CONSTRAINT [FK_RejectionReports_CustomQuotations_RejectedQuotationId]
GO
ALTER TABLE [dbo].[RequestForms]  WITH CHECK ADD  CONSTRAINT [FK_RequestForms_AspNetUsers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[RequestForms] CHECK CONSTRAINT [FK_RequestForms_AspNetUsers_CustomerId]
GO
ALTER TABLE [dbo].[TaskDetails]  WITH CHECK ADD  CONSTRAINT [FK_TaskDetails_CustomQuotations_QuotationId] FOREIGN KEY([QuotationId])
REFERENCES [dbo].[CustomQuotations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaskDetails] CHECK CONSTRAINT [FK_TaskDetails_CustomQuotations_QuotationId]
GO
ALTER TABLE [dbo].[TaskDetails]  WITH CHECK ADD  CONSTRAINT [FK_TaskDetails_Tasks_TaskId] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaskDetails] CHECK CONSTRAINT [FK_TaskDetails_Tasks_TaskId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_TaskCategories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[TaskCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_TaskCategories_CategoryId]
GO
ALTER TABLE [dbo].[WorkingReports]  WITH CHECK ADD  CONSTRAINT [FK_WorkingReports_AspNetUsers_StaffId] FOREIGN KEY([StaffId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkingReports] CHECK CONSTRAINT [FK_WorkingReports_AspNetUsers_StaffId]
GO
ALTER TABLE [dbo].[WorkingReports]  WITH CHECK ADD  CONSTRAINT [FK_WorkingReports_RequestForms_RequestId] FOREIGN KEY([RequestId])
REFERENCES [dbo].[RequestForms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkingReports] CHECK CONSTRAINT [FK_WorkingReports_RequestForms_RequestId]
GO
/****** Object:  Trigger [dbo].[increment_id_combo]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create TRIGGER [dbo].[increment_id_combo] ON [dbo].[Combos]
INSTEAD OF INSERT
AS

BEGIN
  DECLARE @NewIdNumber CHAR(4);

    -- Lấy số lượng các bản ghi đã có trong bảng Materials 
    SET @NewIdNumber = (SELECT COUNT(*) FROM dbo.Combos) + 1;

	-- Chèn các hàng mới vào bảng Materials với ID mới lớn nhất
    INSERT INTO Combos(id, Name, Description, Price, status, ConstructionId, ImageUrl)
    SELECT 
        'CB' + FORMAT((ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @NewIdNumber), '0000'),
        Name, Description, Price, status, ConstructionId, ImageUrl
    FROM 
        INSERTED;
END
GO
ALTER TABLE [dbo].[Combos] ENABLE TRIGGER [increment_id_combo]
GO
/****** Object:  Trigger [dbo].[increment_id_project]    Script Date: 7/23/2024 9:16:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create TRIGGER [dbo].[increment_id_project] ON [dbo].[Projects]
INSTEAD OF INSERT
AS

BEGIN
  DECLARE @NewIdNumber CHAR(4);

    -- Lấy số lượng các bản ghi đã có trong bảng Materials 
    SET @NewIdNumber = (SELECT COUNT(*) FROM dbo.Projects) + 1;

	-- Chèn các hàng mới vào bảng Materials với ID mới lớn nhất
    INSERT INTO Projects(id, Name, Location, Scale, Size,Status, Description, Overview,Date, CustomerId)
    SELECT 
        'PJ' + FORMAT((ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @NewIdNumber), '0000'),
        Name, Location, Scale, Size,Status, Description, Overview, Date, CustomerId
    FROM 
        INSERTED;
END
GO
ALTER TABLE [dbo].[Projects] ENABLE TRIGGER [increment_id_project]
GO
USE [master]
GO
ALTER DATABASE [SWP391DB] SET  READ_WRITE 
GO
