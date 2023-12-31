USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Canteen_Menu_Mapping]    Script Date: 12-03-2022 17:45:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canteen_Menu_Mapping](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Id] [int] NULL,
	[Menu_Id] [int] NULL,
	[Is_Active] [tinyint] NULL,
	[Time_Restriction] [datetime] NULL,
	[Created_By] [int] NULL,
	[Created_On] [datetime] NULL,
	[Modified_By] [int] NULL,
	[Modified_On] [datetime] NULL,
 CONSTRAINT [PK_Canteen_Menu_Mapping] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
