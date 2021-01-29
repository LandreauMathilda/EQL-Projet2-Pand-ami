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
            DemandeServiceDao demandeServiceDao = new DemandeServiceDao();
            ViewBag.listeDemandes = demandeServiceDao.AfficherDemandes();
            ViewBag.utilisateur = 2;
            TypeServiceDao typeServiceDao = new TypeServiceDao();
            ViewBag.listeTypeService = typeServiceDao.ChargerListeTypeService();
            return View();
        }

        [HttpPost]
        public ActionResult RechercherUneDemande(int idUtilisateur, int idDemande)
        {

            DaoReponse rbd = new DaoReponse();
            rbd.AjoutReponse(idUtilisateur,idDemande);
            
            return  RedirectToAction ("RechercherUneDemande");
        }
        


        public ActionResult SuiviDesDemandes()
        {
            DemandeServiceDao dao = new DemandeServiceDao();

            ViewBag.idUtilisateur = 1;
            // liste des demandes en cours
            List<DemandeService> demandesEnCoursBeneficiaire = dao.GetDemandesEnCoursBeneficiaire(ViewBag.idUtilisateur);
            ViewBag.demandesEnCours = demandesEnCoursBeneficiaire;
            foreach (DemandeService demande in ViewBag.demandesEnCours)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesEnCoursBenevole = dao.GetDemandesEnCoursBenevole(ViewBag.idUtilisateur);
            ViewBag.demandesEnCoursBenevole = demandesEnCoursBenevole;
            foreach (DemandeService demande in ViewBag.demandesEnCoursBenevole)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesNonPourvues = dao.GetDemandesNonPourvues(ViewBag.idUtilisateur);
            ViewBag.demandesNonPourvues = demandesNonPourvues;
            foreach (DemandeService demande in ViewBag.demandesNonPourvues)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesEnAttenteAValider = dao.GetDemandesEnAttenteAValider(ViewBag.idUtilisateur);
            ViewBag.demandesEnAttenteAValider = demandesEnAttenteAValider;
            foreach (DemandeService demande in ViewBag.demandesEnAttenteAValider)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesACloturerBeneficiaire = dao.GetDemandesACloturerBeneficiaire(ViewBag.idUtilisateur);
            ViewBag.demandesACloturerBeneficiaire = demandesACloturerBeneficiaire;
            foreach (DemandeService demande in ViewBag.demandesACloturerBeneficiaire)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesACloturerBenevole = dao.GetDemandesACloturerBenevole(ViewBag.idUtilisateur);
            ViewBag.demandesACloturerBenevole = demandesACloturerBenevole;
            foreach (DemandeService demande in ViewBag.demandesACloturerBenevole)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesAValiderParBeneficiaire = dao.GetDemandesAValiderParBeneficiaire(ViewBag.idUtilisateur);
            ViewBag.demandesAValiderParBeneficiaire = demandesAValiderParBeneficiaire;
            foreach (DemandeService demande in ViewBag.demandesAValiderParBeneficiaire)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
           
            return View();
        }

        [HttpPost]
        public ActionResult SuiviDesDemandes(int idDemande, int idBenevole)
        {
            DaoReponse daoReponse = new DaoReponse();
            daoReponse.MaJDateAcceptation(idDemande, idBenevole);

            DemandeServiceDao dao = new DemandeServiceDao();
            ViewBag.idUtilisateur = 1;
            // liste des demandes en cours
            List<DemandeService> demandesEnCoursBeneficiaire = dao.GetDemandesEnCoursBeneficiaire(ViewBag.idUtilisateur);
            ViewBag.demandesEnCours = demandesEnCoursBeneficiaire;
            foreach (DemandeService demande in ViewBag.demandesEnCours)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesEnCoursBenevole = dao.GetDemandesEnCoursBenevole(ViewBag.idUtilisateur);
            ViewBag.demandesEnCoursBenevole = demandesEnCoursBenevole;
            foreach (DemandeService demande in ViewBag.demandesEnCoursBenevole)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesNonPourvues = dao.GetDemandesNonPourvues(ViewBag.idUtilisateur);
            ViewBag.demandesNonPourvues = demandesNonPourvues;
            foreach (DemandeService demande in ViewBag.demandesNonPourvues)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            List<DemandeService> demandesEnAttenteAValider = dao.GetDemandesEnAttenteAValider(ViewBag.idUtilisateur);
            ViewBag.demandesEnAttenteAValider = demandesEnAttenteAValider;
            foreach (DemandeService demande in ViewBag.demandesEnAttenteAValider)
            {
                EquipementDao eqdao = new EquipementDao();
                demande.Equipements = eqdao.RecupererListeEquipement(demande.IdDemande);

            }
            // TODO : idem pour autres demandes


            return View();

        }



    }
}