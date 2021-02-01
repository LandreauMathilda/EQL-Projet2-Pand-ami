using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using Pandami2.ClassesDao;
using Pandami2.Models;

namespace Pandami2.Models
{
    public class DaoUtilisateur
    {
        private SqlConnection cnx;


        private void connection()
        {
            string connectionstring= System.Configuration.ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;
            cnx = new SqlConnection(connectionstring);
        }

        public void AjoutUtilisateur(Utilisateur utilisateur)
        {
            connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Insert into utilisateur (nom,prenom,id_genre,date_naissance,adresse,Id_ville,num_telephone,email,date_inscription) values(@nom,@prenom,@Id_genre,@date_naissance,@adresse,@Id_ville,@num_telephone,@email,@date_inscription)";
            cmd.CommandType = System.Data.CommandType.Text;           
            
            cmd.Parameters.Add(new SqlParameter("@nom", utilisateur.Nom));

            
            cmd.Parameters.Add(new SqlParameter("@prenom", utilisateur.Prenom));

            
            cmd.Parameters.Add( new SqlParameter("@Id_genre", utilisateur.Id_genre));

            
            cmd.Parameters.Add(new SqlParameter("@date_naissance", utilisateur.Date_naissance));

           
            cmd.Parameters.Add(new SqlParameter("@adresse", utilisateur.Adresse));

           
            cmd.Parameters.Add(new SqlParameter("@Id_ville", utilisateur.Id_ville));

            
            cmd.Parameters.Add(new SqlParameter("@num_telephone", utilisateur.Num_telephone));

            
            cmd.Parameters.Add(new SqlParameter("@email", utilisateur.Email));

            
            cmd.Parameters.Add(new SqlParameter("@date_inscription", DateTime.Now));
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();

        }


        public List <Utilisateur> AfficherListeUtilisateur()

        {
            connection();
            List<Utilisateur> listeUtilisateurs = new List<Utilisateur>();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "AfficherListeUtilisateur";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cnx.Open();
            da.Fill(dt);
            cnx.Close();

            foreach(DataRow dr in dt.Rows)
            {
                listeUtilisateurs.Add(new Utilisateur
                {
                 Id_utilisateur=Convert.ToInt32(dr["id_utilisateur"]),
                 Nom=Convert.ToString(dr["nom"]),
                 Prenom=Convert.ToString(dr["Prenom"]),
                 Id_genre=Convert.ToInt32(dr["id_genre"]),
                 Date_naissance=Convert.ToDateTime(dr["date_naissance"]),
                 Adresse=Convert.ToString(dr["adresse"]),
                 Id_ville=Convert.ToInt32(dr["id_ville"]),
                 Num_telephone=Convert.ToInt32(dr["num_telephone"]),
                 Email=Convert.ToString(dr["email"]),
                 Date_inscription=Convert.ToDateTime(dr["date_inscription"])
                
                });

               
            }
            return listeUtilisateurs;
            

        }
       
       
    }
}