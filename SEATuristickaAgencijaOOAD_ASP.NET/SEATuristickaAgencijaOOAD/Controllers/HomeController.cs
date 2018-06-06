using SEATuristickaAgencijaOOAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEATuristickaAgencijaOOAD.Controllers
{
    public class HomeController : Controller
    {
        SEAContext db = new SEAContext();
        public ActionResult Index()
        {
            /*var samoZaID = db.OpisPutovanja.ToList();
            int id = samoZaID.Count();
            OpisPutovanja p = new OpisPutovanja();
            p.Id = id;
            p.naziv = "NewYork2018";
            p.planPutovanja = "Centar New Yorka je trg Times Square. Oni koji nisu bili u New Yorku ranije prepoznat će ga po blještavilu reklama sa svih krajeva. Zanimljivo je da se cijena prosječne svjetleće reklame godišnje kreće između 1 i 4 milijuna dolara. Kako ima više 230 reklama, samo pokušajte izračunati zaradu. Trg se izvorno zvao Longacre Square, no promijenio je ime kada se 1904. godine New York Timespreselio u novu zgradu Times na trgu.";
            p.putaOdrzano = 1;
            p.brojDana = 10;
            p.hotel = "https://www.roblox.com/Groups/group.aspx?gid=3676066";
            p.liveCamera = "";
            p.slika = "https://i.imgur.com/O7QbvcW.jpg";
            db.OpisPutovanja.Add(p);
            db.SaveChanges();
            
            var samoZaID1 = db.Putovanje.ToList();
            int id1 = samoZaID.Count();
            Putovanje p1 = new Putovanje();
            p1.Id = id1;
            p1.polazak = new DateTime(2018,9,5);
            p1.povratak = new DateTime(2018, 9, 15);
            p1.cijena = 1200;
            p1.kapacitet = 20;
            p1.putnici = "";
            p1.opisPutovanjaID = id;
            db.Putovanje.Add(p1);
            db.SaveChanges();*/
            return View();
        }

        public ActionResult Ponude()
        {
            ViewBag.Message = "Your application description page.";

            return View(db.Putovanje.ToList());
        }

        public ActionResult Anketa()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}