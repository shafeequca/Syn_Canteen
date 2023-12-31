SET IDENTITY_INSERT [Synthite_Canteen].[dbo].[Canteen_Transaction] ON
GO
INSERT INTO [Synthite_Canteen].[dbo].[Canteen_Transaction]
           (Transaction_Id
			,Attribute1
			,[Employee_Id]
           ,[Menu_Id]
           ,[Transaction_Time]
           ,[Created_By]
           ,[Created_On])
SELECT	TC.TRA_ID
		,TC.TRA_ID
		,E.Employee_Id
		,TC.MNU_CODE		
		,CONVERT(DATETIME,CONVERT(VARCHAR(10),TRA_DATE,23)+' '+CONVERT(VARCHAR(8),TRA_Time,108))
		,0
		,GETDATE() 
FROM	synCanteen_24_01_2019..TRA_CANTEEN TC JOIN [Synthite_Canteen].[dbo].Employee E
		ON E.Employee_Code=TC.Emp_ID
WHERE	NOT EXISTS (SELECT 1 FROM [Synthite_Canteen].[dbo].[Canteen_Transaction] CT WHERE CT.Transaction_Id=TC.TRA_ID)
		AND TC.TRA_ID NOT IN (SELECT TRA_ID
							FROm synCanteen_24_01_2019..TRA_CANTEEN 
							group by TRA_ID
							having count(1)>1)
SET IDENTITY_INSERT [Synthite_Canteen].[dbo].[Canteen_Transaction] OFF
GO


INSERT INTO [Synthite_Canteen].[dbo].[Canteen_Transaction]
           (Attribute1
			,[Employee_Id]
           ,[Menu_Id]
           ,[Transaction_Time]
           ,[Created_By]
           ,[Created_On])
SELECT	TC.TRA_ID
		,E.Employee_Id
		,TC.MNU_CODE		
		,CONVERT(DATETIME,CONVERT(VARCHAR(10),TRA_DATE,23)+' '+CONVERT(VARCHAR(8),TRA_Time,108))
		,0
		,GETDATE() 
FROM	synCanteen_24_01_2019..TRA_CANTEEN TC JOIN [Synthite_Canteen].[dbo].Employee E
		ON E.Employee_Code=TC.Emp_ID
WHERE	NOT EXISTS (SELECT 1 FROM [Synthite_Canteen].[dbo].[Canteen_Transaction] CT WHERE CT.Attribute1=TC.TRA_ID)
		AND TC.TRA_ID IN (SELECT TRA_ID
						FROm synCanteen_24_01_2019..TRA_CANTEEN 
						group by TRA_ID
						having count(1)>1)

--TRUNCATE TABLE [Synthite_Canteen].[dbo].[Canteen_Transaction]