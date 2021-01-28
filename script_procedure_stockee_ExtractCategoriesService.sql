USE [pandamidb]
GO

/****** Object:  StoredProcedure [dbo].[ExtractCategoriesService]    Script Date: 27/01/2021 11:36:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		BM
-- Create date: 23/01/2021
-- Description:	Permet d'obtenir la liste des catégories de service
-- =============================================
CREATE PROCEDURE [dbo].[ExtractCategoriesService] 
	-- Add the parameters for the stored procedure here
	--@id_type_service int = 0, 
	--@libelle_type_service nvarchar = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id_type_service, libelle_type_service, id_categorie
	FROM type_service ;
END
GO

