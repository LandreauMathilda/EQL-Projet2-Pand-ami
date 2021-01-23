using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Pandami2.Models
{
    public class DemandeService
    {
        private int idDemande;
        private int idEmetteur;
        private DateTime dateEnregistrement;
        private DateTime dateRealisation;
        private string adresseRealisation;
        private int villeRealisation;
        private DateTime heureRealisation;
        private int idTypeService;
        private DateTime dateAnnulation;
        private DateTime dateCloture;
        private DateTime dateNonFinalisation;
        private int idMotifAnnulation;

        
            

        public int IdDemande { get => idDemande ; }
        public int IdEmetteur { get => idEmetteur; set => idEmetteur = value; }
        public DateTime DateEnregistrement { get => dateEnregistrement; set => dateEnregistrement = value; }
        public DateTime DateRealisation { get => dateRealisation; set => dateRealisation = value; }
        public string AdresseRealisation { get => adresseRealisation; set => adresseRealisation = value; }
        public int VilleRealisation { get => villeRealisation; set => villeRealisation = value; }
        public DateTime HeureRealisation { get => heureRealisation; set => heureRealisation = value; }
        public int IdTypeService { get => idTypeService; set => idTypeService = value; }
        public DateTime DateAnnulation { get => dateAnnulation; set => dateAnnulation = value; }
        public DateTime DateCloture { get => dateCloture; set => dateCloture = value; }
        public DateTime DateNonFinalisation { get => dateNonFinalisation; set => dateNonFinalisation = value; }
        public int IdMotifAnnulation { get => idMotifAnnulation; set => idMotifAnnulation = value; }

        public DemandeService(int idEmetteur)
        {
            this.idEmetteur = idEmetteur;
        }

        // constructeur chargé demande de service :
        public DemandeService(DateTime dateEnregistrement, DateTime dateRealisation, string adresseRealisation, int villeRealisation, DateTime heureRealisation, int idEmetteur = default, int idTypeService = default)
        {
            this.dateEnregistrement = dateEnregistrement;
            this.dateRealisation = dateRealisation;
            this.adresseRealisation = adresseRealisation;
            this.villeRealisation = villeRealisation;
            this.heureRealisation = heureRealisation;
            this.idTypeService = idTypeService;// remplacer par type de service 
            this.idEmetteur = idEmetteur;// remplacer par utilisateur qui a créé la demande

        }





        // Méthode qui permet d'obtenir la liste des catégories de service. 
        // @return : un objet List<string> qui comporte l'ensemble des catégories de service.
        public List<string> ChargerListeCategorieService()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = "Data Source=FORM229\\SQLEXPRESS;Initial Catalog=pandamidb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT libelle_categorie from categorie";
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> listeCategorieService = new List<string>();
            while (dr.Read())
            {
                listeCategorieService.Add((string) dr["libelle_categorie"]);
            }
            dr.Close();
            cnx.Close();
            return listeCategorieService;
        }

        // Méthode qui permet d'obtenir la liste des types de service. 
        // @return : un objet List<string> qui comporte l'ensemble des types de service.
        public List<string> ChargerListeTypeService()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = "Data Source=FORM229\\SQLEXPRESS;Initial Catalog=pandamidb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT libelle_type_service from type_service";
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> listeTypeService = new List<string>();
            while (dr.Read())
            {
                listeTypeService.Add((string)dr["libelle_categorie"]);
            }
            dr.Close();
            cnx.Close();
            return listeTypeService;
        }

        // Méthode qui permet d'obtenir la liste des villes. 
        // @return : un objet List<string> qui comporte l'ensemble des villes.
        public List<string> ChargerListeVille()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = "Data Source=FORM229\\SQLEXPRESS;Initial Catalog=pandamidb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT libelle_ville || code_postal FROM ville";
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> listeVille = new List<string>();
            while (dr.Read())
            {
                listeVille.Add((string)dr["libelle_categorie"]);
            }
            dr.Close();
            cnx.Close();
            return listeVille;
        }


        
        public List<DemandeService>AfficherDemandes()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["pandamidb"].ConnectionString;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FORM demande_service";
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>();
            while(dr.Read())
            {
              DemandeService demandeService = new DemandeService((DateTime)dr["date_enregistrement"], 
                                                                 (DateTime)dr["date_realisation"], 
                                                                 (string)dr["adresse_realisation"], 
                                                                 (int)dr["id_ville"], 
                                                                 (DateTime)dr["heure_realisation"]);

                listeDemandes.Add(demandeService);

             }
            dr.Close();
            cnx.Close();
            return listeDemandes;


        }
        
       


    }
}