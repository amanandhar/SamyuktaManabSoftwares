USE [GrocerySupplyManagement]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 5/2/2021 9:56:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierId] [bigint] NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[Brand] [nvarchar](250) NULL,
	[Unit] [int] NULL,
	[PurchasePrice] [float] NULL,
	[SellPrice] [float] NULL,
	[Quanity] [nvarchar](50) NULL,
	[PurchaseDate] [datetime] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


