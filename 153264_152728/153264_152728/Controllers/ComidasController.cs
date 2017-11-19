using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _153264_152728;
using _153264_152728.Models;

namespace _153264_152728.Controllers
{
    public class ComidasController : Controller
    {
        private DbLanches3 db = new DbLanches3();

        // GET: Comidas
        public ActionResult Index()
        {
            return View(db.Comidas.ToList());
        }

        // GET: Comidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comidas comidas = db.Comidas.Find(id);
            if (comidas == null)
            {
                return HttpNotFound();
            }
            return View(comidas);
        }

        // GET: Comidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComida,Nome,Preco")] Comidas comidas)
        {
            if (ModelState.IsValid)
            {
                db.Comidas.Add(comidas);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comidas);
        }

        // GET: Comidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comidas comidas = db.Comidas.Find(id);
            if (comidas == null)
            {
                return HttpNotFound();
            }
            return View(comidas);
        }

        // POST: Comidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComida,Nome,Preco")] Comidas comidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comidas);
        }

        // GET: Comidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comidas comidas = db.Comidas.Find(id);
            if (comidas == null)
            {
                return HttpNotFound();
            }
            return View(comidas);
        }

        // POST: Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comidas comidas = db.Comidas.Find(id);
            db.Comidas.Remove(comidas);
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
