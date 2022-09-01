using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoHogarDulceCorazonJoelGramajo.Models;

namespace ProyectoHogarDulceCorazonJoelGramajo.Controllers
{
    [Authorize]
    public class Estados_de_tratamientosController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Estados_de_tratamientos
        public ActionResult Index()
        {
            return View(db.Estados_de_tratamientos.ToList());
        }

        // GET: Estados_de_tratamientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados_de_tratamientos estados_de_tratamientos = db.Estados_de_tratamientos.Find(id);
            if (estados_de_tratamientos == null)
            {
                return HttpNotFound();
            }
            return View(estados_de_tratamientos);
        }

        // GET: Estados_de_tratamientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estados_de_tratamientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Estado_de_tratamiento,Nombre_estado_tratamiento")] Estados_de_tratamientos estados_de_tratamientos)
        {
            if (ModelState.IsValid)
            {
                db.Estados_de_tratamientos.Add(estados_de_tratamientos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estados_de_tratamientos);
        }

        // GET: Estados_de_tratamientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados_de_tratamientos estados_de_tratamientos = db.Estados_de_tratamientos.Find(id);
            if (estados_de_tratamientos == null)
            {
                return HttpNotFound();
            }
            return View(estados_de_tratamientos);
        }

        // POST: Estados_de_tratamientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Estado_de_tratamiento,Nombre_estado_tratamiento")] Estados_de_tratamientos estados_de_tratamientos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estados_de_tratamientos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estados_de_tratamientos);
        }

        // GET: Estados_de_tratamientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados_de_tratamientos estados_de_tratamientos = db.Estados_de_tratamientos.Find(id);
            if (estados_de_tratamientos == null)
            {
                return HttpNotFound();
            }
            return View(estados_de_tratamientos);
        }

        // POST: Estados_de_tratamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estados_de_tratamientos estados_de_tratamientos = db.Estados_de_tratamientos.Find(id);
            db.Estados_de_tratamientos.Remove(estados_de_tratamientos);
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
