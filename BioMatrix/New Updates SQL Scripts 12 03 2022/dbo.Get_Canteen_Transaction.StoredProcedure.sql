USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[Get_Canteen_Transaction]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Get_Canteen_Transaction]
	@DTFrom DATETIME
	,@DTTo DATETIME
	,@Department_ID INT=NULL
	,@Payment_Mode_ID INT=NULL
	,@Employee_ID INT=NULL
	,@Source VARCHAR(100)=NULL
	,@Breakfast_Count INT OUTPUT
	,@Lunch_Count INT OUTPUT
	,@Chapathi_Count INT OUTPUT
	,@Dinner_Count INT OUTPUT
	,@Dinner_Chapathi_Count INT OUTPUT

AS
BEGIN
	
	SET NOCOUNT ON;

	SET @DTTo=DATEADD(D,1,@DTTo)

	SELECT	@Breakfast_Count=COUNT(1)
	FROM	Canteen_Transaction CT JOIN Employee E
			ON E.Employee_ID=CT.Employee_ID
			JOIN Department D
			ON D.Department_ID=E.Department_ID
			JOIN Payment_Mode PM
			ON PM.ID=E.Payment_Mode_ID
			JOIN Canteen_Menu CM
			ON CM.Menu_ID=CT.Menu_ID
	WHERE	CT.Transaction_Time BETWEEN @DTFrom AND @DTTo
			AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
			AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
			AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID) 
			AND (@Source IS NULL OR CT.source=@Source)
			AND CM.Menu_Code='BreakFast'

	SELECT	@Lunch_Count=SUM(1)
	FROM	Canteen_Transaction CT JOIN Employee E
			ON E.Employee_ID=CT.Employee_ID
			JOIN Department D
			ON D.Department_ID=E.Department_ID
			JOIN Payment_Mode PM
			ON PM.ID=E.Payment_Mode_ID
			JOIN Canteen_Menu CM
			ON CM.Menu_ID=CT.Menu_ID
	WHERE	CT.Transaction_Time BETWEEN @DTFrom AND @DTTo
			AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
			AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
			AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID) 
			AND (@Source IS NULL OR CT.source=@Source)
			AND CM.Menu_Code='Lunch'
	
	SELECT	@Chapathi_Count=SUM(1)
	FROM	Canteen_Transaction CT JOIN Employee E
			ON E.Employee_ID=CT.Employee_ID
			JOIN Department D
			ON D.Department_ID=E.Department_ID
			JOIN Payment_Mode PM
			ON PM.ID=E.Payment_Mode_ID
			JOIN Canteen_Menu CM
			ON CM.Menu_ID=CT.Menu_ID
	WHERE	CT.Transaction_Time BETWEEN @DTFrom AND @DTTo
			AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
			AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
			AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID) 
			AND (@Source IS NULL OR CT.source=@Source)
			AND CM.Menu_Code='Chapathi'

	SELECT	@Dinner_Chapathi_Count=SUM(1)
	FROM	Canteen_Transaction CT JOIN Employee E
			ON E.Employee_ID=CT.Employee_ID
			JOIN Department D
			ON D.Department_ID=E.Department_ID
			JOIN Payment_Mode PM
			ON PM.ID=E.Payment_Mode_ID
			JOIN Canteen_Menu CM
			ON CM.Menu_ID=CT.Menu_ID
	WHERE	CT.Transaction_Time BETWEEN @DTFrom AND @DTTo
			AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
			AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
			AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID) 
			AND (@Source IS NULL OR CT.source=@Source)
			AND CM.Menu_Code='DINNER-CHAPATHI'
	
	SELECT	@Dinner_Count=SUM(1)
	FROM	Canteen_Transaction CT JOIN Employee E
			ON E.Employee_ID=CT.Employee_ID
			JOIN Department D
			ON D.Department_ID=E.Department_ID
			JOIN Payment_Mode PM
			ON PM.ID=E.Payment_Mode_ID
			JOIN Canteen_Menu CM
			ON CM.Menu_ID=CT.Menu_ID
	WHERE	CT.Transaction_Time BETWEEN @DTFrom AND @DTTo
			AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
			AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
			AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID) 
			AND (@Source IS NULL OR CT.source=@Source)
			AND CM.Menu_Code='Dinner'
	
	SELECT	E.Employee_Code
			,CT.Transaction_Id
			,E.Employee_Name
			,D.Department_Code
			,PM.Payment_Mode
			,CT.Transaction_Time
			,CM.Menu_Caption
			,CT.source
	FROM	Canteen_Transaction CT JOIN Employee E
			ON E.Employee_ID=CT.Employee_ID
			JOIN Department D
			ON D.Department_ID=E.Department_ID
			JOIN Payment_Mode PM
			ON PM.ID=E.Payment_Mode_ID
			JOIN Canteen_Menu CM
			ON CM.Menu_ID=CT.Menu_ID
	WHERE	CT.Transaction_Time BETWEEN @DTFrom AND @DTTo
			AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
			AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
			AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID)
			AND (@Source IS NULL OR CT.source=@Source)
	ORDER BY CT.Transaction_Time

	SET @Breakfast_Count =ISNULL(@Breakfast_Count,0)
	SET @Lunch_Count =ISNULL(@Lunch_Count,0)
	SET @Chapathi_Count =ISNULL(@Chapathi_Count,0)
	SET @Dinner_Count=ISNULL(@Dinner_Count,0)
	SET @Dinner_Chapathi_Count=ISNULL(@Dinner_Chapathi_Count,0)
	
END



GO
