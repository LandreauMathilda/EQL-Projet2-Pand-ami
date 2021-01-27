using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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


       //string connStr = ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;
       
        // constructeur chargé demande de service :
        public DemandeService(DateTime dateEnregistrement, DateTime dateRealisation, string adresseRealisation, int villeRealisation, DateTime heureRealisation, int idEmetteur = default, int idTypeService = default)
        {
            this.dateEnregistrement = dateEnregistrement;
            this.dateRealisation = dateRealisation;
            this.adresseRealisation = adresseRealisation;
            this.villeRealisation = villeRealisation;
            this.heureRealisation = heureRealisation;
            this.idTypeService = idTypeService;// == type de service 
            this.idEmetteur = idEmetteur;//  ==utilisateur qui a créé la demande

        }

        //Constructeur vide
        public DemandeService()
        {
        }

        public DemandeService(int idDemande, int idEmetteur, DateTime dateEnregistrement, DateTime dateRealisation, string adresseRealisation, int villeRealisation,
            DateTime heureRealisation, int idTypeService, DateTime dateAnnulation, DateTime dateCloture, DateTime dateNonFinalisation, int idMotifAnnulation         
            )
        {
            this.idDemande = idDemande;
            this.idEmetteur = idEmetteur;
            this.dateEnregistrement = dateEnregistrement;
            this.dateRealisation = dateRealisation;
            this.adresseRealisation = adresseRealisation;
            this.villeRealisation = villeRealisation;
            this.heureRealisation = heureRealisation;
            this.idTypeService = idTypeService;
            this.dateAnnulation = dateAnnulation;
            this.dateCloture = dateCloture;
            this.dateNonFinalisation = dateNonFinalisation;
            this.idMotifAnnulation = idMotifAnnulation;
            
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
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SELECT libelle_categorie from categorie"; // nom de la procédure stockée 
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> listeCategorieService = new List<string>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listeCategorieService.Add((string)dr["libelle_categorie"]);
                }
                dr.Close();
            }
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
            if (dr.HasRows) 
            { 
            while (dr.Read())
            {
                listeTypeService.Add((string)dr["libelle_type_service"]);
            }
                dr.Close();
            }
            
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
            if (dr.HasRows) 
            { 
                while (dr.Read())
            {
                listeVille.Add((string)dr["libelle_ville"]);
            }
            dr.Close();
            }
            cnx.Close();
            return listeVille;
        }


        
        public List<DemandeService>AfficherDemandes()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString= System.Configuration.ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Select * From demande_service";
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            List<DemandeService> listeDemandes = new List<DemandeService>(); 
                if (dr.HasRows)
                {
                 while(dr.Read())

                {
                    DemandeService demande = new DemandeService();

                    if (dr["id_Emetteur"]!=DBNull.Value)
                    {
                       demande.IdEmetteur = (int)dr["id_emetteur"];
                    }
                    if (dr["date_enregistrement"] != DBNull.Value)
                    {
                       demande.DateEnregistrement = (DateTime)dr["date_enregistrement"];
                    }
                    if (dr["date_realisation"] != DBNull.Value)
                    {
                        demande.DateRealisation = (DateTime)dr["date_realisation"];
                    }
                    if (dr["adresse_realisation"] != DBNull.Value)
                    {
                        demande.AdresseRealisation = (string)dr["adresse_realisation"];
                    }
                    if (dr["id_ville"] != DBNull.Value)
                    {
                        demande.VilleRealisation = (int)dr["id_ville"];
                    }
                    if(dr["id_type_service"] != DBNull.Value)
                    {
                        demande.IdTypeService = (int)dr["id_type_service"];
                    }
                    if (dr["date_annulation"] != DBNull.Value)
                    {
                        demande.DateAnnulation = (DateTime)dr["date_annulation"];
                    }
                    if(dr["date_annulation"] != DBNull.Value)
                    {
                        demande.DateCloture = (DateTime)dr["date_cloture"];
                    }
                    
                    
                   // demande. DateNonFinalisation = (DateTime)dr["date_non_finalisation"];                
                    // demande. IdMotifAnnulation = (int)dr["id_motif_annulation"];

                    listeDemandes.Add(demande);
                    
                }   
            }

            cnx.Close();


            return listeDemandes;

        }


        //declaration de l'evenement 
        


        //creation de l'event args qui comprend l'id de la demande selectionnee
        

            

           


    }
      




    
}