USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Canteen_Expense]    Script Date: 12-03-2022 17:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canteen_Expense](
	[Expense_ID] [int] IDENTITY(1,1) NOT NULL,
	[Expense_Date] [datetime] NULL,
	[Menu_Id] [int] NULL,
	[Expense_Amount] [decimal](18, 2) NULL,
	[Description] [varchar](500) NULL,
	[Created_By] [int] NULL,
	[Created_On] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Modified_on] [datetime] NULL,
 CONSTRAINT [PK_Canteen_Expense] PRIMARY KEY CLUSTERED 
(
	[Expense_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Canteen_Expense] ADD  CONSTRAINT [DF_Canteen_Expense_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
