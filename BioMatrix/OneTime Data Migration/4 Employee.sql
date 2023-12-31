INSERT INTO [Synthite_Canteen].[dbo].[Employee]
           ([Employee_Code]
           ,[Employee_Name]
           ,[Department_ID]
           ,[Payment_Mode_ID]
           ,[Is_Active]
           ,[Created_By]
           ,[Created_On])
SELECT		EMP_ID,EMP_NAME,D.Department_ID,PM.ID,1,0,GETDATE()
from		synCanteen_24_01_2019..MAS_EMP E JOIN [Synthite_Canteen].[dbo].Department D
			ON D.Department_Code=E.DEPT_CODE
			JOIN [Synthite_Canteen].[dbo].Payment_Mode PM
			ON PM.Payment_Mode=E.PAY_CODE
WHERE		NOT EXISTS (SELECT 1 FROM [Synthite_Canteen].[dbo].[Employee] SE WHERE SE.Employee_Code=E.EMP_ID)