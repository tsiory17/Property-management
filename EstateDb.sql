USE [master]
GO
/****** Object:  Database [EstateDb]    Script Date: 2024-12-04 6:56:19 PM ******/
CREATE DATABASE [EstateDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EstateDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EstateDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EstateDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EstateDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EstateDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EstateDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EstateDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EstateDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EstateDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EstateDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EstateDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [EstateDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EstateDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EstateDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EstateDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EstateDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EstateDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EstateDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EstateDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EstateDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EstateDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EstateDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EstateDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EstateDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EstateDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EstateDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EstateDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EstateDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EstateDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EstateDb] SET  MULTI_USER 
GO
ALTER DATABASE [EstateDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EstateDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EstateDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EstateDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EstateDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EstateDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EstateDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [EstateDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EstateDb]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 2024-12-04 6:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[ApartmentId] [int] IDENTITY(1,1) NOT NULL,
	[BuildingId] [int] NOT NULL,
	[NumberOfRooms] [int] NOT NULL,
	[Rent] [float] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED 
(
	[ApartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 2024-12-04 6:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 2024-12-04 6:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[BuildingId] [int] IDENTITY(1,1) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[ManagerId] [int] NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Zip] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 2024-12-04 6:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[ManagerId] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ReportedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 2024-12-04 6:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[ManagerId] [int] IDENTITY(10000,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[ManagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 2024-12-04 6:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [int] NOT NULL,
	[ReceiverId] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[SentAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owners]    Script Date: 2024-12-04 6:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owners](
	[OwnerId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2024-12-04 6:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 2024-12-04 6:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[ManagerId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenants]    Script Date: 2024-12-04 6:56:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[TenantId] [int] IDENTITY(100000,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Apartments] ON 

INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [NumberOfRooms], [Rent], [Status]) VALUES (1, 1, 4, 3550, N'Available')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [NumberOfRooms], [Rent], [Status]) VALUES (2, 1, 2, 1800, N'Available')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [NumberOfRooms], [Rent], [Status]) VALUES (3, 1, 2, 1900, N'Occupied')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [NumberOfRooms], [Rent], [Status]) VALUES (4, 2, 3, 2200, N'Occupied')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [NumberOfRooms], [Rent], [Status]) VALUES (5, 2, 2, 1900, N'Available')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [NumberOfRooms], [Rent], [Status]) VALUES (6, 1, 5, 3000, N'Available')
INSERT [dbo].[Apartments] ([ApartmentId], [BuildingId], [NumberOfRooms], [Rent], [Status]) VALUES (7, 1, 4, 3500, N'Available')
SET IDENTITY_INSERT [dbo].[Apartments] OFF
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentId], [ScheduleId], [TenantId], [Status]) VALUES (1, 2, 100002, N'accepted')
INSERT [dbo].[Appointments] ([AppointmentId], [ScheduleId], [TenantId], [Status]) VALUES (2, 5, 100002, N'pending')
INSERT [dbo].[Appointments] ([AppointmentId], [ScheduleId], [TenantId], [Status]) VALUES (3, 1, 100002, N'accepted')
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[Buildings] ON 

INSERT [dbo].[Buildings] ([BuildingId], [OwnerId], [ManagerId], [Address], [City], [Zip]) VALUES (1, 1, 10000, N'1200 Sainte Catherines', N'Montreal', N'H3H3E1')
INSERT [dbo].[Buildings] ([BuildingId], [OwnerId], [ManagerId], [Address], [City], [Zip]) VALUES (2, 2, 10001, N'3222 Bishop', N'Montreal', N'H5E3Z7')
INSERT [dbo].[Buildings] ([BuildingId], [OwnerId], [ManagerId], [Address], [City], [Zip]) VALUES (3, 1, 10000, N'test address ', N'test city', N'test zip')
SET IDENTITY_INSERT [dbo].[Buildings] OFF
GO
SET IDENTITY_INSERT [dbo].[Managers] ON 

