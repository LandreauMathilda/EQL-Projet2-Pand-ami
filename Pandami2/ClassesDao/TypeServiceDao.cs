using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Pandami2.ClassesDao
{
    public class TypeServiceDao
    {
        private int idTypeService;
        private int idCategorie;

        public int IdTypeService { get => idTypeService; }
        public int IdCategorie { get => idCategorie; }



        string connStr = ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;

        public String LireTypeService(int idTypeService)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.LireLibelleTypeServiceEtIdCategorie";
            SqlParameter idTypeServicePara = new SqlParameter("@IdTypeService", idTypeService);
            cmd.Parameters.Add(idTypeServicePara);
            SqlDataReader dr = cmd.ExecuteReader();
            String typeService = "";

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    typeService = (dr["libelle_type_service"]).ToString();
                }
                dr.Close();
            }
            cnx.Close();

            return typeService;
        }

        // Méthode qui permet d'obtenir un dictionnaire des types de service. 
        // @return : un objet dictionnaire qui comporte en clés les id des types de service et en valeurs les types de service.
        public Dictionary<int, string> ChargerListeTypeService()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connStr;
            cnx.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnx;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.ExtractCategoriesService";
            SqlDataReader dr = cmd.ExecuteReader();
            Dictionary<int, string> listeTypeService = new Dictionary<int, string>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listeTypeService.Add((int)dr["id_type_service"], (string)dr["libelle_type_service"]);
                }
                dr.Close();
            }
            cnx.Close();
            return listeTypeService;
        }
    }
}