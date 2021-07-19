USE [GrocerySupplyManagement]
GO
/****** Object:  Table [dbo].[UserTransaction]    Script Date: 07/19/2021 11:12:48 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserTransaction] ON
INSERT [dbo].[UserTransaction] ([Id], [EndOfDate], [InvoiceNo], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [DueAmount], [ReceivedAmount], [Date]) VALUES (1, CAST(0x9B420B00 AS Date), NULL, N'BN-01-0001', NULL, N'S-0001', N'Purchase', N'Credit', NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD6A00990D47 AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [EndOfDate], [InvoiceNo], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [DueAmount], [ReceivedAmount], [Date]) VALUES (2, CAST(0x9B420B00 AS Date), N'IN-01-0001', NULL, N'M-0001', NULL, N'Sales', N'Credit', NULL, NULL, CAST(550.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(550.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD6A009C4E0A AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [EndOfDate], [InvoiceNo], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [DueAmount], [ReceivedAmount], [Date]) VALUES (3, CAST(0x9B420B00 AS Date), NULL, N'BN-01-0002', NULL, N'S-0001', N'Purchase', N'Credit', NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1050.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD6A009DC583 AS DateTime))
SET IDENTITY_INSERT [dbo].[UserTransaction] OFF
/****** Object:  Table [dbo].[Tax]    Script Date: 07/19/2021 11:12:48 ******/
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
INSERT [dbo].[Tax] ([Discount], [Vat], [DeliveryCharge]) VALUES (CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
/****** Object:  Table [dbo].[Supplier]    Script Date: 07/19/2021 11:12:48 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON
INSERT [dbo].[Supplier] ([Id], [Counter], [SupplierId], [Name], [Address], [ContactNo], [Email], [Owner], [Date]) VALUES (1, 1, N'S-0001', N'Basanta Traders', N'Balaju-16,Kathmandu', 98015264589, N'basantanath@gmail.com', N'Basanta Nath', CAST(0x0000AD6A0098DA0A AS DateTime))
SET IDENTITY_INSERT [dbo].[Supplier] OFF
/****** Object:  Table [dbo].[SoldItem]    Script Date: 07/19/2021 11:12:48 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SoldItem] ON
INSERT [dbo].[SoldItem] ([Id], [EndOfDate], [MemberId], [InvoiceNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (1, CAST(0x9B420B00 AS Date), N'M-0001', N'IN-01-0001', 83, N'kg', 5, CAST(110.00 AS Decimal(18, 2)), CAST(0x0000AD6A009C4E10 AS DateTime))
SET IDENTITY_INSERT [dbo].[SoldItem] OFF
/****** Object:  Table [dbo].[PurchasedItem]    Script Date: 07/19/2021 11:12:48 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PurchasedItem] ON
INSERT [dbo].[PurchasedItem] ([Id], [EndOfDate], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (1, CAST(0x9B420B00 AS Date), N'S-0001', N'BN-01-0001', 83, N'kg', 50, CAST(100.00 AS Decimal(18, 2)), CAST(0x0000AD6A00990D25 AS DateTime))
INSERT [dbo].[PurchasedItem] ([Id], [EndOfDate], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (2, CAST(0x9B420B00 AS Date), N'S-0001', N'BN-01-0002', 83, N'kg', 10, CAST(105.00 AS Decimal(18, 2)), CAST(0x0000AD6A009DC582 AS DateTime))
SET IDENTITY_INSERT [dbo].[PurchasedItem] OFF
/****** Object:  Table [dbo].[Member]    Script Date: 07/19/2021 11:12:48 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Member] ON
INSERT [dbo].[Member] ([Id], [Counter], [MemberId], [Name], [Address], [ContactNo], [Email], [AccountNo], [Date]) VALUES (1, 1, N'M-0001', N'Bhai Raja Manandhar', N'Nayabazar-16,Kathmandu', 9841862943, N'manandharbhairaja@gmail.com', N'MS-00001', CAST(0x0000AD6A00987CD7 AS DateTime))
SET IDENTITY_INSERT [dbo].[Member] OFF
/****** Object:  Table [dbo].[Item]    Script Date: 07/19/2021 11:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Brand] [nvarchar](250) NULL,
	[Unit] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Item_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Item] ON
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (1, N'11.01', N'Rice Basmati', N'Aarati', N'gram')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (2, N'13.01', N'Beans Rajma', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (3, N'12.01', N'Lentil Mass', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (4, N'14.01', N'Flour Maida', N'Furtune', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (5, N'17.01', N'Biscuit Glucose', N'Nebico', N'pkt')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (6, N'11.02', N'Rice Basmati', N'Hulas', N'pkt')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (7, N'11.03', N'Rice Jeera Masino', N'Goodluck', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (8, N'11.04', N'Rice Jeera Masino', N'Local', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (9, N'11.05', N'Rice Mansuli', N'Munni', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (10, N'12.02', N'Lentil Rahar', N'', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (11, N'12.03', N'Lentil Musuro', N'', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (12, N'12.04', N'Lentil Mung Khosta', N'', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (13, N'12.05', N'Lentil Mung Chhata', N'', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (14, N'12.06', N'Lentil Chana', N'', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (15, N'13.02', N'Beans Bodi', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (16, N'13.03', N'Beans Chana Khairo', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (17, N'13.04', N'Beans Chana Kauli', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (18, N'13.05', N'Beans Kerau Seto', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (19, N'13.06', N'Beans Kerau Hario', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (20, N'13.07', N'Beans Kerau Sano', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (21, N'13.08', N'Beans Mung Geda', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (22, N'13.09', N'Bhatmas Khairo', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (23, N'13.10', N'Bhatmas Seto', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (24, N'14.03', N'Flour Aanta', N'Gyan Chakki', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (25, N'14.02', N'Flour Maida Khulla', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (26, N'14.04', N'Flour Aanta', N'Hulas', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (27, N'14.05', N'Flour Aanta', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (28, N'14.06', N'Flour Suji', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (29, N'14.07', N'Flour Besan', N'SMGM', N'kg')
INSERT [dbo].[Item] ([Id], [Code], [Name], [Brand], [Unit]) VALUES (30, N'14.08', N'Flour Corn', N'SMGM', N'kg')
SET IDENTITY_INSERT [dbo].[Item] OFF
/****** Object:  Table [dbo].[FiscalYear]    Script Date: 07/19/2021 11:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FiscalYear](
	[InvoiceNo] [varchar](50) NULL,
	[BillNo] [varchar](50) NULL,
	[StartingDate] [date] NULL,
	[Year] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[FiscalYear] ([InvoiceNo], [BillNo], [StartingDate], [Year]) VALUES (N'IN-01-0001', N'BN-01-0001', CAST(0x9B420B00 AS Date), N'2077/78')
/****** Object:  Table [dbo].[CodedItem]    Script Date: 07/19/2021 11:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[ItemSubCode] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[ProfitPercent] [decimal](18, 2) NOT NULL,
	[ProfitAmount] [decimal](18, 2) NOT NULL,
	[SalesPrice] [decimal](18, 2) NOT NULL,
	[SalesPricePerUnit] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_ItemManagement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CodedItem] ON
INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Price], [Quantity], [TotalPrice], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit], [Date]) VALUES (1, 83, N'01', N'kg', CAST(105.00 AS Decimal(18, 2)), 1, CAST(105.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.50 AS Decimal(18, 2)), CAST(115.50 AS Decimal(18, 2)), CAST(115.50 AS Decimal(18, 2)), CAST(0x0000AD6A009B5A1B AS DateTime))
INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Price], [Quantity], [TotalPrice], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit], [Date]) VALUES (2, 83, N'02', N'kg', CAST(101.00 AS Decimal(18, 2)), 1, CAST(101.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.10 AS Decimal(18, 2)), CAST(111.10 AS Decimal(18, 2)), CAST(111.10 AS Decimal(18, 2)), CAST(0x0000AD6A00A3E6D9 AS DateTime))
INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Price], [Quantity], [TotalPrice], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit], [Date]) VALUES (3, 83, N'03', N'kg', CAST(103.00 AS Decimal(18, 2)), 1, CAST(103.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.30 AS Decimal(18, 2)), CAST(113.30 AS Decimal(18, 2)), CAST(113.30 AS Decimal(18, 2)), CAST(0x0000AD6A00ABE7D2 AS DateTime))
SET IDENTITY_INSERT [dbo].[CodedItem] OFF
/****** Object:  Table [dbo].[BankTransaction]    Script Date: 07/19/2021 11:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 07/19/2021 11:12:48 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
