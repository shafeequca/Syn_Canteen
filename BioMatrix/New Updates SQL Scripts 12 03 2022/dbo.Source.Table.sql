USE [Synthite_Canteen]
GO
/****** Object:  Table [dbo].[Source]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Source](
	[Source_ID] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](100) NULL,
	[Created_On] [datetime] NULL,
 CONSTRAINT [PK_Source] PRIMARY KEY CLUSTERED 
(
	[Source_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Source] ADD  CONSTRAINT [DF_Source_Created_On]  DEFAULT (getdate()) FOR [Created_On]
GO
