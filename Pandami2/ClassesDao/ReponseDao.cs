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
        public void AjoutReponse(int idUtilisateur,int idDemande)
        {
            connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "Insert into reponse (date_reponse,id_utilisateur,id_demande)  values (@date_reponse,@id_utilisateur,@id_demande)";
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("@date_reponse", DateTime.Now));
            cmd.Parameters.Add(new SqlParameter("@id_utilisateur", idUtilisateur));
            cmd.Parameters.Add(new SqlParameter("@id_demande", idDemande));
            //Reponse reponse = new Reponse(idUtilisateur, idDemande, DateTime.Now);
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();
            //return reponse;
           

            
        }



        








    }
}