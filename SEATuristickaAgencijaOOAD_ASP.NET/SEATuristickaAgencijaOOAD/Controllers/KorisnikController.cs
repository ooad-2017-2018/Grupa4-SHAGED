using SEATuristickaAgencijaOOAD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SEATuristickaAgencijaOOAD.Controllers
{
    public class KorisnikController : Controller
    {
        SEAContext db = new SEAContext();
        // GET: Korisnik
        
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnikAzure = db.Korisnik.Find(id);
            if (korisnikAzure == null)
            {
                return HttpNotFound();
            }
            return View(korisnikAzure);
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return RedirectToAction("Contact", "Home");
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }


        // GET: Korisnik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, brojPasosa, spol, brojTelefona, obavijesti, osiguranje, putovanje, zadnjePutovanje, imeIprezime, datumRodjenja, email, jmbg")] Korisnik korisnikAzure)
        {//id,createdAt,updatedAt,version,deleted,
            var zaId = db.Korisnik.ToList();
            int id = zaId.Count;
            korisnikAzure.Id = id;
            

            if (ModelState.IsValid)
            {


                db.Korisnik.Add(korisnikAzure);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }


            return View(korisnikAzure);
        }






        // GET: Korisnik/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnikAzure = db.Korisnik.Find(id);
            if (korisnikAzure == null)
            {
                return HttpNotFound();
            }
            return View(korisnikAzure);
        }

        // POST: Korisnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, brojPasosa, spol, brojTelefona, obavijesti, osiguranje, putovanja, zadnjePutovanje, imeIprezime, datumRodjenja, email, jmbg")] Korisnik korisnikAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnikAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnikAzure);
        }

        // GET: Korisnik/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnikAzure = db.Korisnik.Find(id);
            if (korisnikAzure == null)
            {
                return HttpNotFound();
            }
            return View(korisnikAzure);
        }

        // POST: Korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Korisnik korisnikAzure = db.Korisnik.Find(id);
            db.Korisnik.Remove(korisnikAzure);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
