USE [pandamidb]
GO
/****** Object:  StoredProcedure [dbo].[UpdateDateAcceptation_TableReponse]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[UpdateDateAcceptation_TableReponse]
GO
/****** Object:  StoredProcedure [dbo].[LireLibelleTypeServiceEtIdCategorie]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[LireLibelleTypeServiceEtIdCategorie]
GO
/****** Object:  StoredProcedure [dbo].[LireGenre]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[LireGenre]
GO
/****** Object:  StoredProcedure [dbo].[LireDonneesDemandeService]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[LireDonneesDemandeService]
GO
/****** Object:  StoredProcedure [dbo].[InsertEquipementDemande]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[InsertEquipementDemande]
GO
/****** Object:  StoredProcedure [dbo].[InsertDemandeService]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[InsertDemandeService]
GO
/****** Object:  StoredProcedure [dbo].[GetListeEquipement]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetListeEquipement]
GO
/****** Object:  StoredProcedure [dbo].[GetLibelleVilleCP]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetLibelleVilleCP]
GO
/****** Object:  StoredProcedure [dbo].[GetInfosDemandesEnCoursBeneficiaire]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetInfosDemandesEnCoursBeneficiaire]
GO
/****** Object:  StoredProcedure [dbo].[GetIdDemandeEnCours]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetIdDemandeEnCours]
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesNonPourvues]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetDemandesNonPourvues]
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesEnCoursBenevole]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetDemandesEnCoursBenevole]
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesEnAttente]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetDemandesEnAttente]
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesAValiderParBeneficiaire]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetDemandesAValiderParBeneficiaire]
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesACloturerBenevole]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetDemandesACloturerBenevole]
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesACloturer]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[GetDemandesACloturer]
GO
/****** Object:  StoredProcedure [dbo].[ExtractListeVilles]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[ExtractListeVilles]
GO
/****** Object:  StoredProcedure [dbo].[ExtractListeEquipements]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[ExtractListeEquipements]
GO
/****** Object:  StoredProcedure [dbo].[ExtractLibelleGenre]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[ExtractLibelleGenre]
GO
/****** Object:  StoredProcedure [dbo].[ExtractCategoriesService]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[ExtractCategoriesService]
GO
/****** Object:  StoredProcedure [dbo].[cloturerUneDemandeNonFinalisee]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[cloturerUneDemandeNonFinalisee]
GO
/****** Object:  StoredProcedure [dbo].[CloturerUneDemandeFinalisee]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[CloturerUneDemandeFinalisee]
GO
/****** Object:  StoredProcedure [dbo].[AfficherDemandesService]    Script Date: 05/02/2021 10:32:03 ******/
DROP PROCEDURE [dbo].[AfficherDemandesService]
GO
/****** Object:  StoredProcedure [dbo].[AfficherDemandesService]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================================
-- Author:		BM
-- Create date: 01.02.2021
-- Description:	Permet d'afficher toutes les demandes de service en cours
-- =======================================================================
CREATE PROCEDURE [dbo].[AfficherDemandesService] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT	ut.nom, 
			ut.prenom, 
			ds.id_demande,
			ds.id_emetteur,
			ds.date_enregistrement, 
			ds.date_realisation, 
			case 
				when ds.adresse_realisation is null then ut.adresse 
				else ds.adresse_realisation 
			end as adresse_realisation,
			ut.id_ville, 
			case 
				when vi.libelle_ville is null then v.libelle_ville 
				else vi.libelle_ville 
			end as libelle_ville,
			ts.libelle_type_service,
			ds.date_annulation,
			ds.date_cloture, 
			ds.date_non_finalisation, 
			ds.id_motif_annulation
	FROM	demande_service ds	INNER JOIN utilisateur ut	ON ds.id_emetteur=ut.id_utilisateur
								INNER JOIN ville v			ON ut.id_ville = v.id_ville
								LEFT OUTER JOIN ville vi	ON ds.id_ville=vi.id_ville
								INNER JOIN type_service ts	ON ds.id_type_service=ts.id_type_service
								LEFT OUTER JOIN reponse	r	ON (	ds.id_demande = r.id_demande and r.date_acceptation is null)
	WHERE	ds.date_annulation is null
	AND		ds.date_cloture is null
	AND		ds.date_non_finalisation is null
END
GO
/****** Object:  StoredProcedure [dbo].[CloturerUneDemandeFinalisee]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CloturerUneDemandeFinalisee]  
    (  
       @idUtlisateur int=1,
	   @idDemande int  
        
    )  
    as  
    begin  
       UPDATE demande_service 
      SET date_cloture = SYSDATETIME()
      WHERE id_demande=@idDemande   
    End
GO
/****** Object:  StoredProcedure [dbo].[cloturerUneDemandeNonFinalisee]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[cloturerUneDemandeNonFinalisee]  
    (  
       @idUtlisateur int=1,
	   @idDemande int  
        
    )  
    as  
    begin  
       UPDATE demande_service 
      SET date_non_finalisation = SYSDATETIME()
      WHERE id_demande=@idDemande   
    End
GO
/****** Object:  StoredProcedure [dbo].[ExtractCategoriesService]    Script Date: 05/02/2021 10:32:03 ******/
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
/****** Object:  StoredProcedure [dbo].[ExtractLibelleGenre]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ExtractLibelleGenre] 
	-- Add the parameters for the stored procedure here
	--@id_type_service int = 0, 
	--@libelle_type_service nvarchar = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id_genre, libelle_genre
	FROM genre;
END
GO
/****** Object:  StoredProcedure [dbo].[ExtractListeEquipements]    Script Date: 05/02/2021 10:32:03 ******/
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
/****** Object:  StoredProcedure [dbo].[ExtractListeVilles]    Script Date: 05/02/2021 10:32:03 ******/
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
/****** Object:  StoredProcedure [dbo].[GetDemandesACloturer]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetDemandesACloturer] 
	-- Add the parameters for the stored procedure here
	@IdUtilisateur int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ds.date_realisation, 
		   ds.id_demande,
		   CASE WHEN ds.adresse_realisation IS NULL THEN ut.adresse ELSE  ds.adresse_realisation END AS adresse_realisation,
	       CASE WHEN v.libelle_ville IS NULL THEN vi.libelle_ville ELSE v.libelle_ville END AS libelle_ville, 
		   CASE WHEN v.code_postal IS NULL THEN vi.code_postal ELSE v.code_postal END AS code_postal,
	       ts.libelle_type_service, 
		   u.nom,
		   u.prenom
	FROM demande_service ds INNER JOIN type_service ts       ON  ds.id_type_service = ts.id_type_service
							LEFT JOIN ville v		         ON v.id_ville = ds.id_ville
							INNER JOIN reponse r             ON r.id_demande = ds.id_demande
							INNER JOIN utilisateur u         ON r.id_utilisateur = u.id_utilisateur
							INNER JOIN utilisateur ut        ON ds.id_emetteur = ut.id_utilisateur
							INNER JOIN ville vi              ON vi.id_ville = ut.id_ville
	WHERE ds.id_emetteur = @IdUtilisateur 
	AND ds.date_annulation IS NULL
	AND ds.date_cloture IS NULL
	AND ds.date_non_finalisation IS NULL 
	AND ds.date_realisation < SYSDATETIME()
	AND r.date_refus IS NULL
	AND r.date_annulation_participation IS NULL
	AND r.date_acceptation IS NOT NULL
	AND r.id_utilisateur != @IdUtilisateur
END
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesACloturerBenevole]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetDemandesACloturerBenevole] 
	-- Add the parameters for the stored procedure here
	@IdUtilisateur int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ds.date_realisation, 
		   ds.id_demande,
		   CASE WHEN ds.adresse_realisation IS NULL THEN ut.adresse ELSE  ds.adresse_realisation END AS adresse_realisation,
	       CASE WHEN v.libelle_ville IS NULL THEN vi.libelle_ville ELSE v.libelle_ville END AS libelle_ville, 
		   CASE WHEN v.code_postal IS NULL THEN vi.code_postal ELSE v.code_postal END AS code_postal,
	       ts.libelle_type_service, 
		   u.nom,
		   u.prenom
	FROM demande_service ds INNER JOIN type_service ts       ON  ds.id_type_service = ts.id_type_service
							LEFT JOIN ville v		         ON v.id_ville = ds.id_ville
							INNER JOIN reponse r             ON r.id_demande = ds.id_demande
							INNER JOIN utilisateur u         ON r.id_utilisateur = u.id_utilisateur
							INNER JOIN utilisateur ut        ON ds.id_emetteur = ut.id_utilisateur
							INNER JOIN ville vi              ON vi.id_ville = ut.id_ville
	WHERE r.id_utilisateur = @IdUtilisateur 
	AND ds.date_annulation IS NULL
	AND ds.date_cloture IS NULL
	AND ds.date_non_finalisation IS NULL 
	AND ds.date_realisation < SYSDATETIME()
	AND r.date_refus IS NULL
	AND r.date_annulation_participation IS NULL
	AND r.date_acceptation IS NOT NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesAValiderParBeneficiaire]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetDemandesAValiderParBeneficiaire] 
	-- Add the parameters for the stored procedure here
	@IdUtilisateur int = 0, 
	@p2 int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ds.date_realisation, 
		   ds.id_demande,
		   CASE WHEN ds.adresse_realisation IS NULL THEN ut.adresse ELSE  ds.adresse_realisation END AS adresse_realisation,
	       CASE WHEN v.libelle_ville IS NULL THEN vi.libelle_ville ELSE v.libelle_ville END AS libelle_ville, 
		   CASE WHEN v.code_postal IS NULL THEN vi.code_postal ELSE v.code_postal END AS code_postal,
	       ts.libelle_type_service, 
		   u.nom,
		   u.prenom
	FROM demande_service ds INNER JOIN type_service ts       ON  ds.id_type_service = ts.id_type_service
							LEFT JOIN ville v		         ON v.id_ville = ds.id_ville
							INNER JOIN reponse r             ON r.id_demande = ds.id_demande
							INNER JOIN utilisateur u         ON r.id_utilisateur = u.id_utilisateur
							INNER JOIN utilisateur ut        ON ds.id_emetteur = ut.id_utilisateur
							INNER JOIN ville vi              ON vi.id_ville = ut.id_ville
	WHERE r.id_utilisateur = @IdUtilisateur 
	AND ds.date_annulation IS NULL
	AND ds.date_cloture IS NULL
	AND ds.date_non_finalisation IS NULL 
	AND ds.date_realisation > SYSDATETIME()
	AND r.date_refus IS NULL
	AND r.date_annulation_participation IS NULL
	AND r.date_acceptation IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesEnAttente]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetDemandesEnAttente] 
	-- Add the parameters for the stored procedure here
	@IdUtilisateur int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
ds.id_emetteur,
ds.date_realisation, 
		   ds.id_demande,
		   CASE WHEN ds.adresse_realisation IS NULL THEN ut.adresse ELSE  ds.adresse_realisation END AS adresse_realisation,
	       CASE WHEN v.libelle_ville IS NULL THEN vi.libelle_ville ELSE v.libelle_ville END AS libelle_ville, 
		   CASE WHEN v.code_postal IS NULL THEN vi.code_postal ELSE v.code_postal END AS code_postal,
	       ts.libelle_type_service, 
		   u.nom,
		   u.prenom,
		   u.id_utilisateur
	FROM demande_service ds INNER JOIN type_service ts       ON  ds.id_type_service = ts.id_type_service
							left JOIN ville v		         ON v.id_ville = ds.id_ville
							INNER JOIN reponse r             ON r.id_demande = ds.id_demande
							INNER JOIN utilisateur u         ON r.id_utilisateur = u.id_utilisateur
							inner JOIN utilisateur ut        ON ds.id_emetteur = ut.id_utilisateur
							INNER JOIN ville vi              ON vi.id_ville = ut.id_ville
	WHERE ds.id_emetteur = @IdUtilisateur 
	AND ds.date_annulation IS NULL
	AND ds.date_cloture IS NULL
	AND ds.date_non_finalisation IS NULL 
	AND ds.date_realisation > SYSDATETIME()
	AND r.date_refus IS NULL
	AND r.date_annulation_participation IS NULL
	AND r.date_acceptation IS NULL
	AND r.id_utilisateur != @IdUtilisateur
END
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesEnCoursBenevole]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetDemandesEnCoursBenevole] 
	-- Add the parameters for the stored procedure here
	@IdUtilisateur int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT ds.date_realisation, 
		   ds.id_demande,
		   CASE WHEN ds.adresse_realisation IS NULL THEN ut.adresse ELSE  ds.adresse_realisation END AS adresse_realisation,
	       CASE WHEN v.libelle_ville IS NULL THEN vi.libelle_ville ELSE v.libelle_ville END AS libelle_ville, 
		   CASE WHEN v.code_postal IS NULL THEN vi.code_postal ELSE v.code_postal END AS code_postal,
	       ts.libelle_type_service, 
		   u.nom,
		   u.prenom
	FROM demande_service ds INNER JOIN type_service ts       ON  ds.id_type_service = ts.id_type_service
							INNER JOIN ville v		         ON v.id_ville = ds.id_ville
							INNER JOIN reponse r             ON r.id_demande = ds.id_demande
							INNER JOIN utilisateur u         ON r.id_utilisateur = u.id_utilisateur
							INNER JOIN utilisateur ut        ON ds.id_emetteur = ut.id_utilisateur
							INNER JOIN ville vi              ON vi.id_ville = ut.id_ville
	WHERE r.id_utilisateur = @IdUtilisateur 
	AND ds.date_annulation IS NULL
	AND ds.date_cloture IS NULL
	AND ds.date_non_finalisation IS NULL 
	AND ds.date_realisation > SYSDATETIME()
	AND r.date_refus IS NULL
	AND r.date_annulation_participation IS NULL
	AND r.date_acceptation IS NOT NULL
END
GO
/****** Object:  StoredProcedure [dbo].[GetDemandesNonPourvues]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetDemandesNonPourvues] 
	-- Add the parameters for the stored procedure here
	@IdUtilisateur int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ds.date_realisation, 
		   ds.id_demande,
		   CASE WHEN ds.adresse_realisation IS NULL THEN ut.adresse ELSE  ds.adresse_realisation END AS adresse_realisation,
	       CASE WHEN v.libelle_ville IS NULL THEN vi.libelle_ville ELSE v.libelle_ville END AS libelle_ville, 
		   CASE WHEN v.code_postal IS NULL THEN vi.code_postal ELSE v.code_postal END AS code_postal,
	       ts.libelle_type_service
	FROM demande_service ds INNER JOIN type_service ts       ON  ds.id_type_service = ts.id_type_service
							LEFT JOIN ville v		         ON v.id_ville = ds.id_ville
							INNER JOIN utilisateur ut        ON ds.id_emetteur = ut.id_utilisateur
							INNER JOIN ville vi              ON vi.id_ville = ut.id_ville
	WHERE ds.id_emetteur = @IdUtilisateur 
	AND ds.date_annulation IS NULL
	AND ds.date_cloture IS NULL
	AND ds.date_non_finalisation IS NULL 
	AND ds.date_realisation > SYSDATETIME()
	AND ds.id_demande not in (SELECT id_demande FROM reponse ) --WHERE date_acceptation IS NOT NULL
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdDemandeEnCours]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetIdDemandeEnCours] 
	-- Add the parameters for the stored procedure here
	@IdUtilisateur int = 0,
	@DateNow date = " "
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id_demande FROM demande_service WHERE id_emetteur = @IdUtilisateur 
	AND date_annulation IS NULL
	AND date_cloture IS NULL
	AND date_non_finalisation IS NULL
	AND date_realisation > @DateNow
	


END
GO
/****** Object:  StoredProcedure [dbo].[GetInfosDemandesEnCoursBeneficiaire]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetInfosDemandesEnCoursBeneficiaire] 
	-- Add the parameters for the stored procedure here
	@IdUtilisateur int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ds.date_realisation, 
		   ds.id_demande,
		   CASE WHEN ds.adresse_realisation IS NULL THEN ut.adresse ELSE  ds.adresse_realisation END AS adresse_realisation,
	       CASE WHEN v.libelle_ville IS NULL THEN vi.libelle_ville ELSE v.libelle_ville END AS libelle_ville, 
		   CASE WHEN v.code_postal IS NULL THEN vi.code_postal ELSE v.code_postal END AS code_postal,
	       ts.libelle_type_service, 
		   u.nom,
		   u.prenom
	FROM demande_service ds INNER JOIN type_service ts       ON  ds.id_type_service = ts.id_type_service
							LEFT JOIN ville v		         ON v.id_ville = ds.id_ville
							INNER JOIN reponse r             ON r.id_demande = ds.id_demande
							INNER JOIN utilisateur u         ON r.id_utilisateur = u.id_utilisateur
							INNER JOIN utilisateur ut        ON ds.id_emetteur = ut.id_utilisateur
							INNER JOIN ville vi              ON vi.id_ville = ut.id_ville
	WHERE ds.id_emetteur = @IdUtilisateur 
	AND ds.date_annulation IS NULL
	AND ds.date_cloture IS NULL
	AND ds.date_non_finalisation IS NULL 
	AND ds.date_realisation > SYSDATETIME()
	AND r.date_refus IS NULL
	AND r.date_annulation_participation IS NULL
	AND r.date_acceptation IS NOT NULL
	AND r.id_utilisateur != @IdUtilisateur
END
GO
/****** Object:  StoredProcedure [dbo].[GetLibelleVilleCP]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetLibelleVilleCP] 
	-- Add the parameters for the stored procedure here
	@IdVille int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT code_postal, libelle_ville FROM ville WHERE id_ville = @IdVille
END
GO
/****** Object:  StoredProcedure [dbo].[GetListeEquipement]    Script Date: 05/02/2021 10:32:03 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertDemandeService]    Script Date: 05/02/2021 10:32:03 ******/
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
/****** Object:  StoredProcedure [dbo].[InsertEquipementDemande]    Script Date: 05/02/2021 10:32:03 ******/
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
/****** Object:  StoredProcedure [dbo].[LireDonneesDemandeService]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[LireDonneesDemandeService] 
	-- Add the parameters for the stored procedure here
	@IdDemande int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT date_realisation, 
		   adresse_realisation, 
		   id_ville, 
		   id_emetteur, 
		   id_type_service, 
		   date_enregistrement,
		   date_annulation,
		   date_cloture,
		   date_non_finalisation,
		   id_motif_annulation
	FROM demande_service
	WHERE id_demande = @IdDemande

END
GO
/****** Object:  StoredProcedure [dbo].[LireGenre]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LireGenre] 
	-- Add the parameters for the stored procedure here
	@IdGenre int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT libelle_genre
		   
	FROM  genre
	WHERE  id_genre = @IdGenre
END
GO
/****** Object:  StoredProcedure [dbo].[LireLibelleTypeServiceEtIdCategorie]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mathilda
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[LireLibelleTypeServiceEtIdCategorie] 
	-- Add the parameters for the stored procedure here
	@IdTypeService int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT libelle_type_service,
		   id_categorie
	FROM   type_service
	WHERE  id_type_service = @IdTypeService
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDateAcceptation_TableReponse]    Script Date: 05/02/2021 10:32:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		BM
-- Create date: 29.01.2021
-- Description:	Permet d'insérer une date d'acceptation dans la table reponse
-- =============================================
CREATE PROCEDURE [dbo].[UpdateDateAcceptation_TableReponse] 
	-- Add the parameters for the stored procedure here
	@idDemande int, 
	@idBenevole int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE reponse 
	SET date_acceptation = SYSDATETIME() 
	WHERE id_demande = @idDemande 
	AND id_utilisateur = @idBenevole
END
GO
