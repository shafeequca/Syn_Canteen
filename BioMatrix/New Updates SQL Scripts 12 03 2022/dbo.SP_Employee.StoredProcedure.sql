USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[SP_Employee]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SP_Employee]
		@Employee_Code VARCHAR(20)=NULL
		,@Employee_Name VARCHAR(100)=NULL
		,@Department_ID INT=NULL
		,@Payment_Mode_ID INT=NULL
		,@Is_Active TINYINT=NULL
		,@User_Id INT
		,@Employee_Id INT=NULL
		,@Is_Delete TINYINT
		,@BreakFast_Enabled TINYINT=NULL
		,@Lunch_Enabled TINYINT=NULL
		,@Chapathi_Enabled TINYINT=NULL
		,@Dinner_Enabled TINYINT=NULL
		,@BreakFast_RestrictTime DATETIME=NULL
		,@Lunch_RestrictTime DATETIME=NULL
		,@Chapathi_RestrictTime DATETIME=NULL
		,@Dinner_RestrictTime DATETIME=NULL
		
AS
BEGIN
IF @Is_Delete =1
BEGIN
	DELETE FROM Canteen_Menu_Mapping WHERE Employee_Id=@Employee_Id
	DELETE FROM Employee WHERE Employee_Id=@Employee_Id
	RETURN
END

IF @Employee_Id IS NULL
BEGIN
	INSERT INTO Employee
			   (Employee_Code
			   ,Employee_Name
			   ,Department_ID
			   ,Payment_Mode_ID
			   ,Is_Active
			   ,Created_By
			   ,Created_On)
		 VALUES
			   (@Employee_Code
			   ,@Employee_Name
			   ,@Department_ID
			   ,@Payment_Mode_ID
			   ,@Is_Active
			   ,@User_Id
			   ,GETDATE())

		SET @Employee_Id=SCOPE_IDENTity()
END
ELSE
BEGIN
	UPDATE	Employee
	SET		Employee_Name=@Employee_Name
			,Employee_Code=@Employee_Code
			,Department_ID=@Department_ID
			,Payment_Mode_ID=@Payment_Mode_ID
			,Is_Active=@Is_Active
			,Modified_By=@User_Id
			,Modified_On=GETDATE()
	WHERE	Employee_Id=@Employee_Id
	
END
DELETE FROM Canteen_Menu_Mapping WHERE Employee_Id=@Employee_Id

DECLARE @Menu_ID INT

SELECT @Menu_ID=Menu_ID FROM Canteen_Menu WHERE MENU_CODE='Breakfast'

INSERT INTO [Canteen_Menu_Mapping]
           ([Employee_Id]
           ,[Menu_Id]
           ,[Is_Active]
           ,[Time_Restriction]
           ,[Created_By]
           ,[Created_On])
     VALUES
           (@Employee_Id
           ,@Menu_ID
           ,@BreakFast_Enabled
           ,@BreakFast_RestrictTime
           ,@User_Id
           ,GETDATE())


SELECT @Menu_ID=Menu_ID FROM Canteen_Menu WHERE MENU_CODE='Lunch'

INSERT INTO [Canteen_Menu_Mapping]
           ([Employee_Id]
           ,[Menu_Id]
           ,[Is_Active]
           ,[Time_Restriction]
           ,[Created_By]
           ,[Created_On])
     VALUES
           (@Employee_Id
           ,@Menu_ID
           ,@Lunch_Enabled
           ,@Lunch_RestrictTime
           ,@User_Id
           ,GETDATE())


SELECT @Menu_ID=Menu_ID FROM Canteen_Menu WHERE MENU_CODE='Chapathi'

INSERT INTO [Canteen_Menu_Mapping]
           ([Employee_Id]
           ,[Menu_Id]
           ,[Is_Active]
           ,[Time_Restriction]
           ,[Created_By]
           ,[Created_On])
     VALUES
           (@Employee_Id
           ,@Menu_ID
           ,@Chapathi_Enabled
           ,@Chapathi_RestrictTime
           ,@User_Id
           ,GETDATE())

SELECT @Menu_ID=Menu_ID FROM Canteen_Menu WHERE MENU_CODE='Dinner'

INSERT INTO [Canteen_Menu_Mapping]
           ([Employee_Id]
           ,[Menu_Id]
           ,[Is_Active]
           ,[Time_Restriction]
           ,[Created_By]
           ,[Created_On])
     VALUES
           (@Employee_Id
           ,@Menu_ID
           ,@Dinner_Enabled
           ,@Dinner_RestrictTime
           ,@User_Id
           ,GETDATE())

END


GO
