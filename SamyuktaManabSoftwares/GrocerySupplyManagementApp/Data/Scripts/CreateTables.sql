USE [GrocerySupplyManagement]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[AccountNo] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_BankDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankTransaction]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDate] [date] NOT NULL,
	[BankId] [bigint] NOT NULL,
	[TransactionId] [bigint] NULL,
	[Action] [char](1) NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Narration] [nvarchar](500) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_BankTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CodedItem]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[ItemSubCode] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[PurchasePrice] [decimal](18, 2) NOT NULL,
	[CurrentPurchasePrice] [decimal](18, 2) NULL,
	[Quantity] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ProfitPercent] [decimal](18, 2) NOT NULL,
	[ProfitAmount] [decimal](18, 2) NOT NULL,
	[SalesPrice] [decimal](18, 2) NOT NULL,
	[SalesPricePerUnit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ItemManagement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FiscalYear]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiscalYear](
	[InvoiceNo] [varchar](50) NULL,
	[BillNo] [varchar](50) NULL,
	[StartingDate] [date] NULL,
	[Year] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Brand] [nvarchar](250) NOT NULL,
	[Code] [nvarchar](10) NULL,
 CONSTRAINT [PK_Item_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Counter] [bigint] NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[ContactNo] [bigint] NULL,
	[Email] [nvarchar](100) NULL,
	[AccountNo] [nvarchar](50) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchasedItem]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchasedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDate] [date] NOT NULL,
	[SupplierId] [nvarchar](50) NOT NULL,
	[BillNo] [nvarchar](50) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoldItem]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoldItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDate] [date] NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[InvoiceNo] [nvarchar](50) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_PosTransaction_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Counter] [bigint] NOT NULL,
	[SupplierId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[ContactNo] [bigint] NULL,
	[Email] [nvarchar](100) NULL,
	[Owner] [nvarchar](50) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tax]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax](
	[Discount] [decimal](18, 2) NULL,
	[Vat] [decimal](18, 2) NULL,
	[DeliveryCharge] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTransaction]    Script Date: 7/16/2021 10:15:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDate] [date] NOT NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[BillNo] [nvarchar](50) NULL,
	[MemberId] [nvarchar](50) NULL,
	[SupplierId] [nvarchar](50) NULL,
	[Action] [nvarchar](50) NOT NULL,
	[ActionType] [nvarchar](50) NOT NULL,
	[Bank] [nvarchar](500) NULL,
	[IncomeExpense] [nvarchar](500) NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[DiscountPercent] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VatPercent] [decimal](18, 2) NOT NULL,
	[Vat] [decimal](18, 2) NOT NULL,
	[DeliveryChargePercent] [decimal](18, 2) NOT NULL,
	[DeliveryCharge] [decimal](18, 2) NOT NULL,
	[DueAmount] [decimal](18, 2) NOT NULL,
	[ReceivedAmount] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_PosTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bank] ON 

INSERT [dbo].[Bank] ([Id], [Name], [AccountNo], [Date]) VALUES (3, N'Samyukta Manab Saccos', N'GS-00019', CAST(N'2021-06-23T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bank] OFF
SET IDENTITY_INSERT [dbo].[CodedItem] ON 

INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (16, 83, N'01', N'kg', CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1, CAST(100.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)))
INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (17, 85, N'01', N'kg', CAST(60.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), 1, CAST(60.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.60 AS Decimal(18, 2)), CAST(60.60 AS Decimal(18, 2)), CAST(60.60 AS Decimal(18, 2)))
INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (18, 84, N'01', N'kg', CAST(55.00 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), 1, CAST(55.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(5.50 AS Decimal(18, 2)), CAST(60.50 AS Decimal(18, 2)), CAST(60.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CodedItem] OFF
INSERT [dbo].[FiscalYear] ([InvoiceNo], [BillNo], [StartingDate], [Year]) VALUES (N'IN-01-0001', N'BN-01-0001', CAST(N'2021-06-07' AS Date), N'2077/78')
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (83, N'Rice Basmati', N'Aarati', N'11.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (84, N'Beans Rajma', N'SMGM', N'13.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (85, N'Lentil Mass', N'SMGM', N'12.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (86, N'Flour Maida', N'Furtune', N'14.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (95, N'Biscuit Glucose', N'Nebico', N'17.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (96, N'Rice Basmati', N'Hulas', N'11.02')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (97, N'Rice Jeera Masino', N'Goodluck', N'11.03')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (98, N'Rice Jeera Masino', N'Local', N'11.04')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (99, N'Rice Mansuli', N'Munni', N'11.05')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (100, N'Lentil Rahar', N'', N'12.02')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (101, N'Lentil Musuro', N'', N'12.03')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (102, N'Lentil Mung Khosta', N'', N'12.04')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (103, N'Lentil Mung Chhata', N'', N'12.05')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (104, N'Lentil Chana', N'', N'12.06')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (105, N'Beans Bodi', N'SMGM', N'13.02')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (106, N'Beans Chana Khairo', N'SMGM', N'13.03')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (107, N'Beans Chana Kauli', N'SMGM', N'13.04')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (108, N'Beans Kerau Seto', N'SMGM', N'13.05')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (109, N'Beans Kerau Hario', N'SMGM', N'13.06')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (110, N'Beans Kerau Sano', N'SMGM', N'13.07')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (111, N'Beans Mung Geda', N'SMGM', N'13.08')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (112, N'Bhatmas Khairo', N'SMGM', N'13.09')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (113, N'Bhatmas Seto', N'SMGM', N'13.10')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (114, N'Flour Aanta', N'Gyan Chakki', N'14.03')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (115, N'Flour Maida Khulla', N'SMGM', N'14.02')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (116, N'Flour Aanta', N'Hulas', N'14.04')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (117, N'Flour Aanta', N'SMGM', N'14.05')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (118, N'Flour Suji', N'SMGM', N'14.06')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (119, N'Flour Besan', N'SMGM', N'14.07')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (120, N'Flour Corn', N'SMGM', N'14.08')
SET IDENTITY_INSERT [dbo].[Item] OFF
INSERT [dbo].[Tax] ([Discount], [Vat], [DeliveryCharge]) VALUES (CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
