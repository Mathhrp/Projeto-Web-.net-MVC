using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _152728_153264;
using _152728_153264.Models;

namespace _152728_153264.Controllers
{
    public class PedidosLanchesController : Controller
    {
<<<<<<< HEAD
        private _DbLanchonete db = new _DbLanchonete();
=======
        private DbLanchonete_ db = new DbLanchonete_();
>>>>>>> e176fdd3a9ca0d54986575dc07965d2da4d198ea

        // GET: PedidosLanches
        public ActionResult Index()
        {
            var pedidoLanches = db.PedidoLanches.Include(p => p.Lanche).Include(p => p.Pedido);
            return View(pedidoLanches.ToList());
        }

        // GET: PedidosLanches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoLanche pedidoLanche = db.PedidoLanches.Find(id);
            if (pedidoLanche == null)
            {
                return HttpNotFound();
            }
            return View(pedidoLanche);
        }

        // GET: PedidosLanches/Create
        public ActionResult Create()
        {
            ViewBag.LancheId = new SelectList((from a in db.Lanches
                                               join
                          b in db.LancheProdutoes on a.LancheID equals b.LancheId
                                               join c in db.Produtoes on b.ProdutoId equals c.ProdutoID
                                               where c.qtde - b.qtde > 0
                                               select a).ToList(), "LancheID", "Nome");
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "Nome");

            return View();
        }

        // POST: PedidosLanches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoLancheId,PedidoId,LancheId")] PedidoLanche pedidoLanche)
        {
            if (ModelState.IsValid)
            {
                db.PedidoLanches.Add(pedidoLanche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LancheId = new SelectList(db.Lanches, "LancheID", "Nome", pedidoLanche.LancheId);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "Nome", pedidoLanche.PedidoId);
            return View(pedidoLanche);
        }

        // GET: PedidosLanches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoLanche pedidoLanche = db.PedidoLanches.Find(id);
            if (pedidoLanche == null)
            {
                return HttpNotFound();
            }
            ViewBag.LancheId = new SelectList(db.Lanches, "LancheID", "Nome", pedidoLanche.LancheId);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "Nome", pedidoLanche.PedidoId);
            return View(pedidoLanche);
        }

        // POST: PedidosLanches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoLancheId,PedidoId,LancheId")] PedidoLanche pedidoLanche)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoLanche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LancheId = new SelectList(db.Lanches, "LancheID", "Nome", pedidoLanche.LancheId);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "Nome", pedidoLanche.PedidoId);
            return View(pedidoLanche);
        }

        // GET: PedidosLanches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoLanche pedidoLanche = db.PedidoLanches.Find(id);
            if (pedidoLanche == null)
            {
                return HttpNotFound();
            }
            return View(pedidoLanche);
        }

        // POST: PedidosLanches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoLanche pedidoLanche = db.PedidoLanches.Find(id);
            db.PedidoLanches.Remove(pedidoLanche);
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
