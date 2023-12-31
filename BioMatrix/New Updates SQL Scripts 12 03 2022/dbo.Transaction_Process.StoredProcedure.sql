USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[Transaction_Process]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Transaction_Process]
	@Breakfast DECIMAL(18,2)
	,@Lunch DECIMAL(18,2)
	,@Chapathi DECIMAL(18,2)
	,@Dinner DECIMAL(18,2)
	,@DTFrom DATETIME
	,@DTTo DATETIME
	,@Breakfast_Count INT OUTPUT
	,@Lunch_Count INT OUTPUT
	,@Chapathi_Count INT OUTPUT
	,@Dinner_Count INT OUTPUT
	,@Breakfast_Amount DECIMAL(18,2) OUTPUT
	,@Lunch_Amount DECIMAL(18,2) OUTPUT
	,@Chapathi_Amount DECIMAL(18,2) OUTPUT
	,@Dinner_Amount DECIMAL(18,2) OUTPUT
	,@Total_Amount DECIMAL(18,2) OUTPUT
AS
BEGIN

TRUNCATE TABLE Temp_Report

INSERT INTO [dbo].[Temp_Report]
           ([Employee_Id]
           ,[BreakFast_Count]
           ,[BreakFast_Amount]
           ,[Lunch_Count]
           ,[Lunch_Amount]
           ,[Chapathi_Count]
           ,[Chapathi_Amount]
           ,[Dinner_Count]
           ,[Dinner_Amount]
           ,[Created_On])
SELECT		E.Employee_Id
			,0
			,0
			,0
			,0
			,0
			,0
			,0
			,0
			,GETDATE()
FROM	Canteen_Transaction ct JOIN Employee e on e.Employee_ID=ct.Employee_Id
WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
GROUP BY E.Employee_Id
		
UPDATE	R
SET		BreakFast_Count=T.Menu_Count
		,BreakFast_Amount=T.Menu_Amount
FROM	Temp_Report R JOIN
		(SELECT	E.Employee_ID
				,count(1) AS Menu_Count
				,count(1)*@Breakfast AS Menu_Amount
		FROM	Canteen_Transaction ct JOIN Employee e 
					ON e.Employee_ID=ct.Employee_Id
				JOIN Canteen_Menu cm 
					ON cm.Menu_ID=ct.Menu_Id
		WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
				AND cm.Menu_Code='BreakFast'
		GROUP BY e.Employee_ID) T
		ON T.Employee_ID=R.Employee_Id

UPDATE	R
SET		Lunch_Count=T.Menu_Count
		,Lunch_Amount=T.Menu_Amount
FROM	Temp_Report R JOIN
		(SELECT	E.Employee_ID
				,count(1) AS Menu_Count
				,count(1)*@Lunch AS Menu_Amount
		FROM	Canteen_Transaction ct JOIN Employee e 
					ON e.Employee_ID=ct.Employee_Id
				JOIN Canteen_Menu cm 
					ON cm.Menu_ID=ct.Menu_Id
		WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
				AND cm.Menu_Code='Lunch'
		GROUP BY e.Employee_ID) T
		ON T.Employee_ID=R.Employee_Id


UPDATE	R
SET		Chapathi_Count=T.Menu_Count
		,Chapathi_Amount=T.Menu_Amount
FROM	Temp_Report R JOIN
		(SELECT	E.Employee_ID
				,count(1) AS Menu_Count
				,count(1)*@Chapathi AS Menu_Amount
		FROM	Canteen_Transaction ct JOIN Employee e 
					ON e.Employee_ID=ct.Employee_Id
				JOIN Canteen_Menu cm 
					ON cm.Menu_ID=ct.Menu_Id
		WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
				AND cm.Menu_Code in ('Chapathi','DINNER-CHAPATHI')
		GROUP BY e.Employee_ID) T
		ON T.Employee_ID=R.Employee_Id

		
UPDATE	R
SET		Dinner_Count=T.Menu_Count
		,Dinner_Amount=T.Menu_Amount
FROM	Temp_Report R JOIN
		(SELECT	E.Employee_ID
				,count(1) AS Menu_Count
				,count(1)*@Dinner AS Menu_Amount
		FROM	Canteen_Transaction ct JOIN Employee e 
					ON e.Employee_ID=ct.Employee_Id
				JOIN Canteen_Menu cm 
					ON cm.Menu_ID=ct.Menu_Id
		WHERE	Transaction_Time>=@DTFrom AND Transaction_Time<=@DTTo
				AND cm.Menu_Code='Dinner'
		GROUP BY e.Employee_ID) T
		ON T.Employee_ID=R.Employee_Id

SELECT	@BreakFast_Count=SUM(BreakFast_Count)
		,@BreakFast_Amount=SUM(BreakFast_Amount)
		,@Lunch_Count=SUM(Lunch_Count)
		,@Lunch_Amount=SUM(Lunch_Amount)
		,@Chapathi_Count=SUM(Chapathi_Count)
		,@Chapathi_Amount=SUM(Chapathi_Amount)
		,@Dinner_Count=SUM(Dinner_Count)
		,@Dinner_Amount=SUM(Dinner_Amount)
		,@Total_Amount=SUM(BreakFast_Amount)+SUM(Lunch_Amount)+SUM(Chapathi_Amount)+SUM(Dinner_Amount)
FROM	Temp_Report

select * from Temp_Report
END
GO
