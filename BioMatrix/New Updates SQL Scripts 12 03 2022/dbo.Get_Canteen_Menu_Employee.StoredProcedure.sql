USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[Get_Canteen_Menu_Employee]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Get_Canteen_Menu_Employee]
	@Employee_Id INT
AS
BEGIN


	SET NOCOUNT ON;
	SELECT	DISTINCT 
			CM.Menu_Id
			,CM.Menu_Code
			,CM.Menu_Caption
	FROM	Canteen_Menu CM JOIN Canteen_Menu_Mapping M
			ON CM.Menu_Id=M.Menu_Id
	WHERE	M.Is_Active=1
			AND CM.Is_Active=1
			AND M.Employee_Id=@Employee_Id
			AND GETDATE()>=CONVERT(DATETIME,CONVERT(VARCHAR(10),GETDATE(),23)+' '+CONVERT(VARCHAR(8),CM.Time_From,108))
			AND GETDATE()<=CONVERT(DATETIME,CONVERT(VARCHAR(10),GETDATE(),23)+' '+CONVERT(VARCHAR(8),CM.Time_To,108))
			AND (Time_Restriction IS NULL
				OR	CONVERT(DATETIME,CONVERT(VARCHAR(10),GETDATE(),23)+' '+CONVERT(VARCHAR(8),M.Time_Restriction,108))>=GETDATE()
				)
	ORDER BY 1
END



GO
