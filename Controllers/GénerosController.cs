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
    public class GénerosController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Géneros
        public ActionResult Index()
        {
            return View(db.Géneros.ToList());
        }

        // GET: Géneros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Géneros géneros = db.Géneros.Find(id);
            if (géneros == null)
            {
                return HttpNotFound();
            }
            return View(géneros);
        }

        // GET: Géneros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Géneros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Género,NombreGenero")] Géneros géneros)
        {
            if (ModelState.IsValid)
            {
                db.Géneros.Add(géneros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(géneros);
        }

        // GET: Géneros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Géneros géneros = db.Géneros.Find(id);
            if (géneros == null)
            {
                return HttpNotFound();
            }
            return View(géneros);
        }

        // POST: Géneros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Género,NombreGenero")] Géneros géneros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(géneros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(géneros);
        }

        // GET: Géneros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Géneros géneros = db.Géneros.Find(id);
            if (géneros == null)
            {
                return HttpNotFound();
            }
            return View(géneros);
        }

        // POST: Géneros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Géneros géneros = db.Géneros.Find(id);
            db.Géneros.Remove(géneros);
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
