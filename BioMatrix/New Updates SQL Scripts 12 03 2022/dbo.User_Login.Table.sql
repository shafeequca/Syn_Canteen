USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[User_Login]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Login](
	[ID] [int] NOT NULL,
	[User_Id] [int] NULL,
	[Login_Time] [datetime] NULL,
	[Logout_Time] [datetime] NULL,
	[Created_On] [datetime] NULL,
	[Modified_On] [datetime] NULL,
 CONSTRAINT [PK_User_Login] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
