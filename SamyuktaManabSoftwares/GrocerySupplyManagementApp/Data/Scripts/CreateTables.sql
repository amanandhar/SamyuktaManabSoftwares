USE [GrocerySupplyManagement_TEST]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 1/20/2022 1:00:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[AccountNo] [nvarchar](50) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_BankDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankTransaction]    Script Date: 1/20/2022 1:00:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[BankId] [bigint] NOT NULL,
	[Type] [char](1) NOT NULL,
	[Action] [nvarchar](50) NULL,
	[TransactionId] [bigint] NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Narration] [nvarchar](500) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_BankTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 1/20/2022 1:00:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfo](
	[Name] [nvarchar](500) NOT NULL,
	[ShortName] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[ContactNo] [bigint] NULL,
	[EmailId] [nvarchar](100) NULL,
	[Website] [nvarchar](500) NULL,
	[FacebookPage] [nvarchar](500) NULL,
	[RegistrationNo] [nvarchar](50) NULL,
	[RegistrationDate] [nvarchar](50) NULL,
	[PanVatNo] [nvarchar](50) NULL,
	[LogoPath] [nvarchar](500) NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[Counter] [bigint] NOT NULL,
	[EmployeeId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[TempAddress] [nvarchar](500) NULL,
	[PermAddress] [nvarchar](500) NULL,
	[ContactNo] [bigint] NULL,
	[Email] [nvarchar](500) NULL,
	[CitizenshipNo] [nvarchar](50) NULL,
	[Education] [nvarchar](50) NULL,
	[DateOfBirth] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[BloodGroup] [nvarchar](50) NULL,
	[FatherName] [nvarchar](500) NULL,
	[MotherName] [nvarchar](500) NULL,
	[Gender] [nvarchar](50) NULL,
	[MaritalStatus] [nvarchar](50) NULL,
	[SpouseName] [nvarchar](500) NULL,
	[Post] [nvarchar](50) NULL,
	[PostStatus] [nvarchar](50) NULL,
	[AppointedDate] [nvarchar](50) NULL,
	[ResignedDate] [nvarchar](50) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EndOfDay]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EndOfDay](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DateInAd] [date] NOT NULL,
	[DateInBs] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MappedDate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IncomeExpense]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomeExpense](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[ActionType] [nvarchar](50) NOT NULL,
	[BankName] [nvarchar](500) NULL,
	[Type] [nvarchar](500) NOT NULL,
	[Narration] [nvarchar](500) NULL,
	[ReceivedAmount] [decimal](18, 2) NOT NULL,
	[PaymentAmount] [decimal](18, 2) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedDate] [nvarchar](50) NULL,
	[UpdatedBy] [datetime] NULL,
 CONSTRAINT [PK_IncomeExpense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Unit] [nvarchar](25) NOT NULL,
	[Threshold] [decimal](18, 2) NOT NULL,
	[DiscountPercent] [decimal](18, 2) NOT NULL,
	[DiscountThreshold] [decimal](18, 2) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Item_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCategory]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[Counter] [bigint] NOT NULL,
	[Name] [nvarchar](2) NOT NULL,
	[ItemCode] [nvarchar](50) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ItemCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[ShareMemberId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[ContactNo] [bigint] NULL,
	[Email] [nvarchar](100) NULL,
	[AccountNo] [nvarchar](50) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POSDetail]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POSDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[UserTransactionId] [bigint] NOT NULL,
	[InvoiceNo] [nvarchar](50) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[DiscountPercent] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VatPercent] [decimal](18, 2) NOT NULL,
	[Vat] [decimal](18, 2) NOT NULL,
	[DeliveryChargePercent] [decimal](18, 2) NOT NULL,
	[DeliveryCharge] [decimal](18, 2) NOT NULL,
	[DeliveryPersonId] [nvarchar](50) NULL,
 CONSTRAINT [PK_POSDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PricedItem]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PricedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[ProfitPercent] [decimal](18, 4) NOT NULL,
	[Profit] [decimal](18, 2) NOT NULL,
	[SalesPricePerUnit] [decimal](18, 2) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ItemManagement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchasedItem]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchasedItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[SupplierId] [nvarchar](50) NOT NULL,
	[BillNo] [nvarchar](50) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StartingInvoiceNo] [nvarchar](50) NULL,
	[StartingBillNo] [nvarchar](50) NULL,
	[StartingDate] [nvarchar](50) NULL,
	[FiscalYear] [nvarchar](50) NULL,
	[Discount] [decimal](18, 2) NULL,
	[Vat] [decimal](18, 2) NULL,
	[DeliveryCharge] [decimal](18, 2) NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShareMember]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShareMember](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[ShareMemberId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[ContactNo] [bigint] NULL,
	[ImagePath] [nvarchar](max) NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ShareMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoldItem]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoldItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[InvoiceNo] [nvarchar](50) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Profit] [decimal](18, 2) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Quantity] [decimal](18, 3) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_PosTransaction_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockAdjustment]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockAdjustment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[IncomeExpenseId] [bigint] NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_StockAdjustment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[Counter] [bigint] NOT NULL,
	[SupplierId] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[ContactNo] [bigint] NULL,
	[Email] [nvarchar](100) NULL,
	[Owner] [nvarchar](50) NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[IsReadOnly] [bit] NOT NULL,
	[Bank] [bit] NOT NULL,
	[DailySummary] [bit] NOT NULL,
	[DailyTransaction] [bit] NOT NULL,
	[Employee] [bit] NOT NULL,
	[EOD] [bit] NOT NULL,
	[ItemPricing] [bit] NOT NULL,
	[Member] [bit] NOT NULL,
	[POS] [bit] NOT NULL,
	[Reports] [bit] NOT NULL,
	[Settings] [bit] NOT NULL,
	[StockSummary] [bit] NOT NULL,
	[Supplier] [bit] NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTransaction]    Script Date: 1/20/2022 1:00:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EndOfDay] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[ActionType] [nvarchar](50) NOT NULL,
	[PartyId] [nvarchar](50) NOT NULL,
	[PartyNumber] [nvarchar](50) NULL,
	[BankName] [nvarchar](500) NULL,
	[Narration] [nvarchar](500) NULL,
	[DueReceivedAmount] [decimal](18, 2) NOT NULL,
	[DuePaymentAmount] [decimal](18, 2) NOT NULL,
	[ReceivedAmount] [decimal](18, 2) NOT NULL,
	[PaymentAmount] [decimal](18, 2) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_PosTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BankTransaction] ADD  CONSTRAINT [DF_BankTransaction_Debit]  DEFAULT ((0.00)) FOR [Debit]
