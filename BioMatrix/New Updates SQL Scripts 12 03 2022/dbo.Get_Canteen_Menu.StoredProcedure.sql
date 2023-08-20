USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[Get_Canteen_Menu]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[Get_Canteen_Menu]
	
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @Time_From DATETIME
	DECLARE @Time_To DATETIME
	
	SELECT	Menu_Id
			,Menu_Code
			,Menu_Caption
	FROM	Canteen_Menu
	--WHERE	Is_Active=1

	ORDER BY 1
END




GO
