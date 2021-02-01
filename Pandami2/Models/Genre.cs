using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandami2.Models
{
    public class Genre
    {
        int id_genre;
        string libelle_genre;

        public int Id_genre { get => id_genre;  }
        public string Libelle_genre { get => libelle_genre; set => libelle_genre = value; }
    }
}