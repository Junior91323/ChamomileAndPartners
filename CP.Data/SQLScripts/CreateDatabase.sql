USE [master]
GO
/****** Object:  Database [ChamomileAndPartners]    Script Date: 11.07.2016 19:25:24 ******/
CREATE DATABASE [ChamomileAndPartners]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChamomileAndPartners', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\ChamomileAndPartners.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ChamomileAndPartners_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\ChamomileAndPartners_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ChamomileAndPartners] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChamomileAndPartners].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChamomileAndPartners] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChamomileAndPartners] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChamomileAndPartners] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChamomileAndPartners] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChamomileAndPartners] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChamomileAndPartners] SET  MULTI_USER 
GO
ALTER DATABASE [ChamomileAndPartners] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChamomileAndPartners] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChamomileAndPartners] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChamomileAndPartners] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ChamomileAndPartners] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ChamomileAndPartners]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 11.07.2016 19:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ContractStatusId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Companies_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContractStatus]    Script Date: 11.07.2016 19:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractStatus] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContractStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11.07.2016 19:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Login] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[LastModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_ContractStatus] FOREIGN KEY([ContractStatusId])
REFERENCES [dbo].[ContractStatus] ([Id])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_ContractStatus]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Companies]
GO
USE [master]
GO
ALTER DATABASE [ChamomileAndPartners] SET  READ_WRITE 
GO
USE [ChamomileAndPartners]
GO
INSERT INTO dbo.[ContractStatus] (ContractStatus) VALUES ('Еще не заключен'), ('Заключен'), ('Расторгнут');
GO