USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[SP_Canteen_Transaction]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Canteen_Transaction]
	@Employee_Id INT
	,@Menu_Id INT
	,@User_ID INT
	,@Transaction_Id INT=NULL
	,@Transaction_Time DATETIME=NULL
	,@Is_Delete TINYINT
	,@No_Of_Entries INT
	,@source VARCHAR(100)=NULL
	,@Transaction_Id_Out INT OUTPUT
AS
BEGIN
	IF @Is_Delete=1
	BEGIN
		DELETE FROM Canteen_Transaction WHERE Transaction_Id=@Transaction_Id
		SET @Transaction_Id_Out=0
		RETURN
	END
	IF @Transaction_Time IS NULL
	BEGIN
		SET @Transaction_Time=GETDATE()
	END
	IF @Transaction_Id IS NOT NULL
	BEGIN
		UPDATE	[Canteen_Transaction]
		SET		[Transaction_Time]=@Transaction_Time
				,[Menu_Id]=@Menu_Id
				,source=@source
				,Modified_By=@User_ID
				,Modified_On=GETDATE()
		WHERE	Transaction_Id=@Transaction_Id

		RETURN
	END

	DECLARE @Inc_Count INT
	SET @Inc_Count=1

	WHILE @Inc_Count<=@No_Of_Entries
	BEGIN

		INSERT INTO [Canteen_Transaction]
				   ([Employee_Id]
				   ,[Menu_Id]
				   ,[Transaction_Time]
				   ,[source]
				   ,[Created_By]
				   ,[Created_On])
			 VALUES
				   (@Employee_Id
				   ,@Menu_Id
				   ,@Transaction_Time
				   ,@source
				   ,@User_ID
				   ,GETDATE())
		SET @Transaction_Id_Out=SCOPE_IDENTITY()

		SET @Inc_Count=@Inc_Count+1
	END
END



GO
