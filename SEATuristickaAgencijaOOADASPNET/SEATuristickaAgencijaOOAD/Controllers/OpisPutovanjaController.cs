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
    public class OpisPutovanjaController : Controller
    {
        SEAContext db = new SEAContext();

        // GET: Ponude
        public ActionResult Index()
        {
            return View(db.OpisPutovanja.ToList());
        }

        public ActionResult Rezervacija()
        {   
            //putovanje gdje je id putovanja 
            return View();
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpisPutovanja ponuda = db.OpisPutovanja.Find(id);
            if (ponuda == null)
            {
                return HttpNotFound();
            }
            return View(ponuda);
        }

        public string vratiIme(string id)
        {
            string ime = string.Empty;
            int x;
            Int32.TryParse(id, out x);
            OpisPutovanja destinacijaAzure = db.OpisPutovanja.Find(x);
            if (destinacijaAzure != null)
            {
                ime = destinacijaAzure.naziv;
            }
            return ime;
        }

        public string vratiSliku(string id)
        {
            string slika = string.Empty;
            int x;
            Int32.TryParse(id, out x); 
            OpisPutovanja destinacijaAzure = db.OpisPutovanja.Find(x);
            if (destinacijaAzure != null)
            {
                slika = destinacijaAzure.slika;
            }
            return slika;
        }

        // GET: DestinacijaAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestinacijaAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,naziv,slika, brojDana, planPutovanja, hotel, liveCamera, putaOdrzano")] OpisPutovanja opisPutovanja)
        {
            if (ModelState.IsValid)
            {
                db.OpisPutovanja.Add(opisPutovanja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opisPutovanja);
        }

        // GET: DestinacijaAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpisPutovanja opisPutovanja = db.OpisPutovanja.Find(id);
            if (opisPutovanja == null)
            {
                return HttpNotFound();
            }
            return View(opisPutovanja);
        }

        // POST: DestinacijaAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv,slika, brojDana, planPutovanja, hotel, liveCamera, putaOdrzano")] OpisPutovanja opisPutovanja)
        {
            {
                if (ModelState.IsValid)
                {
                    db.Entry(opisPutovanja).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(opisPutovanja);
            }
        }

        // GET: DestinacijaAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpisPutovanja destinacijaAzure = db.OpisPutovanja.Find(id);
            if (destinacijaAzure == null)
            {
                return HttpNotFound();
            }
            return View(destinacijaAzure);
        }

        // POST: DestinacijaAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            OpisPutovanja destinacijaAzure = db.OpisPutovanja.Find(id);
            db.OpisPutovanja.Remove(destinacijaAzure);
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