USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[Get_Employee]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Get_Employee]
	@Employee_Code VARCHAR(20)
	,@Employee_Id INT OUTPUT
	,@Employee_Name VARCHAR(100) OUTPUT
	,@Department_Name VARCHAR(100) OUTPUT
AS
BEGIN
	SELECT	@Employee_Id=Employee_Id
			,@Employee_Name=Employee_Name
			,@Department_Name=D.Department_Name
	FROM	Employee E JOIN Department D
			ON E.Department_Id=D.Department_Id
	WHERE	Employee_Code=@Employee_Code
			AND Is_Active=1
END

GO
