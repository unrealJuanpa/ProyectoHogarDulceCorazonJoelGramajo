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
    public class Asignar_padecimiento_a_ficha_médicaController : Controller
    {
        private DatabaseHogarEntities db = new DatabaseHogarEntities();

        // GET: Asignar_padecimiento_a_ficha_médica
        public ActionResult Index()
        {
            var asignar_padecimiento_a_ficha_médica = db.Asignar_padecimiento_a_ficha_médica.Include(a => a.Fichas_médicas).Include(a => a.Padecimientos).Include(a => a.Estados_de_tratamientos);
            return View(asignar_padecimiento_a_ficha_médica.ToList());
        }

        // GET: Asignar_padecimiento_a_ficha_médica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignar_padecimiento_a_ficha_médica asignar_padecimiento_a_ficha_médica = db.Asignar_padecimiento_a_ficha_médica.Find(id);
            if (asignar_padecimiento_a_ficha_médica == null)
            {
                return HttpNotFound();
            }
            return View(asignar_padecimiento_a_ficha_médica);
        }

        // GET: Asignar_padecimiento_a_ficha_médica/Create
        public ActionResult Create()
        {
            ViewBag.Código_ficha_médica = new SelectList(db.Fichas_médicas, "Código_ficha_médica", "Código_ficha_médica");
            ViewBag.Padecimiento = new SelectList(db.Padecimientos, "Padecimiento", "Nombre_padecimiento");
            ViewBag.Estado_de_tratamiento = new SelectList(db.Estados_de_tratamientos, "Estado_de_tratamiento", "Nombre_estado_tratamiento");
            return View();
        }

        // POST: Asignar_padecimiento_a_ficha_médica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Código_de_asignación_padecimiento,Fecha_de_diagnóstico,Padecimiento,Código_ficha_médica,Estado_de_tratamiento")] Asignar_padecimiento_a_ficha_médica asignar_padecimiento_a_ficha_médica)
        {
            if (ModelState.IsValid)
            {
                db.Asignar_padecimiento_a_ficha_médica.Add(asignar_padecimiento_a_ficha_médica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Código_ficha_médica = new SelectList(db.Fichas_médicas, "Código_ficha_médica", "Código_ficha_médica", asignar_padecimiento_a_ficha_médica.Código_ficha_médica);
            ViewBag.Padecimiento = new SelectList(db.Padecimientos, "Padecimiento", "Nombre_padecimiento", asignar_padecimiento_a_ficha_médica.Padecimiento);
            ViewBag.Estado_de_tratamiento = new SelectList(db.Estados_de_tratamientos, "Estado_de_tratamiento", "Nombre_estado_tratamiento", asignar_padecimiento_a_ficha_médica.Estado_de_tratamiento);
            return View(asignar_padecimiento_a_ficha_médica);
        }

        // GET: Asignar_padecimiento_a_ficha_médica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignar_padecimiento_a_ficha_médica asignar_padecimiento_a_ficha_médica = db.Asignar_padecimiento_a_ficha_médica.Find(id);
            if (asignar_padecimiento_a_ficha_médica == null)
            {
                return HttpNotFound();
            }
            ViewBag.Código_ficha_médica = new SelectList(db.Fichas_médicas, "Código_ficha_médica", "Código_ficha_médica", asignar_padecimiento_a_ficha_médica.Código_ficha_médica);
            ViewBag.Padecimiento = new SelectList(db.Padecimientos, "Padecimiento", "Nombre_padecimiento", asignar_padecimiento_a_ficha_médica.Padecimiento);
            ViewBag.Estado_de_tratamiento = new SelectList(db.Estados_de_tratamientos, "Estado_de_tratamiento", "Nombre_estado_tratamiento", asignar_padecimiento_a_ficha_médica.Estado_de_tratamiento);
            return View(asignar_padecimiento_a_ficha_médica);
        }

        // POST: Asignar_padecimiento_a_ficha_médica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Código_de_asignación_padecimiento,Fecha_de_diagnóstico,Padecimiento,Código_ficha_médica,Estado_de_tratamiento")] Asignar_padecimiento_a_ficha_médica asignar_padecimiento_a_ficha_médica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignar_padecimiento_a_ficha_médica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Código_ficha_médica = new SelectList(db.Fichas_médicas, "Código_ficha_médica", "Código_ficha_médica", asignar_padecimiento_a_ficha_médica.Código_ficha_médica);
            ViewBag.Padecimiento = new SelectList(db.Padecimientos, "Padecimiento", "Nombre_padecimiento", asignar_padecimiento_a_ficha_médica.Padecimiento);
            ViewBag.Estado_de_tratamiento = new SelectList(db.Estados_de_tratamientos, "Estado_de_tratamiento", "Nombre_estado_tratamiento", asignar_padecimiento_a_ficha_médica.Estado_de_tratamiento);
            return View(asignar_padecimiento_a_ficha_médica);
        }

        // GET: Asignar_padecimiento_a_ficha_médica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignar_padecimiento_a_ficha_médica asignar_padecimiento_a_ficha_médica = db.Asignar_padecimiento_a_ficha_médica.Find(id);
            if (asignar_padecimiento_a_ficha_médica == null)
            {
                return HttpNotFound();
            }
            return View(asignar_padecimiento_a_ficha_médica);
        }

        // POST: Asignar_padecimiento_a_ficha_médica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignar_padecimiento_a_ficha_médica asignar_padecimiento_a_ficha_médica = db.Asignar_padecimiento_a_ficha_médica.Find(id);
            db.Asignar_padecimiento_a_ficha_médica.Remove(asignar_padecimiento_a_ficha_médica);
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
