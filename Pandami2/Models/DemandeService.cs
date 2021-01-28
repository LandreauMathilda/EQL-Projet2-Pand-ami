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
        private string nomPrenomEmetteur;
        private DateTime dateEnregistrement;
        private DateTime dateRealisation;
        private string adresseRealisation;
        private int villeRealisation;
        private string libelleVilleRealisation;
        private DateTime heureRealisation;
        private int idTypeService;
        private string libelleTypeService;
        private DateTime dateAnnulation;
        private DateTime dateCloture;
        private DateTime dateNonFinalisation;
        private int idMotifAnnulation;
        private List<string> equipements;
        private string nomBenevole;
        private string codePostal;


        string connStr = ConfigurationManager.ConnectionStrings["PandamiConnectionString"].ConnectionString;
        public int IdDemande { get => idDemande; set => idDemande = value; }
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
        public string LibelleVilleRealisation { get => libelleVilleRealisation; set => libelleVilleRealisation = value; }
        public string LibelleTypeService { get => libelleTypeService; set => libelleTypeService = value; }
        public string NomPrenomEmetteur { get => nomPrenomEmetteur; set => nomPrenomEmetteur = value; }
        public string NomBenevole { get => nomBenevole; set => nomBenevole = value; }
        public string CodePostal { get => codePostal; set => codePostal = value; }
        public List<string> Equipements { get => equipements; set => equipements = value; }

        public DemandeService(int idUtilisateur)
        {
            this.idEmetteur = idUtilisateur;
        }


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

        public DemandeService (DateTime dateRealisation, string adresseRealisation, string codePostal, string libelleVilleRealisation, string libelleTypeService, string nomBenevole, int idDemande)
        {
            this.dateRealisation = dateRealisation;
            this.adresseRealisation = adresseRealisation;
            this.codePostal = codePostal;
            this.libelleVilleRealisation = libelleVilleRealisation;
            this.libelleTypeService = libelleTypeService;
            this.nomBenevole = nomBenevole;
            this.idDemande = idDemande;
        }
        public DemandeService(DateTime dateRealisation, string adresseRealisation, string codePostal, string libelleVilleRealisation, string libelleTypeService, int idDemande)
        {
            this.dateRealisation = dateRealisation;
            this.adresseRealisation = adresseRealisation;
            this.codePostal = codePostal;
            this.libelleVilleRealisation = libelleVilleRealisation;
            this.libelleTypeService = libelleTypeService;
            this.idDemande = idDemande;
        }
    }


    
}