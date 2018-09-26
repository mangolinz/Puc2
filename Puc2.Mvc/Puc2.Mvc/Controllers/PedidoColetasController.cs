using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Puc2.Mvc.Context;
using Puc2.Mvc.Entidades;
using Puc2.Mvc.Atributos;
using Puc2.Controllers.Extensions;

namespace Puc2.Mvc.Controllers
{
    [MinhaAutenticacao]
    public class PedidoColetasController : ControlerPuc
    {
        private Puc2.RegraDeNegocio.PedidoColeta _negocioPedidoColeta;
        //private MyDbContext db = new MyDbContext();
        //private readonly Puc2.AcessoADados.Entidades.PedidoColeta pedidoColeta;

        public PedidoColetasController()
        {
            _negocioPedidoColeta = new RegraDeNegocio.PedidoColeta();
        }

        // GET: PedidoColetas
        public ActionResult Index()
        {
            //return View(db.PedidoColetas.ToList());
            return View(_negocioPedidoColeta.Listar());
        }

        // GET: PedidoColetas/Details/5
        public ActionResult Details(int? id)
        {
            ////if (id == null)
            ////{
            ////    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ////}
            ////PedidoColeta pedidoColeta = db.PedidoColetas.Find(id);
            ////if (pedidoColeta == null)
            ////{
            ////    return HttpNotFound();
            ////}
            ////return View(pedidoColeta);

            var model = _negocioPedidoColeta.PorId(id);

            return View(model);

        }

        // GET: PedidoColetas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoColetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedidoColeta,NomeCliente,EnderecoCliente,TelefoneCliente,LarguraEncomenda,AlturaEncomenda,ProfEncomenda,PesoEncomenda,EndereRetirada,EnderecoEntrega")] Modelo.PedidoColetaView pedidoColeta)
        {
            if (ModelState.IsValid)
            {
                ////db.PedidoColetas.Add(pedidoColeta);
                ////db.SaveChanges();
                ////return RedirectToAction("Index");
                int? id = _negocioPedidoColeta.Incluir(pedidoColeta);
                if (id == null)
                    return Content("Pedido Coleta não encontrada");

                return RedirectToAction("Index");
            }

            return View(pedidoColeta);
        }

        // GET: PedidoColetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo.PedidoColetaView pedidoColeta = _negocioPedidoColeta.PorId(id);
            if (pedidoColeta == null)
            {
                return HttpNotFound();
            }
            return View(pedidoColeta);
        }

        // POST: PedidoColetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedidoColeta,NomeCliente,EnderecoCliente,TelefoneCliente,LarguraEncomenda,AlturaEncomenda,ProfEncomenda,PesoEncomenda,EndereRetirada,EnderecoEntrega")] Modelo.PedidoColetaView pedidoColeta)
        {
            if (ModelState.IsValid)
            {
                ////db.Entry(pedidoColeta).State = EntityState.Modified;
                ////db.SaveChanges();

                _negocioPedidoColeta.Alterar(pedidoColeta);

                return RedirectToAction("Index");
            }
            return View(pedidoColeta);
        }

        // GET: PedidoColetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PedidoColeta pedidoColeta = db.PedidoColetas.Find(id);
            Modelo.PedidoColetaView pedidoColeta = _negocioPedidoColeta.PorId(id);
            if (pedidoColeta == null)
            {
                return HttpNotFound();
            }
            return View(pedidoColeta);
        }

        // POST: PedidoColetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ////PedidoColeta pedidoColeta = db.PedidoColetas.Find(id);
            ////db.PedidoColetas.Remove(pedidoColeta);
            ////db.SaveChanges();

            Modelo.PedidoColetaView coleta = _negocioPedidoColeta.PorId(id);
            _negocioPedidoColeta.Excluir(coleta);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _negocioPedidoColeta.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
