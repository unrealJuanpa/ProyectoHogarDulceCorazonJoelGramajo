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
    public class NiñosController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Niños
        public ActionResult Index()
        {
            var niños = db.Niños.Include(n => n.Géneros);
            return View(niños.ToList());
        }

        // GET: Niños/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niños niños = db.Niños.Find(id);
            if (niños == null)
            {
                return HttpNotFound();
            }
            return View(niños);
        }

        // GET: Niños/Create
        public ActionResult Create()
        {
            ViewBag.Género = new SelectList(db.Géneros, "Género", "NombreGenero");
            return View();
        }

        // POST: Niños/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Niño,Nombre,CUI_niño,Fecha_nacimiento,Género")] Niños niños)
        {
            if (ModelState.IsValid)
            {
                db.Niños.Add(niños);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Género = new SelectList(db.Géneros, "Género", "NombreGenero", niños.Género);
            return View(niños);
        }

        // GET: Niños/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niños niños = db.Niños.Find(id);
            if (niños == null)
            {
                return HttpNotFound();
            }
            ViewBag.Género = new SelectList(db.Géneros, "Género", "NombreGenero", niños.Género);
            return View(niños);
        }

        // POST: Niños/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Niño,Nombre,CUI_niño,Fecha_nacimiento,Género")] Niños niños)
        {
            if (ModelState.IsValid)
            {
                db.Entry(niños).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Género = new SelectList(db.Géneros, "Género", "NombreGenero", niños.Género);
            return View(niños);
        }

        // GET: Niños/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Niños niños = db.Niños.Find(id);
            if (niños == null)
            {
                return HttpNotFound();
            }
            return View(niños);
        }

        // POST: Niños/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Niños niños = db.Niños.Find(id);
            db.Niños.Remove(niños);
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
