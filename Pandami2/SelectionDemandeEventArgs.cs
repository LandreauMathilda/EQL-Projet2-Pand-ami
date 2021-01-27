using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandami2
{
    public class SelectionDemandeEventArgs:EventArgs


    {

        int id_demande;

        public int Id_demande
        {
            get { return Id_demande; }
        }
        public SelectionDemandeEventArgs (int IdDemande)
        {
            id_demande = IdDemande;
        }
        
    }
}