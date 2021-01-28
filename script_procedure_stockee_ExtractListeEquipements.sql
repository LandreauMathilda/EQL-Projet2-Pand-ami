USE [pandamidb]
GO

/****** Object:  StoredProcedure [dbo].[ExtractListeEquipements]    Script Date: 27/01/2021 11:37:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		BM
-- Create date: 26/01/2021
-- Description:	Permet d'extraire la liste des équipements
-- =============================================
CREATE PROCEDURE [dbo].[ExtractListeEquipements] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id_equipement, libelle_equipement
	FROM equipement ;
END
GO

