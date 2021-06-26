USE [GrocerySupplyManagement]
GO
/****** Object:  Table [dbo].[TaxDetail]    Script Date: 06/26/2021 10:18:06 ******/
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
INSERT [dbo].[TaxDetail] ([Discount], [Vat], [DeliveryCharge]) VALUES (CAST(2.50 AS Decimal(18, 2)), CAST(13.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)))
/****** Object:  Table [dbo].[SupplierTransaction]    Script Date: 06/26/2021 10:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](250) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[BillNo] [nvarchar](10) NULL,
	[PaymentType] [nvarchar](10) NULL,
	[Bank] [nvarchar](250) NULL,
	[Debit] [decimal](18, 0) NULL,
	[Credit] [decimal](18, 0) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_SupplierTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SupplierTransaction] ON
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [Status], [BillNo], [PaymentType], [Bank], [Debit], [Credit], [Date]) VALUES (94, N'Basanta Suppliers', N'Purchase', N'BN-01-0001', NULL, NULL, CAST(14400 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0x0000AD460094514C AS DateTime))
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [Status], [BillNo], [PaymentType], [Bank], [Debit], [Credit], [Date]) VALUES (95, N'ABC Suppliers', N'Purchase', N'BN-01-0002', NULL, NULL, CAST(500 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0x0000AD46016D8C27 AS DateTime))
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [Status], [BillNo], [PaymentType], [Bank], [Debit], [Credit], [Date]) VALUES (96, N'Shyam Treding', N'Purchase', N'BN-01-0003', NULL, NULL, CAST(3400 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0x0000AD4C00A7AF7B AS DateTime))
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [Status], [BillNo], [PaymentType], [Bank], [Debit], [Credit], [Date]) VALUES (97, N'Basanta Suppliers', N'Payment', N'', N'Cheque', N'Samyukta Manab Saccos', CAST(0 AS Decimal(18, 0)), CAST(10000 AS Decimal(18, 0)), CAST(0x0000AD51015B5A03 AS DateTime))
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [Status], [BillNo], [PaymentType], [Bank], [Debit], [Credit], [Date]) VALUES (98, N'Basanta Suppliers', N'Payment', N'', N'Cheque', N'Samyukta Manab Saccos', CAST(0 AS Decimal(18, 0)), CAST(400 AS Decimal(18, 0)), CAST(0x0000AD5200F495AD AS DateTime))
INSERT [dbo].[SupplierTransaction] ([Id], [SupplierName], [Status], [BillNo], [PaymentType], [Bank], [Debit], [Credit], [Date]) VALUES (99, N'ABC Suppliers', N'Payment', N'', N'Cheque', N'Samyukta Manab Saccos', CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(0x0000AD5200FB2193 AS DateTime))
SET IDENTITY_INSERT [dbo].[SupplierTransaction] OFF
/****** Object:  Table [dbo].[Supplier]    Script Date: 06/26/2021 10:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
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
INSERT [dbo].[Supplier] ([Id], [Name], [Owner], [Address], [Email], [ContactNumber]) VALUES (10, N'Basanta Suppliers', N'Basanta Nath', N'Balaju-16,Kathmandu', N'basanta@gmail.com', 9802541245)
INSERT [dbo].[Supplier] ([Id], [Name], [Owner], [Address], [Email], [ContactNumber]) VALUES (11, N'ABC Suppliers', N'Dinesh Gupta', N'Kuleshwor-16,Kathmandu', N'dinesh@gmail.com', 9823568522)
INSERT [dbo].[Supplier] ([Id], [Name], [Owner], [Address], [Email], [ContactNumber]) VALUES (12, N'Shyam Treding', N'Shyam Sahi', N'Kalimati-13,Kathmandu', N'shyam@gmail.com', 98234512562)
INSERT [dbo].[Supplier] ([Id], [Name], [Owner], [Address], [Email], [ContactNumber]) VALUES (13, N'', N'', N'', N'', 0)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
/****** Object:  Table [dbo].[Purchase]    Script Date: 06/26/2021 10:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierId] [bigint] NULL,
	[ItemId] [bigint] NULL,
	[BillNo] [varbinary](50) NULL,
	[PurchasePrice] [float] NULL,
	[PurchaseDate] [datetime] NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PreparedItem]    Script Date: 06/26/2021 10:18:06 ******/
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
/****** Object:  Table [dbo].[PosTransaction]    Script Date: 06/26/2021 10:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosTransaction](
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
SET IDENTITY_INSERT [dbo].[PosTransaction] ON
INSERT [dbo].[PosTransaction] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (35, N'IN-01-0001', N'11.01', N'Rice Basmati', N'Aarati', N'kg', CAST(132.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[PosTransaction] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (36, N'IN-01-0002', N'11.01', N'Rice Basmati', N'Aarati', N'kg', CAST(132.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[PosTransaction] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (37, N'IN-01-0002', N'13.01', N'Beans Rajma', N'SMGM', N'kg', CAST(90.40 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[PosTransaction] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (38, N'IN-01-0003', N'11.01', N'Rice Basmati', N'Aarati', N'kg', CAST(132.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[PosTransaction] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (39, N'IN-01-0004', N'12.01', N'Lentil Mass', N'SMGM', N'kg', CAST(143.75 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[PosTransaction] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (40, N'IN-01-0005', N'11.01', N'Rice Basmati', N'Aarati', N'kg', CAST(132.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[PosTransaction] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (41, N'IN-01-0005', N'11.01', N'Rice Basmati', N'Aarati', N'kg', CAST(135.60 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[PosTransaction] OFF
/****** Object:  Table [dbo].[PosInvoice]    Script Date: 06/26/2021 10:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosInvoice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](50) NOT NULL,
	[InvoiceDate] [date] NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[PaymentType] [nvarchar](50) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[DiscountPercent] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VatPercent] [decimal](18, 2) NOT NULL,
	[Vat] [decimal](18, 2) NOT NULL,
	[DeliveryChargePercent] [decimal](18, 2) NOT NULL,
	[DeliveryCharge] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[ReceivedAmount] [decimal](18, 2) NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_PosTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PosInvoice] ON
INSERT [dbo].[PosInvoice] ([Id], [InvoiceNo], [InvoiceDate], [MemberId], [PaymentType], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Balance], [Date]) VALUES (16, N'IN-01-0001', CAST(0x9B420B00 AS Date), N'M-0001', N'Credit', CAST(2640.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(26.40 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(52.27 AS Decimal(18, 2)), CAST(2665.87 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2665.87 AS Decimal(18, 2)), CAST(0x0000AD51016D0FC9 AS DateTime))
INSERT [dbo].[PosInvoice] ([Id], [InvoiceNo], [InvoiceDate], [MemberId], [PaymentType], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Balance], [Date]) VALUES (17, N'IN-01-0002', CAST(0x9B420B00 AS Date), N'M-0002', N'Cash', CAST(3092.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(30.92 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(61.22 AS Decimal(18, 2)), CAST(3122.30 AS Decimal(18, 2)), CAST(3122.30 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD5101728F31 AS DateTime))
INSERT [dbo].[PosInvoice] ([Id], [InvoiceNo], [InvoiceDate], [MemberId], [PaymentType], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Balance], [Date]) VALUES (18, N'IN-01-0003', CAST(0x9B420B00 AS Date), N'M-0001', N'Credit', CAST(2640.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(26.40 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(52.27 AS Decimal(18, 2)), CAST(2665.87 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2665.87 AS Decimal(18, 2)), CAST(0x0000AD5200B0C214 AS DateTime))
INSERT [dbo].[PosInvoice] ([Id], [InvoiceNo], [InvoiceDate], [MemberId], [PaymentType], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Balance], [Date]) VALUES (19, N'IN-01-0004', CAST(0x9B420B00 AS Date), N'M-0002', N'Cash', CAST(143.75 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.44 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(2.85 AS Decimal(18, 2)), CAST(145.16 AS Decimal(18, 2)), CAST(145.16 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD5200B0DC40 AS DateTime))
INSERT [dbo].[PosInvoice] ([Id], [InvoiceNo], [InvoiceDate], [MemberId], [PaymentType], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Balance], [Date]) VALUES (20, N'IN-01-0005', CAST(0x9B420B00 AS Date), N'M-0003', N'Cash', CAST(3318.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(33.18 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(65.70 AS Decimal(18, 2)), CAST(3350.52 AS Decimal(18, 2)), CAST(3350.52 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD5200F425CA AS DateTime))
INSERT [dbo].[PosInvoice] ([Id], [InvoiceNo], [InvoiceDate], [MemberId], [PaymentType], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Balance], [Date]) VALUES (21, N'Cash', CAST(0x9B420B00 AS Date), N'M-0001', N'Payment In', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(4331.74 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD5300A36B8A AS DateTime))
SET IDENTITY_INSERT [dbo].[PosInvoice] OFF
/****** Object:  Table [dbo].[Member]    Script Date: 06/26/2021 10:18:06 ******/
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
SET IDENTITY_INSERT [dbo].[Member] OFF
/****** Object:  Table [dbo].[ItemPurchase]    Script Date: 06/26/2021 10:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemPurchase](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](500) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Quantity] [decimal](18, 0) NOT NULL,
	[PurchasePrice] [decimal](18, 2) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[BillNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ItemPurchase] ON
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [ItemId], [Unit], [Quantity], [PurchasePrice], [PurchaseDate], [BillNo]) VALUES (85, N'Basanta Suppliers', 83, N'kg', CAST(50 AS Decimal(18, 0)), CAST(120.00 AS Decimal(18, 2)), CAST(0x0000AD460094514C AS DateTime), N'BN-01-0001')
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [ItemId], [Unit], [Quantity], [PurchasePrice], [PurchaseDate], [BillNo]) VALUES (86, N'Basanta Suppliers', 85, N'kg', CAST(40 AS Decimal(18, 0)), CAST(125.00 AS Decimal(18, 2)), CAST(0x0000AD460094514C AS DateTime), N'BN-01-0001')
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [ItemId], [Unit], [Quantity], [PurchasePrice], [PurchaseDate], [BillNo]) VALUES (87, N'Basanta Suppliers', 84, N'kg', CAST(30 AS Decimal(18, 0)), CAST(80.00 AS Decimal(18, 2)), CAST(0x0000AD460094514C AS DateTime), N'BN-01-0001')
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [ItemId], [Unit], [Quantity], [PurchasePrice], [PurchaseDate], [BillNo]) VALUES (88, N'Basanta Suppliers', 86, N'kg', CAST(25 AS Decimal(18, 0)), CAST(40.00 AS Decimal(18, 2)), CAST(0x0000AD460094514C AS DateTime), N'BN-01-0001')
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [ItemId], [Unit], [Quantity], [PurchasePrice], [PurchaseDate], [BillNo]) VALUES (89, N'ABC Suppliers', 95, N'pkt', CAST(50 AS Decimal(18, 0)), CAST(10.00 AS Decimal(18, 2)), CAST(0x0000AD46016D8C27 AS DateTime), N'BN-01-0002')
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [ItemId], [Unit], [Quantity], [PurchasePrice], [PurchaseDate], [BillNo]) VALUES (90, N'Shyam Treding', 83, N'kg', CAST(25 AS Decimal(18, 0)), CAST(125.00 AS Decimal(18, 2)), CAST(0x0000AD4C00A7AF7B AS DateTime), N'BN-01-0003')
INSERT [dbo].[ItemPurchase] ([Id], [SupplierName], [ItemId], [Unit], [Quantity], [PurchasePrice], [PurchaseDate], [BillNo]) VALUES (91, N'Shyam Treding', 95, N'pkt', CAST(25 AS Decimal(18, 0)), CAST(11.00 AS Decimal(18, 2)), CAST(0x0000AD4C00A7AF7B AS DateTime), N'BN-01-0003')
SET IDENTITY_INSERT [dbo].[ItemPurchase] OFF
/****** Object:  Table [dbo].[Item]    Script Date: 06/26/2021 10:18:06 ******/
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
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (87, N'', N'', N'')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (88, N'', N'', N'')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (89, N'', N'', N'')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (90, N'', N'', N'')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (91, N'', N'', N'')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (92, N'', N'', N'')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (93, N'', N'', N'')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (94, N'', N'', N'')
INSERT [dbo].[Item] ([Id], [Name], [Brand], [Code]) VALUES (95, N'Biscuit Glucose', N'Nebico', N'17.01')
SET IDENTITY_INSERT [dbo].[Item] OFF
/****** Object:  Table [dbo].[FiscalYearDetail]    Script Date: 06/26/2021 10:18:06 ******/
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
/****** Object:  Table [dbo].[BankTransaction]    Script Date: 06/26/2021 10:18:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BankId] [bigint] NOT NULL,
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
INSERT [dbo].[BankTransaction] ([Id], [BankId], [Action], [Debit], [Credit], [Narration], [Date]) VALUES (10, 3, N'1', CAST(50000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'Capital Amount Deposited By Bhai Raja Manandhar', CAST(0x0000AD5200FB810A AS DateTime))
SET IDENTITY_INSERT [dbo].[BankTransaction] OFF
/****** Object:  Table [dbo].[BankDetail]    Script Date: 06/26/2021 10:18:06 ******/
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
