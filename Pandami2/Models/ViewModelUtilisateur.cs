using Pandami2.ClassesDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandami2.Models
{
    public class ViewModelUtilisateur
    {
        private Utilisateur utilisateur;
        private VilleDao villeDao;
        private GenreDAO genreDao;

        public ViewModelUtilisateur(Utilisateur utilisateur)
        {
            this.utilisateur = utilisateur;
        }

        public ViewModelUtilisateur(Utilisateur utilisateur, VilleDao villeDao, GenreDAO genreDao)
        {
            this.utilisateur = utilisateur;
            this.villeDao = villeDao;
            this.genreDao = genreDao;
        }

        public Utilisateur Utilisateur { get => utilisateur; set => utilisateur = value; }
        public VilleDao VilleDao { get => villeDao; set => villeDao = value; }
        public GenreDAO GenreDao { get => genreDao; set => genreDao = value; }


    }
}