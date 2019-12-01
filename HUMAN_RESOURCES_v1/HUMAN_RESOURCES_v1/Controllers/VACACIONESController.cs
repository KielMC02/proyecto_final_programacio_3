using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HUMAN_RESOURCES_v1.Models;

namespace HUMAN_RESOURCES_v1.Controllers
{
    public class VACACIONEsController : Controller
    {
        private HUMAN_RESOURCES_Entities db = new HUMAN_RESOURCES_Entities();

        // GET: VACACIONEs
        public ActionResult Index()
        {
            var vACACIONES = db.VACACIONES.Include(v => v.EMPLEADO);
            return View(vACACIONES.ToList());
        }

        // GET: VACACIONEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONE vACACIONE = db.VACACIONES.Find(id);
            if (vACACIONE == null)
            {
                return HttpNotFound();
            }
            return View(vACACIONE);
        }

        // GET: VACACIONEs/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre");
            return View();
        }

        // POST: VACACIONEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vacaciones,id_empleado,fecha_inicio_vacaciones,fecha_fin_vaciones,comentario_vacaiones")] VACACIONE vACACIONE)
        {
            if (ModelState.IsValid)
            {
                db.VACACIONES.Add(vACACIONE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", vACACIONE.id_empleado);
            return View(vACACIONE);
        }

        // GET: VACACIONEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONE vACACIONE = db.VACACIONES.Find(id);
            if (vACACIONE == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", vACACIONE.id_empleado);
            return View(vACACIONE);
        }

        // POST: VACACIONEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vacaciones,id_empleado,fecha_inicio_vacaciones,fecha_fin_vaciones,comentario_vacaiones")] VACACIONE vACACIONE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vACACIONE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", vACACIONE.id_empleado);
            return View(vACACIONE);
        }

        // GET: VACACIONEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONE vACACIONE = db.VACACIONES.Find(id);
            if (vACACIONE == null)
            {
                return HttpNotFound();
            }
            return View(vACACIONE);
        }

        // POST: VACACIONEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VACACIONE vACACIONE = db.VACACIONES.Find(id);
            db.VACACIONES.Remove(vACACIONE);
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
