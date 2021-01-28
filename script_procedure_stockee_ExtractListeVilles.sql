USE [pandamidb]
GO

/****** Object:  StoredProcedure [dbo].[ExtractListeVilles]    Script Date: 27/01/2021 11:37:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		BM
-- Create date: 23.01.2021
-- Description:	Permet d'obtenir la liste des villes
-- =============================================
CREATE PROCEDURE [dbo].[ExtractListeVilles] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id_ville, libelle_ville, code_postal
	FROM ville
END
GO

