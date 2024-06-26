USE [master]
GO
/****** Object:  Database [ShopSampleDB]    Script Date: 7/4/2567 12:04:08 ******/
CREATE DATABASE [ShopSampleDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopSampleDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ShopSampleDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopSampleDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ShopSampleDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopSampleDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopSampleDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopSampleDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopSampleDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopSampleDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopSampleDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopSampleDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopSampleDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopSampleDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopSampleDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopSampleDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopSampleDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopSampleDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopSampleDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopSampleDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopSampleDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopSampleDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopSampleDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopSampleDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopSampleDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopSampleDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopSampleDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopSampleDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopSampleDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopSampleDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopSampleDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShopSampleDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopSampleDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopSampleDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopSampleDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopSampleDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopSampleDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopSampleDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopSampleDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopSampleDB]
GO
/****** Object:  Table [dbo].[tb_ex]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ex](
	[ex_id] [int] IDENTITY(1,1) NOT NULL,
	[ex_datetime] [datetime] NULL,
	[extype_id] [int] NULL,
	[ex_value] [decimal](18, 2) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_tb_ex] PRIMARY KEY CLUSTERED 
(
	[ex_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_extype]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_extype](
	[extype_id] [int] NOT NULL,
	[extype_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_extype] PRIMARY KEY CLUSTERED 
(
	[extype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_invoice]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_invoice](
	[invoice_id] [int] IDENTITY(1,1) NOT NULL,
	[vendor_id] [int] NULL,
	[invoice_number] [nvarchar](50) NULL,
	[invoice_date] [date] NULL,
	[invoice_count] [int] NULL,
	[invoice_total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tb_invoice] PRIMARY KEY CLUSTERED 
(
	[invoice_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_invoice_detail]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_invoice_detail](
	[invdetail_id] [int] IDENTITY(1,1) NOT NULL,
	[invoice_id] [int] NULL,
	[pro_id] [int] NULL,
	[invdetail_count] [int] NULL,
	[invdetail_sum] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tb_invoice_detail] PRIMARY KEY CLUSTERED 
(
	[invdetail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_member]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_member](
	[mem_id] [int] IDENTITY(1,1) NOT NULL,
	[mem_name] [nvarchar](50) NULL,
	[mem_address] [nvarchar](50) NULL,
	[mem_tel] [nvarchar](10) NULL,
 CONSTRAINT [PK_tb_member] PRIMARY KEY CLUSTERED 
(
	[mem_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_product]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_product](
	[pro_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_name] [nvarchar](50) NULL,
	[pro_detail] [nvarchar](max) NULL,
	[pro_price] [decimal](18, 2) NULL,
	[pro_stock] [int] NULL,
	[pro_image] [nvarchar](50) NULL,
	[protype_id] [int] NULL,
 CONSTRAINT [PK_tb_product] PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_producttype]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_producttype](
	[protype_id] [int] IDENTITY(1,1) NOT NULL,
	[protype_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_producttype] PRIMARY KEY CLUSTERED 
(
	[protype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_sale]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_sale](
	[sale_id] [int] NOT NULL,
	[mem_id] [int] NULL,
	[sale_datetime] [datetime] NULL,
	[sale_count] [int] NULL,
	[sale_total] [decimal](18, 2) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_tb_sale] PRIMARY KEY CLUSTERED 
(
	[sale_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_sale_detail]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_sale_detail](
	[saledetail_id] [int] IDENTITY(1,1) NOT NULL,
	[sale_id] [int] NULL,
	[pro_id] [int] NULL,
	[saledetail_count] [int] NULL,
	[saledetail_sum] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tb_sale_detail] PRIMARY KEY CLUSTERED 
(
	[saledetail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_user]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_username] [nvarchar](30) NULL,
	[user_password] [nvarchar](50) NULL,
	[user_fullname] [nvarchar](50) NULL,
	[user_address] [nvarchar](max) NULL,
	[user_tel] [nvarchar](10) NULL,
	[user_status] [nvarchar](1) NULL,
	[user_type] [nvarchar](1) NULL,
 CONSTRAINT [PK_tb_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_vendor]    Script Date: 7/4/2567 12:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_vendor](
	[vendor_id] [int] IDENTITY(1,1) NOT NULL,
	[vendor_name] [nvarchar](50) NULL,
	[vendor_address] [nvarchar](max) NULL,
	[vendor_tel] [nvarchar](10) NULL,
 CONSTRAINT [PK_tb_vendor] PRIMARY KEY CLUSTERED 
(
	[vendor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_member] ON 

INSERT [dbo].[tb_member] ([mem_id], [mem_name], [mem_address], [mem_tel]) VALUES (1, N'ลูกค้าทั่วไป', N'กรุงเทพ', N'0935545888')
SET IDENTITY_INSERT [dbo].[tb_member] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_user] ON 

INSERT [dbo].[tb_user] ([user_id], [user_username], [user_password], [user_fullname], [user_address], [user_tel], [user_status], [user_type]) VALUES (1, N'admin', N'password', N'ผู้ดูแลระบบ', N'กรุงเทพ', N'0935545888', N'1', N'1')
SET IDENTITY_INSERT [dbo].[tb_user] OFF
GO
ALTER TABLE [dbo].[tb_ex]  WITH CHECK ADD  CONSTRAINT [FK_tb_ex_tb_extype] FOREIGN KEY([extype_id])
REFERENCES [dbo].[tb_extype] ([extype_id])
GO
ALTER TABLE [dbo].[tb_ex] CHECK CONSTRAINT [FK_tb_ex_tb_extype]
GO
ALTER TABLE [dbo].[tb_ex]  WITH CHECK ADD  CONSTRAINT [FK_tb_ex_tb_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tb_user] ([user_id])
GO
ALTER TABLE [dbo].[tb_ex] CHECK CONSTRAINT [FK_tb_ex_tb_user]
GO
ALTER TABLE [dbo].[tb_invoice]  WITH CHECK ADD  CONSTRAINT [FK_tb_invoice_tb_vendor] FOREIGN KEY([vendor_id])
REFERENCES [dbo].[tb_vendor] ([vendor_id])
GO
ALTER TABLE [dbo].[tb_invoice] CHECK CONSTRAINT [FK_tb_invoice_tb_vendor]
GO
ALTER TABLE [dbo].[tb_invoice_detail]  WITH CHECK ADD  CONSTRAINT [FK_tb_invoice_detail_tb_invoice] FOREIGN KEY([invoice_id])
REFERENCES [dbo].[tb_invoice] ([invoice_id])
GO
ALTER TABLE [dbo].[tb_invoice_detail] CHECK CONSTRAINT [FK_tb_invoice_detail_tb_invoice]
GO
ALTER TABLE [dbo].[tb_invoice_detail]  WITH CHECK ADD  CONSTRAINT [FK_tb_invoice_detail_tb_product] FOREIGN KEY([pro_id])
REFERENCES [dbo].[tb_product] ([pro_id])
GO
ALTER TABLE [dbo].[tb_invoice_detail] CHECK CONSTRAINT [FK_tb_invoice_detail_tb_product]
GO
ALTER TABLE [dbo].[tb_product]  WITH CHECK ADD  CONSTRAINT [FK_tb_product_tb_producttype] FOREIGN KEY([protype_id])
REFERENCES [dbo].[tb_producttype] ([protype_id])
GO
ALTER TABLE [dbo].[tb_product] CHECK CONSTRAINT [FK_tb_product_tb_producttype]
GO
ALTER TABLE [dbo].[tb_sale]  WITH CHECK ADD  CONSTRAINT [FK_tb_sale_tb_member] FOREIGN KEY([mem_id])
REFERENCES [dbo].[tb_member] ([mem_id])
GO
ALTER TABLE [dbo].[tb_sale] CHECK CONSTRAINT [FK_tb_sale_tb_member]
GO
ALTER TABLE [dbo].[tb_sale]  WITH CHECK ADD  CONSTRAINT [FK_tb_sale_tb_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[tb_user] ([user_id])
GO
ALTER TABLE [dbo].[tb_sale] CHECK CONSTRAINT [FK_tb_sale_tb_user]
GO
ALTER TABLE [dbo].[tb_sale_detail]  WITH CHECK ADD  CONSTRAINT [FK_tb_sale_detail_tb_product] FOREIGN KEY([pro_id])
REFERENCES [dbo].[tb_product] ([pro_id])
GO
ALTER TABLE [dbo].[tb_sale_detail] CHECK CONSTRAINT [FK_tb_sale_detail_tb_product]
GO
ALTER TABLE [dbo].[tb_sale_detail]  WITH CHECK ADD  CONSTRAINT [FK_tb_sale_detail_tb_sale] FOREIGN KEY([sale_id])
REFERENCES [dbo].[tb_sale] ([sale_id])
GO
ALTER TABLE [dbo].[tb_sale_detail] CHECK CONSTRAINT [FK_tb_sale_detail_tb_sale]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสรายจ่าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_ex', @level2type=N'COLUMN',@level2name=N'ex_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่บันทึก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_ex', @level2type=N'COLUMN',@level2name=N'ex_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภทรายจ่าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_ex', @level2type=N'COLUMN',@level2name=N'extype_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รายจ่าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_ex', @level2type=N'COLUMN',@level2name=N'ex_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสผู้ใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_ex', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางรายจ่าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_ex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสประเภทรายจ่าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_extype', @level2type=N'COLUMN',@level2name=N'extype_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อประเภทรายจ่าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_extype', @level2type=N'COLUMN',@level2name=N'extype_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางประเภทรายจ่าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_extype'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสใบสั่งซื้อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice', @level2type=N'COLUMN',@level2name=N'invoice_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสผู้ขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice', @level2type=N'COLUMN',@level2name=N'vendor_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เลขที่ใบสั่งซื้อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice', @level2type=N'COLUMN',@level2name=N'invoice_number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice', @level2type=N'COLUMN',@level2name=N'invoice_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice', @level2type=N'COLUMN',@level2name=N'invoice_count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ราคารวม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice', @level2type=N'COLUMN',@level2name=N'invoice_total'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ใบสั่งซื้อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสรายละเอียดรับเข้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice_detail', @level2type=N'COLUMN',@level2name=N'invdetail_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสใบสั่งซื้อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice_detail', @level2type=N'COLUMN',@level2name=N'invoice_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice_detail', @level2type=N'COLUMN',@level2name=N'pro_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice_detail', @level2type=N'COLUMN',@level2name=N'invdetail_count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ราคา' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice_detail', @level2type=N'COLUMN',@level2name=N'invdetail_sum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รายละเอียดใบสั่งซื้อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_invoice_detail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสมาชิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_member', @level2type=N'COLUMN',@level2name=N'mem_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อสมาชิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_member', @level2type=N'COLUMN',@level2name=N'mem_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_member', @level2type=N'COLUMN',@level2name=N'mem_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โทร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_member', @level2type=N'COLUMN',@level2name=N'mem_tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางสมาชิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_member'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_product', @level2type=N'COLUMN',@level2name=N'pro_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_product', @level2type=N'COLUMN',@level2name=N'pro_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รายละเอียดสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_product', @level2type=N'COLUMN',@level2name=N'pro_detail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ราคาสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_product', @level2type=N'COLUMN',@level2name=N'pro_price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_product', @level2type=N'COLUMN',@level2name=N'pro_stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รูปสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_product', @level2type=N'COLUMN',@level2name=N'pro_image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสประเภทสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_product', @level2type=N'COLUMN',@level2name=N'protype_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_product'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสประเภทสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_producttype', @level2type=N'COLUMN',@level2name=N'protype_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อประเภทสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_producttype', @level2type=N'COLUMN',@level2name=N'protype_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางประเภทสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_producttype'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสการขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale', @level2type=N'COLUMN',@level2name=N'sale_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสมาชิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale', @level2type=N'COLUMN',@level2name=N'mem_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่ขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale', @level2type=N'COLUMN',@level2name=N'sale_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale', @level2type=N'COLUMN',@level2name=N'sale_count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ราคารวม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale', @level2type=N'COLUMN',@level2name=N'sale_total'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสผู้ใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางการขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสรายละเอียดการขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale_detail', @level2type=N'COLUMN',@level2name=N'saledetail_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสการขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale_detail', @level2type=N'COLUMN',@level2name=N'sale_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสินค้า' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale_detail', @level2type=N'COLUMN',@level2name=N'pro_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนการขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale_detail', @level2type=N'COLUMN',@level2name=N'saledetail_count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ราคารวม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale_detail', @level2type=N'COLUMN',@level2name=N'saledetail_sum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางรายละเอียดการขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_sale_detail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสผู้ใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อผู้ใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสผ่าน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ-นามสกุล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_fullname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โทร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภทผู้ใช้ 1 = ผู้ดูแลระบบ 2 = พนักงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางผู้ใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสผู้ขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_vendor', @level2type=N'COLUMN',@level2name=N'vendor_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อผู้ขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_vendor', @level2type=N'COLUMN',@level2name=N'vendor_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_vendor', @level2type=N'COLUMN',@level2name=N'vendor_address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โทรศัพท์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_vendor', @level2type=N'COLUMN',@level2name=N'vendor_tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตารางผู้ขาย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_vendor'
GO
USE [master]
GO
ALTER DATABASE [ShopSampleDB] SET  READ_WRITE 
GO
