USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[SP_Canteen_Menu]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Canteen_Menu]
		@DTFrom DATETIME
		,@DTTo DATETIME
		,@Is_Active TINYINT
		,@Menu_ID INT
		,@User_Id INT
AS
BEGIN


	UPDATE	Canteen_Menu
	SET		Time_From=@DTFrom
			,Time_To=@DTTo
			,Is_Active=@Is_Active
			,Modified_By=@User_Id
			,Modified_On=GETDATE()
	WHERE	Menu_ID=@Menu_ID
	
END








GO
