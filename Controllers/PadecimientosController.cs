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
    public class PadecimientosController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Padecimientos
        public ActionResult Index()
        {
            return View(db.Padecimientos.ToList());
        }

        // GET: Padecimientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padecimientos padecimientos = db.Padecimientos.Find(id);
            if (padecimientos == null)
            {
                return HttpNotFound();
            }
            return View(padecimientos);
        }

        // GET: Padecimientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Padecimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Padecimiento,Nombre_padecimiento,Notas_adicionales")] Padecimientos padecimientos)
        {
            if (ModelState.IsValid)
            {
                db.Padecimientos.Add(padecimientos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(padecimientos);
        }

        // GET: Padecimientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padecimientos padecimientos = db.Padecimientos.Find(id);
            if (padecimientos == null)
            {
                return HttpNotFound();
            }
            return View(padecimientos);
        }

        // POST: Padecimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Padecimiento,Nombre_padecimiento,Notas_adicionales")] Padecimientos padecimientos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(padecimientos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(padecimientos);
        }

        // GET: Padecimientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padecimientos padecimientos = db.Padecimientos.Find(id);
            if (padecimientos == null)
            {
                return HttpNotFound();
            }
            return View(padecimientos);
        }

        // POST: Padecimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Padecimientos padecimientos = db.Padecimientos.Find(id);
            db.Padecimientos.Remove(padecimientos);
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
