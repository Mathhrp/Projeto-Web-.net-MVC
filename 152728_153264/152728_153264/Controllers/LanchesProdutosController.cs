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
    public class LanchesProdutosController : Controller
    {
        private DbLanchonete_ db = new DbLanchonete_();

        // GET: LanchesProdutos
        public ActionResult Index()
        {
            var lancheProdutoes = db.LancheProdutoes.Include(l => l.Lanche).Include(l => l.Produto);
            return View(lancheProdutoes.ToList());
        }

        // GET: LanchesProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LancheProduto lancheProduto = db.LancheProdutoes.Find(id);
            if (lancheProduto == null)
            {
                return HttpNotFound();
            }
            return View(lancheProduto);
        }

        // GET: LanchesProdutos/Create
        public ActionResult Create()
        {
            ViewBag.LancheId = new SelectList(db.Lanches, "LancheID", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoID", "Nome");
            return View();
        }

        // POST: LanchesProdutos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LancheProdutoId,qtde,ProdutoId,LancheId")] LancheProduto lancheProduto)
        {
            if (ModelState.IsValid)
            {
                db.LancheProdutoes.Add(lancheProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LancheId = new SelectList(db.Lanches, "LancheID", "Nome", lancheProduto.LancheId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoID", "Nome", lancheProduto.ProdutoId);
            return View(lancheProduto);
        }

        // GET: LanchesProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LancheProduto lancheProduto = db.LancheProdutoes.Find(id);
            if (lancheProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.LancheId = new SelectList(db.Lanches, "LancheID", "Nome", lancheProduto.LancheId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoID", "Nome", lancheProduto.ProdutoId);
            return View(lancheProduto);
        }

        // POST: LanchesProdutos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LancheProdutoId,qtde,ProdutoId,LancheId")] LancheProduto lancheProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lancheProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LancheId = new SelectList(db.Lanches, "LancheID", "Nome", lancheProduto.LancheId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoID", "Nome", lancheProduto.ProdutoId);
            return View(lancheProduto);
        }

        // GET: LanchesProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LancheProduto lancheProduto = db.LancheProdutoes.Find(id);
            if (lancheProduto == null)
            {
                return HttpNotFound();
            }
            return View(lancheProduto);
        }

        // POST: LanchesProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LancheProduto lancheProduto = db.LancheProdutoes.Find(id);
            db.LancheProdutoes.Remove(lancheProduto);
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
