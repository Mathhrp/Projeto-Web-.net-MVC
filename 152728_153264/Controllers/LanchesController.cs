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
    public class LanchesController : Controller
    {
        private DbLanchonete_ db = new DbLanchonete_();

        // GET: Lanches
        public ActionResult Index()
        {
            return View(db.Lanches.ToList());
        }

        // GET: Lanches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Lanche lanche = db.Lanches.Find(id);
            lanche.LancheProduto = (from a in db.LancheProdutoes
                                    where a.LancheId == id
                                    select a).ToList();

            ViewBag.Produtos = db.Produtoes.ToList();

            if (lanche == null)
            {
                return HttpNotFound();
            }
            return View(lanche);
        }

        // GET: Lanches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lanches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LancheID,Nome,Preco")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                db.Lanches.Add(lanche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lanche);
        }

        // GET: Lanches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lanche lanche = db.Lanches.Find(id);
            if (lanche == null)
            {
                return HttpNotFound();
            }
            return View(lanche);
        }

        // POST: Lanches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LancheID,Nome,Preco")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lanche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lanche);
        }

        // GET: Lanches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lanche lanche = db.Lanches.Find(id);
            if (lanche == null)
            {
                return HttpNotFound();
            }
            return View(lanche);
        }

        // POST: Lanches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lanche lanche = db.Lanches.Find(id);
            db.Lanches.Remove(lanche);
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


        public ActionResult getProdutos(int Id)
        {
            var lista = db.Lanches.Find(Id).LancheProduto.ToList();

            List<Produto> listaT = new List<Produto>();
            foreach (var item in lista)
            {
                Produto a = new Produto();
                a.ProdutoID = item.ProdutoId;
                a.Nome = item.Produto.Nome;
                listaT.Add(a);
            }

            return Json(listaT, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeletaProduto(int Id, int ProdutoId)
        {
            Produto produto = db.Produtoes.Find(ProdutoId);
            Lanche lanche = db.Lanches.Find(Id);
            var produtolanchel = db.LancheProdutoes.Where(x => x.LancheId == Id && x.ProdutoId == ProdutoId).ToList();
           LancheProduto produtolanche = produtolanchel.Find(x => x.LancheId == Id && x.ProdutoId == ProdutoId);
            produto.LancheProduto.Remove(produtolanche);
            lanche.LancheProduto.Remove(produtolanche);
            db.LancheProdutoes.Remove(produtolanche);
            db.Entry(produto).State = EntityState.Modified;
            db.Entry(lanche).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new Lanche(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult AdicionaProduto(int Id, int ProdutoId)
        {
            Lanche lanche = db.Lanches.Find(Id);

            LancheProduto a = lanche.LancheProduto.ToList().Find(x => x.LancheId == Id && x.ProdutoId == ProdutoId);
            if (a == null)
            {
                Produto team = db.Produtoes.Find(ProdutoId);
                LancheProduto x = new LancheProduto();
                x.Produto = team;
                x.ProdutoId = ProdutoId;
                x.LancheId = Id;
                x.Lanche = lanche;
                lanche.LancheProduto.Add(x);
                team.LancheProduto.Add(x);
                db.LancheProdutoes.Add(x);
                db.Entry(lanche).State = EntityState.Modified;
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new Lanche(), JsonRequestBehavior.AllowGet);
        }


    }
}
