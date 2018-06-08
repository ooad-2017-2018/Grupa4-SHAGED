using SEATuristickaAgencijaOOAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEATuristickaAgencijaOOAD.Controllers
{
    public class RezervacijaController : Controller
    {
        private SEAContext db = new SEAContext();
        private static int samozarezervaciju=0;
        string idKor = "1";
        // GET: Rezervacija
        public ActionResult Index(string id)
        {
            return View(id);
        }


        public String rezervacija1(String putovanje1, String idKorisnika1)
        {
            new BooksSearch();
            var x = BooksSearch.Search("love");
            

            //trazi();
            int putovanje, idKorisnika;
            Int32.TryParse(putovanje1, out putovanje);
            Int32.TryParse(idKor, out idKorisnika);
            var query1 = from a in db.Putovanje
                         where a.Id.Equals(putovanje)
                         select a;
            var rez1 = query1.FirstOrDefault();

            var samoZaID = db.Rezervacijas.ToList();
            int id = samoZaID.Count();

            var query = from a in db.Rezervacijas
                        where a.IdPutnika.Equals(idKorisnika)
                        select a;

            List<Rezervacija> rez = query.ToList();
            List<Korisnik> korisnici = new List<Korisnik>();
            foreach (Rezervacija re in rez)
            {
                var q = from k in db.Korisnik
                        where k.Id.Equals(re.IdPutnika)
                        select k;
                korisnici.AddRange(q.ToList());
            }

            if (korisnici.Count() > 20)
            {
                return "Sva mjesta su popunjena!";
            }

            Rezervacija r = new Rezervacija();
            r.IdPutovanja = rez1.Id;

            r.IdPutnika = idKorisnika;

            r.Id = id;
            db.Rezervacijas.Add(r);
            db.SaveChanges();
            return "Uspjesno ste rezervisali!";

        }
    }
}