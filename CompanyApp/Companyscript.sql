USE [master]
GO
/****** Object:  Database [CompanyBusinessAppDb]    Script Date: 29-Mar-20 5:57:10 PM ******/
CREATE DATABASE [CompanyBusinessAppDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompanyBusinessApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CompanyBusinessApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CompanyBusinessApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CompanyBusinessApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CompanyBusinessAppDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompanyBusinessAppDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompanyBusinessAppDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET  MULTI_USER 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompanyBusinessAppDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompanyBusinessAppDb] SET QUERY_STORE = OFF
GO
USE [CompanyBusinessAppDb]
GO
/****** Object:  Table [dbo].[BusinessUnits]    Script Date: 29-Mar-20 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessUnits](
	[BusinessUnitId] [int] IDENTITY(1,1) NOT NULL,
	[BusinessUnitName] [varchar](40) NOT NULL,
 CONSTRAINT [PK_BusinessUnits] PRIMARY KEY CLUSTERED 
(
	[BusinessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 29-Mar-20 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](30) NOT NULL,
	[MobileNumber] [varchar](15) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[EmailId] [varchar](30) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[BusinessUnitId] [int] NOT NULL,
	[EmployeeCode] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 29-Mar-20 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[BusinessUnitId] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTeams]    Script Date: 29-Mar-20 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTeams](
	[ProjectTeamId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[EmployeeDesignation] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ProjectTeams] PRIMARY KEY CLUSTERED 
(
	[ProjectTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacations]    Script Date: 29-Mar-20 5:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacations](
	[VacationId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Vacations] PRIMARY KEY CLUSTERED 
(
	[VacationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_BusinessUnits] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnits] ([BusinessUnitId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_BusinessUnits]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_BusinessUnits] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnits] ([BusinessUnitId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_BusinessUnits]
GO
ALTER TABLE [dbo].[ProjectTeams]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeams_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[ProjectTeams] CHECK CONSTRAINT [FK_ProjectTeams_Employees]
GO
ALTER TABLE [dbo].[ProjectTeams]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeams_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjectTeams] CHECK CONSTRAINT [FK_ProjectTeams_Projects]
GO
ALTER TABLE [dbo].[Vacations]  WITH CHECK ADD  CONSTRAINT [FK_Vacations_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Vacations] CHECK CONSTRAINT [FK_Vacations_Employees]
GO
USE [master]
GO
ALTER DATABASE [CompanyBusinessAppDb] SET  READ_WRITE 
GO
