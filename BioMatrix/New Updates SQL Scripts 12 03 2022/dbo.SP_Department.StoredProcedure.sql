USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[SP_Department]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SP_Department]
		@Department_Code VARCHAR(20)
		,@Department_Name VARCHAR(100)
		,@Department_ID INT=NULL
		,@User_Id INT
		
AS
BEGIN


IF @Department_ID IS NULL
BEGIN
	INSERT INTO Department
			   (Department_Code
			   ,Department_Name
			   ,Created_By
			   ,Created_On)
		 VALUES
			   (@Department_Code
			   ,@Department_Name
			   ,@User_Id
			   ,GETDATE())

		SET @Department_Id=SCOPE_IDENTity()
END
ELSE
BEGIN
	UPDATE	Department
	SET		Department_Name=@Department_Name
			,Modified_By=@User_Id
			,Modified_On=GETDATE()
	WHERE	Department_Id=@Department_Id
	
END


END



GO