INSERT [dbo].[Managers] ([ManagerId], [RoleId], [FirstName], [LastName], [Email], [Password], [Phone]) VALUES (10000, 2, N'Jhalil', N'Roman', N'jr@gmail.com', N'12345', N'1234567877')
INSERT [dbo].[Managers] ([ManagerId], [RoleId], [FirstName], [LastName], [Email], [Password], [Phone]) VALUES (10001, 2, N'Ramiro', N'Zaza', N'rz@gmail.com', N'12345', N'3432423432')
INSERT [dbo].[Managers] ([ManagerId], [RoleId], [FirstName], [LastName], [Email], [Password], [Phone]) VALUES (10003, 2, N'Test', N'test', N'testM@gmailcom', N'12345', N'5555555555')
SET IDENTITY_INSERT [dbo].[Managers] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (1, 100002, 10001, N'hello', CAST(N'2024-12-01T13:54:15.207' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (2, 100002, 100002, N'hi', CAST(N'2024-12-01T13:54:32.207' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (3, 100002, 10000, N'knknkn', CAST(N'2024-12-01T17:24:09.080' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (4, 100002, 10000, N'h/ihijkjkmjlm', CAST(N'2024-12-01T17:37:33.163' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (5, 10000, 100002, N'Hello we received your message fuck you ', CAST(N'2024-12-01T17:57:31.040' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (6, 10000, 100002, N'hdsakjfndsalkjf;dsaf', CAST(N'2024-12-01T20:10:01.110' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (7, 10000, 100002, N'hello aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', CAST(N'2024-12-01T20:11:02.333' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (8, 100002, 10001, N'jbkhvhjvyluvhbkjbj', CAST(N'2024-12-01T20:13:54.883' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (9, 10000, 100002, N'test', CAST(N'2024-12-03T15:23:41.720' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (10, 100002, 10000, N'test reply', CAST(N'2024-12-03T15:25:57.280' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (11, 100002, 10000, N'j;j;hj', CAST(N'2024-12-03T16:52:22.380' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (12, 100002, 10000, N'fssd', CAST(N'2024-12-03T16:55:08.130' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (13, 100002, 10000, N'testreply again ', CAST(N'2024-12-03T17:04:53.897' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (14, 10000, 100002, N'replytestReply', CAST(N'2024-12-03T17:07:12.197' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (15, 100002, 10000, N'fasfsa', CAST(N'2024-12-03T17:07:32.887' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (17, 100002, 10001, N'fadsfasf', CAST(N'2024-12-03T17:14:19.947' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (18, 100002, 100002, N'reply', CAST(N'2024-12-04T14:56:36.030' AS DateTime))
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [Content], [SentAt]) VALUES (19, 100002, 100002, N'reply from tenant', CAST(N'2024-12-04T15:00:14.100' AS DateTime))
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[Owners] ON 

INSERT [dbo].[Owners] ([OwnerId], [RoleId], [FirstName], [LastName], [Email], [Password], [Phone]) VALUES (1, 1, N'Tsiory', N'Rak', N't@gmail.com', N'12345', N'12345')
INSERT [dbo].[Owners] ([OwnerId], [RoleId], [FirstName], [LastName], [Email], [Password], [Phone]) VALUES (2, 1, N'TestOwner', N'test', N'test@gmail.com', N'12345', N'12345')
SET IDENTITY_INSERT [dbo].[Owners] OFF
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Owner')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Manager')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Tenant')
GO
SET IDENTITY_INSERT [dbo].[Schedules] ON 

INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (1, 10000, CAST(N'2024-12-03' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'booked')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (2, 10000, CAST(N'2024-12-03' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (3, 10000, CAST(N'2024-12-03' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (4, 10000, CAST(N'2024-12-03' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (5, 10000, CAST(N'2024-12-03' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (6, 10000, CAST(N'2024-12-03' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (7, 10000, CAST(N'2024-12-03' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (8, 10000, CAST(N'2024-12-03' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (9, 10000, CAST(N'2024-12-04' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (10, 10000, CAST(N'2024-12-04' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (11, 10000, CAST(N'2024-12-04' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (12, 10000, CAST(N'2024-12-04' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (13, 10000, CAST(N'2024-12-04' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (14, 10000, CAST(N'2024-12-04' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (15, 10000, CAST(N'2024-12-04' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (16, 10000, CAST(N'2024-12-04' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (17, 10000, CAST(N'2024-12-05' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (18, 10000, CAST(N'2024-12-05' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (19, 10000, CAST(N'2024-12-05' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (20, 10000, CAST(N'2024-12-05' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (21, 10000, CAST(N'2024-12-05' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (22, 10000, CAST(N'2024-12-05' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (23, 10000, CAST(N'2024-12-05' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (24, 10000, CAST(N'2024-12-05' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (25, 10000, CAST(N'2024-12-06' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (26, 10000, CAST(N'2024-12-06' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (27, 10000, CAST(N'2024-12-06' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (28, 10000, CAST(N'2024-12-06' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (29, 10000, CAST(N'2024-12-06' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (30, 10000, CAST(N'2024-12-06' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (31, 10000, CAST(N'2024-12-06' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (32, 10000, CAST(N'2024-12-06' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (33, 10000, CAST(N'2024-12-09' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (34, 10000, CAST(N'2024-12-09' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (35, 10000, CAST(N'2024-12-09' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (36, 10000, CAST(N'2024-12-09' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (37, 10000, CAST(N'2024-12-09' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (38, 10000, CAST(N'2024-12-09' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (39, 10000, CAST(N'2024-12-09' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (40, 10000, CAST(N'2024-12-09' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (41, 10000, CAST(N'2024-12-10' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (42, 10000, CAST(N'2024-12-10' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (43, 10000, CAST(N'2024-12-10' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (44, 10000, CAST(N'2024-12-10' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (45, 10000, CAST(N'2024-12-10' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (46, 10000, CAST(N'2024-12-10' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (47, 10000, CAST(N'2024-12-10' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (48, 10000, CAST(N'2024-12-10' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (49, 10000, CAST(N'2024-12-11' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (50, 10000, CAST(N'2024-12-11' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (51, 10000, CAST(N'2024-12-11' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (52, 10000, CAST(N'2024-12-11' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (53, 10000, CAST(N'2024-12-11' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (54, 10000, CAST(N'2024-12-11' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (55, 10000, CAST(N'2024-12-11' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (56, 10000, CAST(N'2024-12-11' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (57, 10000, CAST(N'2024-12-12' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (58, 10000, CAST(N'2024-12-12' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (59, 10000, CAST(N'2024-12-12' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (60, 10000, CAST(N'2024-12-12' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (61, 10000, CAST(N'2024-12-12' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (62, 10000, CAST(N'2024-12-12' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (63, 10000, CAST(N'2024-12-12' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (64, 10000, CAST(N'2024-12-12' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (65, 10000, CAST(N'2024-12-13' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (66, 10000, CAST(N'2024-12-13' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (67, 10000, CAST(N'2024-12-13' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (68, 10000, CAST(N'2024-12-13' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (69, 10000, CAST(N'2024-12-13' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (70, 10000, CAST(N'2024-12-13' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (71, 10000, CAST(N'2024-12-13' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (72, 10000, CAST(N'2024-12-13' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (73, 10000, CAST(N'2024-12-16' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (74, 10000, CAST(N'2024-12-16' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (75, 10000, CAST(N'2024-12-16' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (76, 10000, CAST(N'2024-12-16' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (77, 10000, CAST(N'2024-12-16' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (78, 10000, CAST(N'2024-12-16' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (79, 10000, CAST(N'2024-12-16' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (80, 10000, CAST(N'2024-12-16' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (81, 10000, CAST(N'2024-12-17' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (82, 10000, CAST(N'2024-12-17' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (83, 10000, CAST(N'2024-12-17' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (84, 10000, CAST(N'2024-12-17' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (85, 10000, CAST(N'2024-12-17' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (86, 10000, CAST(N'2024-12-17' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (87, 10000, CAST(N'2024-12-17' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (88, 10000, CAST(N'2024-12-17' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (89, 10000, CAST(N'2024-12-18' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (90, 10000, CAST(N'2024-12-18' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (91, 10000, CAST(N'2024-12-18' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (92, 10000, CAST(N'2024-12-18' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (93, 10000, CAST(N'2024-12-18' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (94, 10000, CAST(N'2024-12-18' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (95, 10000, CAST(N'2024-12-18' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (96, 10000, CAST(N'2024-12-18' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (97, 10000, CAST(N'2024-12-19' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (98, 10000, CAST(N'2024-12-19' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (99, 10000, CAST(N'2024-12-19' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
GO
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (100, 10000, CAST(N'2024-12-19' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (101, 10000, CAST(N'2024-12-19' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (102, 10000, CAST(N'2024-12-19' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (103, 10000, CAST(N'2024-12-19' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (104, 10000, CAST(N'2024-12-19' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (105, 10000, CAST(N'2024-12-20' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (106, 10000, CAST(N'2024-12-20' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (107, 10000, CAST(N'2024-12-20' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (108, 10000, CAST(N'2024-12-20' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (109, 10000, CAST(N'2024-12-20' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (110, 10000, CAST(N'2024-12-20' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (111, 10000, CAST(N'2024-12-20' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (112, 10000, CAST(N'2024-12-20' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (113, 10000, CAST(N'2024-12-23' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (114, 10000, CAST(N'2024-12-23' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (115, 10000, CAST(N'2024-12-23' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (116, 10000, CAST(N'2024-12-23' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (117, 10000, CAST(N'2024-12-23' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (118, 10000, CAST(N'2024-12-23' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (119, 10000, CAST(N'2024-12-23' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (120, 10000, CAST(N'2024-12-23' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (121, 10000, CAST(N'2024-12-24' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (122, 10000, CAST(N'2024-12-24' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (123, 10000, CAST(N'2024-12-24' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (124, 10000, CAST(N'2024-12-24' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (125, 10000, CAST(N'2024-12-24' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (126, 10000, CAST(N'2024-12-24' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (127, 10000, CAST(N'2024-12-24' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (128, 10000, CAST(N'2024-12-24' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (129, 10000, CAST(N'2024-12-25' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (130, 10000, CAST(N'2024-12-25' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (131, 10000, CAST(N'2024-12-25' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (132, 10000, CAST(N'2024-12-25' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (133, 10000, CAST(N'2024-12-25' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (134, 10000, CAST(N'2024-12-25' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (135, 10000, CAST(N'2024-12-25' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (136, 10000, CAST(N'2024-12-25' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (137, 10000, CAST(N'2024-12-26' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (138, 10000, CAST(N'2024-12-26' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (139, 10000, CAST(N'2024-12-26' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (140, 10000, CAST(N'2024-12-26' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (141, 10000, CAST(N'2024-12-26' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (142, 10000, CAST(N'2024-12-26' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (143, 10000, CAST(N'2024-12-26' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (144, 10000, CAST(N'2024-12-26' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (145, 10000, CAST(N'2024-12-27' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (146, 10000, CAST(N'2024-12-27' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (147, 10000, CAST(N'2024-12-27' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (148, 10000, CAST(N'2024-12-27' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (149, 10000, CAST(N'2024-12-27' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (150, 10000, CAST(N'2024-12-27' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (151, 10000, CAST(N'2024-12-27' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (152, 10000, CAST(N'2024-12-27' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (153, 10000, CAST(N'2024-12-30' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (154, 10000, CAST(N'2024-12-30' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (155, 10000, CAST(N'2024-12-30' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (156, 10000, CAST(N'2024-12-30' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (157, 10000, CAST(N'2024-12-30' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (158, 10000, CAST(N'2024-12-30' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (159, 10000, CAST(N'2024-12-30' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (160, 10000, CAST(N'2024-12-30' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (161, 10000, CAST(N'2024-12-31' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (162, 10000, CAST(N'2024-12-31' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (163, 10000, CAST(N'2024-12-31' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (164, 10000, CAST(N'2024-12-31' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (165, 10000, CAST(N'2024-12-31' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (166, 10000, CAST(N'2024-12-31' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (167, 10000, CAST(N'2024-12-31' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (168, 10000, CAST(N'2024-12-31' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (169, 10000, CAST(N'2025-01-01' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (170, 10000, CAST(N'2025-01-01' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (171, 10000, CAST(N'2025-01-01' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (172, 10000, CAST(N'2025-01-01' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (173, 10000, CAST(N'2025-01-01' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (174, 10000, CAST(N'2025-01-01' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (175, 10000, CAST(N'2025-01-01' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (176, 10000, CAST(N'2025-01-01' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (177, 10000, CAST(N'2025-01-02' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (178, 10000, CAST(N'2025-01-02' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (179, 10000, CAST(N'2025-01-02' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (180, 10000, CAST(N'2025-01-02' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (181, 10000, CAST(N'2025-01-02' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (182, 10000, CAST(N'2025-01-02' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (183, 10000, CAST(N'2025-01-02' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (184, 10000, CAST(N'2025-01-02' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (185, 10000, CAST(N'2025-01-03' AS Date), CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (186, 10000, CAST(N'2025-01-03' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (187, 10000, CAST(N'2025-01-03' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (188, 10000, CAST(N'2025-01-03' AS Date), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (189, 10000, CAST(N'2025-01-03' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (190, 10000, CAST(N'2025-01-03' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (191, 10000, CAST(N'2025-01-03' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'available')
INSERT [dbo].[Schedules] ([ScheduleId], [ManagerId], [Date], [StartTime], [EndTime], [Status]) VALUES (192, 10000, CAST(N'2025-01-03' AS Date), CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), N'available')
SET IDENTITY_INSERT [dbo].[Schedules] OFF
GO
SET IDENTITY_INSERT [dbo].[Tenants] ON 

INSERT [dbo].[Tenants] ([TenantId], [RoleId], [FirstName], [LastName], [Email], [Password], [Phone]) VALUES (100000, 3, N'Duy', N'Thai', N'duy@gmail.com', N'12345', N'123456789')
INSERT [dbo].[Tenants] ([TenantId], [RoleId], [FirstName], [LastName], [Email], [Password], [Phone]) VALUES (100002, 3, N'Maria', N'Carbonell', N'mc@gmail.com', N'12345', N'0123456789')
INSERT [dbo].[Tenants] ([TenantId], [RoleId], [FirstName], [LastName], [Email], [Password], [Phone]) VALUES (100003, 3, N'test', N'test', N'testT@gmail.com', N'12345', N'5555555556')
SET IDENTITY_INSERT [dbo].[Tenants] OFF
GO
USE [master]
GO
ALTER DATABASE [EstateDb] SET  READ_WRITE 
GO
