INSERT INTO [Synthite_Canteen].[dbo].[Payment_Mode]
           ([Payment_Mode]
           ,[Description]
           ,[Created_By]
           ,[Created_On])
SELECT	PAY_CODE
		,PAY_DES
		,0
		,GETDATE()
FROM	synCanteen_24_01_2019..MAS_PAY P
WHERE	NOT EXISTS (SELECT 1 FROM [Synthite_Canteen].[dbo].[Payment_Mode] SP WHERE SP.Payment_Mode=P.PAY_CODE)