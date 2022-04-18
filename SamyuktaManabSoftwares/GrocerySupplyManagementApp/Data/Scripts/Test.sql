UPDATE [SoldItem] set AdjustedType = 'Add', AdjustedAmount = 0.00

/****** Object:  Table [dbo].[QuantitySetting]    Script Date: 4/16/2022 9:07:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuantitySetting](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Bag] [decimal](18, 2) NOT NULL,
	[Box] [decimal](18, 2) NOT NULL,
	[Packet] [decimal](18, 2) NOT NULL,
	[AddedBy] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]
GO



