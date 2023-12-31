USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Canteen_Menu]    Script Date: 12-03-2022 17:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canteen_Menu](
	[Menu_ID] [int] IDENTITY(1,1) NOT NULL,
	[Menu_Code] [varchar](50) NULL,
	[Menu_Caption] [varchar](50) NULL,
	[Menu_Description] [varchar](50) NULL,
	[Is_Active] [tinyint] NULL,
	[Time_From] [datetime] NULL,
	[Time_To] [datetime] NULL,
	[Menu_Group] [varchar](50) NULL,
	[Created_By] [int] NULL,
	[Created_On] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Modified_On] [datetime] NULL,
 CONSTRAINT [PK_Canteen_Menu] PRIMARY KEY CLUSTERED 
(
	[Menu_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Canteen_Menu] ADD  CONSTRAINT [DF_Canteen_Menu_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
