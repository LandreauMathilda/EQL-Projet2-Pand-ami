using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandami2.Models;
using Pandami2.ClassesDao;

namespace Pandami2.Controllers
{
    public class GestionDesDemandesController : Controller
    {
        // GET: GestionDesDemandes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeposerUneDemande()
        {
            ViewModelDemandeService viewModelDemandeService = new ViewModelDemandeService(1);
            return View(viewModelDemandeService);
        }

        [HttpPost]
        public ActionResult DeposerUneDemande(int idEmetteur, DateTime dateEnregistrement, DateTime dateRealisation, DateTime heureRealisation,
        string adresseRealisation, int? idVille, int idTypeService, int? idEquipement, DateTime? dateAnnulation, DateTime? dateCloture,
            DateTime? dateNonFinalisation, int? idMotifAnnulation)
        {
            DateTime dateHeureRealisation = new DateTime(dateRealisation.Year, dateRealisation.Month, dateRealisation.Day, heureRealisation.Hour, heureRealisation.Minute, heureRealisation.Second);
            DemandeServiceDao dao = new DemandeServiceDao();
            dao.AjouterDemande(idEmetteur, dateEnregistrement, dateHeureRealisation, adresseRealisation, idVille, idTypeService, dateAnnulation,
                dateCloture, dateNonFinalisation, idMotifAnnulation);
            if (idEquipement != null)
            {
                EquipementDao equipementDao = new EquipementDao();
                equipementDao.AjouterEquipementDemande(idEquipement);
            }
            ViewModelDemandeService viewModelDemandeService = new ViewModelDemandeService(1);
            ViewBag.Message = "Votre demande a bien été enregistrée!";
            return View(viewModelDemandeService);
        }

        public ActionResult RechercherUneDemande()
        {
            ViewModelDemandeService viewModelDemandeService = new ViewModelDemandeService(1);
            return View(viewModelDemandeService);
        }

        [HttpPost]
        public ActionResult RechercherUneDemande(int idUtilisateur, int idDemande)
        {
            // faire une méthode qui à partir de idUtilisateur et idDemande insère dans la table reponse un idUtilisateur, un idDemande
            ViewModelDemandeService viewModelDemandeService = new ViewModelDemandeService(1);
            return View(viewModelDemandeService);
        }


        public ActionResult SuiviDesDemandes()
        {
            return View();
        }
        public ActionResult ListeDesDemandes ()
        {
            DemandeService demande = new DemandeService();
            return View(demande);
        }


    }
}