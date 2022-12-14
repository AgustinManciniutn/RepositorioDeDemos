USE [master]
GO
/****** Object:  Database [sigmaHashDB]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE DATABASE [sigmaHashDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sigaHashDB', FILENAME = N'C:\Users\Agust\sigaHashDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sigaHashDB_log', FILENAME = N'C:\Users\Agust\sigaHashDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [sigmaHashDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sigmaHashDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sigmaHashDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sigmaHashDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sigmaHashDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sigmaHashDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sigmaHashDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [sigmaHashDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [sigmaHashDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sigmaHashDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sigmaHashDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sigmaHashDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sigmaHashDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sigmaHashDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sigmaHashDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sigmaHashDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sigmaHashDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [sigmaHashDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sigmaHashDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sigmaHashDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sigmaHashDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sigmaHashDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sigmaHashDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [sigmaHashDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sigmaHashDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sigmaHashDB] SET  MULTI_USER 
GO
ALTER DATABASE [sigmaHashDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sigmaHashDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sigmaHashDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sigmaHashDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sigmaHashDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sigmaHashDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [sigmaHashDB] SET QUERY_STORE = OFF
GO
USE [sigmaHashDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[AttributeOptions]    Script Date: 12/19/2022 7:24:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeOptions](
	[AttributeOptionId] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NOT NULL,
	[Option] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AttributeOptions] PRIMARY KEY CLUSTERED 
(
	[AttributeOptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attributes]    Script Date: 12/19/2022 7:24:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attributes](
	[AttributeId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[AttrName] [nvarchar](max) NOT NULL,
	[HasOptions] [bit] NOT NULL,
 CONSTRAINT [PK_Attributes] PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/19/2022 7:24:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttributes]    Script Date: 12/19/2022 7:24:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [nvarchar](450) NOT NULL,
	[AttributeId] [int] NOT NULL,
	[AttributeName] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductAttributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 12/19/2022 7:24:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [nvarchar](450) NOT NULL,
	[Category] [nvarchar](max) NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
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
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationItems]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[Reservations]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[RoledUsers]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[Sales]    Script Date: 12/19/2022 7:24:05 PM ******/
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
/****** Object:  Table [dbo].[UserReservations]    Script Date: 12/19/2022 7:24:05 PM ******/
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
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'582d062a-cb4a-43b5-9a14-e5517838cca0', N'Assistant', N'ASSISTANT', N'a5044c89-d8cb-4154-a9b8-49d844f19a25')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b09589a5-6d8d-44c1-ba65-f91490f1b13d', N'Administrator', N'ADMINISTRATOR', N'11efcb8d-ba4d-46f4-a611-041f673d5816')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c9dce70d-a245-414b-9661-291e299fd9fd', N'Manager', N'MANAGER', N'dde42252-711b-4e08-bc65-81c6d448ebe6')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8b237ed4-14d3-4d04-a6d6-b6d7e9c418a9', N'582d062a-cb4a-43b5-9a14-e5517838cca0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8b237ed4-14d3-4d04-a6d6-b6d7e9c418a9', N'b09589a5-6d8d-44c1-ba65-f91490f1b13d')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8b237ed4-14d3-4d04-a6d6-b6d7e9c418a9', N'c9dce70d-a245-414b-9661-291e299fd9fd')
GO
INSERT [dbo].[AspNetUsers] ([Id], [CompleteName], [DNI], [Phone], [OptInorOptOut], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8b237ed4-14d3-4d04-a6d6-b6d7e9c418a9', NULL, NULL, NULL, 1, N'sigma.hash@gobs.com.ar', N'SIGMA.HASH@GOBS.COM.AR', N'sigma.hash@gobs.com.ar', N'SIGMA.HASH@GOBS.COM.AR', 1, N'AQAAAAEAACcQAAAAEIeyQVmZj/smJt5FHxnw/8DyXoBcnOwpnUhOZbVoz8zWPqSOlHzLdf9ExgvMXpughQ==', N'JW2JIDDOJGEHJVBJJXKG3MRBQC7JNY6V', N'26230a76-8b25-4921-80f5-dc6cfae9fd71', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[AttributeOptions] ON 

INSERT [dbo].[AttributeOptions] ([AttributeOptionId], [AttributeId], [Option]) VALUES (1, 6, N'Si')
INSERT [dbo].[AttributeOptions] ([AttributeOptionId], [AttributeId], [Option]) VALUES (2, 6, N'No')
INSERT [dbo].[AttributeOptions] ([AttributeOptionId], [AttributeId], [Option]) VALUES (3, 9, N'Si')
INSERT [dbo].[AttributeOptions] ([AttributeOptionId], [AttributeId], [Option]) VALUES (4, 9, N'No')
INSERT [dbo].[AttributeOptions] ([AttributeOptionId], [AttributeId], [Option]) VALUES (5, 14, N'HDD')
INSERT [dbo].[AttributeOptions] ([AttributeOptionId], [AttributeId], [Option]) VALUES (6, 14, N'SSD')
INSERT [dbo].[AttributeOptions] ([AttributeOptionId], [AttributeId], [Option]) VALUES (7, 14, N'NVME')
SET IDENTITY_INSERT [dbo].[AttributeOptions] OFF
GO
SET IDENTITY_INSERT [dbo].[Attributes] ON 

INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (1, 1, N'Núcleos', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (2, 1, N'Frecuencia', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (3, 1, N'Hilos', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (4, 1, N'Memoria L2', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (5, 1, N'Memoria L3', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (6, 1, N'Incluye Cooler', 1)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (7, 3, N'Hdmi', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (8, 3, N'Displayports', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (9, 3, N'Backplate', 1)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (10, 3, N'Tipo de Memoria', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (11, 3, N'Velocidad de memoria', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (12, 3, N'Capacidad ', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (13, 3, N'Consumo', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (14, 4, N'Tipo', 1)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (15, 4, N'Capacidad', 0)
INSERT [dbo].[Attributes] ([AttributeId], [CategoryId], [AttrName], [HasOptions]) VALUES (16, 4, N'Tipo de conexión', 0)
SET IDENTITY_INSERT [dbo].[Attributes] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (1, N'CPU')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (3, N'GPU')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (4, N'Almacenamiento')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductAttributes] ON 

INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (1, N'CPU898720', 1, N'Núcleos', N'16')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (2, N'CPU898720', 2, N'Frecuencia', N'5200 mhz')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (3, N'CPU898720', 3, N'Hilos', N'24')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (4, N'CPU898720', 4, N'Memoria L2', N'16 mb')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (5, N'CPU898720', 5, N'Memoria L3', N'32 mb')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (6, N'CPU898720', 6, N'Incluye Cooler', N'Si')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (7, N'GPU904468', 7, N'Hdmi', N'2')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (8, N'GPU904468', 8, N'Displayports', N'3')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (9, N'GPU904468', 9, N'Backplate', N'Si')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (10, N'GPU904468', 10, N'Tipo de Memoria', N' GDDR6X ')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (11, N'GPU904468', 11, N'Velocidad de memoria', N'19500 mhz')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (12, N'GPU904468', 12, N'Capacidad ', N'24 gb')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (13, N'GPU904468', 13, N'Consumo', N'350 w')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (14, N'Alm715856', 14, N'Tipo', N'SSD')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (15, N'Alm715856', 15, N'Capacidad', N'480 gb')
INSERT [dbo].[ProductAttributes] ([Id], [ProductId], [AttributeId], [AttributeName], [Value]) VALUES (16, N'Alm715856', 16, N'Tipo de conexión', N'Sata')
SET IDENTITY_INSERT [dbo].[ProductAttributes] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath]) VALUES (1, N'CPU898720', N'CPU8987201.png')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath]) VALUES (2, N'CPU898720', N'CPU8987202.png')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath]) VALUES (3, N'GPU904468', N'GPU9044681.png')
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath]) VALUES (4, N'Alm715856', N'Alm7158561.png')
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
INSERT [dbo].[Products] ([ProductId], [Category], [Brand], [Model], [Price], [Warranty], [MainImage], [ShipsNational], [ShipsInternational], [Stock], [VisitCounter], [SoldCounter], [Popularity], [DateCreated]) VALUES (N'Alm715856', N'Almacenamiento', N'Wester Digital', N'Blue SN570 480gb', CAST(28800.00 AS Decimal(18, 2)), 4, N'Alm7158561.png', 1, 0, 0, 0, 0, NULL, N'12/19/2022')
INSERT [dbo].[Products] ([ProductId], [Category], [Brand], [Model], [Price], [Warranty], [MainImage], [ShipsNational], [ShipsInternational], [Stock], [VisitCounter], [SoldCounter], [Popularity], [DateCreated]) VALUES (N'CPU898720', N'CPU', N'Intel', N'Core i9 12900KF 5.2GHz Turbo', CAST(145000.00 AS Decimal(18, 2)), 4, N'CPU8987201.png', 1, 1, 0, 0, 0, NULL, N'12/19/2022')
INSERT [dbo].[Products] ([ProductId], [Category], [Brand], [Model], [Price], [Warranty], [MainImage], [ShipsNational], [ShipsInternational], [Stock], [VisitCounter], [SoldCounter], [Popularity], [DateCreated]) VALUES (N'GPU904468', N'GPU', N'MSI', N'GeForce RTX 3070', CAST(198000.00 AS Decimal(18, 2)), 4, N'GPU9044681.png', 1, 1, 0, 0, 0, NULL, N'12/19/2022')
GO
SET IDENTITY_INSERT [dbo].[RoledUsers] ON 

INSERT [dbo].[RoledUsers] ([Id], [UserId]) VALUES (1, N'8b237ed4-14d3-4d04-a6d6-b6d7e9c418a9')
SET IDENTITY_INSERT [dbo].[RoledUsers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttributeOptions_AttributeId]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttributeOptions_AttributeId] ON [dbo].[AttributeOptions]
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Attributes_CategoryId]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Attributes_CategoryId] ON [dbo].[Attributes]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductAttributes_AttributeId]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductAttributes_AttributeId] ON [dbo].[ProductAttributes]
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductAttributes_ProductId]    Script Date: 12/19/2022 7:24:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductAttributes_ProductId] ON [dbo].[ProductAttributes]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
ALTER TABLE [dbo].[AttributeOptions]  WITH CHECK ADD  CONSTRAINT [FK_AttributeOptions_Attributes_AttributeId] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attributes] ([AttributeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AttributeOptions] CHECK CONSTRAINT [FK_AttributeOptions_Attributes_AttributeId]
GO
ALTER TABLE [dbo].[Attributes]  WITH CHECK ADD  CONSTRAINT [FK_Attributes_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attributes] CHECK CONSTRAINT [FK_Attributes_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_Attributes_AttributeId] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attributes] ([AttributeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_Attributes_AttributeId]
GO
ALTER TABLE [dbo].[ProductAttributes]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributes_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttributes] CHECK CONSTRAINT [FK_ProductAttributes_Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [sigmaHashDB] SET  READ_WRITE 
GO
