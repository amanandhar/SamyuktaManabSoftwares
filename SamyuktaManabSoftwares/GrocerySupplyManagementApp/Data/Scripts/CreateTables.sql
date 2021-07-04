USE [GrocerySupplyManagement]
GO
/****** Object:  Table [dbo].[TaxDetail]    Script Date: 07/04/2021 11:02:52 ******/
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
INSERT [dbo].[TaxDetail] ([Discount], [Vat], [DeliveryCharge]) VALUES (CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
/****** Object:  Table [dbo].[SupplierTransaction]    Script Date: 07/04/2021 11:02:52 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SupplierTransaction] ON
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [BillNo], [Action], [ActionType], [Bank], [Debit], [Credit], [Date]) VALUES (3, N'ABC Treding', N'BN-01-0010', N'Purchase', N'Credit', NULL, CAST(11800.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD55016C29C7 AS DateTime))
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [BillNo], [Action], [ActionType], [Bank], [Debit], [Credit], [Date]) VALUES (4, N'ABC Treding', N'', N'Payment', N'Cheque', N'Samyukta Manab Saccos', CAST(0.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(0x0000AD5600A92045 AS DateTime))
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [BillNo], [Action], [ActionType], [Bank], [Debit], [Credit], [Date]) VALUES (5, N'Basanta Treders', N'BN-01-0011', N'Purchase', N'Credit', NULL, CAST(3000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD5600B54DAA AS DateTime))
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [BillNo], [Action], [ActionType], [Bank], [Debit], [Credit], [Date]) VALUES (6, N'Basanta Treders', N'BN-01-0012', N'Purchase', N'Credit', NULL, CAST(3250.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD560156C1AB AS DateTime))
SET IDENTITY_INSERT [dbo].[SupplierTransaction] OFF
/****** Object:  Table [dbo].[Supplier]    Script Date: 07/04/2021 11:02:52 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON
INSERT [dbo].[Supplier] ([Id], [SupplierId], [Name], [Owner], [Address], [Email], [ContactNumber]) VALUES (1, N'S-0001', N'ABC Treding', N'Shyam Shrestha', N'Balaju-16,Kathmandu,Nepal', N'shyam@gmail.com', 9841256321)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
/****** Object:  Table [dbo].[PreparedItem]    Script Date: 07/04/2021 11:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreparedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[ItemSubCode] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Stock] [bigint] NOT NULL,
	[PurchasePrice] [decimal](18, 2) NOT NULL,
	[OldPurchasePrice] [decimal](18, 2) NULL,
	[Quantity] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ProfitPercent] [decimal](18, 2) NOT NULL,
	[ProfitAmount] [decimal](18, 2) NOT NULL,
	[SalesPrice] [decimal](18, 2) NOT NULL,
	[SalesPricePerUnit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ItemManagement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PreparedItem] ON
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (1, 83, N'01', N'kg', 50, CAST(120.00 AS Decimal(18, 2)), NULL, 1, CAST(120.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), CAST(138.00 AS Decimal(18, 2)), CAST(138.00 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (2, 83, N'05', N'kg', 50, CAST(120.00 AS Decimal(18, 2)), NULL, 5, CAST(600.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), CAST(78.00 AS Decimal(18, 2)), CAST(678.00 AS Decimal(18, 2)), CAST(135.60 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (3, 83, N'20', N'kg', 50, CAST(120.00 AS Decimal(18, 2)), NULL, 20, CAST(2400.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(240.00 AS Decimal(18, 2)), CAST(2640.00 AS Decimal(18, 2)), CAST(132.00 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (4, 95, N'', N'pkt', 50, CAST(10.00 AS Decimal(18, 2)), NULL, 1, CAST(10.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(11.50 AS Decimal(18, 2)), CAST(11.50 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (5, 95, N'06', N'pkt', 50, CAST(10.00 AS Decimal(18, 2)), NULL, 6, CAST(60.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), CAST(7.80 AS Decimal(18, 2)), CAST(67.80 AS Decimal(18, 2)), CAST(11.30 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (6, 95, N'01', N'pkt', 50, CAST(10.00 AS Decimal(18, 2)), NULL, 1, CAST(10.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(11.50 AS Decimal(18, 2)), CAST(11.50 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (7, 95, N'12', N'pkt', 50, CAST(10.00 AS Decimal(18, 2)), NULL, 12, CAST(120.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), CAST(132.00 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (8, 86, N'01', N'kg', 25, CAST(40.00 AS Decimal(18, 2)), NULL, 1, CAST(40.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(46.00 AS Decimal(18, 2)), CAST(46.00 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (9, 86, N'05', N'kg', 25, CAST(40.00 AS Decimal(18, 2)), NULL, 5, CAST(200.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), CAST(26.00 AS Decimal(18, 2)), CAST(226.00 AS Decimal(18, 2)), CAST(45.20 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (10, 84, N'01', N'kg', 30, CAST(80.00 AS Decimal(18, 2)), NULL, 1, CAST(80.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), CAST(92.00 AS Decimal(18, 2)), CAST(92.00 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (11, 84, N'05', N'kg', 30, CAST(80.00 AS Decimal(18, 2)), NULL, 5, CAST(400.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), CAST(52.00 AS Decimal(18, 2)), CAST(452.00 AS Decimal(18, 2)), CAST(90.40 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (12, 85, N'01', N'kg', 40, CAST(125.00 AS Decimal(18, 2)), NULL, 1, CAST(125.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(18.75 AS Decimal(18, 2)), CAST(143.75 AS Decimal(18, 2)), CAST(143.75 AS Decimal(18, 2)))
INSERT [dbo].[PreparedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [OldPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (13, 85, N'05', N'kg', 40, CAST(125.00 AS Decimal(18, 2)), NULL, 5, CAST(625.00 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), CAST(81.25 AS Decimal(18, 2)), CAST(706.25 AS Decimal(18, 2)), CAST(141.25 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[PreparedItem] OFF
/****** Object:  Table [dbo].[PosTransaction]    Script Date: 07/04/2021 11:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosTransaction](
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PosSoldItem]    Script Date: 07/04/2021 11:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosSoldItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](50) NOT NULL,
	[ItemCode] [nvarchar](50) NOT NULL,
	[ItemName] [nvarchar](500) NOT NULL,
	[ItemBrand] [nvarchar](500) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_PosTransaction_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 07/04/2021 11:02:52 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Member] ON
INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (9, 1, N'M-0001', N'Bhai Raja Manandhar', N'Nayabazar-16,Kathmandu', 9841862943, N'manandharbhairaja@gmail.com', N'MS-00001')
INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (10, 2, N'M-0002', N'Jesus Krishna Nyachhyon', N'Baphal-13,Kathmandu', 9851056839, N'jesusnyachhyon@gmail.com', N'MS-00007')
INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (11, 3, N'M-0003', N'Jeewan Bikram Adhikary', N'Paknajol-16,Kathmandu', 98415263256, N'jeewan@gmail.com', N'MS-00303')
INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (12, 4, N'M-0004', N'Nilendra Kuikel', N'Kuleshwor-16,Kathmandu', 98416235921, N'nilendra@gmail.com', N'DS-00014')
INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (13, 5, N'M-0005', N'Bharat Ram Rijal', N'Ombahal-23,Kathmandu', 98415212567, N'bhrat@gmail.com', N'DS-00051')
INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (14, 6, N'M-0006', N'Adam Manandhar', N'Balaju, KTM', 9841272950, N'adam.manandhar@gmail.com', N'MS-11111')
INSERT [dbo].[Member] ([Key], [Id], [MemberId], [Name], [Address], [ContactNumber], [Email], [AccountNumber]) VALUES (15, 7, N'M-0007', N'Rajya Laxmi Shrestha', N'Balaju-16,Ktm.', 9841256321, N'rajya@gmail.com', N'MS-00010')
SET IDENTITY_INSERT [dbo].[Member] OFF
/****** Object:  Table [dbo].[ItemPurchase]    Script Date: 07/04/2021 11:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemPurchase](
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ItemPurchase] ON
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (85, N'Basanta Suppliers', N'BN-01-0001', 83, N'kg', CAST(50 AS Decimal(18, 0)), CAST(120.00 AS Decimal(18, 2)), CAST(0x0000AD460094514C AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (86, N'Basanta Suppliers', N'BN-01-0001', 85, N'kg', CAST(40 AS Decimal(18, 0)), CAST(125.00 AS Decimal(18, 2)), CAST(0x0000AD460094514C AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (87, N'Basanta Suppliers', N'BN-01-0001', 84, N'kg', CAST(30 AS Decimal(18, 0)), CAST(80.00 AS Decimal(18, 2)), CAST(0x0000AD460094514C AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (88, N'Basanta Suppliers', N'BN-01-0001', 86, N'kg', CAST(25 AS Decimal(18, 0)), CAST(40.00 AS Decimal(18, 2)), CAST(0x0000AD460094514C AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (89, N'ABC Suppliers', N'BN-01-0002', 95, N'pkt', CAST(50 AS Decimal(18, 0)), CAST(10.00 AS Decimal(18, 2)), CAST(0x0000AD46016D8C27 AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (90, N'Shyam Treding', N'BN-01-0003', 83, N'kg', CAST(25 AS Decimal(18, 0)), CAST(125.00 AS Decimal(18, 2)), CAST(0x0000AD4C00A7AF7B AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (91, N'Shyam Treding', N'BN-01-0003', 95, N'pkt', CAST(25 AS Decimal(18, 0)), CAST(11.00 AS Decimal(18, 2)), CAST(0x0000AD4C00A7AF7B AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (92, N'Basanta Suppliers', N'BN-01-0004', 83, N'kg', CAST(100 AS Decimal(18, 0)), CAST(100.00 AS Decimal(18, 2)), CAST(0x0000AD5401587919 AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (93, N'Basanta Suppliers', N'BN-01-0005', 83, N'kg', CAST(100 AS Decimal(18, 0)), CAST(100.00 AS Decimal(18, 2)), CAST(0x0000AD54015A5757 AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (94, N'Basanta Suppliers', N'BN-01-0005', 86, N'kg', CAST(50 AS Decimal(18, 0)), CAST(50.00 AS Decimal(18, 2)), CAST(0x0000AD54015A5757 AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (95, N'Basanta Suppliers', N'BN-01-0006', 83, N'kg', CAST(100 AS Decimal(18, 0)), CAST(100.00 AS Decimal(18, 2)), CAST(0x0000AD54015AC0CA AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (96, N'ABC Treding', N'BN-01-0007', 83, N'kg', CAST(100 AS Decimal(18, 0)), CAST(100.00 AS Decimal(18, 2)), CAST(0x0000AD5500B1ABFB AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (97, N'ABC Treding', N'BN-01-0008', 83, N'kg', CAST(2 AS Decimal(18, 0)), CAST(12.00 AS Decimal(18, 2)), CAST(0x0000AD5500B3829A AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (98, N'ABC Treding', N'BN-01-0009', 83, N'kg', CAST(2 AS Decimal(18, 0)), CAST(12.00 AS Decimal(18, 2)), CAST(0x0000AD5500B43900 AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (99, N'ABC Treding', N'BN-01-0010', 83, N'kg', CAST(92 AS Decimal(18, 0)), CAST(100.00 AS Decimal(18, 2)), CAST(0x0000AD55016C29C7 AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (100, N'ABC Treding', N'BN-01-0010', 85, N'kg', CAST(52 AS Decimal(18, 0)), CAST(50.00 AS Decimal(18, 2)), CAST(0x0000AD55016C29C7 AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (101, N'Basanta Treders', N'BN-01-0011', 83, N'kg', CAST(50 AS Decimal(18, 0)), CAST(60.00 AS Decimal(18, 2)), CAST(0x0000AD5600B54DAA AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (102, N'Basanta Treders', N'BN-01-0012', 84, N'kg', CAST(50 AS Decimal(18, 0)), CAST(60.00 AS Decimal(18, 2)), CAST(0x0000AD560156C1AB AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (103, N'Basanta Treders', N'BN-01-0012', 95, N'pkt', CAST(25 AS Decimal(18, 0)), CAST(10.00 AS Decimal(18, 2)), CAST(0x0000AD560156C1AB AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (104, N'ABC Treding', N'BN-01-0013', 83, N'kg', CAST(3 AS Decimal(18, 0)), CAST(200.00 AS Decimal(18, 2)), CAST(0x0000AD5700ACA623 AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (105, N'ABC Treding', N'BN-01-0014', 83, N'kg', CAST(50 AS Decimal(18, 0)), CAST(125.00 AS Decimal(18, 2)), CAST(0x0000AD59015E2D9A AS DateTime))
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (106, N'ABC Treding', N'BN-01-0014', 85, N'kg', CAST(45 AS Decimal(18, 0)), CAST(90.00 AS Decimal(18, 2)), CAST(0x0000AD59015E2D9A AS DateTime))
SET IDENTITY_INSERT [dbo].[ItemPurchase] OFF
/****** Object:  Table [dbo].[Item]    Script Date: 07/04/2021 11:02:52 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Item] ON
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (83, N'Rice Basmati', N'Aarati', N'11.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (84, N'Beans Rajma', N'SMGM', N'13.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (85, N'Lentil Mass', N'SMGM', N'12.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (86, N'Flour Maida', N'Furtune', N'14.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (95, N'Biscuit Glucose', N'Nebico', N'17.01')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (96, N'Rice Basmati', N'Hulas', N'11.02')
SET IDENTITY_INSERT [dbo].[Item] OFF
/****** Object:  Table [dbo].[FiscalYearDetail]    Script Date: 07/04/2021 11:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FiscalYearDetail](
	[InvoiceNo] [varchar](50) NULL,
	[BillNo] [varchar](50) NULL,
	[StartingDate] [date] NULL,
	[FiscalYear] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[FiscalYearDetail] ([InvoiceNo], [BillNo], [StartingDate], [FiscalYear]) VALUES (N'IN-01-0001', N'BN-01-0001', CAST(0x9B420B00 AS Date), N'2077/78')
/****** Object:  Table [dbo].[BankTransaction]    Script Date: 07/04/2021 11:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BankTransaction] ON
INSERT [dbo].[BankTransaction] ([Id], [BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [Date]) VALUES (10, 3, NULL, N'1', CAST(50000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'Capital Amount Deposited By Bhai Raja Manandhar', CAST(0x0000AD5200FB810A AS DateTime))
SET IDENTITY_INSERT [dbo].[BankTransaction] OFF
/****** Object:  Table [dbo].[BankDetail]    Script Date: 07/04/2021 11:02:52 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BankDetail] ON
INSERT [dbo].[BankDetail] ([Id], [Name], [AccountNo], [Date]) VALUES (3, N'Samyukta Manab Saccos', N'GS-00019', CAST(0x0000AD5000000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[BankDetail] OFF
