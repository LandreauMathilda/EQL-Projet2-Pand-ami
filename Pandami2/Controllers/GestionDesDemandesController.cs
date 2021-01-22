using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        public ActionResult RechercherUneDemande()
        {
            return View();
        }

        public ActionResult SuiviDesDemandes()
        {
            return View();
        }
    }
}