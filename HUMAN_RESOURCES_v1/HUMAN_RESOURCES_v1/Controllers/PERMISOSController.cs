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
    public class PERMISOSController : Controller
    {
        private HUMAN_RESOURCES_Entities db = new HUMAN_RESOURCES_Entities();

        // GET: PERMISOS
        public ActionResult Index()
        {
            var pERMISOS = db.PERMISOS.Include(p => p.EMPLEADO);
            return View(pERMISOS.ToList());
        }

        // GET: PERMISOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISOS.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            return View(pERMISO);
        }

        // GET: PERMISOS/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre");
            return View();
        }

        // POST: PERMISOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_permiso,id_empleado,fecha_inicio_permiso,fecha_fin_permiso,comentario_permiso")] PERMISO pERMISO)
        {
            if (ModelState.IsValid)
            {
                db.PERMISOS.Add(pERMISO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", pERMISO.id_empleado);
            return View(pERMISO);
        }

        // GET: PERMISOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISOS.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", pERMISO.id_empleado);
            return View(pERMISO);
        }

        // POST: PERMISOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_permiso,id_empleado,fecha_inicio_permiso,fecha_fin_permiso,comentario_permiso")] PERMISO pERMISO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERMISO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", pERMISO.id_empleado);
            return View(pERMISO);
        }

        // GET: PERMISOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERMISO pERMISO = db.PERMISOS.Find(id);
            if (pERMISO == null)
            {
                return HttpNotFound();
            }
            return View(pERMISO);
        }

        // POST: PERMISOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERMISO pERMISO = db.PERMISOS.Find(id);
            db.PERMISOS.Remove(pERMISO);
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







        public ActionResult PermisosTomados()
        {           
            return View(db.PERMISOS.ToList());
        }

        [HttpPost]
        public ActionResult PermisosTomados(string Nombusqueda)
        {


            var lista = from x in db.PERMISOS
                        select x;


            if (string.IsNullOrEmpty(Nombusqueda))
            {
                return View(db.PERMISOS.ToList());
            }
            else if (Nombusqueda != null)
            {
                lista = lista.Where(a => a.EMPLEADO.nombre.Equals(Nombusqueda));
                return View(lista);

            }
            else
            {
                return View(db.EMPLEADOS.ToList());
            }
          
        }








    }
}
