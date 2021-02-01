using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;



namespace Pandami2.Models
{
    public class Utilisateur
    {
        int id_utilisateur;
        string nom;
        string prenom;
        int id_genre;
        DateTime date_naissance;
        string adresse;
        int id_ville;
        int num_telephone;
        string email;
        DateTime date_inscription;
        DateTime date_desinscription;
        int id_motif_desinscription;

        [Display (Name ="Id_utilisateur")]
        public int Id_utilisateur { get => id_utilisateur; set => id_utilisateur = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime Date_naissance { get => date_naissance; set => date_naissance = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public int Id_ville { get => id_ville; set => id_ville = value; }
        public int Num_telephone { get => num_telephone; set => num_telephone = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Date_inscription { get => date_inscription; set => date_inscription = value; }
        public DateTime Date_desinscription { get => date_desinscription; set => date_desinscription = value; }
        public int Id_motif_desinscription { get => id_motif_desinscription; set => id_motif_desinscription = value; }
        public int Id_genre { get => id_genre; set => id_genre = value; }

        public Utilisateur()
        {
        }
        public Utilisateur(int id_utilisateur, string nom, string prenom, int id_genre, DateTime date_naissance, string adresse, int id_ville, int num_telephone, string email,
            DateTime date_inscription, DateTime date_desinscription, int id_motif_desinscription )
        {
            this. Id_utilisateur = id_utilisateur;
            this.nom = nom;
            this.prenom = prenom;
            this.Id_genre = id_genre;
            this.date_naissance = date_naissance;
            this.adresse = adresse;
            this.id_ville = id_ville;
            this.num_telephone = num_telephone;
            this.email = email;
            this.date_inscription = date_inscription;
            this.date_desinscription = date_desinscription;
            this.id_motif_desinscription = id_motif_desinscription;
        }
    }
}