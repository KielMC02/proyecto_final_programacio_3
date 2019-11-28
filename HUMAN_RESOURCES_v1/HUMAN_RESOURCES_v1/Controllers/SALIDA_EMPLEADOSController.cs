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
    public class SALIDA_EMPLEADOSController : Controller
    {
        private HUMAN_RESOURCES_Entities db = new HUMAN_RESOURCES_Entities();

        // GET: SALIDA_EMPLEADOS
        public ActionResult Index()
        {
            return View(db.SALIDA_EMPLEADOS.ToList());
        }

        // GET: SALIDA_EMPLEADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDA_EMPLEADOS sALIDA_EMPLEADOS = db.SALIDA_EMPLEADOS.Find(id);
            if (sALIDA_EMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(sALIDA_EMPLEADOS);
        }

        // GET: SALIDA_EMPLEADOS/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index","EMPLEADOS");
            }
            ViewBag.Id_Empleado = id;
            EMPLEADO Nombre_Empleado = db.EMPLEADOS.Find(id);
            //var Nombre_Empleado = from x in db.EMPLEADOS
            //                          where x.id_empleado == id
            //                          select x.nombre;
            ViewBag.Nombre_Empleado = Nombre_Empleado.nombre;
            ViewBag.Apellido_Empleado = Nombre_Empleado.apellido;
            return View();
        }

        // POST: SALIDA_EMPLEADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_salida_empleado,id_emplado,tipo_salida")] SALIDA_EMPLEADOS sALIDA_EMPLEADOS)
        {


            if (ModelState.IsValid)
            {
                db.SALIDA_EMPLEADOS.Add(sALIDA_EMPLEADOS);
                db.SaveChanges();
                return RedirectToAction("Edit","EMPLEADOS",routeValues: new {id=sALIDA_EMPLEADOS.id_emplado});
            }

            return View(sALIDA_EMPLEADOS);
        }

        // GET: SALIDA_EMPLEADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDA_EMPLEADOS sALIDA_EMPLEADOS = db.SALIDA_EMPLEADOS.Find(id);
            if (sALIDA_EMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(sALIDA_EMPLEADOS);
        }

        // POST: SALIDA_EMPLEADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_salida_empleado,id_emplado,tipo_salida")] SALIDA_EMPLEADOS sALIDA_EMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALIDA_EMPLEADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALIDA_EMPLEADOS);
        }

        // GET: SALIDA_EMPLEADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            SALIDA_EMPLEADOS sALIDA_EMPLEADOS = db.SALIDA_EMPLEADOS.Find(id);
            if (sALIDA_EMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(sALIDA_EMPLEADOS);
        }

        // POST: SALIDA_EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SALIDA_EMPLEADOS sALIDA_EMPLEADOS = db.SALIDA_EMPLEADOS.Find(id);
                db.SALIDA_EMPLEADOS.Remove(sALIDA_EMPLEADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", routeValues: new{id});
            }
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
