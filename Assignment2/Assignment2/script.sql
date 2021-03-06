USE [master]
GO
/****** Object:  Database [Assignmen2Db]    Script Date: 24-03-2020 18:37:41 ******/
CREATE DATABASE [Assignmen2Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assignmen2Db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Assignmen2Db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Assignmen2Db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Assignmen2Db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Assignmen2Db] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assignmen2Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assignmen2Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assignmen2Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assignmen2Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assignmen2Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assignmen2Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assignmen2Db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Assignmen2Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assignmen2Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assignmen2Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assignmen2Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assignmen2Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assignmen2Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assignmen2Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assignmen2Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assignmen2Db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Assignmen2Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assignmen2Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assignmen2Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assignmen2Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assignmen2Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assignmen2Db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Assignmen2Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assignmen2Db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assignmen2Db] SET  MULTI_USER 
GO
ALTER DATABASE [Assignmen2Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assignmen2Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assignmen2Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assignmen2Db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Assignmen2Db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Assignmen2Db] SET QUERY_STORE = OFF
GO
USE [Assignmen2Db]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 24-03-2020 18:37:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tracks]    Script Date: 24-03-2020 18:37:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks](
	[TrackId] [int] IDENTITY(1,1) NOT NULL,
	[TrackName] [varchar](30) NOT NULL,
	[ArtistId] [int] NOT NULL,
 CONSTRAINT [PK_Tracks] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vMusic]    Script Date: 24-03-2020 18:37:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vMusic]
AS
SELECT        dbo.Artists.ArtistId AS Expr1, dbo.Artists.ArtistName, dbo.Tracks.TrackName AS Expr2, dbo.Tracks.TrackId AS Expr3
FROM            dbo.Artists INNER JOIN
                         dbo.Tracks ON dbo.Artists.ArtistId = dbo.Tracks.ArtistId
GO
ALTER TABLE [dbo].[Tracks]  WITH CHECK ADD  CONSTRAINT [FK_Tracks_Artists] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[Tracks] CHECK CONSTRAINT [FK_Tracks_Artists]
GO
/****** Object:  StoredProcedure [dbo].[spSerachMusic]    Script Date: 24-03-2020 18:37:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSerachMusic]
@ArtistName varchar(50)
AS 
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM vMusic where ArtistName = @ArtistName FOR JSON AUTO;
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Artists"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 193
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tracks"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 206
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vMusic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vMusic'
GO
USE [master]
GO
ALTER DATABASE [Assignmen2Db] SET  READ_WRITE 
GO
