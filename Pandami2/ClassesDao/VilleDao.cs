using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Pandami2.ClassesDao
{
    public class VilleDao
    {
        string connStr = ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;

        public String LireVille(int idVille)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetLibelleVilleCP";
            SqlParameter idVillePara = new SqlParameter("@IdVille", idVille);
            cmd.Parameters.Add(idVillePara);
            SqlDataReader dr = cmd.ExecuteReader();
            String cpVille = "";
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cpVille = (dr["code_postal"], dr["libelle_ville"]).ToString();
                }
                dr.Close();
            }
            cnx.Close();
            return cpVille;
        }

        // Méthode qui permet d'obtenir un dictionnaire des villes. 
        // @return : un objet Dictionary<int, string> qui comporte en clés les id des villes et en cp le libellé des villes et le code postal.
        public Dictionary<int, string> ChargerListeVille()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.ExtractListeVilles";
            SqlDataReader dr = cmd.ExecuteReader();
            Dictionary<int, string> listeVille = new Dictionary<int, string>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string villeCp = String.Concat((string)dr["libelle_ville"] + " - " + (string)dr["code_postal"]);
                    listeVille.Add((int)dr["id_ville"], villeCp);
                }
                dr.Close();
            }
            cnx.Close();
            return listeVille;
        }
    }
}