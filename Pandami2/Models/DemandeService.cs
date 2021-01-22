using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

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
        private List<string> listeCategoriesService;

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
            ChargerListeCategorieService();
        }

        private void ChargerListeCategorieService()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = "Data Source=FORM224\\SQLEXPRESS;Initial Catalog=pandamidb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT libelle_categorie from categorie";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listeCategoriesService.Add((string) dr["libelle_categorie"]);
            }
            dr.Close();
            cnx.Close();
        }

    }
}