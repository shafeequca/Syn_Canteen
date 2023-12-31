USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[SP_Payment_Mode]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SP_Payment_Mode]
		@Payment_Mode VARCHAR(20)
		,@Description VARCHAR(100)
		,@ID INT=NULL
		,@User_Id INT
		
AS
BEGIN


IF @ID IS NULL
BEGIN
	INSERT INTO Payment_Mode
			   (Payment_Mode
			   ,Description
			   ,Created_By
			   ,Created_On)
		 VALUES
			   (@Payment_Mode
			   ,@Description
			   ,@User_Id
			   ,GETDATE())

		SET @ID=SCOPE_IDENTity()
END
ELSE
BEGIN
	UPDATE	Payment_Mode
	SET		Payment_Mode=@Payment_Mode
			,Description=@Description
			,Modified_By=@User_Id
			,Modified_On=GETDATE()
	WHERE	ID=@ID
	
END


END




GO
