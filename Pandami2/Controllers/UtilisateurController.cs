using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pandami2.ClassesDao;
using Pandami2.Models;


namespace Pandami2.Controllers
{
    public class UtilisateurController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profil()
        {
            return View();
        }
        public ActionResult Inscription()
        {
            Utilisateur utilisateur = new Utilisateur();
            VilleDao villeDao = new VilleDao();
            GenreDAO genreDao = new GenreDAO();

           ViewModelUtilisateur u = new ViewModelUtilisateur(utilisateur,villeDao,genreDao);
            return View(u);
        }
        [HttpPost]
        public ActionResult Inscription(Utilisateur utilisateur)
        {
            DaoUtilisateur ubd = new DaoUtilisateur();
            ubd.AjoutUtilisateur(utilisateur);
            ViewBag.Message = "==========Votre Inscription s'est bien déroulée =============";
            return RedirectToAction("Inscription");
        }
    }
}