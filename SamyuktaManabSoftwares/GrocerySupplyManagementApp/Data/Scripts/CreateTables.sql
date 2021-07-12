USE [GrocerySupplyManagement]
GO
/****** Object:  Table [dbo].[UserTransaction]    Script Date: 07/12/2021 10:07:44 ******/
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
	[IncomeExpense] [nvarchar](500) NULL,
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
SET IDENTITY_INSERT [dbo].[UserTransaction] ON
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (79, NULL, CAST(0x9B420B00 AS Date), N'BN-01-0001', NULL, N'S-0001', N'Purchase', N'Credit', NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1600.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD610173B490 AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (80, NULL, CAST(0x9B420B00 AS Date), N'', NULL, N'S-0001', N'Payment', N'Cheque', N'Samyukta Manab Saccos', NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1600.00 AS Decimal(18, 2)), CAST(0x0000AD61017516DB AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (81, NULL, CAST(0x9B420B00 AS Date), NULL, NULL, NULL, N'Expense', N'Cheque', N'Samyukta Manab Saccos', N'Staff Salary ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD6101759D45 AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (82, N'IN-01-0001', CAST(0x9B420B00 AS Date), NULL, N'M-0001', NULL, N'Sales', N'Cash', NULL, NULL, CAST(550.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(550.00 AS Decimal(18, 2)), CAST(550.00 AS Decimal(18, 2)), CAST(0x0000AD610177370D AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (83, NULL, CAST(0x9B420B00 AS Date), NULL, NULL, NULL, N'Expense', N'Cheque', N'Samyukta Manab Saccos', N'Office Rent ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD61018175F9 AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (84, N'IN-01-0002', CAST(0x9B420B00 AS Date), NULL, N'M-0002', NULL, N'Sales', N'Credit', NULL, NULL, CAST(60.60 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(60.60 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000AD62015FBDFE AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (85, NULL, CAST(0x9B420B00 AS Date), NULL, NULL, NULL, N'Receipt', N'Cash', NULL, N'Other Income', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(0x0000AD620164ECD8 AS DateTime))
INSERT [dbo].[UserTransaction] ([Id], [InvoiceNo], [InvoiceDate], [BillNo], [MemberId], [SupplierId], [Action], [ActionType], [Bank], [IncomeExpense], [SubTotal], [DiscountPercent], [Discount], [VatPercent], [Vat], [DeliveryChargePercent], [DeliveryCharge], [TotalAmount], [ReceivedAmount], [Date]) VALUES (86, NULL, CAST(0x9B420B00 AS Date), NULL, NULL, NULL, N'Receipt', N'Cash', NULL, N'Other Income', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(0x0000AD62016B338F AS DateTime))
SET IDENTITY_INSERT [dbo].[UserTransaction] OFF
/****** Object:  Table [dbo].[Tax]    Script Date: 07/12/2021 10:07:44 ******/
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
/****** Object:  Table [dbo].[Supplier]    Script Date: 07/12/2021 10:07:44 ******/
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
INSERT [dbo].[Supplier] ([Id], [SupplierId], [Name], [Owner], [Address], [Email], [ContactNumber]) VALUES (1, N'S-0001', N'ABC Trading', N'Basanta Nath', N'Balaju-16,Kathmandu', N'basantanath@gmail.com', 9802154879)
INSERT [dbo].[Supplier] ([Id], [SupplierId], [Name], [Owner], [Address], [Email], [ContactNumber]) VALUES (2, N'S-0002', N'Basanta Traders', N'Basanta Nath', N'Balaju-16,Kathmandu', N'basantanath@gmail.com', 9802565214)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
/****** Object:  Table [dbo].[SoldItem]    Script Date: 07/12/2021 10:07:44 ******/
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
	[Quantity] [bigint] NOT NULL,
 CONSTRAINT [PK_PosTransaction_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SoldItem] ON
INSERT [dbo].[SoldItem] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (34, N'IN-01-0001', N'11.01', N'Rice Basmati', N'Aarati', N'kg', CAST(110.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[SoldItem] ([Id], [InvoiceNo], [ItemCode], [ItemName], [ItemBrand], [Unit], [Price], [Quantity]) VALUES (35, N'IN-01-0002', N'12.01', N'Lentil Mass', N'SMGM', N'kg', CAST(60.60 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[SoldItem] OFF
/****** Object:  Table [dbo].[PurchasedItem]    Script Date: 07/12/2021 10:07:44 ******/
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
INSERT [dbo].[PurchasedItem] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (128, N'ABC Treding', N'BN-01-0001', 83, N'kg', 10, CAST(100.00 AS Decimal(18, 2)), CAST(0x0000AD610173B477 AS DateTime))
INSERT [dbo].[PurchasedItem] ([Id], [SupplierName], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (129, N'ABC Treding', N'BN-01-0001', 85, N'kg', 10, CAST(60.00 AS Decimal(18, 2)), CAST(0x0000AD610173B477 AS DateTime))
SET IDENTITY_INSERT [dbo].[PurchasedItem] OFF
/****** Object:  Table [dbo].[Member]    Script Date: 07/12/2021 10:07:44 ******/
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
SET IDENTITY_INSERT [dbo].[Member] OFF
/****** Object:  Table [dbo].[Item]    Script Date: 07/12/2021 10:07:44 ******/
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
/****** Object:  Table [dbo].[Income]    Script Date: 07/12/2021 10:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDate] [date] NOT NULL,
	[Type] [nvarchar](500) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Income] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FiscalYear]    Script Date: 07/12/2021 10:07:44 ******/
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
/****** Object:  Table [dbo].[CodedItem]    Script Date: 07/12/2021 10:07:44 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CodedItem] ON
INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (16, 83, N'01', N'kg', 5, CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1, CAST(100.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)))
INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (17, 85, N'01', N'kg', 50, CAST(60.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), 1, CAST(60.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(0.60 AS Decimal(18, 2)), CAST(60.60 AS Decimal(18, 2)), CAST(60.60 AS Decimal(18, 2)))
INSERT [dbo].[CodedItem] ([Id], [ItemId], [ItemSubCode], [Unit], [Stock], [PurchasePrice], [CurrentPurchasePrice], [Quantity], [Price], [ProfitPercent], [ProfitAmount], [SalesPrice], [SalesPricePerUnit]) VALUES (18, 84, N'01', N'kg', 50, CAST(55.00 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), 1, CAST(55.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(5.50 AS Decimal(18, 2)), CAST(60.50 AS Decimal(18, 2)), CAST(60.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CodedItem] OFF
/****** Object:  Table [dbo].[BankTransaction]    Script Date: 07/12/2021 10:07:44 ******/
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
INSERT [dbo].[BankTransaction] ([Id], [BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [Date]) VALUES (38, 3, 0, N'1', CAST(100000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'Capital', CAST(0x0000AD6101612CC7 AS DateTime))
INSERT [dbo].[BankTransaction] ([Id], [BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [Date]) VALUES (40, 3, 80, N'0', CAST(0.00 AS Decimal(18, 2)), CAST(1600.00 AS Decimal(18, 2)), N'S-0001 - ABC Treding', CAST(0x0000AD61017516E9 AS DateTime))
INSERT [dbo].[BankTransaction] ([Id], [BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [Date]) VALUES (41, 3, 81, N'0', CAST(0.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), N'Staff Salary ', CAST(0x0000AD6101759D57 AS DateTime))
INSERT [dbo].[BankTransaction] ([Id], [BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [Date]) VALUES (42, 3, 83, N'0', CAST(0.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), N'Office Rent ', CAST(0x0000AD6101817609 AS DateTime))
INSERT [dbo].[BankTransaction] ([Id], [BankId], [TransactionId], [Action], [Debit], [Credit], [Narration], [Date]) VALUES (45, 3, 0, N'0', CAST(0.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), N'', CAST(0x0000AD6300A1264B AS DateTime))
SET IDENTITY_INSERT [dbo].[BankTransaction] OFF
/****** Object:  Table [dbo].[Bank]    Script Date: 07/12/2021 10:07:44 ******/
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
SET IDENTITY_INSERT [dbo].[Bank] ON
INSERT [dbo].[Bank] ([Id], [Name], [AccountNo], [Date]) VALUES (3, N'Samyukta Manab Saccos', N'GS-00019', CAST(0x0000AD5000000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Bank] OFF
