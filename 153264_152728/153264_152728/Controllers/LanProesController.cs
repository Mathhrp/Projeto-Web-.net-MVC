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
    public class LanProesController : Controller
    {
        private DbLanches3 db = new DbLanches3();

        // GET: LanProes
        public ActionResult Index()
        {
            var lanProes = db.LanProes.Include(l => l.Produtos);
            return View(lanProes.ToList());
        }

        // GET: LanProes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanPro lanPro = db.LanProes.Find(id);
            if (lanPro == null)
            {
                return HttpNotFound();
            }
            return View(lanPro);
        }

        // GET: LanProes/Create
        public ActionResult Create()
        {
            ViewBag.IdProduto = new SelectList(db.Produtos, "IdProduto", "Nome");
            return View();
        }

        // POST: LanProes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanProId,IdProduto")] LanPro lanPro)
        {
            if (ModelState.IsValid)
            {
                db.LanProes.Add(lanPro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProduto = new SelectList(db.Produtos, "IdProduto", "Nome", lanPro.IdProduto);
            return View(lanPro);
        }

        // GET: LanProes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanPro lanPro = db.LanProes.Find(id);
            if (lanPro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProduto = new SelectList(db.Produtos, "IdProduto", "Nome", lanPro.IdProduto);
            return View(lanPro);
        }

        // POST: LanProes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanProId,IdProduto")] LanPro lanPro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lanPro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProduto = new SelectList(db.Produtos, "IdProduto", "Nome", lanPro.IdProduto);
            return View(lanPro);
        }

        // GET: LanProes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanPro lanPro = db.LanProes.Find(id);
            if (lanPro == null)
            {
                return HttpNotFound();
            }
            return View(lanPro);
        }

        // POST: LanProes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LanPro lanPro = db.LanProes.Find(id);
            db.LanProes.Remove(lanPro);
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
