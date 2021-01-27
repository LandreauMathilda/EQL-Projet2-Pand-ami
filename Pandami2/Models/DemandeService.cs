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

<<<<<<< HEAD
        
            

        public int IdDemande { get => idDemande ; }
=======
        string connStr = ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;

        public int IdDemande { get => idDemande; set => idDemande = value; }
>>>>>>> 3fe10349b9afb27f82cfaaa1123d141b58e64967
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

        public DemandeService(int idUtilisateur)
        {
            this.idEmetteur = idUtilisateur;
        }

<<<<<<< HEAD

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
=======
        public String ChargerDateService(int idDemande)
>>>>>>> 3fe10349b9afb27f82cfaaa1123d141b58e64967
        {
            SqlConnection cnx = new SqlConnection();
           
            cnx.ConnectionString = "Data Source=FORM229\\SQLEXPRESS;Initial Catalog=pandamidb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.LireDonneesDemandeService";
            SqlParameter idDemandePara = new SqlParameter("@IdDemande", idDemande);
            cmd.Parameters.Add(idDemandePara);
            SqlDataReader dr = cmd.ExecuteReader();
            //DateTime dateService = new DateTime();
            String dateServiceString = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dateServiceString = string.Format("{0:d}", dr["date_realisation"]);
                }
                dr.Close();
            }
            cnx.Close();

            return dateServiceString;
        }

        public String ChargerHeureService(int idDemande)
        {
            SqlConnection cnx = new SqlConnection();
            
            cnx.ConnectionString = "Data Source=FORM229\\SQLEXPRESS;Initial Catalog=pandamidb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.LireDonneesDemandeService";
            SqlParameter idDemandePara = new SqlParameter("@IdDemande", idDemande);
            cmd.Parameters.Add(idDemandePara);
            SqlDataReader dr = cmd.ExecuteReader();

            String heureServiceString = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    heureServiceString = string.Format("{0: HH:mm}", dr["date_realisation"]);
                }
                dr.Close();
            }

            cnx.Close();

            return heureServiceString;
        }

        public String ChargerAdresseRealisation(int idDemande)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.LireDonneesDemandeService";
            SqlParameter idDemandePara = new SqlParameter("@IdDemande", idDemande);
            cmd.Parameters.Add(idDemandePara);
            SqlDataReader dr = cmd.ExecuteReader();
            String adresseRealisation = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    adresseRealisation = dr["adresse_realisation"].ToString();
                }
                dr.Close();
            }

            cnx.Close();
            return adresseRealisation;
        }

        public int GetIdVille(int idDemande)
        {
            SqlConnection cnx = new SqlConnection();
          
            cnx.ConnectionString = "Data Source=FORM229\\SQLEXPRESS;Initial Catalog=pandamidb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.LireDonneesDemandeService";
            SqlParameter idDemandePara = new SqlParameter("@IdDemande", idDemande);
            cmd.Parameters.Add(idDemandePara);
            SqlDataReader dr = cmd.ExecuteReader();
            int idVille = 0;
            String idVilleString = "";

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    idVilleString = (dr["id_ville"]).ToString();
                }
                dr.Close();
            }
            cnx.Close();

            idVille = int.Parse(idVilleString);
            return idVille;
        }

        public int GetIdDemandeEnCours(int idUtilisateur)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetIdDemandeEnCours";
            SqlParameter idUtilisateurPara = new SqlParameter("@IdUtilisateur", idUtilisateur);
            SqlParameter dateDuJourPara = new SqlParameter("@DateNow", DateTime.Now);
            cmd.Parameters.Add(idUtilisateurPara);
            cmd.Parameters.Add(dateDuJourPara);
            SqlDataReader dr = cmd.ExecuteReader();
            int idDemandeEnCours = 0;
            String idDemandeEnCoursString = "";

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    idDemandeEnCoursString = (dr["id_demande"]).ToString();
                }
                dr.Close();
            }
            cnx.Close();

            idDemandeEnCours = int.Parse(idDemandeEnCoursString);
            return idDemandeEnCours;
        }

        public String BenevoleOuBeneficiaire(int idDemande, int idUtilisateur)
        {

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.LireDonneesDemandeService";
            SqlParameter idDemandePara = new SqlParameter("@IdDemande", idDemande);
            cmd.Parameters.Add(idDemandePara);
            SqlDataReader dr = cmd.ExecuteReader();
            String statutBouB = "";
            String idEmetteurString = "";
            int idEmetteur = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    idEmetteurString = (dr["id_emetteur"]).ToString();
                }
                dr.Close();
            }
            cnx.Close();
            idEmetteur = int.Parse(idEmetteurString);

            if (idEmetteur == idUtilisateur)
            {
                statutBouB = "Bénéficiaire";
            }
            else if (idEmetteur != idUtilisateur)
            {
                statutBouB = "Bénévole";
            }


            return statutBouB;
        }


<<<<<<< HEAD
        
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
        

            

           


=======
        public int GetIdService(int idDemande)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.LireDonneesDemandeService";
            SqlParameter idDemandePara = new SqlParameter("@IdDemande", idDemande);
            cmd.Parameters.Add(idDemandePara);
            SqlDataReader dr = cmd.ExecuteReader();
            int idTypeService = 0;
            String idTypeServiceString = "";

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    idTypeServiceString = (dr["id_type_service"]).ToString();
                }
                dr.Close();
            }
            cnx.Close();

            idTypeService = int.Parse(idTypeServiceString);
            return idTypeService;
        }
>>>>>>> 3fe10349b9afb27f82cfaaa1123d141b58e64967
    }
      




    
}