using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pandami2.ClassesDao;

namespace Pandami2.Models
{

    public class ViewModelDemandeService
    {
        private DemandeServiceDao demServiceDao;
        private EquipementDao equipmtDao;
        private TypeServiceDao typeServDao;
        private VilleDao vilDao;
        private int idEmetteur;

        public ViewModelDemandeService(int idUtilisateur)
        {
            DemServiceDao = new DemandeServiceDao();
            EquipmtDao = new EquipementDao();
            TypeServDao = new TypeServiceDao();
            VilDao = new VilleDao();
            this.idEmetteur = idUtilisateur;
        }

        public DemandeServiceDao DemServiceDao { get => demServiceDao; set => demServiceDao = value; }
        public EquipementDao EquipmtDao { get => equipmtDao; set => equipmtDao = value; }
        public TypeServiceDao TypeServDao { get => typeServDao; set => typeServDao = value; }
        public VilleDao VilDao { get => vilDao; set => vilDao = value; }
        public int IdEmetteur { get => idEmetteur; set => idEmetteur = value; }
    }
}