GO
ALTER TABLE [dbo].[BankTransaction] ADD  CONSTRAINT [DF_BankTransaction_Credit]  DEFAULT ((0.00)) FOR [Credit]
GO
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_DiscountPercent]  DEFAULT ((0.00)) FOR [DiscountPercent]
GO
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_DiscountThreshold]  DEFAULT ((0.00)) FOR [DiscountThreshold]
GO
ALTER TABLE [dbo].[SoldItem] ADD  CONSTRAINT [DF_SoldItem_Discount]  DEFAULT ((0.00)) FOR [Discount]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsReadOnly]  DEFAULT ((0)) FOR [IsReadOnly]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Bank]  DEFAULT ((0)) FOR [Bank]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_DailyExpense]  DEFAULT ((0)) FOR [DailySummary]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_DailySummary]  DEFAULT ((0)) FOR [DailyTransaction]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Employee]  DEFAULT ((0)) FOR [Employee]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_EOD]  DEFAULT ((0)) FOR [EOD]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_ItemPricing]  DEFAULT ((0)) FOR [ItemPricing]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Member]  DEFAULT ((0)) FOR [Member]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_POS]  DEFAULT ((0)) FOR [POS]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Report]  DEFAULT ((0)) FOR [Reports]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Setting]  DEFAULT ((0)) FOR [Settings]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Stock]  DEFAULT ((0)) FOR [StockSummary]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Supplier]  DEFAULT ((0)) FOR [Supplier]
GO
ALTER TABLE [dbo].[UserTransaction] ADD  CONSTRAINT [DF_UserTransaction_DueReceivedAmount]  DEFAULT ((0.00)) FOR [DueReceivedAmount]
GO
ALTER TABLE [dbo].[UserTransaction] ADD  CONSTRAINT [DF_UserTransaction_DuePaymentAmount]  DEFAULT ((0.00)) FOR [DuePaymentAmount]
GO
ALTER TABLE [dbo].[UserTransaction] ADD  CONSTRAINT [DF_UserTransaction_ReceivedAmount]  DEFAULT ((0.00)) FOR [ReceivedAmount]
GO
ALTER TABLE [dbo].[UserTransaction] ADD  CONSTRAINT [DF_UserTransaction_PaymentAmount]  DEFAULT ((0.00)) FOR [PaymentAmount]
GO
ALTER TABLE [dbo].[BankTransaction]  WITH CHECK ADD  CONSTRAINT [FK_BankTransaction_Bank] FOREIGN KEY([BankId])
REFERENCES [dbo].[Bank] ([Id])
GO
ALTER TABLE [dbo].[BankTransaction] CHECK CONSTRAINT [FK_BankTransaction_Bank]
GO
ALTER TABLE [dbo].[POSDetail]  WITH CHECK ADD  CONSTRAINT [FK_POSDetail_UserTransaction] FOREIGN KEY([UserTransactionId])
REFERENCES [dbo].[UserTransaction] ([Id])
GO
ALTER TABLE [dbo].[POSDetail] CHECK CONSTRAINT [FK_POSDetail_UserTransaction]
GO
ALTER TABLE [dbo].[PricedItem]  WITH CHECK ADD  CONSTRAINT [FK_PricedItem_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[PricedItem] CHECK CONSTRAINT [FK_PricedItem_Item]
GO
ALTER TABLE [dbo].[PurchasedItem]  WITH CHECK ADD  CONSTRAINT [FK_PurchasedItem_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[PurchasedItem] CHECK CONSTRAINT [FK_PurchasedItem_Item]
GO
ALTER TABLE [dbo].[SoldItem]  WITH CHECK ADD  CONSTRAINT [FK_SoldItem_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[SoldItem] CHECK CONSTRAINT [FK_SoldItem_Item]
GO
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_StockAdjustment_IncomeExpense] FOREIGN KEY([IncomeExpenseId])
REFERENCES [dbo].[IncomeExpense] ([Id])
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_StockAdjustment_IncomeExpense]
GO
ALTER TABLE [dbo].[StockAdjustment]  WITH CHECK ADD  CONSTRAINT [FK_StockAdjustment_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[StockAdjustment] CHECK CONSTRAINT [FK_StockAdjustment_Item]
GO
