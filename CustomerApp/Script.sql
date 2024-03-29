USE [master]
GO
/****** Object:  Database [CustomerApp]    Script Date: 07-May-20 7:06:33 PM ******/
CREATE DATABASE [CustomerApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CustomerApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CustomerApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CustomerApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CustomerApp] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerApp] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CustomerApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CustomerApp] SET QUERY_STORE = OFF
GO
USE [CustomerApp]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 07-May-20 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[MobileNumber] [varchar](20) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[Address] [varchar](30) NOT NULL,
	[DOB] [date] NOT NULL,
	[CustomerNumber] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 07-May-20 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [int] NOT NULL,
	[ProductName] [varchar](30) NOT NULL,
	[Brand] [varchar](30) NOT NULL,
	[ProductPrice] [int] NOT NULL,
	[ProductStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [COde_Unique] UNIQUE NONCLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spFilterProduct]    Script Date: 07-May-20 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spFilterProduct]
	@Status bit
AS
BEGIN
	SET NOCOUNT ON;
	if(@Status=1)
	begin
	select ProductName,ProductPrice,Brand from Products where ProductStatus=1;
	end
	else
	if(@Status=0)
	begin
	select ProductName,ProductPrice,Brand from Products where ProductStatus=0;
	end
   
END
GO
/****** Object:  StoredProcedure [dbo].[spSearchProduct]    Script Date: 07-May-20 7:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSearchProduct]
@Product varchar(30)
	AS
BEGIN
	SET NOCOUNT ON;
	select * from Products where ProductName like '%'+@Product+'%' or ProductCode like '%'+CAST( @Product as varchar)+'%' ;
END
GO
USE [master]
GO
ALTER DATABASE [CustomerApp] SET  READ_WRITE 
GO
