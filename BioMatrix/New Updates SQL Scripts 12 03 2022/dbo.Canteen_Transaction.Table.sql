USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Canteen_Transaction]    Script Date: 12-03-2022 17:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canteen_Transaction](
	[Transaction_Id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Id] [int] NULL,
	[Menu_Id] [int] NULL,
	[Transaction_Time] [datetime] NULL,
	[Attribute1] [varchar](1000) NULL,
	[Attribute2] [varchar](1000) NULL,
	[Attribute3] [varchar](1000) NULL,
	[Created_By] [int] NULL,
	[Created_On] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Modified_On] [datetime] NULL,
	[source] [varchar](100) NULL,
 CONSTRAINT [PK_Canteen_Transactions] PRIMARY KEY CLUSTERED 
(
	[Transaction_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
