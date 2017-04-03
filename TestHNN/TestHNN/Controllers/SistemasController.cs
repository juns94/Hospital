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
    public class SistemasController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: Sistemas
        public ActionResult Index()
        {
            return View(db.Sistema.ToList());
        }

        // GET: Sistemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sistema sistema = db.Sistema.Find(id);
            if (sistema == null)
            {
                return HttpNotFound();
            }
            return View(sistema);
        }

        // GET: Sistemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sistemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion")] Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                db.Sistema.Add(sistema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sistema);
        }

        // GET: Sistemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sistema sistema = db.Sistema.Find(id);
            if (sistema == null)
            {
                return HttpNotFound();
            }
            return View(sistema);
        }

        // POST: Sistemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] Sistema sistema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sistema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sistema);
        }

        // GET: Sistemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sistema sistema = db.Sistema.Find(id);
            if (sistema == null)
            {
                return HttpNotFound();
            }
            return View(sistema);
        }

        // POST: Sistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sistema sistema = db.Sistema.Find(id);
            db.Sistema.Remove(sistema);
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
