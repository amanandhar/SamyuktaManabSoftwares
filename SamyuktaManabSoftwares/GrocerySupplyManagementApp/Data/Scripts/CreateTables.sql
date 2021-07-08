USE [GrocerySupplyManagement]
GO
/****** Object:  Table [dbo].[BankDetail]    Script Date: 7/7/2021 9:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankDetail](
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
/****** Object:  Table [dbo].[BankTransaction]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BankId] [bigint] NOT NULL,
	[TransactionId] [bigint] NULL,
	[Action] [char](1) NOT NULL,
	[Debit] [decimal](18, 2) NULL,
	[Credit] [decimal](18, 2) NULL,
	[Narration] [nvarchar](500) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_BankTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CodedItem]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[ItemSubCode] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Stock] [bigint] NOT NULL,
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
/****** Object:  Table [dbo].[FiscalYearDetail]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiscalYearDetail](
	[InvoiceNo] [varchar](50) NULL,
	[BillNo] [varchar](50) NULL,
	[StartingDate] [date] NULL,
	[FiscalYear] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 7/7/2021 9:55:27 PM ******/
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
/****** Object:  Table [dbo].[Member]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Key] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NULL,
	[ContactNumber] [bigint] NULL,
	[Email] [nvarchar](100) NULL,
	[AccountNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchasedItem]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchasedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](500) NOT NULL,
	[BillNo] [nvarchar](50) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Quantity] [decimal](18, 0) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoldItem]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoldItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](50) NOT NULL,
	[ItemCode] [nvarchar](50) NOT NULL,
	[ItemName] [nvarchar](500) NOT NULL,
	[ItemBrand] [nvarchar](500) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_PosTransaction_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Owner] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[ContactNumber] [bigint] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierTransaction]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](250) NOT NULL,
	[BillNo] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[ActionType] [nvarchar](50) NOT NULL,
	[Bank] [nvarchar](500) NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_SupplierTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaxDetail]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxDetail](
	[Discount] [decimal](18, 2) NULL,
	[Vat] [decimal](18, 2) NULL,
	[DeliveryCharge] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTransaction]    Script Date: 7/7/2021 9:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[InvoiceDate] [date] NOT NULL,
	[BillNo] [nvarchar](50) NULL,
	[MemberId] [nvarchar](50) NULL,
	[SupplierId] [nvarchar](50) NULL,
	[Action] [nvarchar](50) NOT NULL,
	[ActionType] [nvarchar](50) NOT NULL,
	[Bank] [nvarchar](500) NULL,
	[Expense] [nvarchar](500) NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[DiscountPercent] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VatPercent] [decimal](18, 2) NOT NULL,
	[Vat] [decimal](18, 2) NOT NULL,
	[DeliveryChargePercent] [decimal](18, 2) NOT NULL,
	[DeliveryCharge] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[ReceivedAmount] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_PosTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BankDetail] ON 

INSERT [dbo].[BankDetail] ([Id], [Name], [AccountNo], [Date]) VALUES (3, N'Samyukta Manab Saccos', N'GS-00019', CAST(N'2021-06-23T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[BankDetail] OFF
SET IDENTITY_INSERT [dbo].[BankTransaction] ON 

INSERT [dbo].[BankTransaction] ([Id], [BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [Date]) VALUES (33, 3, 0, N'1', CAST(50000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'Share Capital', CAST(N'2021-07-06T10:02:52.527' AS DateTime))
SET IDENTITY_INSERT [dbo].[BankTransaction] OFF
SET IDENTITY_INSERT [dbo].[CodedItem] ON 

INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (16, 83, N'', N'kg', 10, CAST(100.00 AS Decimal(18, 2)), NULL, 1, CAST(100.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CodedItem] OFF
INSERT [dbo].[FiscalYearDetail] ([InvoiceNo], [BillNo], [StartingDate], [FiscalYear]) VALUES (N'IN-01-0001', N'BN-01-0001', CAST(N'2021-06-07' AS Date), N'2077/78')
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (83, N'Rice Basmati', N'', N'11.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (84, N'Beans Rajma', N'SMGM', N'13.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (85, N'Lentil Mass', N'', N'12.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (86, N'Flour Maida', N'Furtune', N'14.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (95, N'Biscuit Glucose', N'Nebico', N'17.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (96, N'Rice Basmati', N'', N'11.02')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (97, N'Rice Jeera Masino', N'', N'11.03')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (98, N'Rice Jeera Masino', N'', N'11.04')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (99, N'Rice Mansuli', N'', N'11.05')
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
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (9, 1, N'M-0001', N'Bhai Raja Manandhar', N'Nayabazar-16,Kathmandu', 9841862943, N'manandharbhairaja@gmail.com', N'MS-00001')
INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (10, 2, N'M-0002', N'Jesus Krishna Nyachhyon', N'Baphal-13,Kathmandu', 9851056839, N'jesusnyachhyon@gmail.com', N'MS-00007')
SET IDENTITY_INSERT [dbo].[Member] OFF
SET IDENTITY_INSERT [dbo].[PurchasedItem] ON 

INSERT [dbo].[PurchasedItem] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (122, N'ABC Treding', N'BN-01-0001', 83, N'kg', CAST(10 AS Decimal(18, 0)), CAST(100.00 AS Decimal(18, 2)), CAST(N'2021-07-06T10:23:16.210' AS DateTime))
SET IDENTITY_INSERT [dbo].[PurchasedItem] OFF
SET IDENTITY_INSERT [dbo].[SoldItem] ON 

INSERT [dbo].[SoldItem] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (27, N'IN-01-0001', N'11.01', N'Rice Basmati', N'', N'kg', CAST(110.00 AS Decimal(18, 2)), CAST(5 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[SoldItem] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [SupplierId], [Name], [Owner], [Address], [Email], [ContactNumber]) VALUES (1, N'S-0001', N'ABC Treding', N'Basanta Nath', N'Balaju-16,Kathmandu', N'basantanath@gmail.com', 9802154879)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
INSERT [dbo].[TaxDetail] ([Discount], [Vat], [DeliveryCharge]) VALUES (CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[UserTransaction] ON 

INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [Expense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (58, NULL, CAST(N'2021-06-07' AS Date), N'BN-01-0001', NULL, N'S-0001', N'Purchase', N'Credit', NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2021-07-06T10:23:16.217' AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [Expense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (66, N'IN-01-0001', CAST(N'2021-06-07' AS Date), NULL, N'M-0001', NULL, N'Sales', N'Credit', NULL, NULL, CAST(550.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(550.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2021-07-07T09:09:36.120' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserTransaction] OFF
