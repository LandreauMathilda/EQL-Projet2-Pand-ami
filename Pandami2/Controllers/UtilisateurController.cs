using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandami2.Controllers
{
    public class UtilisateurController : Controller
    {
        // GET: Utilisateur
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConnexionInscription()
        {
            return View();
        }

        public ActionResult Profil()
        {
            return View();
        }
    }
}