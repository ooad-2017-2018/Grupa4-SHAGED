﻿using SEATuristickaAgencijaOOAD.Models;
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
        // GET: Rezervacija
        public ActionResult Index()
        {
            return View();
        }

        public String rezervacija1(String putovanje1, String idKorisnika1)
        {
            idKorisnika1 = "1";
            int putovanje, idKorisnika;
            Int32.TryParse(putovanje1, out putovanje);
            Int32.TryParse(idKorisnika1, out idKorisnika);
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