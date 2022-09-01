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
    public class Asignar_padre_a_adopciónController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Asignar_padre_a_adopción
        public ActionResult Index()
        {
            var asignar_padre_a_adopción = db.Asignar_padre_a_adopción.Include(a => a.Adopciones).Include(a => a.Candidatos_a_padres_adoptivos);
            return View(asignar_padre_a_adopción.ToList());
        }

        // GET: Asignar_padre_a_adopción/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignar_padre_a_adopción asignar_padre_a_adopción = db.Asignar_padre_a_adopción.Find(id);
            if (asignar_padre_a_adopción == null)
            {
                return HttpNotFound();
            }
            return View(asignar_padre_a_adopción);
        }

        // GET: Asignar_padre_a_adopción/Create
        public ActionResult Create()
        {
            ViewBag.Adopción_de_niño = new SelectList(db.Adopciones, "Adopción_de_niño", "Adopción_de_niño");
            ViewBag.Candidato_a_padre_adoptivo = new SelectList(db.Candidatos_a_padres_adoptivos, "Padre_adoptivo", "Nombre_padre");
            return View();
        }

        // POST: Asignar_padre_a_adopción/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Padre_adopción,Adopción_de_niño,Candidato_a_padre_adoptivo")] Asignar_padre_a_adopción asignar_padre_a_adopción)
        {
            if (ModelState.IsValid)
            {
                db.Asignar_padre_a_adopción.Add(asignar_padre_a_adopción);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Adopción_de_niño = new SelectList(db.Adopciones, "Adopción_de_niño", "Adopción_de_niño", asignar_padre_a_adopción.Adopción_de_niño);
            ViewBag.Candidato_a_padre_adoptivo = new SelectList(db.Candidatos_a_padres_adoptivos, "Padre_adoptivo", "Nombre_padre", asignar_padre_a_adopción.Candidato_a_padre_adoptivo);
            return View(asignar_padre_a_adopción);
        }

        // GET: Asignar_padre_a_adopción/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignar_padre_a_adopción asignar_padre_a_adopción = db.Asignar_padre_a_adopción.Find(id);
            if (asignar_padre_a_adopción == null)
            {
                return HttpNotFound();
            }
            ViewBag.Adopción_de_niño = new SelectList(db.Adopciones, "Adopción_de_niño", "Adopción_de_niño", asignar_padre_a_adopción.Adopción_de_niño);
            ViewBag.Candidato_a_padre_adoptivo = new SelectList(db.Candidatos_a_padres_adoptivos, "Padre_adoptivo", "Nombre_padre", asignar_padre_a_adopción.Candidato_a_padre_adoptivo);
            return View(asignar_padre_a_adopción);
        }

        // POST: Asignar_padre_a_adopción/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Padre_adopción,Adopción_de_niño,Candidato_a_padre_adoptivo")] Asignar_padre_a_adopción asignar_padre_a_adopción)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignar_padre_a_adopción).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Adopción_de_niño = new SelectList(db.Adopciones, "Adopción_de_niño", "Adopción_de_niño", asignar_padre_a_adopción.Adopción_de_niño);
            ViewBag.Candidato_a_padre_adoptivo = new SelectList(db.Candidatos_a_padres_adoptivos, "Padre_adoptivo", "Nombre_padre", asignar_padre_a_adopción.Candidato_a_padre_adoptivo);
            return View(asignar_padre_a_adopción);
        }

        // GET: Asignar_padre_a_adopción/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignar_padre_a_adopción asignar_padre_a_adopción = db.Asignar_padre_a_adopción.Find(id);
            if (asignar_padre_a_adopción == null)
            {
                return HttpNotFound();
            }
            return View(asignar_padre_a_adopción);
        }

        // POST: Asignar_padre_a_adopción/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignar_padre_a_adopción asignar_padre_a_adopción = db.Asignar_padre_a_adopción.Find(id);
            db.Asignar_padre_a_adopción.Remove(asignar_padre_a_adopción);
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
