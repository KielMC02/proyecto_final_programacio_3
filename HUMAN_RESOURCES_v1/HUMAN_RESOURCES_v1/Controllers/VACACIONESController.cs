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
    public class VACACIONESController : Controller
    {
        private HUMAN_RESOURCES_Entities db = new HUMAN_RESOURCES_Entities();

        
        public ActionResult Index()
        {
            var vACACIONES = db.VACACIONES.Include(v => v.EMPLEADO);
            return View(vACACIONES.ToList());
        }

      
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

        
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre");
            return View();
        }

        
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
