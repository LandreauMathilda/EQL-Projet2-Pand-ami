using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandami2.Models;

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
            DemandeService demandeService = new DemandeService(1);
            return View(demandeService);
        }

        public ActionResult RechercherUneDemande()
        {
            DemandeService demande = new DemandeService();

            return View(demande);
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