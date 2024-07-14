USE [master]
GO
/****** Object:  Database [OrderManagement]    Script Date: 7/15/2024 1:19:13 AM ******/
CREATE DATABASE [OrderManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\OrderManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\OrderManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OrderManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrderManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrderManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [OrderManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [OrderManagement] SET  MULTI_USER 
GO
ALTER DATABASE [OrderManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OrderManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrderManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OrderManagement', N'ON'
GO
ALTER DATABASE [OrderManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [OrderManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OrderManagement]
GO
/****** Object:  Schema [Item]    Script Date: 7/15/2024 1:19:13 AM ******/
CREATE SCHEMA [Item]
GO
/****** Object:  Schema [Order]    Script Date: 7/15/2024 1:19:13 AM ******/
CREATE SCHEMA [Order]
GO
/****** Object:  Schema [Supplier]    Script Date: 7/15/2024 1:19:13 AM ******/
CREATE SCHEMA [Supplier]
GO
/****** Object:  UserDefinedTableType [Order].[OrderItems]    Script Date: 7/15/2024 1:19:13 AM ******/
CREATE TYPE [Order].[OrderItems] AS TABLE(
	[OrderId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL
)
GO
/****** Object:  Table [Item].[Item]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Item].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Order].[Order]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Order].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[OrderNo] [nvarchar](max) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[ExpectedDate] [datetime2](7) NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Order].[OrderItem]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Order].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderItem_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Supplier].[Supplier]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Supplier].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [Item].[Item] ON 
GO
INSERT [Item].[Item] ([Id], [Name], [UnitPrice]) VALUES (1, N'A', CAST(12.00 AS Decimal(18, 2)))
GO
INSERT [Item].[Item] ([Id], [Name], [UnitPrice]) VALUES (2, N'B', CAST(12.00 AS Decimal(18, 2)))
GO
INSERT [Item].[Item] ([Id], [Name], [UnitPrice]) VALUES (3, N'C', CAST(12.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [Item].[Item] OFF
GO
SET IDENTITY_INSERT [Order].[Order] ON 
GO
INSERT [Order].[Order] ([Id], [ReferenceId], [OrderNo], [OrderDate], [SupplierId], [ExpectedDate], [Remarks]) VALUES (1, 1, N'1001', CAST(N'2024-07-15T01:11:13.0000000' AS DateTime2), 1, CAST(N'2024-07-15T01:11:13.0000000' AS DateTime2), N'Create Default Order')
GO
SET IDENTITY_INSERT [Order].[Order] OFF
GO
SET IDENTITY_INSERT [Order].[OrderItem] ON 
GO
INSERT [Order].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [Rate]) VALUES (1, 1, 1, 5, CAST(12.00 AS Decimal(18, 2)))
GO
INSERT [Order].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [Rate]) VALUES (2, 1, 2, 6, CAST(12.00 AS Decimal(18, 2)))
GO
INSERT [Order].[OrderItem] ([Id], [OrderId], [ItemId], [Quantity], [Rate]) VALUES (3, 1, 3, 7, CAST(12.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [Order].[OrderItem] OFF
GO
SET IDENTITY_INSERT [Supplier].[Supplier] ON 
GO
INSERT [Supplier].[Supplier] ([Id], [Name], [PhoneNumber], [Address]) VALUES (1, N'Mr.X', N'015XXXXXXXX', N'Eastern Housing, Pallabi')
GO
INSERT [Supplier].[Supplier] ([Id], [Name], [PhoneNumber], [Address]) VALUES (2, N'Biplob Hossain', N'01303040782', N'Eastern Housing, Pallabi, Mirpur-12, Dhaka')
GO
SET IDENTITY_INSERT [Supplier].[Supplier] OFF
GO
/****** Object:  StoredProcedure [Item].[USP_CreateItem]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-13>
-- Description:	<Description,[Supplier].[USP_CreateSupplier]>
-- =============================================
CREATE PROCEDURE [Item].[USP_CreateItem]
(
 @Name NVARCHAR(100) = '',
 @UnitPrice decimal(18,2)
)
AS
BEGIN
	INSERT INTO [Item].[Item] 
		([Name],UnitPrice)    
	VALUES    
		(@Name,@UnitPrice)
END
GO
/****** Object:  StoredProcedure [Item].[USP_GetAllItem]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-14>
-- Description:	<Description,[Item].[USP_GetAllItem]>
-- =============================================
CREATE PROCEDURE [Item].[USP_GetAllItem] 
	
AS
BEGIN
	SELECT
		*
	FROM
		[Item].[Item]
END
GO
/****** Object:  StoredProcedure [Order].[USP_CreateOrder]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-13>
-- Description:	<Description,[Order].[USP_CreateOrder]>
-- =============================================
CREATE PROCEDURE [Order].[USP_CreateOrder]
(
 @OrderItem AS [Order].[OrderItems] Readonly,
 @ReferenceId INT=0,
 @OrderNo VARCHAR(50) = '',
 @OrderDate DATETIME,
 @SupplierId INT=0,
 @ExpectedDate DATETIME,
 @Remarks NVARCHAR(255)=''
)
AS
BEGIN
	INSERT INTO [Order].[Order]    
		(ReferenceId,OrderNo,OrderDate,SupplierId,ExpectedDate,Remarks)    
	VALUES    
		(@ReferenceId,@OrderNo,@OrderDate,@SupplierId,@ExpectedDate,@Remarks)
	INSERT INTO [Order].[OrderItem]
	SELECT OrderId = Scope_Identity(),ItemId,Quantity,Rate FROM @OrderItem
END
GO
/****** Object:  StoredProcedure [Order].[USP_GetAllOrder]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-13>
-- Description:	<Description,[Order].[USP_GetAllOrder]>
-- =============================================
CREATE PROCEDURE [Order].[USP_GetAllOrder]

AS
BEGIN
	SELECT
		O.*,S.[Name] AS SupplierName,S.PhoneNumber,S.[Address]
	FROM
		[Order].[Order] AS O
		INNER JOIN [Supplier].[Supplier] AS S ON S.Id = O.SupplierId
		--INNER JOIN [Order].[OrderItem] AS OI ON OI.OrderId = O.Id
		--INNER JOIN [Item].[Item] AS I ON I.Id = OI.ItemId
END
GO
/****** Object:  StoredProcedure [Order].[USP_GetById]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-13>
-- Description:	<Description,[Order].[USP_GetById]>
-- =============================================
CREATE PROCEDURE [Order].[USP_GetById]
(    
 @Id INT=0 
)
AS
BEGIN
	SELECT
		OI.*, I.[Name] AS ItemName,I.UnitPrice
	FROM
		[Order].[OrderItem] AS OI
		INNER JOIN [Item].[Item] AS I ON I.Id = OI.ItemId
	WHERE
		OrderId = @Id
END
GO
/****** Object:  StoredProcedure [Order].[USP_RemoveOrder]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-13>
-- Description:	<Description,[Order].[USP_RemoveOrder]>
-- =============================================
CREATE PROCEDURE [Order].[USP_RemoveOrder]
(    
 @Id INT=0 
)
AS
BEGIN
	DELETE FROM
		[Order].[Order]
	WHERE
		Id = @Id

	DELETE FROM
		[Order].[OrderItem]
	WHERE
		OrderId = @Id
END
GO
/****** Object:  StoredProcedure [Order].[USP_UpdateOrder]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-13>
-- Description:	<Description,[Order].[USP_UpdateOrder]>
-- =============================================
CREATE PROCEDURE [Order].[USP_UpdateOrder]
(
 @OrderItem AS [Order].[OrderItems] Readonly,
 @Id INT=0,
 @OrderNo VARCHAR(50) = '',
 @OrderDate DATETIME,
 @SupplierId INT=0,
 @ExpectedDate DATETIME,
 @Remarks NVARCHAR(255)=''
)
AS
BEGIN
	UPDATE [Order].[Order]
    SET 
		OrderNo = @OrderNo,
		OrderDate = @OrderDate,
		SupplierId = @SupplierId,
		ExpectedDate = @ExpectedDate,
		Remarks = @Remarks
    WHERE 
		Id = @Id

	UPDATE [Order].[OrderItem]
	SET
		OrderId = @Id,
		ItemId = tvp.ItemId,
		Quantity = tvp.Quantity,
		Rate = tvp.Rate
	FROM
		@OrderItem AS tvp
	WHERE 
		[Order].[OrderItem].OrderId = @Id
END

GO
/****** Object:  StoredProcedure [Supplier].[USP_CreateSupplier]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-13>
-- Description:	<Description,[Supplier].[USP_CreateSupplier]>
-- =============================================
CREATE PROCEDURE [Supplier].[USP_CreateSupplier]
(
 @Name NVARCHAR(50) = '',
 @PhoneNumber VARCHAR(20) = '',
 @Address NVARCHAR(255) = ''
)
AS
BEGIN
	INSERT INTO [Supplier].[Supplier]  
		([Name],PhoneNumber,[Address])    
	VALUES    
		(@Name,@PhoneNumber,@Address)
END
GO
/****** Object:  StoredProcedure [Supplier].[USP_GetAllSupplier]    Script Date: 7/15/2024 1:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-07-14>
-- Description:	<Description,[Supplier].[USP_GetAllSupplier]>
-- =============================================
CREATE PROCEDURE [Supplier].[USP_GetAllSupplier] 
	
AS
BEGIN
	SELECT
		*
	FROM
		[Supplier].[Supplier]
END
GO
USE [master]
GO
ALTER DATABASE [OrderManagement] SET  READ_WRITE 
GO
