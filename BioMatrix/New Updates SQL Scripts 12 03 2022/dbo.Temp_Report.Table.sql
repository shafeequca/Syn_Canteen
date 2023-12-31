USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Temp_Report]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Report](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Id] [int] NULL,
	[BreakFast_Count] [int] NULL,
	[BreakFast_Amount] [decimal](18, 2) NULL,
	[Lunch_Count] [int] NULL,
	[Lunch_Amount] [decimal](18, 2) NULL,
	[Chapathi_Count] [int] NULL,
	[Chapathi_Amount] [decimal](18, 2) NULL,
	[Dinner_Count] [int] NULL,
	[Dinner_Amount] [decimal](18, 2) NULL,
	[Created_On] [datetime] NULL,
 CONSTRAINT [PK_Temp_Report] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Temp_Report] ADD  CONSTRAINT [DF_Temp_Report_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
