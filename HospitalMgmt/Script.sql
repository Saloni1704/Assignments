USE [master]
GO
/****** Object:  Database [HospitalManagementDb]    Script Date: 26-03-2020 10:05:11 ******/
CREATE DATABASE [HospitalManagementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HospitalManagementDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HospitalManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HospitalManagementDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HospitalManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HospitalManagementDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HospitalManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HospitalManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HospitalManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HospitalManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HospitalManagementDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HospitalManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [HospitalManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HospitalManagementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HospitalManagementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HospitalManagementDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HospitalManagementDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HospitalManagementDb] SET QUERY_STORE = OFF
GO
USE [HospitalManagementDb]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 26-03-2020 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[AppointmentTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignAssistants]    Script Date: 26-03-2020 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignAssistants](
	[AssignAssistantId] [int] NOT NULL,
	[AssistantId] [int] NOT NULL,
	[AppointmentId] [int] NOT NULL,
 CONSTRAINT [PK_AssignAssistants] PRIMARY KEY CLUSTERED 
(
	[AssignAssistantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 26-03-2020 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 26-03-2020 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drugs]    Script Date: 26-03-2020 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drugs](
	[DrugId] [int] IDENTITY(1,1) NOT NULL,
	[DrugName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Drugs] PRIMARY KEY CLUSTERED 
(
	[DrugId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HealthcareAssistants]    Script Date: 26-03-2020 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthcareAssistants](
	[AssistantId] [int] IDENTITY(1,1) NOT NULL,
	[AssistantName] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_HealthcareAssistants] PRIMARY KEY CLUSTERED 
(
	[AssistantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 26-03-2020 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](50) NOT NULL,
	[ContactNumber] [varchar](20) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[BloodGroup] [varchar](10) NOT NULL,
	[Disease] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treatments]    Script Date: 26-03-2020 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatments](
	[PrescriptionId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[Timing] [varchar](20) NOT NULL,
	[DrugId] [int] NOT NULL,
 CONSTRAINT [PK_Treatments] PRIMARY KEY CLUSTERED 
(
	[PrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments] ADD  CONSTRAINT [DF_Appointments_AppointmentTime]  DEFAULT (getdate()) FOR [AppointmentTime]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Doctors]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Patients]
GO
ALTER TABLE [dbo].[AssignAssistants]  WITH CHECK ADD  CONSTRAINT [FK_AssignAssistants_Appointments] FOREIGN KEY([AppointmentId])
REFERENCES [dbo].[Appointments] ([AppointmentId])
GO
ALTER TABLE [dbo].[AssignAssistants] CHECK CONSTRAINT [FK_AssignAssistants_Appointments]
GO
ALTER TABLE [dbo].[AssignAssistants]  WITH CHECK ADD  CONSTRAINT [FK_AssignAssistants_HealthcareAssistants] FOREIGN KEY([AssistantId])
REFERENCES [dbo].[HealthcareAssistants] ([AssistantId])
GO
ALTER TABLE [dbo].[AssignAssistants] CHECK CONSTRAINT [FK_AssignAssistants_HealthcareAssistants]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_Departments]
GO
ALTER TABLE [dbo].[HealthcareAssistants]  WITH CHECK ADD  CONSTRAINT [FK_HealthcareAssistants_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[HealthcareAssistants] CHECK CONSTRAINT [FK_HealthcareAssistants_Departments]
GO
ALTER TABLE [dbo].[Treatments]  WITH CHECK ADD  CONSTRAINT [FK_Treatments_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
GO
ALTER TABLE [dbo].[Treatments] CHECK CONSTRAINT [FK_Treatments_Doctors]
GO
ALTER TABLE [dbo].[Treatments]  WITH CHECK ADD  CONSTRAINT [FK_Treatments_Drugs] FOREIGN KEY([DrugId])
REFERENCES [dbo].[Drugs] ([DrugId])
GO
ALTER TABLE [dbo].[Treatments] CHECK CONSTRAINT [FK_Treatments_Drugs]
GO
ALTER TABLE [dbo].[Treatments]  WITH CHECK ADD  CONSTRAINT [FK_Treatments_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[Treatments] CHECK CONSTRAINT [FK_Treatments_Patients]
GO
USE [master]
GO
ALTER DATABASE [HospitalManagementDb] SET  READ_WRITE 
GO
