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
    public class ColetasController : ControlerPuc
    {
        private Puc2.RegraDeNegocio.Coleta _negocioColeta;

        //private MyDbContext db = new MyDbContext();
        public ColetasController()
        {
            _negocioColeta = new RegraDeNegocio.Coleta();
        }

        // GET: Coletas
        public ActionResult Index()
        {
            var model = _negocioColeta.Listar();

            return View(model);
        }

        // GET: Coletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Modelo.ColetaView coleta = _negocioColeta.PorId(id);
            if (coleta == null)
                return Content("Coleta não encontrada  ");

            return View(coleta);
        }

        // GET: Coletas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedidoColeta,EndereRetirada,EnderecoEntrega")] Modelo.ColetaView coleta)
        {
            if (ModelState.IsValid)
            {
                //                db.Coletas.Add(coleta);
                //                db.SaveChanges();

                int? id = _negocioColeta.Incluir(coleta);
                if (id == null)
                    return Content("Coleta não encontrada");

                return RedirectToAction("Index");
            }

            return View(coleta);
        }

        // GET: Coletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Coleta coleta = db.Coletas.Find(id);
            Modelo.ColetaView coleta = _negocioColeta.PorId(id);
            if (coleta == null)
            {
                return HttpNotFound();
            }
            return View(coleta);
        }

        // POST: Coletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedidoColeta,EndereRetirada,EnderecoEntrega")] Modelo.ColetaView coleta)
        {
            if (ModelState.IsValid)
            {
 
                _negocioColeta.Alterar(coleta);

                return RedirectToAction("Index");
            }
            return View(coleta);
        }

        // GET: Coletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Coleta coleta = db.Coletas.Find(id);
            Modelo.ColetaView coleta = _negocioColeta.PorId(id);
            if (coleta == null)
            {
                return HttpNotFound();
            }
            return View(coleta);
        }

        // POST: Coletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Coleta coleta = db.Coletas.Find(id);
            //db.Coletas.Remove(coleta);
            //db.SaveChanges();

            Modelo.ColetaView coleta = _negocioColeta.PorId(id);
            _negocioColeta.Excluir(coleta);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _negocioColeta.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
