USE [Synthite_Canteen]
GO
/****** Object:  StoredProcedure [dbo].[SP_Revision_Delete]    Script Date: 12-03-2022 17:45:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Revision_Delete]
	@Revision_Id INT
AS
BEGIN

DELETE FROM Revision_Details WHERE Revision_Id=@Revision_Id

DELETE FROM Revision WHERE Revision_Id=@Revision_Id

END

GO
