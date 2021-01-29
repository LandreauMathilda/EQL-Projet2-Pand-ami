USE [pandamidb]
GO
/****** Object:  StoredProcedure [dbo].[GetListeEquipement]    Script Date: 29/01/2021 11:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetListeEquipement] 
	-- Add the parameters for the stored procedure here
	@IdDemande int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT libelle_equipement FROM equipement e 
	INNER JOIN equipement_demande ed ON e.id_equipement = ed.id_equipement
	WHERE ed.id_demande = @IdDemande
END
GO
