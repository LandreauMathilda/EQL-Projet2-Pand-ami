USE [pandamidb]
GO

/****** Object:  StoredProcedure [dbo].[InsertDemandeService]    Script Date: 27/01/2021 16:21:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =================================================================================================
-- Author:		BM
-- Create date: 25/01/2021
-- Description:	Permet d'insérer une nouvelle demande de service dans la table demande_service
-- =================================================================================================
CREATE PROCEDURE [dbo].[InsertDemandeService] 
	@idEmetteur int, 
	@dateEnregistrement DateTime,
	@dateRealisation DateTime, 
	@adresseRealisation nvarchar(70)=NULL,
	@idVille int = NULL, 
	@idTypeService int,
	@dateAnnulation DateTime = NULL, 
	@dateCloture DateTime = NULL,
	@dateNonFinalisation DateTime = NULL,
	@idMotifAnnulation int = NULL
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO demande_service VALUES (@idEmetteur, @dateEnregistrement, @dateRealisation, @adresseRealisation, @idVille, @idTypeService, @dateAnnulation, 
	@dateCloture, @dateNonFinalisation, @idMotifAnnulation);
END
GO

