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
    public class Regreso_de_niñosController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Regreso_de_niños
        public ActionResult Index()
        {
            var regreso_de_niños = db.Regreso_de_niños.Include(r => r.Adopciones);
            return View(regreso_de_niños.ToList());
        }

        // GET: Regreso_de_niños/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regreso_de_niños regreso_de_niños = db.Regreso_de_niños.Find(id);
            if (regreso_de_niños == null)
            {
                return HttpNotFound();
            }
            return View(regreso_de_niños);
        }

        // GET: Regreso_de_niños/Create
        public ActionResult Create()
        {
            ViewBag.Adopción_de_niño = new SelectList(db.Adopciones, "Adopción_de_niño", "Adopción_de_niño");
            return View();
        }

        // POST: Regreso_de_niños/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Regreso_de_niño,Adopción_de_niño,Fecha_regreso,Motivo_regreso")] Regreso_de_niños regreso_de_niños)
        {
            if (ModelState.IsValid)
            {
                db.Regreso_de_niños.Add(regreso_de_niños);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Adopción_de_niño = new SelectList(db.Adopciones, "Adopción_de_niño", "Adopción_de_niño", regreso_de_niños.Adopción_de_niño);
            return View(regreso_de_niños);
        }

        // GET: Regreso_de_niños/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regreso_de_niños regreso_de_niños = db.Regreso_de_niños.Find(id);
            if (regreso_de_niños == null)
            {
                return HttpNotFound();
            }
            ViewBag.Adopción_de_niño = new SelectList(db.Adopciones, "Adopción_de_niño", "Adopción_de_niño", regreso_de_niños.Adopción_de_niño);
            return View(regreso_de_niños);
        }

        // POST: Regreso_de_niños/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Regreso_de_niño,Adopción_de_niño,Fecha_regreso,Motivo_regreso")] Regreso_de_niños regreso_de_niños)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regreso_de_niños).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Adopción_de_niño = new SelectList(db.Adopciones, "Adopción_de_niño", "Adopción_de_niño", regreso_de_niños.Adopción_de_niño);
            return View(regreso_de_niños);
        }

        // GET: Regreso_de_niños/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regreso_de_niños regreso_de_niños = db.Regreso_de_niños.Find(id);
            if (regreso_de_niños == null)
            {
                return HttpNotFound();
            }
            return View(regreso_de_niños);
        }

        // POST: Regreso_de_niños/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regreso_de_niños regreso_de_niños = db.Regreso_de_niños.Find(id);
            db.Regreso_de_niños.Remove(regreso_de_niños);
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
