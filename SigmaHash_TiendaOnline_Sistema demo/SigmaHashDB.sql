USE [master]
GO
/****** Object:  Database [HashDBBeta]    Script Date: 11/23/2022 8:59:53 PM ******/
CREATE DATABASE [HashDBBeta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HashDBBeta', FILENAME = N'C:\Users\Agust\HashDBBeta.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HashDBBeta_log', FILENAME = N'C:\Users\Agust\HashDBBeta_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HashDBBeta] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HashDBBeta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HashDBBeta] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HashDBBeta] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HashDBBeta] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HashDBBeta] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HashDBBeta] SET ARITHABORT OFF 
GO
ALTER DATABASE [HashDBBeta] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HashDBBeta] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HashDBBeta] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HashDBBeta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HashDBBeta] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HashDBBeta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HashDBBeta] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HashDBBeta] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HashDBBeta] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HashDBBeta] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HashDBBeta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HashDBBeta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HashDBBeta] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HashDBBeta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HashDBBeta] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HashDBBeta] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HashDBBeta] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HashDBBeta] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HashDBBeta] SET  MULTI_USER 
GO
ALTER DATABASE [HashDBBeta] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HashDBBeta] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HashDBBeta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HashDBBeta] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HashDBBeta] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HashDBBeta] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HashDBBeta] SET QUERY_STORE = OFF
GO
USE [HashDBBeta]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/23/2022 8:59:53 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/23/2022 8:59:53 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/23/2022 8:59:53 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/23/2022 8:59:53 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/23/2022 8:59:53 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[CompleteName] [nvarchar](max) NULL,
	[DNI] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[OptInorOptOut] [bit] NOT NULL,
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
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cases]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cases](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[FactorMother] [nvarchar](max) NULL,
	[TopPositionPSU] [bit] NOT NULL,
	[SideWindow] [bit] NOT NULL,
	[Color] [nvarchar](max) NULL,
	[RBG] [nvarchar](max) NULL,
	[RGBControl] [bit] NOT NULL,
	[USB20front] [smallint] NULL,
	[USB30front] [smallint] NULL,
	[USBTypeC] [smallint] NULL,
	[USBTypeCInternal] [smallint] NULL,
	[HDFrontAudio] [bit] NOT NULL,
	[Width] [smallint] NULL,
	[Height] [smallint] NULL,
	[Lenght] [smallint] NULL,
	[MaxCPUHeight] [smallint] NULL,
	[Fans80mmSupported] [smallint] NULL,
	[Fans80mmIncluded] [smallint] NULL,
	[Fans120mmSupported] [smallint] NULL,
	[Fans120mmIncluded] [smallint] NULL,
	[Fans140mmSupported] [smallint] NULL,
	[Fans140mmIncluded] [smallint] NULL,
	[Fans200mmSupported] [smallint] NULL,
	[Fans200mmIncluded] [smallint] NULL,
	[Radiator240mmSupport] [smallint] NULL,
	[Radiator280mmSupport] [smallint] NULL,
	[Radiator360mmSupport] [smallint] NULL,
	[Radiator420mmSupport] [smallint] NULL,
 CONSTRAINT [PK_Cases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cpus]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cpus](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[Series] [nvarchar](max) NULL,
	[Socket] [nvarchar](max) NULL,
	[Cores] [smallint] NULL,
	[Frequency] [float] NULL,
	[GPUChipset] [nvarchar](max) NULL,
	[Threads] [smallint] NULL,
	[TurboFrequency] [float] NULL,
	[TDP] [smallint] NULL,
	[IncludesCooler] [bit] NOT NULL,
	[L3] [smallint] NULL,
 CONSTRAINT [PK_Cpus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gpus]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gpus](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[HDMI] [smallint] NULL,
	[VGA] [smallint] NULL,
	[DVIdigital] [smallint] NULL,
	[DisplayPorts] [smallint] NULL,
	[DoubleBridge] [bit] NOT NULL,
	[USBtypeC] [smallint] NULL,
	[SLIorCrossfire] [nvarchar](max) NULL,
	[Width] [smallint] NULL,
	[Lenght] [smallint] NULL,
	[Consumption] [smallint] NULL,
	[RecommendedWatts] [smallint] NULL,
	[Backplate] [bit] NOT NULL,
	[VGAWaterCooling] [bit] NOT NULL,
	[AmountOfCoolers] [smallint] NULL,
	[MemorySpeed] [smallint] NULL,
	[MemoryType] [nvarchar](max) NULL,
	[MemoryCapacity] [smallint] NULL,
	[MemoryInterface] [smallint] NULL,
	[CoreTurboSpeed] [smallint] NULL,
 CONSTRAINT [PK_Gpus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Keyboards]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Keyboards](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[MechanismType] [nvarchar](max) NULL,
	[SwitchFamily] [int] NULL,
	[RGBColor] [bit] NOT NULL,
	[AntiGhosting] [bit] NOT NULL,
	[NKeyRollover] [bit] NOT NULL,
	[width] [smallint] NULL,
	[lenght] [smallint] NULL,
	[Wireless] [bit] NOT NULL,
	[CanRemoveCable] [bit] NOT NULL,
 CONSTRAINT [PK_Keyboards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Miscellaneous]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Miscellaneous](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Miscellaneous] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monitors]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitors](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[RetroilluminationType] [nvarchar](max) NULL,
	[IsCurved] [bit] NOT NULL,
	[Inches] [smallint] NULL,
	[MaxResolution] [nvarchar](max) NULL,
	[RefreshRate] [smallint] NULL,
	[NvidiaGSync] [bit] NOT NULL,
	[AMDFreeSync] [bit] NOT NULL,
	[TouchScreen] [bit] NOT NULL,
	[HDMI] [smallint] NULL,
	[DVI] [smallint] NULL,
	[VGA] [smallint] NULL,
	[DisplayPort] [smallint] NULL,
	[Usb20Ports] [smallint] NULL,
	[Usb30Ports] [smallint] NULL,
	[Usb31Ports] [smallint] NULL,
	[MiniDisplayPort] [smallint] NULL,
	[Width] [smallint] NULL,
	[Height] [smallint] NULL,
 CONSTRAINT [PK_Monitors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motherboards]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motherboards](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[Platform] [nvarchar](max) NOT NULL,
	[Socket] [nvarchar](max) NULL,
	[PCIE16Xslots] [smallint] NULL,
	[PCIE1Xslots] [smallint] NULL,
	[MultiGPU] [smallint] NULL,
	[SATAports] [smallint] NULL,
	[VGAoutputs] [smallint] NULL,
	[HDMIoutputs] [smallint] NULL,
	[DIVoutputs] [smallint] NULL,
	[DisplayPorts] [smallint] NULL,
	[M2slots] [smallint] NULL,
	[BuiltInWifi] [nvarchar](max) NULL,
	[RGBconnection] [nvarchar](max) NULL,
	[USB20] [smallint] NULL,
	[USB30] [smallint] NULL,
	[USB31] [smallint] NULL,
	[USB32] [smallint] NULL,
	[USBtypeC] [smallint] NULL,
	[PCIE4X] [smallint] NULL,
	[M2SATA] [smallint] NULL,
	[M2nvme] [smallint] NULL,
	[factor] [nvarchar](max) NULL,
	[MaxCpuWatts] [smallint] NULL,
	[CPU4pins] [smallint] NULL,
	[CPU4pinsplus] [smallint] NULL,
	[pins24] [smallint] NULL,
	[consumption] [smallint] NULL,
	[DDRslots] [smallint] NULL,
	[DDR2slots] [smallint] NULL,
	[DDR3slots] [smallint] NULL,
	[DDR4slots] [smallint] NULL,
	[DDR5slots] [smallint] NULL,
	[SoundCard] [nvarchar](max) NULL,
 CONSTRAINT [PK_Motherboards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mouses]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mouses](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[ButtonAmount] [smallint] NULL,
	[SwitchesType] [nvarchar](max) NULL,
	[SensorType] [nvarchar](max) NULL,
	[Wireless] [bit] NOT NULL,
	[Wired] [bit] NOT NULL,
	[AdjustableDPI] [bit] NOT NULL,
	[MinimumDPI] [smallint] NULL,
	[MaximumDPI] [smallint] NULL,
	[Weight] [smallint] NULL,
	[CanChangeWeights] [bit] NOT NULL,
	[Width] [smallint] NULL,
	[lenght] [smallint] NULL,
 CONSTRAINT [PK_Mouses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [nvarchar](max) NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[MainImage] [nvarchar](max) NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[Stock] [int] NOT NULL,
	[VisitCounter] [int] NOT NULL,
	[SoldCounter] [int] NOT NULL,
	[Popularity] [real] NULL,
	[DateCreated] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Psus]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Psus](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[Certification] [nvarchar](max) NULL,
	[WattsNominal] [smallint] NULL,
	[WattsReal] [smallint] NULL,
	[Format] [nvarchar](max) NULL,
	[HybridMode] [bit] NOT NULL,
	[CableType] [nvarchar](max) NULL,
	[DigitalPSU] [bit] NOT NULL,
	[CPU4Pin] [smallint] NULL,
	[CPU4PinPlus] [smallint] NULL,
	[Pin24] [smallint] NULL,
	[PCI6Pin] [smallint] NULL,
	[PCI2PinPlus] [smallint] NULL,
	[SataConnection] [smallint] NULL,
	[MolexConnection] [smallint] NULL,
	[FloppyConnection] [smallint] NULL,
 CONSTRAINT [PK_Psus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rams]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rams](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[Capacity] [smallint] NULL,
	[Speed] [smallint] NULL,
	[Type] [nvarchar](max) NULL,
	[Voltage] [float] NULL,
	[HeatSink] [bit] NOT NULL,
 CONSTRAINT [PK_Rams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationItems]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReservationItemId] [nvarchar](max) NOT NULL,
	[ProductId] [nvarchar](max) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Amount] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ReservationItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationId] [nvarchar](50) NOT NULL,
	[UserEmail] [nvarchar](200) NOT NULL,
	[Telephone] [nvarchar](50) NULL,
	[DNI] [nvarchar](50) NULL,
	[BankTransferReceipt] [varbinary](max) NULL,
	[Created] [nvarchar](80) NOT NULL,
	[IsExpired] [bit] NOT NULL,
	[Archived] [bit] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoledUsers]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoledUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RoledUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[ReservationId] [nvarchar](50) NOT NULL,
	[UserEmail] [nvarchar](200) NOT NULL,
	[Telephone] [nvarchar](50) NULL,
	[DNI] [nvarchar](50) NULL,
	[BankTransferReceipt] [varbinary](max) NULL,
	[Created] [nvarchar](80) NOT NULL,
	[Archived] [bit] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storages]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storages](
	[Id] [nvarchar](450) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Price] [real] NOT NULL,
	[Warranty] [smallint] NOT NULL,
	[ShipsNational] [bit] NOT NULL,
	[ShipsInternational] [bit] NOT NULL,
	[StorageSize] [smallint] NULL,
	[ConnectionType] [nvarchar](max) NULL,
	[Consumption] [smallint] NULL,
	[StorageType] [nvarchar](max) NULL,
	[RPM] [smallint] NULL,
 CONSTRAINT [PK_Storages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserReservations]    Script Date: 11/23/2022 8:59:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserReservations](
	[UserReservationId] [int] IDENTITY(1,1) NOT NULL,
	[Id] [nvarchar](max) NOT NULL,
	[ReservationId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserReservations] PRIMARY KEY CLUSTERED 
(
	[UserReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2331e585-dd0c-4f2c-93af-97a717481437', N'Manager', N'MANAGER', N'43a7ce16-2403-4001-89c6-ee5d3364b494')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'43f14a58-03b1-429b-89eb-9240e34e3874', N'Assistant', N'ASSISTANT', N'6fe69529-0e06-4820-9ed2-f46bb1d933a0')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5f34524b-cf3a-408b-a9c5-56f1a470762b', N'Administrator', N'ADMINISTRATOR', N'6f0e1450-09a2-42df-9258-d00933128776')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e9a6755-8d78-4f47-b2e1-bdce3c53fd2e', N'2331e585-dd0c-4f2c-93af-97a717481437')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e9a6755-8d78-4f47-b2e1-bdce3c53fd2e', N'43f14a58-03b1-429b-89eb-9240e34e3874')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e9a6755-8d78-4f47-b2e1-bdce3c53fd2e', N'5f34524b-cf3a-408b-a9c5-56f1a470762b')
GO
INSERT [dbo].[AspNetUsers] ([Id], [CompleteName], [DNI], [Phone], [OptInorOptOut], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5e9a6755-8d78-4f47-b2e1-bdce3c53fd2e', NULL, NULL, NULL, 1, N'sigma.hash@gobs.com.ar', N'SIGMA.HASH@GOBS.COM.AR', N'sigma.hash@gobs.com.ar', N'SIGMA.HASH@GOBS.COM.AR', 1, N'AQAAAAEAACcQAAAAELU408mSwMAbsoaoR9w+AUCAXTzJStXXoPcKLlH2OgaRZEw01WZoX8glS5eIgQt9sQ==', N'6BYMMCFE4YEFIIMZOGJ6ALA5XTAPR6HM', N'd96068bb-8480-49c2-97c4-8e4014043bba', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[Cpus] ([Id], [Brand], [Model], [Category], [Price], [Warranty], [ShipsNational], [ShipsInternational], [Series], [Socket], [Cores], [Frequency], [GPUChipset], [Threads], [TurboFrequency], [TDP], [IncludesCooler], [L3]) VALUES (N'CPU709865', N'AMD', N'Ryzen 7 ', N'CPU', 35000, 3, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath]) VALUES (1, N'CPU709865', N'CPU7098651.png')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath]) VALUES (2, N'RAM803182', N'RAM8031821.png')
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
INSERT [dbo].[Products] ([Id], [Brand], [Model], [Category], [Price], [Warranty], [MainImage], [ShipsNational], [ShipsInternational], [Stock], [VisitCounter], [SoldCounter], [Popularity], [DateCreated]) VALUES (N'CPU709865', N'AMD', N'Ryzen 7 ', N'CPU', 35000, 3, N'CPU7098651.png', 1, 1, -7, 0, 0, NULL, N'11/23/2022')
INSERT [dbo].[Products] ([Id], [Brand], [Model], [Category], [Price], [Warranty], [MainImage], [ShipsNational], [ShipsInternational], [Stock], [VisitCounter], [SoldCounter], [Popularity], [DateCreated]) VALUES (N'RAM803182', N'Corsair', N'Vengeance Pro', N'RAM', 25000, 3, N'RAM8031821.png', 1, 1, -3, 0, 0, NULL, N'11/23/2022')
GO
INSERT [dbo].[Rams] ([Id], [Brand], [Model], [Category], [Price], [Warranty], [ShipsNational], [ShipsInternational], [Capacity], [Speed], [Type], [Voltage], [HeatSink]) VALUES (N'RAM803182', N'Corsair', N'Vengeance Pro', N'RAM', 25000, 3, 1, 1, NULL, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[ReservationItems] ON 

INSERT [dbo].[ReservationItems] ([Id], [ReservationItemId], [ProductId], [ProductName], [Amount], [Price]) VALUES (1, N'RES290337', N'CPU709865', N'CPU AMD Ryzen 7 ', 2, CAST(35000.00 AS Decimal(18, 2)))
INSERT [dbo].[ReservationItems] ([Id], [ReservationItemId], [ProductId], [ProductName], [Amount], [Price]) VALUES (2, N'RES290337', N'RAM803182', N'RAM Corsair Vengeance Pro', 3, CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[ReservationItems] ([Id], [ReservationItemId], [ProductId], [ProductName], [Amount], [Price]) VALUES (3, N'RES542920', N'CPU709865', N'CPU AMD Ryzen 7 ', 5, CAST(35000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ReservationItems] OFF
GO
INSERT [dbo].[Reservations] ([ReservationId], [UserEmail], [Telephone], [DNI], [BankTransferReceipt], [Created], [IsExpired], [Archived]) VALUES (N'RES290337', N'sigma.hash@gobs.com.ar', NULL, NULL, NULL, N'11/23/2022 8:56:00 PM', 0, 0)
INSERT [dbo].[Reservations] ([ReservationId], [UserEmail], [Telephone], [DNI], [BankTransferReceipt], [Created], [IsExpired], [Archived]) VALUES (N'RES542920', N'sigma.hash@gobs.com.ar', NULL, NULL, NULL, N'11/23/2022 8:56:10 PM', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[RoledUsers] ON 

INSERT [dbo].[RoledUsers] ([Id], [UserId]) VALUES (1, N'5e9a6755-8d78-4f47-b2e1-bdce3c53fd2e')
SET IDENTITY_INSERT [dbo].[RoledUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[UserReservations] ON 

INSERT [dbo].[UserReservations] ([UserReservationId], [Id], [ReservationId]) VALUES (1, N'5e9a6755-8d78-4f47-b2e1-bdce3c53fd2e', N'RES290337')
INSERT [dbo].[UserReservations] ([UserReservationId], [Id], [ReservationId]) VALUES (2, N'5e9a6755-8d78-4f47-b2e1-bdce3c53fd2e', N'RES542920')
SET IDENTITY_INSERT [dbo].[UserReservations] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11/23/2022 8:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/23/2022 8:59:54 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11/23/2022 8:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11/23/2022 8:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11/23/2022 8:59:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/23/2022 8:59:54 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/23/2022 8:59:54 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [HashDBBeta] SET  READ_WRITE 
GO
