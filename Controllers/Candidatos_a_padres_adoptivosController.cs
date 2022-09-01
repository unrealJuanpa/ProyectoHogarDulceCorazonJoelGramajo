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
    public class Candidatos_a_padres_adoptivosController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Candidatos_a_padres_adoptivos
        public ActionResult Index()
        {
            return View(db.Candidatos_a_padres_adoptivos.ToList());
        }

        // GET: Candidatos_a_padres_adoptivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatos_a_padres_adoptivos candidatos_a_padres_adoptivos = db.Candidatos_a_padres_adoptivos.Find(id);
            if (candidatos_a_padres_adoptivos == null)
            {
                return HttpNotFound();
            }
            return View(candidatos_a_padres_adoptivos);
        }

        // GET: Candidatos_a_padres_adoptivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidatos_a_padres_adoptivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Padre_adoptivo,Nombre_padre,DPI,Dirección,Correo,Teléfono,Dirección_de_trabajo")] Candidatos_a_padres_adoptivos candidatos_a_padres_adoptivos)
        {
            if (ModelState.IsValid)
            {
                db.Candidatos_a_padres_adoptivos.Add(candidatos_a_padres_adoptivos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidatos_a_padres_adoptivos);
        }

        // GET: Candidatos_a_padres_adoptivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatos_a_padres_adoptivos candidatos_a_padres_adoptivos = db.Candidatos_a_padres_adoptivos.Find(id);
            if (candidatos_a_padres_adoptivos == null)
            {
                return HttpNotFound();
            }
            return View(candidatos_a_padres_adoptivos);
        }

        // POST: Candidatos_a_padres_adoptivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Padre_adoptivo,Nombre_padre,DPI,Dirección,Correo,Teléfono,Dirección_de_trabajo")] Candidatos_a_padres_adoptivos candidatos_a_padres_adoptivos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidatos_a_padres_adoptivos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidatos_a_padres_adoptivos);
        }

        // GET: Candidatos_a_padres_adoptivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatos_a_padres_adoptivos candidatos_a_padres_adoptivos = db.Candidatos_a_padres_adoptivos.Find(id);
            if (candidatos_a_padres_adoptivos == null)
            {
                return HttpNotFound();
            }
            return View(candidatos_a_padres_adoptivos);
        }

        // POST: Candidatos_a_padres_adoptivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidatos_a_padres_adoptivos candidatos_a_padres_adoptivos = db.Candidatos_a_padres_adoptivos.Find(id);
            db.Candidatos_a_padres_adoptivos.Remove(candidatos_a_padres_adoptivos);
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
