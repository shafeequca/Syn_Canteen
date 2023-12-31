--BreakFast
INSERT INTO [Synthite_Canteen].[dbo].[Canteen_Menu_Mapping]
           ([Employee_Id]
           ,[Menu_Id]
           ,[Is_Active]
           ,[Created_By]
           ,[Created_On])
SELECT	Employee_Id,1,1,0,GETDATE()
FROM	Synthite_Canteen.[dbo].Employee E
WHERE	NOT EXISTS(SELECT 1 FROM [Synthite_Canteen].[dbo].[Canteen_Menu_Mapping] CMM WHERE CMM.Employee_Id=E.Employee_ID AND CMM.Menu_ID=1)

--Lunch
INSERT INTO [Synthite_Canteen].[dbo].[Canteen_Menu_Mapping]
           ([Employee_Id]
           ,[Menu_Id]
           ,[Is_Active]
           ,[Created_By]
           ,[Created_On])
SELECT	Employee_Id,2,1,0,GETDATE()
FROM	Synthite_Canteen.[dbo].Employee E
WHERE	NOT EXISTS(SELECT 1 FROM [Synthite_Canteen].[dbo].[Canteen_Menu_Mapping] CMM WHERE CMM.Employee_Id=E.Employee_ID AND CMM.Menu_ID=2)

--Chapathi
INSERT INTO [Synthite_Canteen].[dbo].[Canteen_Menu_Mapping]
           ([Employee_Id]
           ,[Menu_Id]
           ,[Is_Active]
           ,[Created_By]
           ,[Created_On])
SELECT	Employee_Id,3,0,0,GETDATE()
FROM	Synthite_Canteen.[dbo].Employee E
WHERE	NOT EXISTS(SELECT 1 FROM [Synthite_Canteen].[dbo].[Canteen_Menu_Mapping] CMM WHERE CMM.Employee_Id=E.Employee_ID AND CMM.Menu_ID=3)

--Dinner
INSERT INTO [Synthite_Canteen].[dbo].[Canteen_Menu_Mapping]
           ([Employee_Id]
           ,[Menu_Id]
           ,[Is_Active]
           ,[Created_By]
           ,[Created_On])
SELECT	Employee_Id,4,1,0,GETDATE()
FROM	Synthite_Canteen.[dbo].Employee E
WHERE	NOT EXISTS(SELECT 1 FROM [Synthite_Canteen].[dbo].[Canteen_Menu_Mapping] CMM WHERE CMM.Employee_Id=E.Employee_ID AND CMM.Menu_ID=4)

UPDATE	CMM
SET		Is_Active=1
FROM	[Synthite_Canteen].[dbo].[Canteen_Menu_Mapping] CMM JOIN Synthite_Canteen.[dbo].Employee SE 
		ON CMM.Employee_ID=SE.Employee_Id
		JOIN synCanteen_24_01_2019..MAS_EMP E
		ON SE.Employee_CODE=E.EMP_ID
WHERE	chk_Mnu=1 AND CMM.Menu_ID=3