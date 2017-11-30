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
    public class PedidosController : Controller
    {
        private DbLanchonete_ db = new DbLanchonete_();

        // GET: Pedidos
        public ActionResult Index()
        {
            return View(db.Pedidoes.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            pedido.PedidoLanche = (from a in db.PedidoLanches
                                   where a.PedidoId == id
                                   select a).ToList();

            ViewBag.Lanches = db.Lanches.ToList();
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoId,Nome,Data,Endereco")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoId,Nome,Data,Endereco")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdicionaLanche(int Id, int LancheId)
        {
            Pedido pedido = db.Pedidoes.Find(Id);

            //PedidoLanche a = pedido.PedidoLanche.ToList().Find(x => x.LancheId == LancheId && x.PedidoId == Id);

            PedidoLanche a = null;
            if (a == null)
            {
                Lanche lanche = db.Lanches.Find(LancheId);
                PedidoLanche x = new PedidoLanche();
                x.Lanche = lanche;
                x.LancheId = LancheId;
                x.PedidoId = Id;
                x.Pedido = pedido;
                pedido.PedidoLanche.Add(x);
                lanche.PedidoLanche.Add(x);
                db.PedidoLanches.Add(x);
                db.Entry(pedido).State = EntityState.Modified;
                db.Entry(lanche).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new Lanche(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeletaLanche(int Id, int LancheId)
        {
            Pedido pedido = db.Pedidoes.Find(Id);
            Lanche lanche = db.Lanches.Find(LancheId);
            var pedidolanchel = db.PedidoLanches.Where(x => x.LancheId == LancheId && x.PedidoId == Id).ToList();
            PedidoLanche pedidolanche = pedidolanchel.Find(x => x.LancheId == LancheId && x.PedidoId == Id);
            pedido.PedidoLanche.Remove(pedidolanche);
            lanche.PedidoLanche.Remove(pedidolanche);
            db.PedidoLanches.Remove(pedidolanche);
            db.Entry(pedido).State = EntityState.Modified;
            db.Entry(lanche).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new Lanche(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult getLanches(int Id)
        {
            var lista = db.Pedidoes.Find(Id).PedidoLanche.ToList();

            List<Lanche> listaT = new List<Lanche>();
            foreach (var item in lista)
            {
                Lanche a = new Lanche();
                a.LancheID = item.LancheId;
                a.Nome = item.Lanche.Nome;
                a.Preco = item.Lanche.Preco;
                listaT.Add(a);
            }

            return Json(listaT, JsonRequestBehavior.AllowGet);
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
