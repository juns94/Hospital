﻿using System;
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
    public class ComentariosController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: Comentarios
        public ActionResult Index()
        {
            var comentario = db.Comentario;
            return View(comentario.ToList());
        }
        // GET: Comentarios
        public ActionResult ShowById(int? id)
        {
            var comentario = db.Comentario.Where(c => c.Requerimiento == id);
            ViewBag.id = id;
            return View(comentario.ToList());
        }

        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Fecha,Solicitante,Requerimiento")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre", comentario.Solicitante);
            return View(comentario);
        }

        public ActionResult CreateForId()
        {
            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForId(int? id,[Bind(Include = "Id,Nombre,Fecha,Solicitante,Requerimiento")] Comentario comentario)
        {
           
                comentario.Requerimiento = (int)id;
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            

            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre", comentario.Solicitante);
            return View(comentario);
        }





        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre", comentario.Solicitante);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Fecha,Solicitante,Requerimiento")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solicitante = new SelectList(db.Usuario, "Id", "Nombre", comentario.Solicitante);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
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
