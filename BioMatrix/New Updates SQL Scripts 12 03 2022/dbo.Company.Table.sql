USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 12-03-2022 17:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Company_ID] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [varchar](50) NULL,
	[Created_By] [int] NULL,
	[Created_On] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Modified_On] [datetime] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Company_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF_Company_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
