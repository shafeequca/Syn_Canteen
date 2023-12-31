USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Revision]    Script Date: 12-03-2022 17:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Revision](
	[Revision_Id] [int] IDENTITY(1,1) NOT NULL,
	[Month_Year] [varchar](50) NULL,
	[DTFrom] [datetime] NULL,
	[DTTo] [datetime] NULL,
	[Breakfast] [decimal](18, 2) NULL,
	[Lunch] [decimal](18, 2) NULL,
	[Chapathi] [decimal](18, 2) NULL,
	[Dinner] [decimal](18, 2) NULL,
	[Breakfast_Count] [int] NULL,
	[Lunch_Count] [int] NULL,
	[Chapathi_Count] [int] NULL,
	[Dinner_Count] [int] NULL,
	[Breakfast_Amount] [decimal](18, 2) NULL,
	[Lunch_Amount] [decimal](18, 2) NULL,
	[Chapathi_Amount] [decimal](18, 2) NULL,
	[Dinner_Amount] [decimal](18, 2) NULL,
	[Created_By] [int] NULL,
	[Created_On] [datetime] NULL,
 CONSTRAINT [PK_Revision] PRIMARY KEY CLUSTERED 
(
	[Revision_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Revision] ADD  CONSTRAINT [DF_Revision_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
