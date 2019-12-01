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
    public class LICENCIASController : Controller
    {
        private HUMAN_RESOURCES_Entities db = new HUMAN_RESOURCES_Entities();

        // GET: LICENCIAS
        public ActionResult Index()
        {
            var lICENCIAS = db.LICENCIAS.Include(l => l.EMPLEADO);
            return View(lICENCIAS.ToList());
        }

        // GET: LICENCIAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIA lICENCIA = db.LICENCIAS.Find(id);
            if (lICENCIA == null)
            {
                return HttpNotFound();
            }
            return View(lICENCIA);
        }

        // GET: LICENCIAS/Create
        public ActionResult Create()
        {
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre");
            return View();
        }

        // POST: LICENCIAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_licencia,id_empleado,fecha_inicio_licencia,fecha_fin_licencia,motivo_licencia,comentario_varchar")] LICENCIA lICENCIA)
        {
            if (ModelState.IsValid)
            {
                db.LICENCIAS.Add(lICENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", lICENCIA.id_empleado);
            return View(lICENCIA);
        }

        // GET: LICENCIAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIA lICENCIA = db.LICENCIAS.Find(id);
            if (lICENCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", lICENCIA.id_empleado);
            return View(lICENCIA);
        }

        // POST: LICENCIAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_licencia,id_empleado,fecha_inicio_licencia,fecha_fin_licencia,motivo_licencia,comentario_varchar")] LICENCIA lICENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lICENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_empleado = new SelectList(db.EMPLEADOS, "id_empleado", "nombre", lICENCIA.id_empleado);
            return View(lICENCIA);
        }

        // GET: LICENCIAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIA lICENCIA = db.LICENCIAS.Find(id);
            if (lICENCIA == null)
            {
                return HttpNotFound();
            }
            return View(lICENCIA);
        }

        // POST: LICENCIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LICENCIA lICENCIA = db.LICENCIAS.Find(id);
            db.LICENCIAS.Remove(lICENCIA);
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
