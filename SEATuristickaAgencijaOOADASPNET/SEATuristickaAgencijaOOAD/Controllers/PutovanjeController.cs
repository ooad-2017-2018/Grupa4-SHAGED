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
    public class PutovanjeController : Controller
    {
        SEAContext db = new SEAContext();
        // GET: Putovanje
        public ActionResult Index()
        {

            var model = db.Putovanje.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Putovanje model)
        {
            var data = db.Putovanje.ToList();
            return View(data);
        }

        // GET: Putovanje/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putovanje putovanjeAzure = db.Putovanje.Find(id);
            if (putovanjeAzure == null)
            {
                return HttpNotFound();
            }
            return View(putovanjeAzure);
        }

        public string vratiDatum (DateTimeOffset datum,DateTimeOffset datum1)
        {
            string dat = string.Empty;
            string dat1 = string.Empty;
            dat = datum.ToString().Substring(0, 10);
            dat1 = datum1.ToString().Substring(0, 10);
            return dat + " - " + dat1;          
        }

        // GET: Putovanje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Putovanje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,putnici, polazak, povratak, kapacitet, cijena, opisPutovanja")] Putovanje putovanjeAzure)
        {
            if (ModelState.IsValid)
            {
                db.Putovanje.Add(putovanjeAzure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(putovanjeAzure);
        }

        // GET: Putovanje/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putovanje putovanjeAzure = db.Putovanje.Find(id);
            if (putovanjeAzure == null)
            {
                return HttpNotFound();
            }
            return View(putovanjeAzure);
        }

        // POST: Putovanje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,datumPolaska,datumPovratka,minBrojPutnika,maxBrojPutnika,opisPutovanja,istaknuto,idAgencije,idDestinacije,idHotela,idPrevoz,cijena")] Putovanje putovanjeAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(putovanjeAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(putovanjeAzure);
        }

        // GET: Putovanje/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putovanje putovanjeAzure = db.Putovanje.Find(id);
            if (putovanjeAzure == null)
            {
                return HttpNotFound();
            }
            return View(putovanjeAzure);
        }

        // POST: Putovanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Putovanje putovanjeAzure = db.Putovanje.Find(id);
            db.Putovanje.Remove(putovanjeAzure);
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