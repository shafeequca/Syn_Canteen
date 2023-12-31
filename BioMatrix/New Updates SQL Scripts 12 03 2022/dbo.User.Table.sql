USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_Id] [int] NOT NULL,
	[User_Name] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Is_Active] [tinyint] NULL,
	[User_Role] [varchar](50) NULL,
	[Created_On] [datetime] NOT NULL,
	[Modified_On] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
