INSERT INTO [Synthite_Canteen].[dbo].[Department]
           ([Department_Code]
           ,[Department_Name]
           ,[Created_By]
           ,[Created_ON])
select		DEPT_CODE
			,DEPT_DES
			,0
			,GETDATE()
FROM		synCanteen_24_01_2019..MAS_DEPT D
WHERE		NOT EXISTS (SELECT 1 FROM [Synthite_Canteen].[dbo].[Department] SD WHERE SD.Department_Code=D.DEPT_CODE)
