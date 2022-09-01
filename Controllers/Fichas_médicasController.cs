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
    public class Fichas_médicasController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Fichas_médicas
        public ActionResult Index()
        {
            var fichas_médicas = db.Fichas_médicas.Include(f => f.Niños);
            return View(fichas_médicas.ToList());
        }

        // GET: Fichas_médicas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichas_médicas fichas_médicas = db.Fichas_médicas.Find(id);
            if (fichas_médicas == null)
            {
                return HttpNotFound();
            }
            return View(fichas_médicas);
        }

        // GET: Fichas_médicas/Create
        public ActionResult Create()
        {
            ViewBag.Niño = new SelectList(db.Niños, "Niño", "Nombre");
            return View();
        }

        // POST: Fichas_médicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Código_ficha_médica,Fecha_de_emisión,Niño")] Fichas_médicas fichas_médicas)
        {
            if (ModelState.IsValid)
            {
                db.Fichas_médicas.Add(fichas_médicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Niño = new SelectList(db.Niños, "Niño", "Nombre", fichas_médicas.Niño);
            return View(fichas_médicas);
        }

        // GET: Fichas_médicas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichas_médicas fichas_médicas = db.Fichas_médicas.Find(id);
            if (fichas_médicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Niño = new SelectList(db.Niños, "Niño", "Nombre", fichas_médicas.Niño);
            return View(fichas_médicas);
        }

        // POST: Fichas_médicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Código_ficha_médica,Fecha_de_emisión,Niño")] Fichas_médicas fichas_médicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichas_médicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Niño = new SelectList(db.Niños, "Niño", "Nombre", fichas_médicas.Niño);
            return View(fichas_médicas);
        }

        // GET: Fichas_médicas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichas_médicas fichas_médicas = db.Fichas_médicas.Find(id);
            if (fichas_médicas == null)
            {
                return HttpNotFound();
            }
            return View(fichas_médicas);
        }

        // POST: Fichas_médicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Fichas_médicas fichas_médicas = db.Fichas_médicas.Find(id);
            db.Fichas_médicas.Remove(fichas_médicas);
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
