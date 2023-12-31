USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[SP_Revision]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Revision]
	@Breakfast DECIMAL(18,2)
	,@Lunch DECIMAL(18,2)
	,@Chapathi DECIMAL(18,2)
	,@Dinner DECIMAL(18,2)
	,@DTFrom DATETIME
	,@DTTo DATETIME
	,@Breakfast_Count INT
	,@Lunch_Count INT
	,@Chapathi_Count INT
	,@Dinner_Count INT
	,@Breakfast_Amount DECIMAL(18,2)
	,@Lunch_Amount DECIMAL(18,2)
	,@Chapathi_Amount DECIMAL(18,2)
	,@Dinner_Amount DECIMAL(18,2)
	,@Month_Year VARCHAR(30)
	,@User_ID INT
AS
BEGIN

DECLARE @Revision_ID INT

INSERT INTO [Revision]
           ([Month_Year]
           ,[DTFrom]
           ,[DTTo]
           ,[Breakfast]
           ,[Lunch]
           ,[Chapathi]
           ,[Dinner]
           ,[Breakfast_Count]
           ,[Lunch_Count]
           ,[Chapathi_Count]
           ,[Dinner_Count]
           ,[Breakfast_Amount]
           ,[Lunch_Amount]
           ,[Chapathi_Amount]
           ,[Dinner_Amount]
           ,[Created_By]
           ,[Created_On])
     VALUES
           (@Month_Year
           ,@DTFrom
           ,@DTTo
           ,@Breakfast
           ,@Lunch
           ,@Chapathi
           ,@Dinner
           ,@Breakfast_Count
           ,@Lunch_Count
           ,@Chapathi_Count
           ,@Dinner_Count
           ,@Breakfast_Amount
           ,@Lunch_Amount
           ,@Chapathi_Amount
           ,@Dinner_Amount
           ,@User_ID
           ,GETDATE())

SET @Revision_ID=SCOPE_IDENTITY()

INSERT INTO [Revision_Details]
           ([Revision_Id]
           ,[Employee_Id]
           ,[BreakFast_Count]
           ,[BreakFast_Amount]
           ,[Lunch_Count]
           ,[Lunch_Amount]
           ,[Chapathi_Count]
           ,[Chapathi_Amount]
           ,[Dinner_Count]
           ,[Dinner_Amount]
		   ,[Source]
           ,[created_by]
           ,[Created_On])
SELECT	@Revision_ID
		,E.Employee_Id
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,0
		,ct.source
		,@User_ID
		,GETDATE()
FROM	Canteen_Transaction ct JOIN Employee e on e.Employee_ID=ct.Employee_Id
WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
GROUP BY E.Employee_Id,ct.source
		
UPDATE	R
SET		BreakFast_Count=T.Menu_Count
		,BreakFast_Amount=T.Menu_Amount
FROM	Revision_Details R JOIN
		(SELECT	E.Employee_ID
				,ct.source
				,count(1) AS Menu_Count
				,count(1)*@Breakfast AS Menu_Amount
		FROM	Canteen_Transaction ct JOIN Employee e 
					ON e.Employee_ID=ct.Employee_Id
				JOIN Canteen_Menu cm 
					ON cm.Menu_ID=ct.Menu_Id
		WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
				AND cm.Menu_Code='BreakFast'
		GROUP BY e.Employee_ID,ct.source) T
		ON	T.Employee_ID=R.Employee_Id
			AND T.source=R.Source
			AND Revision_Id=@Revision_Id

UPDATE	R
SET		Lunch_Count=T.Menu_Count
		,Lunch_Amount=T.Menu_Amount
FROM	Revision_Details R JOIN
		(SELECT	E.Employee_ID
				,ct.source
				,count(1) AS Menu_Count
				,count(1)*@Lunch AS Menu_Amount
		FROM	Canteen_Transaction ct JOIN Employee e 
					ON e.Employee_ID=ct.Employee_Id
				JOIN Canteen_Menu cm 
					ON cm.Menu_ID=ct.Menu_Id
		WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
				AND cm.Menu_Code='Lunch'
				
		GROUP BY e.Employee_ID,ct.source) T
		ON	T.Employee_ID=R.Employee_Id
			AND T.source=R.Source
			AND Revision_Id=@Revision_Id


UPDATE	R
SET		Chapathi_Count=T.Menu_Count
		,Chapathi_Amount=T.Menu_Amount
FROM	Revision_Details R JOIN
		(SELECT	E.Employee_ID
				,ct.source
				,count(1) AS Menu_Count
				,count(1)*@Chapathi AS Menu_Amount
		FROM	Canteen_Transaction ct JOIN Employee e 
					ON e.Employee_ID=ct.Employee_Id
				JOIN Canteen_Menu cm 
					ON cm.Menu_ID=ct.Menu_Id
		WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
				AND cm.Menu_Code IN ('Chapathi','DINNER-CHAPATHI')
		GROUP BY e.Employee_ID,ct.source) T
		ON	T.Employee_ID=R.Employee_Id
			AND T.source=R.Source
			AND Revision_Id=@Revision_Id

		
UPDATE	R
SET		Dinner_Count=T.Menu_Count
		,Dinner_Amount=T.Menu_Amount
FROM	Revision_Details R JOIN
		(SELECT	E.Employee_ID
				,ct.source
				,count(1) AS Menu_Count
				,count(1)*@Dinner AS Menu_Amount
		FROM	Canteen_Transaction ct JOIN Employee e 
					ON e.Employee_ID=ct.Employee_Id
				JOIN Canteen_Menu cm 
					ON cm.Menu_ID=ct.Menu_Id
		WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
				AND cm.Menu_Code='Dinner'
		GROUP BY e.Employee_ID,ct.source) T
		ON T.Employee_ID=R.Employee_Id
			AND T.source=R.Source
			AND Revision_Id=@Revision_Id

END
GO
