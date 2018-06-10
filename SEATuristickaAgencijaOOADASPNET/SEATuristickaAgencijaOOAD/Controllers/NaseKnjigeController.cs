using SEATuristickaAgencijaOOAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEATuristickaAgencijaOOAD.Controllers
{
    public class NaseKnjigeController : Controller
    {
        // GET: NaseKnjige
        public ActionResult Index()
        {
            return View();
        }

        public string dajNaziv(Knjiga knjiga)
        {
            return knjiga.Naziv;

        }



    }
}