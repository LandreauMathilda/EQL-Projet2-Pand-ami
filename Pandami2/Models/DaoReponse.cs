using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pandami2.Models
{
    public class DaoReponse
    {
        private SqlConnection cnx;

        private void connection()
        {
            string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;
            cnx = new SqlConnection(connectionstring);
        }
        public void AjoutReponse(Reponse reponse)
        {
            connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Insert into reponse  values (@date_reponse,@id_utilisateur,@id_demande)";
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@date_reponse", DateTime.Now));
            cmd.Parameters.Add(new SqlParameter("@id_utilisateur", reponse.Id_utilisateur));
            cmd.Parameters.Add(new SqlParameter("@id_demande", reponse.Id_demande));
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();

        }



        //je dois recuperer id-utilisateur =benevole:


        // je dois recuperer id-demande:
        // quand je clique le bouton repondre : un message de confirmation s'affiche "vous acceptez de repondre a cette demande cliquez sui pour confirmer"
        // une methode qui envoie les informations de la demande à la base de données reponse
        
        public event EventHandler OnClick;









    }
}