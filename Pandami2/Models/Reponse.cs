using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisioForge.Shared.MediaFoundation.OPM;

namespace Pandami2.Models
{
    public class Reponse
    {
        int id_reponse;
        int id_utilisateur;
        int id_demande;
        DateTime date_reponse;
        DateTime date_acceptation;
        DateTime date_refus;
        DateTime date_annulation_participation;
        Utilisateur utilisateur;
        DemandeService demande;

        public int Id_reponse { get => id_reponse; }
        public int Id_utilisateur { get => id_utilisateur; }
        public int Id_demande { get => id_demande; }
        public DateTime Date_reponse { get => date_reponse; set => date_reponse = value; }
        public DateTime Date_acceptation { get => date_acceptation; set => date_acceptation = value; }
        public DateTime Date_refus { get => date_refus; set => date_refus = value; }
        public DateTime Date_annulation_participation { get => date_annulation_participation; set => date_annulation_participation = value; }
        public Utilisateur Utilisateur { get => utilisateur; set => utilisateur = value; }
        public DemandeService Demande { get => demande; set => demande = value; }

        public Reponse()
        {
        }
        public Reponse(DateTime date_reponse, DateTime date_acceptation, DateTime date_refus, DateTime date_annulation_participation, Utilisateur utilisateur, DemandeService demande)
        {
            this.date_reponse = date_reponse;
            this.date_acceptation = date_acceptation;
            this.date_refus = date_refus;
            this.date_annulation_participation = date_annulation_participation;
            this.utilisateur = utilisateur;
            this.demande = demande;
        }
        public Reponse(int id_utilisateur, int id_demande, DateTime date_reponse)
        {
            this.id_utilisateur = id_utilisateur;
            this.id_demande = id_demande;
            this.date_reponse = date_reponse;
        }
    }
}