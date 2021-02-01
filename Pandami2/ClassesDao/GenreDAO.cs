using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Pandami2.ClassesDao
{
    public class GenreDAO
    {
        private SqlConnection cnx;

        private void connection()
        {
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;
            cnx = new SqlConnection(connectionstring);
        }
        public String LireGenre(int IdGenre)
        {

            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.LireGenre";
           
            cmd.Parameters.Add(new SqlParameter("@IdGenre", IdGenre));
            SqlDataReader dr = cmd.ExecuteReader();
            String libelleGenre="" ;

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    libelleGenre = (dr["libelle_genre"]).ToString();
                }
                dr.Close();
            }
            cnx.Close();

            return libelleGenre;
        }

        public Dictionary<int, string> ListeGenre()
        {
            SqlConnection cnx = new SqlConnection();
           cnx.ConnectionString= System.Configuration.ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;

            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.ExtractLibelleGenre";
            SqlDataReader dr = cmd.ExecuteReader();
            Dictionary<int, string> listeGenre = new Dictionary<int, string>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    
                    listeGenre.Add((int)dr["id_genre"], (string)dr["libelle_genre"]);
                }
                dr.Close();
            }
            
            cnx.Close();
            return listeGenre;
        }
    }
}