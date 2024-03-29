USE [master]
GO
/****** Object:  Database [Ignis]    Script Date: 22-10-2019 18:56:59 ******/
CREATE DATABASE [Ignis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ignis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Ignis.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ignis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Ignis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Ignis] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ignis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ignis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ignis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ignis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ignis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ignis] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ignis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ignis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ignis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ignis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ignis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ignis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ignis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ignis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ignis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ignis] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Ignis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ignis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ignis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ignis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ignis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ignis] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Ignis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ignis] SET RECOVERY FULL 
GO
ALTER DATABASE [Ignis] SET  MULTI_USER 
GO
ALTER DATABASE [Ignis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ignis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ignis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ignis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ignis] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ignis', N'ON'
GO
ALTER DATABASE [Ignis] SET QUERY_STORE = OFF
GO
USE [Ignis]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 22-10-2019 18:56:59 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BatteryChanges]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatteryChanges](
	[Id] [uniqueidentifier] NOT NULL,
	[OdometerReading] [float] NOT NULL,
	[RoadRunKilometer] [float] NOT NULL,
	[PumpRunKilometer] [float] NOT NULL,
	[VehicleId] [uniqueidentifier] NOT NULL,
	[DateOfChange] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.BatteryChanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BreakRooms]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BreakRooms](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.BreakRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassRooms]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassRooms](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Capacity] [int] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.ClassRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Counts]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counts](
	[Id] [uniqueidentifier] NOT NULL,
	[Sanctioned] [decimal](18, 2) NOT NULL,
	[Alloted] [decimal](18, 2) NOT NULL,
	[RankId] [uniqueidentifier] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Counts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Damages]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Damages](
	[Id] [uniqueidentifier] NOT NULL,
	[DateNoticed] [datetime] NOT NULL,
	[OdometerReading] [float] NULL,
	[Report] [nvarchar](max) NOT NULL,
	[CostEstimate] [float] NOT NULL,
	[VehicleId] [uniqueidentifier] NULL,
	[VehicleDamageTypeId] [uniqueidentifier] NULL,
	[VehicleEquipmentId] [uniqueidentifier] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[VehicleEquipmentDamageTypeId] [uniqueidentifier] NULL,
	[FireExtinguishingEquipmentId] [uniqueidentifier] NULL,
	[FireExtinguishingEquipmentDamageTypeId] [uniqueidentifier] NULL,
	[ClassRoomId] [uniqueidentifier] NULL,
	[ClassRoomDamageTypeId] [uniqueidentifier] NULL,
	[BreakRoomId] [uniqueidentifier] NULL,
	[BreakRoomDamageTypeId] [uniqueidentifier] NULL,
	[FireStationId] [uniqueidentifier] NULL,
	[FireStationDamageTypeId] [uniqueidentifier] NULL,
	[HouseId] [uniqueidentifier] NULL,
	[HouseDamageTypeId] [uniqueidentifier] NULL,
	[OfficeId] [uniqueidentifier] NULL,
	[OfficeDamageTypeId] [uniqueidentifier] NULL,
	[TelephoneRoomId] [uniqueidentifier] NULL,
	[TelephoneRoomDamageTypeId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Damages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DamageStatus]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DamageStatus](
	[Id] [uniqueidentifier] NOT NULL,
	[DateOfArrival] [datetime] NOT NULL,
	[DateOfLeaving] [datetime] NULL,
	[Comment] [nvarchar](max) NULL,
	[Action] [int] NOT NULL,
	[Official] [int] NOT NULL,
	[VehicleDamageId] [uniqueidentifier] NULL,
	[CaseId] [uniqueidentifier] NOT NULL,
	[VehicleEquipmentDamageId] [uniqueidentifier] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[FireExtinguishingEquipmentDamageId] [uniqueidentifier] NULL,
	[ClassRoomDamageId] [uniqueidentifier] NULL,
	[BreakRoomDamageId] [uniqueidentifier] NULL,
	[FireStationDamageId] [uniqueidentifier] NULL,
	[HouseDamageId] [uniqueidentifier] NULL,
	[OfficeDamageId] [uniqueidentifier] NULL,
	[TelephoneRoomDamageId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.DamageStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DamageTypes]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DamageTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsMajor] [bit] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.DamageTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Districts]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Districts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Kgidno] [nvarchar](25) NOT NULL,
	[HK] [bit] NOT NULL,
	[SpouseCadre] [bit] NOT NULL,
	[Gender] [nvarchar](6) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[DateOfJoining] [datetime] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](10) NULL,
	[Seniority] [int] NOT NULL,
	[RankId] [uniqueidentifier] NOT NULL,
	[TalukId] [uniqueidentifier] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FireExtinguishingEquipments]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FireExtinguishingEquipments](
	[Id] [uniqueidentifier] NOT NULL,
	[DateofPurchase] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[FireExtinguishingEquipmentTypeId] [uniqueidentifier] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.FireExtinguishingEquipments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FireExtinguishingEquipmentTypes]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FireExtinguishingEquipmentTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Make] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[YearOfManufacture] [int] NOT NULL,
	[Cost] [float] NOT NULL,
	[IsFuelRequired] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.FireExtinguishingEquipmentTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FireStations]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FireStations](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[NumberOfBays] [int] NOT NULL,
	[SanctionNumber] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[LandArea] [float] NOT NULL,
	[DateOfEstablishment] [datetime] NOT NULL,
	[CostOfEstablishment] [float] NOT NULL,
	[SanctionedStrength] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.FireStations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FittnessCertificates]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FittnessCertificates](
	[Id] [uniqueidentifier] NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[VehicleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.FittnessCertificates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MaxYears] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoblis]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoblis](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TalukId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Hoblis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Houses]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Houses](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [int] NOT NULL,
	[NumberOfBedrooms] [int] NOT NULL,
	[OccupantDesignation] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[ResidentialQuarterId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Houses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsuranceRenewals]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsuranceRenewals](
	[Id] [uniqueidentifier] NOT NULL,
	[DateOfPayment] [datetime] NOT NULL,
	[AmountPaid] [float] NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[VehicleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.InsuranceRenewals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lands]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lands](
	[Id] [uniqueidentifier] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Area] [float] NOT NULL,
	[DateOfPurchase] [datetime] NOT NULL,
	[Cost] [float] NOT NULL,
	[GovernmentSactionNumber] [nvarchar](max) NOT NULL,
	[IsEncroached] [bit] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Lands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offices]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offices](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Offices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OilChanges]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OilChanges](
	[Id] [uniqueidentifier] NOT NULL,
	[OdometerReading] [float] NOT NULL,
	[RoadRunKilometer] [float] NOT NULL,
	[PumpRunKilometer] [float] NOT NULL,
	[DateOfChange] [datetime] NOT NULL,
	[OilTypeId] [uniqueidentifier] NOT NULL,
	[VehicleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.OilChanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OilTypes]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OilTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.OilTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RangeDistricts]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RangeDistricts](
	[Id] [uniqueidentifier] NOT NULL,
	[RangeId] [uniqueidentifier] NOT NULL,
	[DistrictId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.RangeDistricts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ranges]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ranges](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Ranges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ranks]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ranks](
	[Id] [uniqueidentifier] NOT NULL,
	[RankName] [nvarchar](max) NOT NULL,
	[GroupId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Ranks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repairs]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repairs](
	[Id] [uniqueidentifier] NOT NULL,
	[BillTIN] [nvarchar](max) NOT NULL,
	[Cost] [float] NOT NULL,
	[AgencyName] [nvarchar](max) NOT NULL,
	[AgencyContact] [float] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[VehicleDamageId] [uniqueidentifier] NULL,
	[VehicleEquipmentDamageId] [uniqueidentifier] NULL,
	[FireExtinguishingEquipmentDamageId] [uniqueidentifier] NULL,
	[ClassRoomDamageId] [uniqueidentifier] NULL,
	[BreakRoomDamageId] [uniqueidentifier] NULL,
	[FireStationDamageId] [uniqueidentifier] NULL,
	[HouseDamageId] [uniqueidentifier] NULL,
	[OfficeDamageId] [uniqueidentifier] NULL,
	[TelephoneRoomDamageId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Repairs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequiredLands]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequiredLands](
	[Id] [uniqueidentifier] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Reason] [nvarchar](max) NOT NULL,
	[PotentialCost] [float] NOT NULL,
	[AreaRequired] [float] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.RequiredLands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResidentialQuarters]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResidentialQuarters](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.ResidentialQuarters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Taluks]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taluks](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DistrictId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Taluks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxPayments]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxPayments](
	[Id] [uniqueidentifier] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[AmountPaid] [float] NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[VehicleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.TaxPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TelephoneRooms]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TelephoneRooms](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.TelephoneRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TyreChanges]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TyreChanges](
	[Id] [uniqueidentifier] NOT NULL,
	[OdometerReading] [float] NOT NULL,
	[RoadRunKilometer] [float] NOT NULL,
	[PumpRunKilometer] [float] NOT NULL,
	[VehicleId] [uniqueidentifier] NOT NULL,
	[DateOfChange] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.TyreChanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[InfrastructureId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacancies]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacancies](
	[Id] [uniqueidentifier] NOT NULL,
	[Vacant] [decimal](18, 2) NOT NULL,
	[RankId] [uniqueidentifier] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Vacancies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleEquipments]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleEquipments](
	[Id] [uniqueidentifier] NOT NULL,
	[DateofPurchase] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[VehicleId] [uniqueidentifier] NOT NULL,
	[VehicleEquipmentTypeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.VehicleEquipments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleEquipmentTypes]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleEquipmentTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Make] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[YearOfManufacture] [int] NOT NULL,
	[Cost] [float] NOT NULL,
	[IsFuelRequired] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.VehicleEquipmentTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Make] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[RegistrationNumber] [nvarchar](max) NOT NULL,
	[Cost] [float] NOT NULL,
	[DateOfPurchase] [datetime] NOT NULL,
	[EngineNumber] [nvarchar](max) NOT NULL,
	[CapacityFuelTank] [float] NOT NULL,
	[TaxCard] [nvarchar](max) NOT NULL,
	[SanctionOrderNumber] [nvarchar](max) NOT NULL,
	[SanctionDate] [datetime] NOT NULL,
	[TheoreticalMileage] [float] NOT NULL,
	[KilometersCovered] [float] NOT NULL,
	[Usage] [nvarchar](max) NOT NULL,
	[CapacityOfAttachement] [float] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
	[PhotoNorth] [nvarchar](max) NULL,
	[PhotoEast] [nvarchar](max) NULL,
	[PhotoWest] [nvarchar](max) NULL,
	[PhotoSouth] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WaterSources]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaterSources](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsOwned] [bit] NOT NULL,
	[Capacity] [float] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.WaterSources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorksFors]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorksFors](
	[Id] [uniqueidentifier] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[NoOfYears] [decimal](18, 2) NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[FireStationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.WorksFors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZoneRanges]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZoneRanges](
	[Id] [uniqueidentifier] NOT NULL,
	[ZoneId] [uniqueidentifier] NOT NULL,
	[RangeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.ZoneRanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zones]    Script Date: 22-10-2019 18:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zones](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Zones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 22-10-2019 18:56:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 22-10-2019 18:56:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[BatteryChanges]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[BreakRooms]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[ClassRooms]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[Counts]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RankId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_RankId] ON [dbo].[Counts]
