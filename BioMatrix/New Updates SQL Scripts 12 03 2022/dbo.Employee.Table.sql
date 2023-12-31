USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12-03-2022 17:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Employee_ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Code] [varchar](20) NOT NULL,
	[Employee_Name] [varchar](100) NOT NULL,
	[Department_ID] [int] NULL,
	[Payment_Mode_ID] [int] NULL,
	[Is_Active] [tinyint] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_By] [int] NULL,
	[Modified_On] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
