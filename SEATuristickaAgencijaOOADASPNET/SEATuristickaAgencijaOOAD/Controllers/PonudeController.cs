using SEATuristickaAgencijaOOAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEATuristickaAgencijaOOAD.Controllers
{
    public class PonudeController : Controller
    {
        private SEAContext db = new SEAContext();
        static String error = "ok";
        public ActionResult Index()
        {

            if (error != "ok") ModelState.AddModelError("pokazi", error);
            error = "ok";
            var model = new List<Putovanje>();
            model = db.Putovanje.ToList();
            return View(model);
        }


        public ActionResult Rezervacija(string id)
        {
            //ViewBag.Message = "O agenciji";
            
            return View(id);
        }

        public ActionResult About()
        {
            ViewBag.Message = "O agenciji";

            return View();
        }
        public ActionResult OpisPutovanja(int id)
        {
            ViewBag.Message = "O agenciji";

            OpisPutovanja Model = db.OpisPutovanja.Find(id);
            return View(Model);
        }

        /*
        public ActionResult Contact()
        {
            //iskoristen api
            //return RedirectToAction("Index1", "AgencijaAzures");

        }*/

        public string funkcija(string id)
        {
            var kontroler = new OpisPutovanjaController();
            return kontroler.vratiIme(id);
        }

       
    }
}