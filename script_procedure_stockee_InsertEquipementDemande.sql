USE [pandamidb]
GO

/****** Object:  StoredProcedure [dbo].[InsertEquipementDemande]    Script Date: 27/01/2021 11:38:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================
-- Author:		BM
-- Create date: 26/01/2021
-- Description:	Permet d'insérer une entrée dans la table equipement_demande
-- ==========================================================================
CREATE PROCEDURE [dbo].[InsertEquipementDemande] 
	@idEquipement int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO equipement_demande VALUES (@idEquipement, (SELECT MAX(id_demande) FROM demande_service)); 
END
GO

