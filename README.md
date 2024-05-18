USE [master]
GO

/****** Object:  Database [TaxCalculatorDB]    Script Date: 5/18/2024 11:13:06 PM ******/
CREATE DATABASE [TaxCalculatorDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaxCalculatorDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.TOOKA\MSSQL\DATA\TaxCalculatorDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaxCalculatorDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.TOOKA\MSSQL\DATA\TaxCalculatorDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaxCalculatorDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TaxCalculatorDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TaxCalculatorDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TaxCalculatorDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [TaxCalculatorDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TaxCalculatorDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET RECOVERY FULL 
GO

ALTER DATABASE [TaxCalculatorDB] SET  MULTI_USER 
GO

ALTER DATABASE [TaxCalculatorDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TaxCalculatorDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [TaxCalculatorDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [TaxCalculatorDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [TaxCalculatorDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [TaxCalculatorDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [TaxCalculatorDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [TaxCalculatorDB] SET  READ_WRITE 
GO










USE [TaxCalculatorDB]
GO
/****** Object:  Table [dbo].[City]    Script Date: 5/18/2024 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongestionConfig]    Script Date: 5/18/2024 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongestionConfig](
	[CityId] [bigint] NULL,
	[MaxAmountPerDay] [int] NULL,
	[SingleChargeRuleMinute] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongestionTax]    Script Date: 5/18/2024 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongestionTax](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CityId] [bigint] NULL,
	[FromTime] [time](7) NULL,
	[ToTime] [time](7) NULL,
	[Amount] [decimal](16, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OffDates]    Script Date: 5/18/2024 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OffDates](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CityId] [bigint] NULL,
	[Year] [int] NULL,
	[Month] [int] NULL,
	[Day] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OffDays]    Script Date: 5/18/2024 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OffDays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [bigint] NULL,
	[Day] [nvarchar](150) NULL,
	[IsWorkingDay] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleTaxInfo]    Script Date: 5/18/2024 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleTaxInfo](
	[CityId] [bigint] NULL,
	[VehicleId] [int] NULL,
	[IsTaxFree] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 5/18/2024 10:38:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [Name]) VALUES (1, N'Gothenburg')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
INSERT [dbo].[CongestionConfig] ([CityId], [MaxAmountPerDay], [SingleChargeRuleMinute]) VALUES (1, 60, 60)
GO
SET IDENTITY_INSERT [dbo].[CongestionTax] ON 

INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (1, 1, CAST(N'06:00:00' AS Time), CAST(N'06:29:00' AS Time), CAST(8.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (2, 1, CAST(N'06:30:00' AS Time), CAST(N'06:59:00' AS Time), CAST(13.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (3, 1, CAST(N'07:00:00' AS Time), CAST(N'07:59:00' AS Time), CAST(18.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (4, 1, CAST(N'08:00:00' AS Time), CAST(N'08:29:00' AS Time), CAST(13.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (5, 1, CAST(N'08:30:00' AS Time), CAST(N'14:59:00' AS Time), CAST(8.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (6, 1, CAST(N'15:00:00' AS Time), CAST(N'15:29:00' AS Time), CAST(13.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (7, 1, CAST(N'15:30:00' AS Time), CAST(N'16:59:00' AS Time), CAST(18.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (8, 1, CAST(N'17:00:00' AS Time), CAST(N'17:59:00' AS Time), CAST(13.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (9, 1, CAST(N'18:00:00' AS Time), CAST(N'18:29:00' AS Time), CAST(8.00 AS Decimal(16, 2)))
INSERT [dbo].[CongestionTax] ([Id], [CityId], [FromTime], [ToTime], [Amount]) VALUES (10, 1, CAST(N'18:30:00' AS Time), CAST(N'05:59:00' AS Time), CAST(0.00 AS Decimal(16, 2)))
SET IDENTITY_INSERT [dbo].[CongestionTax] OFF
GO
SET IDENTITY_INSERT [dbo].[OffDates] ON 

INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (1, 1, 2013, 1, 1)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (2, 1, 2013, 3, 28)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (3, 1, 2013, 3, 29)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (4, 1, 2013, 4, 1)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (5, 1, 2013, 4, 30)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (6, 1, 2013, 5, 1)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (7, 1, 2013, 5, 8)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (8, 1, 2013, 5, 9)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (9, 1, 2013, 6, 5)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (10, 1, 2013, 6, 6)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (11, 1, 2013, 6, 20)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (12, 1, 2013, 6, 21)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (13, 1, 2013, 7, 0)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (14, 1, 2013, 11, 1)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (15, 1, 2013, 12, 24)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (16, 1, 2013, 12, 25)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (17, 1, 2013, 12, 26)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (18, 1, 2013, 12, 30)
INSERT [dbo].[OffDates] ([Id], [CityId], [Year], [Month], [Day]) VALUES (19, 1, 2013, 12, 31)
SET IDENTITY_INSERT [dbo].[OffDates] OFF
GO
SET IDENTITY_INSERT [dbo].[OffDays] ON 

INSERT [dbo].[OffDays] ([Id], [CityId], [Day], [IsWorkingDay]) VALUES (1, 1, N'Monday', 1)
INSERT [dbo].[OffDays] ([Id], [CityId], [Day], [IsWorkingDay]) VALUES (2, 1, N'Tuesday', 1)
INSERT [dbo].[OffDays] ([Id], [CityId], [Day], [IsWorkingDay]) VALUES (3, 1, N'Wednesday', 1)
INSERT [dbo].[OffDays] ([Id], [CityId], [Day], [IsWorkingDay]) VALUES (4, 1, N'Thursday', 1)
INSERT [dbo].[OffDays] ([Id], [CityId], [Day], [IsWorkingDay]) VALUES (5, 1, N'Friday', 1)
INSERT [dbo].[OffDays] ([Id], [CityId], [Day], [IsWorkingDay]) VALUES (6, 1, N'Saturday', 0)
INSERT [dbo].[OffDays] ([Id], [CityId], [Day], [IsWorkingDay]) VALUES (7, 1, N'Sunday', 0)
SET IDENTITY_INSERT [dbo].[OffDays] OFF
GO
INSERT [dbo].[VehicleTaxInfo] ([CityId], [VehicleId], [IsTaxFree]) VALUES (1, 1, 1)
INSERT [dbo].[VehicleTaxInfo] ([CityId], [VehicleId], [IsTaxFree]) VALUES (1, 2, 1)
INSERT [dbo].[VehicleTaxInfo] ([CityId], [VehicleId], [IsTaxFree]) VALUES (1, 3, 1)
INSERT [dbo].[VehicleTaxInfo] ([CityId], [VehicleId], [IsTaxFree]) VALUES (1, 4, 1)
INSERT [dbo].[VehicleTaxInfo] ([CityId], [VehicleId], [IsTaxFree]) VALUES (1, 5, 1)
INSERT [dbo].[VehicleTaxInfo] ([CityId], [VehicleId], [IsTaxFree]) VALUES (1, 6, 1)
INSERT [dbo].[VehicleTaxInfo] ([CityId], [VehicleId], [IsTaxFree]) VALUES (1, 7, 0)
GO
SET IDENTITY_INSERT [dbo].[VehicleType] ON 

INSERT [dbo].[VehicleType] ([Id], [Name]) VALUES (1, N'Emergency')
INSERT [dbo].[VehicleType] ([Id], [Name]) VALUES (2, N'Busses')
INSERT [dbo].[VehicleType] ([Id], [Name]) VALUES (3, N'Diplomat')
INSERT [dbo].[VehicleType] ([Id], [Name]) VALUES (4, N'Motorcycles')
INSERT [dbo].[VehicleType] ([Id], [Name]) VALUES (5, N'Foreign')
INSERT [dbo].[VehicleType] ([Id], [Name]) VALUES (6, N'Military')
INSERT [dbo].[VehicleType] ([Id], [Name]) VALUES (7, N'Personal')
SET IDENTITY_INSERT [dbo].[VehicleType] OFF
GO
ALTER TABLE [dbo].[CongestionConfig]  WITH CHECK ADD  CONSTRAINT [FK_City_CongestionConfig] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[CongestionConfig] CHECK CONSTRAINT [FK_City_CongestionConfig]
GO
ALTER TABLE [dbo].[CongestionTax]  WITH CHECK ADD  CONSTRAINT [FK_City_CongestionTax] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[CongestionTax] CHECK CONSTRAINT [FK_City_CongestionTax]
GO
ALTER TABLE [dbo].[OffDates]  WITH CHECK ADD  CONSTRAINT [FK_City_OffDates] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[OffDates] CHECK CONSTRAINT [FK_City_OffDates]
GO
ALTER TABLE [dbo].[OffDays]  WITH CHECK ADD  CONSTRAINT [FK_City_OffDaYs] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[OffDays] CHECK CONSTRAINT [FK_City_OffDaYs]
GO
ALTER TABLE [dbo].[VehicleTaxInfo]  WITH CHECK ADD  CONSTRAINT [FK_City_TaxFreeVehicles] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[VehicleTaxInfo] CHECK CONSTRAINT [FK_City_TaxFreeVehicles]
GO
ALTER TABLE [dbo].[VehicleTaxInfo]  WITH CHECK ADD  CONSTRAINT [FK_City_VehicleType] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[VehicleType] ([Id])
GO
ALTER TABLE [dbo].[VehicleTaxInfo] CHECK CONSTRAINT [FK_City_VehicleType]
GO

