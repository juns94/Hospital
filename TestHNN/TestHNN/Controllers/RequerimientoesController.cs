using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestHNN.Models;

namespace TestHNN.Controllers
{
    public class RequerimientoesController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: Requerimientoes
        public ActionResult Index()
        {
            var requerimiento = db.Requerimiento.Include(r => r.Estado1).Include(r => r.Usuario);
            return View(requerimiento.ToList());
        }

        // GET: Requerimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // GET: Requerimientoes/Create
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Nombre");
            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre");
            return View();
        }

        // POST: Requerimientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Fecha,Solicitante,Dificultad,Plantilla,Descripcion,FechaEnviado,FechaRecibido,Estado")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Requerimiento.Add(requerimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.Estado, "Id", "Nombre", requerimiento.Estado);
            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre", requerimiento.Solicitante);
            return View(requerimiento);
        }

        // GET: Requerimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Nombre", requerimiento.Estado);
            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre", requerimiento.Solicitante);
            return View(requerimiento);
        }

        // POST: Requerimientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Fecha,Solicitante,Dificultad,Plantilla,Descripcion,FechaEnviado,FechaRecibido,Estado")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Nombre", requerimiento.Estado);
            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre", requerimiento.Solicitante);
            return View(requerimiento);
        }

        // GET: Requerimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // POST: Requerimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requerimiento requerimiento = db.Requerimiento.Find(id);
            db.Requerimiento.Remove(requerimiento);
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
