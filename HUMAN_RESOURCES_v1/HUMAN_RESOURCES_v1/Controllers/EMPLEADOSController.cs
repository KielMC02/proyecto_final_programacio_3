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
    public class EMPLEADOSController : Controller
    {
        private HUMAN_RESOURCES_Entities db = new HUMAN_RESOURCES_Entities();
        [Authorize]
        // GET: EMPLEADOS
        public ActionResult Index()
        {
            var eMPLEADOS = db.EMPLEADOS.Include(e => e.CARGO).Include(e => e.DEPARTAMENTO).Include(e => e.SALIDA_EMPLEADOS);
            return View(eMPLEADOS.ToList());
        }

        // GET: EMPLEADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: EMPLEADOS/Create
        public ActionResult Create()
        {
            ViewBag.id_cargo = new SelectList(db.CARGOS, "id_cargo", "nombre_cargo");
            ViewBag.id_departamento = new SelectList(db.DEPARTAMENTOS, "id_departamento", "nombre_departamento");
            ViewBag.id_salida_empleado = new SelectList(db.SALIDA_EMPLEADOS, "id_salida_empleado", "tipo_salida");
            return View();
        }

        // POST: EMPLEADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_empleado,nombre,apellido,telefono,id_departamento,id_cargo,fecha_ingreso,salario,estatus,id_salida_empleado")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADOS.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cargo = new SelectList(db.CARGOS, "id_cargo", "nombre_cargo", eMPLEADO.id_cargo);
            ViewBag.id_departamento = new SelectList(db.DEPARTAMENTOS, "id_departamento", "nombre_departamento", eMPLEADO.id_departamento);
            ViewBag.id_salida_empleado = new SelectList(db.SALIDA_EMPLEADOS, "id_salida_empleado", "tipo_salida", eMPLEADO.id_salida_empleado);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cargo = new SelectList(db.CARGOS, "id_cargo", "nombre_cargo", eMPLEADO.id_cargo);
            ViewBag.id_departamento = new SelectList(db.DEPARTAMENTOS, "id_departamento", "nombre_departamento", eMPLEADO.id_departamento);
            ViewBag.id_salida_empleado = new SelectList(db.SALIDA_EMPLEADOS, "id_salida_empleado", "tipo_salida", eMPLEADO.id_salida_empleado);
            return View(eMPLEADO);
        }

        // POST: EMPLEADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_empleado,nombre,apellido,telefono,id_departamento,id_cargo,fecha_ingreso,salario,estatus,id_salida_empleado")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cargo = new SelectList(db.CARGOS, "id_cargo", "nombre_cargo", eMPLEADO.id_cargo);
            ViewBag.id_departamento = new SelectList(db.DEPARTAMENTOS, "id_departamento", "nombre_departamento", eMPLEADO.id_departamento);
            ViewBag.id_salida_empleado = new SelectList(db.SALIDA_EMPLEADOS, "id_salida_empleado", "tipo_salida", eMPLEADO.id_salida_empleado);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADOS.Find(id);
            db.EMPLEADOS.Remove(eMPLEADO);
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
