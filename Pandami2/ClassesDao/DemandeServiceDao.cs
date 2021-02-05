using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Pandami2.Models;
using Pandami2.ClassesDao;

namespace Pandami2.ClassesDao
{

    // classe qui permet d'extraire et insérer des données depuis/vers la table demande_service
    public class DemandeServiceDao
    {
        string connStr = ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;

        // méthode qui permet d'ajouter une demande de service dans la table demande_service
        public void AjouterDemande(int idEmetteur, DateTime dateEnregistrement, DateTime dateRealisation,
           string adresseRealisation, int? idVille, int idTypeService, DateTime? dateAnnulation, DateTime? dateCloture,
           DateTime? dateNonFinalisation, int? idMotifAnnulation)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.InsertDemandeService";
            SqlParameter param1 = new SqlParameter("@idEmetteur", idEmetteur);
            SqlParameter param2 = new SqlParameter("@dateEnregistrement", dateEnregistrement);
            SqlParameter param3 = new SqlParameter("@dateRealisation", dateRealisation);
            SqlParameter param4 = new SqlParameter("@adresseRealisation", adresseRealisation);
            SqlParameter param5 = new SqlParameter("@idVille", idVille);
            SqlParameter param6 = new SqlParameter("@idTypeService", idTypeService);
            SqlParameter param7 = new SqlParameter("@dateAnnulation", dateAnnulation);
            SqlParameter param8 = new SqlParameter("@dateCloture", dateCloture);
            SqlParameter param9 = new SqlParameter("@dateNonFinalisation", dateNonFinalisation);
            SqlParameter param10 = new SqlParameter("@idMotifAnnulation", idMotifAnnulation);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);
            cmd.Parameters.Add(param9);
            cmd.Parameters.Add(param10);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
        public List<DemandeService> AfficherDemandes()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.AfficherDemandesService";
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DemandeService demande = new DemandeService((int)dr["id_emetteur"]);
                    demande.NomPrenomEmetteur = (string)dr["nom"] + " " + (string)dr["prenom"];
                    demande.IdDemande = (int)dr["id_demande"];
                    demande.DateEnregistrement = (DateTime)dr["date_enregistrement"];
                    demande.DateRealisation = (DateTime)dr["date_realisation"];
                    demande.AdresseRealisation = (string)dr["adresse_realisation"];
                    demande.LibelleVilleRealisation = (string)dr["libelle_ville"];
                    demande.LibelleTypeService = (string)dr["libelle_type_service"];
                    if (dr["date_annulation"] != DBNull.Value)
                    {
                        demande.DateAnnulation = (DateTime)dr["date_annulation"];
                    }
                    if (dr["date_cloture"] != DBNull.Value)
                    {
                        demande.DateCloture = (DateTime)dr["date_cloture"];
                    }
                    listeDemandes.Add(demande);
                }
            }
            cnx.Close();
            return listeDemandes;
        }
        public List<DemandeService> GetDemandesEnCoursBeneficiaire(int idUtilisateur)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetInfosDemandesEnCoursBeneficiaire";
            SqlParameter idUtilisateurPara = new SqlParameter("@IdUtilisateur", idUtilisateur);
            cmd.Parameters.Add(idUtilisateurPara);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DemandeService demande = new DemandeService((DateTime)dr["date_realisation"], 
                                                                (string)dr["adresse_realisation"], 
                                                                (string)dr["code_postal"], 
                                                                (string)dr["libelle_ville"],
                                                                (string)dr["libelle_type_service"],
                                                                (string)dr["nom"]+" "+dr["prenom"],
                                                                (int)dr["id_demande"]);
                    listeDemandes.Add(demande);
                }
            }
            cnx.Close();
            return listeDemandes;
        }
        public List<DemandeService> GetDemandesEnCoursBenevole(int idUtilisateur)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetDemandesEnCoursBenevole";
            SqlParameter idUtilisateurPara = new SqlParameter("@IdUtilisateur", idUtilisateur);
            cmd.Parameters.Add(idUtilisateurPara);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DemandeService demande = new DemandeService((DateTime)dr["date_realisation"],
                                                                (string)dr["adresse_realisation"],
                                                                (string)dr["code_postal"],
                                                                (string)dr["libelle_ville"],
                                                                (string)dr["libelle_type_service"],
                                                                (string)dr["nom"] + " " + dr["prenom"],
                                                                (int)dr["id_demande"]);
                    listeDemandes.Add(demande);
                }
            }
            cnx.Close();
            return listeDemandes;
        }
        public List<DemandeService> GetDemandesNonPourvues(int idUtilisateur)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetDemandesNonPourvues";
            SqlParameter idUtilisateurPara = new SqlParameter("@IdUtilisateur", idUtilisateur);
            cmd.Parameters.Add(idUtilisateurPara);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DemandeService demande = new DemandeService((DateTime)dr["date_realisation"],
                                                                (string)dr["adresse_realisation"],
                                                                (string)dr["code_postal"],
                                                                (string)dr["libelle_ville"],
                                                                (string)dr["libelle_type_service"],
                                                                (int)dr["id_demande"]);
                    listeDemandes.Add(demande);
                }
            }
            cnx.Close();
            return listeDemandes;
        }
        public List<DemandeService> GetDemandesEnAttenteAValider(int idUtilisateur)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetDemandesEnAttente";
            SqlParameter idUtilisateurPara = new SqlParameter("@IdUtilisateur", idUtilisateur);
            cmd.Parameters.Add(idUtilisateurPara);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DemandeService demande = new DemandeService((DateTime)dr["date_realisation"],
                                                                (string)dr["adresse_realisation"],
                                                                (string)dr["code_postal"],
                                                                (string)dr["libelle_ville"],
                                                                (string)dr["libelle_type_service"],
                                                                (string)dr["nom"] + " " + dr["prenom"],
                                                                (int)dr["id_demande"],
                                                                (int)dr["id_utilisateur"]);
                    listeDemandes.Add(demande);
                }
            }
            cnx.Close();
            return listeDemandes;
        }
        public List<DemandeService> GetDemandesACloturerBeneficiaire(int idUtilisateur)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetDemandesACloturer";
            SqlParameter idUtilisateurPara = new SqlParameter("@IdUtilisateur", idUtilisateur);
            cmd.Parameters.Add(idUtilisateurPara);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DemandeService demande = new DemandeService((DateTime)dr["date_realisation"],
                                                                (string)dr["adresse_realisation"],
                                                                (string)dr["code_postal"],
                                                                (string)dr["libelle_ville"],
                                                                (string)dr["libelle_type_service"],
                                                                (string)dr["nom"] + " " + dr["prenom"],
                                                                (int)dr["id_demande"]);
                    listeDemandes.Add(demande);
                }
            }
            cnx.Close();
            return listeDemandes;
        }
        public List<DemandeService> GetDemandesACloturerBenevole(int idUtilisateur)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetDemandesACloturerBenevole";
            SqlParameter idUtilisateurPara = new SqlParameter("@IdUtilisateur", idUtilisateur);
            cmd.Parameters.Add(idUtilisateurPara);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DemandeService demande = new DemandeService((DateTime)dr["date_realisation"],
                                                                (string)dr["adresse_realisation"],
                                                                (string)dr["code_postal"],
                                                                (string)dr["libelle_ville"],
                                                                (string)dr["libelle_type_service"],
                                                                (int)dr["id_demande"]);
                    listeDemandes.Add(demande);
                }
            }
            cnx.Close();
            return listeDemandes;
        }
        public List<DemandeService> GetDemandesAValiderParBeneficiaire(int idUtilisateur)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetDemandesAValiderParBeneficiaire";
            SqlParameter idUtilisateurPara = new SqlParameter("@IdUtilisateur", idUtilisateur);
            cmd.Parameters.Add(idUtilisateurPara);
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DemandeService demande = new DemandeService((DateTime)dr["date_realisation"],
                                                                (string)dr["adresse_realisation"],
                                                                (string)dr["code_postal"],
                                                                (string)dr["libelle_ville"],
                                                                (string)dr["libelle_type_service"],
                                                                (string)dr["nom"] + " " + dr["prenom"],
                                                                (int)dr["id_demande"]);
                    listeDemandes.Add(demande);
                }
            }
            cnx.Close();
            return listeDemandes;
        }
        public void RechercherParType(int type)
        {
        SqlConnection cnx = new SqlConnection();
        cnx.ConnectionString = connStr;
        cnx.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cnx;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "SELECT id_emetteur,date_enregistrement,date_realisation,adresse_realisation,id_ville,id_type_service FROM demande_service where id_type_service = @id_type ";
        cmd.CommandType = System.Data.CommandType.Text;
        SqlDataReader dr = cmd.ExecuteReader();
        List<DemandeService> listeParType = new List<DemandeService>();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                DemandeService demande = new DemandeService((int)dr["id_emetteur"]);
                demande.IdDemande = (int)dr["id_demande"];
                demande.DateEnregistrement = (DateTime)dr["date_enregistrement"];
                demande.DateRealisation = (DateTime)dr["date_realisation"];
                if (dr["adresse_realisation"] != DBNull.Value)
                {
                    demande.AdresseRealisation = (string)dr["adresse_realisation"];
                }
                if (dr["id_ville"] != DBNull.Value)
                {
                    demande.VilleRealisation = (int)dr["id_ville"];
                }
                demande.IdTypeService = (int)dr["id_type_service"];
                if (dr["date_annulation"] != DBNull.Value)
                {
                    demande.DateAnnulation = (DateTime)dr["date_annulation"];
                }
                if (dr["date_cloture"] != DBNull.Value)
                {
                    demande.DateCloture = (DateTime)dr["date_cloture"];
                }
                listeParType.Add(demande);
            }
        }
        cnx.Close();
    }

        public void AnnulerDemande(int idDemande)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE demande_service " +
                              "SET date_annulation=SYSDATETIME() " +
                              "WHERE id_demande = @idDemande";
            cmd.Parameters.Add(new SqlParameter("@idDemande", idDemande));
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
        public void CloturerUneDemandeFinalisee(int idDemande)
            {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "dbo.CloturerUneDemandeFinalisee";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDemande", idDemande));
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
        public void CloturerUneDemandeNonFinalisee(int idDemande)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "dbo.cloturerUneDemandeNonFinalisee";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@idDemande", idDemande));
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
    }
}
    

