SET IDENTITY_INSERT [Synthite_Canteen].[dbo].[Canteen_Menu] ON

INSERT INTO [Synthite_Canteen].[dbo].[Canteen_Menu]
           (MENU_ID
			,[Menu_Code]
           ,[Menu_Caption]
           ,[Menu_Description]
           ,[Is_Active]
           ,[Time_From]
           ,[Time_To]
           ,[Created_By]
           ,[Created_On])
SELECT	MNU_CODE,MNU_DES,MNU_DES,MNU_DES,1,MNU_FRM,MNU_TO,0,GETDATE() 
FROM	synCanteen_24_01_2019..MAS_MNU M
WHERE	NOT EXISTS (SELECT 1 FROM  [Synthite_Canteen].[dbo].[Canteen_Menu] CM WHERE CM.MENU_ID=M.MNU_CODE)

SET IDENTITY_INSERT [Synthite_Canteen].[dbo].[Canteen_Menu] OFF

[Synthite_Canteen].[dbo].[Canteen_Menu]