(
	[RankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BreakRoomDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_BreakRoomDamageTypeId] ON [dbo].[Damages]
(
	[BreakRoomDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BreakRoomId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_BreakRoomId] ON [dbo].[Damages]
(
	[BreakRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassRoomDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_ClassRoomDamageTypeId] ON [dbo].[Damages]
(
	[ClassRoomDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassRoomId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_ClassRoomId] ON [dbo].[Damages]
(
	[ClassRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireExtinguishingEquipmentDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireExtinguishingEquipmentDamageTypeId] ON [dbo].[Damages]
(
	[FireExtinguishingEquipmentDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireExtinguishingEquipmentId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireExtinguishingEquipmentId] ON [dbo].[Damages]
(
	[FireExtinguishingEquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationDamageTypeId] ON [dbo].[Damages]
(
	[FireStationDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[Damages]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HouseDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_HouseDamageTypeId] ON [dbo].[Damages]
(
	[HouseDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HouseId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_HouseId] ON [dbo].[Damages]
(
	[HouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OfficeDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_OfficeDamageTypeId] ON [dbo].[Damages]
(
	[OfficeDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OfficeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_OfficeId] ON [dbo].[Damages]
(
	[OfficeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TelephoneRoomDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_TelephoneRoomDamageTypeId] ON [dbo].[Damages]
(
	[TelephoneRoomDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TelephoneRoomId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_TelephoneRoomId] ON [dbo].[Damages]
(
	[TelephoneRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleDamageTypeId] ON [dbo].[Damages]
(
	[VehicleDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleEquipmentDamageTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleEquipmentDamageTypeId] ON [dbo].[Damages]
(
	[VehicleEquipmentDamageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleEquipmentId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleEquipmentId] ON [dbo].[Damages]
(
	[VehicleEquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[Damages]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BreakRoomDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_BreakRoomDamageId] ON [dbo].[DamageStatus]
(
	[BreakRoomDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassRoomDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_ClassRoomDamageId] ON [dbo].[DamageStatus]
(
	[ClassRoomDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireExtinguishingEquipmentDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireExtinguishingEquipmentDamageId] ON [dbo].[DamageStatus]
(
	[FireExtinguishingEquipmentDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationDamageId] ON [dbo].[DamageStatus]
(
	[FireStationDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HouseDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_HouseDamageId] ON [dbo].[DamageStatus]
(
	[HouseDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OfficeDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_OfficeDamageId] ON [dbo].[DamageStatus]
(
	[OfficeDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TelephoneRoomDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_TelephoneRoomDamageId] ON [dbo].[DamageStatus]
(
	[TelephoneRoomDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleDamageId] ON [dbo].[DamageStatus]
(
	[VehicleDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleEquipmentDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleEquipmentDamageId] ON [dbo].[DamageStatus]
(
	[VehicleEquipmentDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[Employees]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RankId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_RankId] ON [dbo].[Employees]
(
	[RankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TalukId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_TalukId] ON [dbo].[Employees]
(
	[TalukId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireExtinguishingEquipmentTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireExtinguishingEquipmentTypeId] ON [dbo].[FireExtinguishingEquipments]
(
	[FireExtinguishingEquipmentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[FireExtinguishingEquipments]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Id]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_Id] ON [dbo].[FireStations]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[FittnessCertificates]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TalukId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_TalukId] ON [dbo].[Hoblis]
(
	[TalukId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ResidentialQuarterId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_ResidentialQuarterId] ON [dbo].[Houses]
(
	[ResidentialQuarterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[InsuranceRenewals]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[Lands]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[Offices]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OilTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_OilTypeId] ON [dbo].[OilChanges]
(
	[OilTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[OilChanges]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DistrictId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_DistrictId] ON [dbo].[RangeDistricts]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RangeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_RangeId] ON [dbo].[RangeDistricts]
(
	[RangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[Ranks]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BreakRoomDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_BreakRoomDamageId] ON [dbo].[Repairs]
(
	[BreakRoomDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassRoomDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_ClassRoomDamageId] ON [dbo].[Repairs]
(
	[ClassRoomDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireExtinguishingEquipmentDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireExtinguishingEquipmentDamageId] ON [dbo].[Repairs]
(
	[FireExtinguishingEquipmentDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationDamageId] ON [dbo].[Repairs]
(
	[FireStationDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HouseDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_HouseDamageId] ON [dbo].[Repairs]
(
	[HouseDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OfficeDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_OfficeDamageId] ON [dbo].[Repairs]
(
	[OfficeDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TelephoneRoomDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_TelephoneRoomDamageId] ON [dbo].[Repairs]
(
	[TelephoneRoomDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleDamageId] ON [dbo].[Repairs]
(
	[VehicleDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleEquipmentDamageId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleEquipmentDamageId] ON [dbo].[Repairs]
(
	[VehicleEquipmentDamageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[RequiredLands]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[ResidentialQuarters]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DistrictId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_DistrictId] ON [dbo].[Taluks]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[TaxPayments]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[TelephoneRooms]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[TyreChanges]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[Vacancies]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RankId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_RankId] ON [dbo].[Vacancies]
(
	[RankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleEquipmentTypeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleEquipmentTypeId] ON [dbo].[VehicleEquipments]
(
	[VehicleEquipmentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[VehicleEquipments]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[Vehicles]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[WaterSources]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeId] ON [dbo].[WorksFors]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FireStationId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_FireStationId] ON [dbo].[WorksFors]
(
	[FireStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RangeId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_RangeId] ON [dbo].[ZoneRanges]
(
	[RangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ZoneId]    Script Date: 22-10-2019 18:56:59 ******/
CREATE NONCLUSTERED INDEX [IX_ZoneId] ON [dbo].[ZoneRanges]
(
	[ZoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BatteryChanges] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [DateOfChange]
GO
ALTER TABLE [dbo].[Damages] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[DamageStatus] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [CaseId]
GO
ALTER TABLE [dbo].[DamageStatus] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[DamageTypes] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [FireStationId]
GO
ALTER TABLE [dbo].[Repairs] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[TyreChanges] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [DateOfChange]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BatteryChanges]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BatteryChanges_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BatteryChanges] CHECK CONSTRAINT [FK_dbo.BatteryChanges_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[BreakRooms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BreakRooms_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BreakRooms] CHECK CONSTRAINT [FK_dbo.BreakRooms_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[ClassRooms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClassRooms_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassRooms] CHECK CONSTRAINT [FK_dbo.ClassRooms_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[Counts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Counts_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Counts] CHECK CONSTRAINT [FK_dbo.Counts_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[Counts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Counts_dbo.Ranks_RankId] FOREIGN KEY([RankId])
REFERENCES [dbo].[Ranks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Counts] CHECK CONSTRAINT [FK_dbo.Counts_dbo.Ranks_RankId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.BreakRooms_BreakRoomId] FOREIGN KEY([BreakRoomId])
REFERENCES [dbo].[BreakRooms] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.BreakRooms_BreakRoomId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.ClassRooms_ClassRoomId] FOREIGN KEY([ClassRoomId])
REFERENCES [dbo].[ClassRooms] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.ClassRooms_ClassRoomId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_BreakRoomDamageTypeId] FOREIGN KEY([BreakRoomDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_BreakRoomDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_ClassRoomDamageTypeId] FOREIGN KEY([ClassRoomDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_ClassRoomDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_FireExtinguishingEquipmentDamageTypeId] FOREIGN KEY([FireExtinguishingEquipmentDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_FireExtinguishingEquipmentDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_FireStationDamageTypeId] FOREIGN KEY([FireStationDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_FireStationDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_HouseDamageTypeId] FOREIGN KEY([HouseDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_HouseDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_OfficeDamageTypeId] FOREIGN KEY([OfficeDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_OfficeDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_TelephoneRoomDamageTypeId] FOREIGN KEY([TelephoneRoomDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_TelephoneRoomDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_VehicleEquipmentDamageTypeId] FOREIGN KEY([VehicleEquipmentDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.DamageTypes_VehicleEquipmentDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.FireExtinguishingEquipments_FireExtinguishingEquipmentId] FOREIGN KEY([FireExtinguishingEquipmentId])
REFERENCES [dbo].[FireExtinguishingEquipments] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.FireExtinguishingEquipments_FireExtinguishingEquipmentId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.Houses_HouseId] FOREIGN KEY([HouseId])
REFERENCES [dbo].[Houses] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.Houses_HouseId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.Offices_OfficeId] FOREIGN KEY([OfficeId])
REFERENCES [dbo].[Offices] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.Offices_OfficeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.TelephoneRooms_TelephoneRoomId] FOREIGN KEY([TelephoneRoomId])
REFERENCES [dbo].[TelephoneRooms] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.TelephoneRooms_TelephoneRoomId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.VehicleEquipments_VehicleEquipmentId] FOREIGN KEY([VehicleEquipmentId])
REFERENCES [dbo].[VehicleEquipments] ([Id])
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.VehicleEquipments_VehicleEquipmentId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleDamages_dbo.VehicleDamageTypes_VehicleDamageTypeId] FOREIGN KEY([VehicleDamageTypeId])
REFERENCES [dbo].[DamageTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.VehicleDamages_dbo.VehicleDamageTypes_VehicleDamageTypeId]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleDamages_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.VehicleDamages_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_BreakRoomDamageId] FOREIGN KEY([BreakRoomDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_BreakRoomDamageId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_ClassRoomDamageId] FOREIGN KEY([ClassRoomDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_ClassRoomDamageId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_FireExtinguishingEquipmentDamageId] FOREIGN KEY([FireExtinguishingEquipmentDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_FireExtinguishingEquipmentDamageId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_FireStationDamageId] FOREIGN KEY([FireStationDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_FireStationDamageId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_HouseDamageId] FOREIGN KEY([HouseDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_HouseDamageId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_OfficeDamageId] FOREIGN KEY([OfficeDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_OfficeDamageId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_TelephoneRoomDamageId] FOREIGN KEY([TelephoneRoomDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_TelephoneRoomDamageId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_VehicleEquipmentDamageId] FOREIGN KEY([VehicleEquipmentDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.DamageStatus_dbo.Damages_VehicleEquipmentDamageId]
GO
ALTER TABLE [dbo].[DamageStatus]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleDamageStatus_dbo.VehicleDamages_VehicleDamageId] FOREIGN KEY([VehicleDamageId])
REFERENCES [dbo].[Damages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DamageStatus] CHECK CONSTRAINT [FK_dbo.VehicleDamageStatus_dbo.VehicleDamages_VehicleDamageId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.Ranks_RankId] FOREIGN KEY([RankId])
REFERENCES [dbo].[Ranks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.Ranks_RankId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Employees_dbo.Taluks_TalukId] FOREIGN KEY([TalukId])
REFERENCES [dbo].[Taluks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_dbo.Employees_dbo.Taluks_TalukId]
GO
ALTER TABLE [dbo].[FireExtinguishingEquipments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FireExtinguishingEquipments_dbo.FireExtinguishingEquipmentTypes_FireExtinguishingEquipmentTypeId] FOREIGN KEY([FireExtinguishingEquipmentTypeId])
REFERENCES [dbo].[FireExtinguishingEquipmentTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FireExtinguishingEquipments] CHECK CONSTRAINT [FK_dbo.FireExtinguishingEquipments_dbo.FireExtinguishingEquipmentTypes_FireExtinguishingEquipmentTypeId]
GO
ALTER TABLE [dbo].[FireExtinguishingEquipments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FireExtinguishingEquipments_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FireExtinguishingEquipments] CHECK CONSTRAINT [FK_dbo.FireExtinguishingEquipments_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[FireStations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FireStations_dbo.Hoblis_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Hoblis] ([Id])
GO
ALTER TABLE [dbo].[FireStations] CHECK CONSTRAINT [FK_dbo.FireStations_dbo.Hoblis_Id]
GO
ALTER TABLE [dbo].[FittnessCertificates]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FittnessCertificates_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FittnessCertificates] CHECK CONSTRAINT [FK_dbo.FittnessCertificates_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[Hoblis]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Hoblis_dbo.Taluks_TalukId] FOREIGN KEY([TalukId])
REFERENCES [dbo].[Taluks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hoblis] CHECK CONSTRAINT [FK_dbo.Hoblis_dbo.Taluks_TalukId]
GO
ALTER TABLE [dbo].[Houses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Houses_dbo.ResidentialQuarters_ResidentialQuarterId] FOREIGN KEY([ResidentialQuarterId])
REFERENCES [dbo].[ResidentialQuarters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Houses] CHECK CONSTRAINT [FK_dbo.Houses_dbo.ResidentialQuarters_ResidentialQuarterId]
GO
ALTER TABLE [dbo].[InsuranceRenewals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InsuranceRenewals_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InsuranceRenewals] CHECK CONSTRAINT [FK_dbo.InsuranceRenewals_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[Lands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Lands_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lands] CHECK CONSTRAINT [FK_dbo.Lands_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[Offices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Offices_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Offices] CHECK CONSTRAINT [FK_dbo.Offices_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[OilChanges]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OilChanges_dbo.OilTypes_OilTypeId] FOREIGN KEY([OilTypeId])
REFERENCES [dbo].[OilTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OilChanges] CHECK CONSTRAINT [FK_dbo.OilChanges_dbo.OilTypes_OilTypeId]
GO
ALTER TABLE [dbo].[OilChanges]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OilChanges_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OilChanges] CHECK CONSTRAINT [FK_dbo.OilChanges_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[RangeDistricts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RangeDistricts_dbo.Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RangeDistricts] CHECK CONSTRAINT [FK_dbo.RangeDistricts_dbo.Districts_DistrictId]
GO
ALTER TABLE [dbo].[RangeDistricts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RangeDistricts_dbo.Ranges_RangeId] FOREIGN KEY([RangeId])
REFERENCES [dbo].[Ranges] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RangeDistricts] CHECK CONSTRAINT [FK_dbo.RangeDistricts_dbo.Ranges_RangeId]
GO
ALTER TABLE [dbo].[Ranks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Ranks_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ranks] CHECK CONSTRAINT [FK_dbo.Ranks_dbo.Groups_GroupId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_BreakRoomDamageId] FOREIGN KEY([BreakRoomDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_BreakRoomDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_ClassRoomDamageId] FOREIGN KEY([ClassRoomDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_ClassRoomDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_FireExtinguishingEquipmentDamageId] FOREIGN KEY([FireExtinguishingEquipmentDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_FireExtinguishingEquipmentDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_FireStationDamageId] FOREIGN KEY([FireStationDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_FireStationDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_HouseDamageId] FOREIGN KEY([HouseDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_HouseDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_OfficeDamageId] FOREIGN KEY([OfficeDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_OfficeDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_TelephoneRoomDamageId] FOREIGN KEY([TelephoneRoomDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_TelephoneRoomDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_VehicleDamageId] FOREIGN KEY([VehicleDamageId])
REFERENCES [dbo].[Damages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_VehicleDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Repairs_dbo.Damages_VehicleEquipmentDamageId] FOREIGN KEY([VehicleEquipmentDamageId])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.Repairs_dbo.Damages_VehicleEquipmentDamageId]
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleRepairs_dbo.VehicleDamages_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Damages] ([Id])
GO
ALTER TABLE [dbo].[Repairs] CHECK CONSTRAINT [FK_dbo.VehicleRepairs_dbo.VehicleDamages_Id]
GO
ALTER TABLE [dbo].[RequiredLands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RequiredLands_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequiredLands] CHECK CONSTRAINT [FK_dbo.RequiredLands_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[ResidentialQuarters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ResidentialQuarters_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ResidentialQuarters] CHECK CONSTRAINT [FK_dbo.ResidentialQuarters_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[Taluks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Taluks_dbo.Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Taluks] CHECK CONSTRAINT [FK_dbo.Taluks_dbo.Districts_DistrictId]
GO
ALTER TABLE [dbo].[TaxPayments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TaxPayments_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaxPayments] CHECK CONSTRAINT [FK_dbo.TaxPayments_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[TelephoneRooms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TelephoneRooms_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TelephoneRooms] CHECK CONSTRAINT [FK_dbo.TelephoneRooms_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[TyreChanges]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TyreChanges_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TyreChanges] CHECK CONSTRAINT [FK_dbo.TyreChanges_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[Vacancies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vacancies_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vacancies] CHECK CONSTRAINT [FK_dbo.Vacancies_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[Vacancies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vacancies_dbo.Ranks_RankId] FOREIGN KEY([RankId])
REFERENCES [dbo].[Ranks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vacancies] CHECK CONSTRAINT [FK_dbo.Vacancies_dbo.Ranks_RankId]
GO
ALTER TABLE [dbo].[VehicleEquipments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleEquipments_dbo.VehicleEquipmentTypes_VehicleEquipmentTypeId] FOREIGN KEY([VehicleEquipmentTypeId])
REFERENCES [dbo].[VehicleEquipmentTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleEquipments] CHECK CONSTRAINT [FK_dbo.VehicleEquipments_dbo.VehicleEquipmentTypes_VehicleEquipmentTypeId]
GO
ALTER TABLE [dbo].[VehicleEquipments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleEquipments_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VehicleEquipments] CHECK CONSTRAINT [FK_dbo.VehicleEquipments_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vehicles_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_dbo.Vehicles_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[WaterSources]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WaterSources_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WaterSources] CHECK CONSTRAINT [FK_dbo.WaterSources_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[WorksFors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorksFors_dbo.Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorksFors] CHECK CONSTRAINT [FK_dbo.WorksFors_dbo.Employees_EmployeeId]
GO
ALTER TABLE [dbo].[WorksFors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WorksFors_dbo.FireStations_FireStationId] FOREIGN KEY([FireStationId])
REFERENCES [dbo].[FireStations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorksFors] CHECK CONSTRAINT [FK_dbo.WorksFors_dbo.FireStations_FireStationId]
GO
ALTER TABLE [dbo].[ZoneRanges]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ZoneRanges_dbo.Ranges_RangeId] FOREIGN KEY([RangeId])
REFERENCES [dbo].[Ranges] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ZoneRanges] CHECK CONSTRAINT [FK_dbo.ZoneRanges_dbo.Ranges_RangeId]
GO
ALTER TABLE [dbo].[ZoneRanges]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ZoneRanges_dbo.Zones_ZoneId] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zones] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ZoneRanges] CHECK CONSTRAINT [FK_dbo.ZoneRanges_dbo.Zones_ZoneId]
GO
USE [master]
GO
ALTER DATABASE [Ignis] SET  READ_WRITE 
GO
