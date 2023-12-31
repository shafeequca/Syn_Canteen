USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[Get_Canteen_Report]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Get_Canteen_Report]
	@Revision_ID INT
	,@Report_Type VARCHAR(20)
	,@Department_ID INT=NULL
	,@Payment_Mode_ID INT=NULL
	,@Employee_ID INT=NULL
	,@Source VARCHAR(100)=NULL
	,@Breakfast_Rate DECIMAL(18,2) OUTPUT
	,@Lunch_Rate DECIMAL(18,2) OUTPUT
	,@Chapathi_Rate DECIMAL(18,2) OUTPUT
	,@Dinner_Rate DECIMAL(18,2) OUTPUT
	,@Breakfast_Count INT OUTPUT
	,@Lunch_Count INT OUTPUT
	,@Chapathi_Count INT OUTPUT
	,@Dinner_Count INT OUTPUT
	,@Breakfast_Amount DECIMAL(18,2) OUTPUT
	,@Lunch_Amount DECIMAL(18,2) OUTPUT
	,@Chapathi_Amount DECIMAL(18,2) OUTPUT
	,@Dinner_Amount DECIMAL(18,2) OUTPUT

AS
BEGIN

	SET NOCOUNT ON;

		SELECT	@Breakfast_Count=SUM(RD.BreakFast_Count)
				,@Breakfast_Amount=SUM(RD.BreakFast_Amount)
				,@Lunch_Count=SUM(RD.Lunch_Count)
				,@Lunch_Amount=SUM(RD.Lunch_Amount)
				,@Chapathi_Count=SUM(RD.Chapathi_Count)
				,@Chapathi_Amount=SUM(RD.Chapathi_Amount)
				,@Dinner_Count=SUM(RD.Dinner_Count)
				,@Dinner_Amount=SUM(RD.Dinner_Amount)
		FROM	Revision R JOIN Revision_Details RD
				ON R.Revision_Id=RD.Revision_ID
				JOIN Employee E
				ON E.Employee_ID=RD.Employee_ID
				JOIN Department D
				ON D.Department_ID=E.Department_ID
				JOIN Payment_Mode PM
				ON PM.ID=E.Payment_Mode_ID
		WHERE	R.Revision_ID=@Revision_ID
				AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
				AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
				AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID)
				AND (@Source IS NULL OR RD.source=@Source)


		SELECT	@Breakfast_Rate=Breakfast
				,@Lunch_Rate=Lunch
				,@Chapathi_Rate =Chapathi
				,@Dinner_Rate=Dinner
		FROM	Revision 
		WHERE	Revision_ID=@Revision_ID

	IF @Report_Type='ALL'
	BEGIN
		SELECT	MAX(R.DTFrom) DTFrom
				,MAX(R.DTTo) DTTo
				,MAX(R.Breakfast) Breakfast
				,MAX(R.Lunch) Lunch
				,MAX(R.Chapathi) Chapathi
				,MAX(R.Dinner) Dinner
				,SUM(RD.BreakFast_Count) BreakFast_Count
				,SUM(RD.Lunch_Count) Lunch_Count
				,SUM(RD.Chapathi_Count) Chapathi_Count
				,SUM(RD.Dinner_Count) Dinner_Count
				,MAX(E.Employee_Code) Employee_Code
				,MAX(E.Employee_Name) Employee_Name
				,MAX(D.Department_Code) Department_Code
				,MAX(PM.Payment_Mode)
				,SUM(ISNULL(RD.BreakFast_Amount,0)) BreakFast_Amount
				,SUM(ISNULL(RD.Lunch_Amount,0)) Lunch_Amount
				,SUM(ISNULL(RD.Chapathi_Amount,0)) Chapathi_Amount
				,SUM(ISNULL(RD.Dinner_Amount,0)) Dinner_Amount
				,SUM(ISNULL(RD.BreakFast_Amount,0)+ISNULL(RD.Lunch_Amount,0)+ISNULL(RD.Chapathi_Amount,0)+ISNULL(RD.Dinner_Amount,0)) TOTAL
				--,RD.Source
		FROM	Revision R JOIN Revision_Details RD
				ON R.Revision_Id=RD.Revision_ID
				JOIN Employee E
				ON E.Employee_ID=RD.Employee_ID
				JOIN Department D
				ON D.Department_ID=E.Department_ID
				JOIN Payment_Mode PM
				ON PM.ID=E.Payment_Mode_ID
		WHERE	R.Revision_ID=@Revision_ID
				AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
				AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
				AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID)
				AND (@Source IS NULL OR RD.source=@Source)
		GROUP BY E.Employee_ID


		
	END
	ELSE IF @Report_Type='EmployeeLevel'
	BEGIN
		SELECT	R.DTFrom
				,R.DTTo
				,R.Breakfast
				,R.Lunch
				,R.Chapathi
				,R.Dinner
				,@Breakfast_Count BreakFast_Count--,RD.BreakFast_Count
				,@Lunch_Count Lunch_Count--,RD.Lunch_Count
				,@Chapathi_Count Chapathi_Count--,RD.Chapathi_Count
				,@Dinner_Count Dinner_Count--,RD.Dinner_Count
				,E.Employee_Code
				,CT.Transaction_Id
				,E.Employee_Name
				,D.Department_Code
				,PM.Payment_Mode
				,CT.Transaction_Time
				,CM.Menu_Caption
		FROM	Revision R JOIN Revision_Details RD
				ON R.Revision_Id=RD.Revision_ID
				JOIN Employee E
				ON E.Employee_ID=RD.Employee_ID
				JOIN Department D
				ON D.Department_ID=E.Department_ID
				JOIN Payment_Mode PM
				ON PM.ID=E.Payment_Mode_ID
				JOIN Canteen_Transaction CT
				ON CT.Employee_ID=E.Employee_ID
					AND CT.source=RD.source
					AND CT.Transaction_Time>=R.DTFrom
					AND CT.Transaction_Time<=R.DTTo
				JOIN Canteen_Menu CM
				ON CM.Menu_ID=CT.Menu_ID
		WHERE	R.Revision_ID=@Revision_ID
				AND (@Employee_ID IS NULL OR E.Employee_ID=@Employee_ID)
				AND (@Department_ID IS NULL OR D.Department_ID=@Department_ID)
				AND (@Payment_Mode_ID IS NULL OR PM.ID=@Payment_Mode_ID)
				AND (@Source IS NULL OR RD.source=@Source)
		ORDER BY CT.Transaction_Time

		
	END
END


GO
