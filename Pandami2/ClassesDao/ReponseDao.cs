using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Pandami2.ClassesDao
{
    public class DaoReponse
    {   
        // classe qui comporte des méthodes pour insérer ou mettre à jour des données dans la table reponse
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
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        // méthode qui permet de mettre à jour la date d'acceptation d'une réponse faite par un bénévole à une demande de service
        //@param : un idDemande => la demande à laquelle le bénévole a répondu
        //         un idBenevole => le bénévole qui a repondu à la demande de service
        public void MaJDateAcceptation(int idDemande, int? idBenevole)
        {
            connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.UpdateDateAcceptation_TableReponse";
            cmd.Parameters.Add(new SqlParameter("@idDemande", idDemande));
            cmd.Parameters.Add(new SqlParameter("@idBenevole", idBenevole));
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        //méthode qui permet de mettre à jour la date_annulation_participation dans la table reponse
        //@param : un idDemande => la demande à laquelle le bénévole a répondu
        //         un idBenevole => le bénévole qui a repondu à la demande de service
        public void MajDateAnnulationParticipation(int idDemande, int? idBenevole)
        {
            connection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE reponse " +
                              "SET date_annulation_participation = SYSDATETIME() " +
                              "WHERE id_demande=@idDemande " +
                              "AND id_utilisateur=@idBenevole";
            cmd.Parameters.Add(new SqlParameter("@idDemande", idDemande));
            cmd.Parameters.Add(new SqlParameter("@idBenevole", idBenevole));
            cnx.Open();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
    }
}