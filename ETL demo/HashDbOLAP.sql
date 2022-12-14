USE [master]
GO
/****** Object:  Database [HashDbETL]    Script Date: 11/23/2022 8:47:47 PM ******/
CREATE DATABASE [HashDbETL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HashDbETL', FILENAME = N'C:\Users\Agust\HashDbETL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HashDbETL_log', FILENAME = N'C:\Users\Agust\HashDbETL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HashDbETL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HashDbETL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HashDbETL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HashDbETL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HashDbETL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HashDbETL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HashDbETL] SET ARITHABORT OFF 
GO
ALTER DATABASE [HashDbETL] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HashDbETL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HashDbETL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HashDbETL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HashDbETL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HashDbETL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HashDbETL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HashDbETL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HashDbETL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HashDbETL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HashDbETL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HashDbETL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HashDbETL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HashDbETL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HashDbETL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HashDbETL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HashDbETL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HashDbETL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HashDbETL] SET  MULTI_USER 
GO
ALTER DATABASE [HashDbETL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HashDbETL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HashDbETL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HashDbETL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HashDbETL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HashDbETL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HashDbETL] SET QUERY_STORE = OFF
GO
USE [HashDbETL]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/23/2022 8:47:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
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
	[AccessFailedCount] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/23/2022 8:47:47 PM ******/
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
	[DateCreated] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 11/23/2022 8:47:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationId] [nvarchar](450) NOT NULL,
	[UserEmail] [nvarchar](max) NOT NULL,
	[BankTransferReceipt] [varbinary](max) NULL,
	[Created] [nvarchar](max) NOT NULL,
	[IsExpired] [bit] NOT NULL,
	[ProductId] [nvarchar](max) NOT NULL,
	[Amount] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [HashDbETL] SET  READ_WRITE 
GO
