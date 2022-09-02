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
    public class LoggedMainPageController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: LoggedMainPage
        public ActionResult Index()
        {
            var adopciones = db.Adopciones.Include(a => a.Niños);
            return View(adopciones.ToList());
        }

        // GET: LoggedMainPage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = db.Adopciones.Find(id);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // GET: LoggedMainPage/Create
        public ActionResult Create()
        {
            ViewBag.Niño = new SelectList(db.Niños, "Niño", "Nombre");
            return View();
        }

        // POST: LoggedMainPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Adopción_de_niño,Niño,Fecha_adopción,Fecha_mudanza")] Adopciones adopciones)
        {
            if (ModelState.IsValid)
            {
                db.Adopciones.Add(adopciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Niño = new SelectList(db.Niños, "Niño", "Nombre", adopciones.Niño);
            return View(adopciones);
        }

        // GET: LoggedMainPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = db.Adopciones.Find(id);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Niño = new SelectList(db.Niños, "Niño", "Nombre", adopciones.Niño);
            return View(adopciones);
        }

        // POST: LoggedMainPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Adopción_de_niño,Niño,Fecha_adopción,Fecha_mudanza")] Adopciones adopciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adopciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Niño = new SelectList(db.Niños, "Niño", "Nombre", adopciones.Niño);
            return View(adopciones);
        }

        // GET: LoggedMainPage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adopciones adopciones = db.Adopciones.Find(id);
            if (adopciones == null)
            {
                return HttpNotFound();
            }
            return View(adopciones);
        }

        // POST: LoggedMainPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adopciones adopciones = db.Adopciones.Find(id);
            db.Adopciones.Remove(adopciones);
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
