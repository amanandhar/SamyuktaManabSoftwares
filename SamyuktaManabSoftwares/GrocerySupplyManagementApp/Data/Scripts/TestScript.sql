USE [Test]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 7/16/2021 9:31:25 PM ******/
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
/****** Object:  Table [dbo].[PurchasedItem]    Script Date: 7/16/2021 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchasedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [date] NOT NULL,
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
/****** Object:  Table [dbo].[SoldItem]    Script Date: 7/16/2021 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoldItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [date] NOT NULL,
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
SET IDENTITY_INSERT [dbo].[PurchasedItem] ON 

INSERT [dbo].[PurchasedItem] ([Id], [EndOfDay], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (1, CAST(N'2078-03-01' AS Date), N'S-0001', N'BN-01-0001', 83, N'kg', 3, CAST(100.00 AS Decimal(18, 2)), CAST(N'2021-03-01T22:03:04.577' AS DateTime))
INSERT [dbo].[PurchasedItem] ([Id], [EndOfDay], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (2, CAST(N'2078-03-03' AS Date), N'S-0001', N'BN-01-0002', 83, N'kg', 10, CAST(110.00 AS Decimal(18, 2)), CAST(N'2021-03-03T22:03:04.583' AS DateTime))
INSERT [dbo].[PurchasedItem] ([Id], [EndOfDay], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (5, CAST(N'2078-03-04' AS Date), N'S-0001', N'BN-01-0003', 83, N'kg', 10, CAST(110.00 AS Decimal(18, 2)), CAST(N'2021-03-04T22:03:04.583' AS DateTime))
INSERT [dbo].[PurchasedItem] ([Id], [EndOfDay], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (6, CAST(N'2078-03-06' AS Date), N'S-0001', N'BN-01-0004', 83, N'kg', 25, CAST(115.00 AS Decimal(18, 2)), CAST(N'2021-03-06T22:03:06.587' AS DateTime))
INSERT [dbo].[PurchasedItem] ([Id], [EndOfDay], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (7, CAST(N'2078-03-07' AS Date), N'S-0001', N'BN-01-0005', 83, N'kg', 50, CAST(90.00 AS Decimal(18, 2)), CAST(N'2021-03-07T22:03:07.597' AS DateTime))
INSERT [dbo].[PurchasedItem] ([Id], [EndOfDay], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (8, CAST(N'2078-03-09' AS Date), N'S-0001', N'BN-01-0006', 83, N'kg', 15, CAST(115.00 AS Decimal(18, 2)), CAST(N'2021-03-09T22:03:09.600' AS DateTime))
INSERT [dbo].[PurchasedItem] ([Id], [EndOfDay], [SupplierId], [BillNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (9, CAST(N'2078-03-04' AS Date), N'S-0001', N'BN-01-0003', 85, N'kg', 10, CAST(100.00 AS Decimal(18, 2)), CAST(N'2021-03-04T22:03:04.583' AS DateTime))
SET IDENTITY_INSERT [dbo].[PurchasedItem] OFF
SET IDENTITY_INSERT [dbo].[SoldItem] ON 

INSERT [dbo].[SoldItem] ([Id], [EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (1, CAST(N'2078-03-02' AS Date), N'M-0001', N'IN-01-0001', 83, N'kg', 1, CAST(100.00 AS Decimal(18, 2)), CAST(N'2021-03-02T22:34:42.957' AS DateTime))
INSERT [dbo].[SoldItem] ([Id], [EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (2, CAST(N'2078-03-04' AS Date), N'M-0001', N'IN-01-0002', 83, N'kg', 5, CAST(109.09 AS Decimal(18, 2)), CAST(N'2021-03-04T22:55:24.913' AS DateTime))
INSERT [dbo].[SoldItem] ([Id], [EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (3, CAST(N'2078-03-05' AS Date), N'M-0001', N'IN-01-0003', 83, N'kg', 3, CAST(109.09 AS Decimal(18, 2)), CAST(N'2021-03-05T22:55:24.913' AS DateTime))
INSERT [dbo].[SoldItem] ([Id], [EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (4, CAST(N'2078-03-08' AS Date), N'M-0001', N'IN-01-0004', 83, N'kg', 10, CAST(115.00 AS Decimal(18, 2)), CAST(N'2021-03-08T22:55:24.913' AS DateTime))
INSERT [dbo].[SoldItem] ([Id], [EndOfDay], [MemberId], [InvoiceNo], [ItemId], [Unit], [Quantity], [Price], [Date]) VALUES (5, CAST(N'2078-03-08' AS Date), N'M-0001', N'IN-01-0004', 85, N'kg', 5, CAST(105.00 AS Decimal(18, 2)), CAST(N'2021-03-08T22:55:24.913' AS DateTime))
SET IDENTITY_INSERT [dbo].[SoldItem] OFF
