using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Pandami2.ClassesDao
{
    public class EquipementDao
    {
        private int idEquipement;
        private string libelleEquipement;

        public int IdTypeService { get => idEquipement; }
        public string LibelleTypeService { get => libelleEquipement; }


        string connStr = ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;

        // Méthode qui permet d'obtenir un dictionnaire des équipements. 
        // @return : un objet Dictionary<int, string> qui comporte en clés les id des équipements et en cp le libellé des équipements.
        public Dictionary<int, string> ChargerListeEquipements()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.ExtractListeEquipements";
            SqlDataReader dr = cmd.ExecuteReader();
            Dictionary<int, string> listeEquipements = new Dictionary<int, string>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listeEquipements.Add((int)dr["id_equipement"], (string)dr["libelle_equipement"]);
                }
                dr.Close();
            }
            cnx.Close();
            return listeEquipements;
        }

        //méthode qui permet d'ajouter un couple idEquipement/idDemande dans la table equipement_demande
        public void AjouterEquipementDemande(int? idEquipement)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.InsertEquipementDemande";
            SqlParameter param2 = new SqlParameter("@idEquipement", idEquipement);
            cmd.Parameters.Add(param2);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public List<string> RecupererListeEquipement(int idDemande)
        {
            List<string> libelleEquipement = new List<string>();
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetListeEquipement";
            SqlParameter param2 = new SqlParameter("@IdDemande", idDemande);
            cmd.Parameters.Add(param2);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    libelleEquipement.Add((string)dr["libelle_equipement"]);
                }
            }
            else
            {
                libelleEquipement.Add("Aucun equipement nécessaire");
            }
            cnx.Close();

            return libelleEquipement; 
        }
    }
}