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
    public class NOMINAsController : Controller
    {
        private HUMAN_RESOURCES_Entities db = new HUMAN_RESOURCES_Entities();

        // GET: NOMINAs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.NOMINAS.ToList());
        }

        // GET: NOMINAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINAS.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // GET: NOMINAs/Create
        public ActionResult Create()
        {
            var salarios = from x in db.EMPLEADOS
                              select x;
            ViewBag.Salarios_Total = salarios.Sum(z => z.salario);
            return View();
        }

        // POST: NOMINAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_codigo,fecha_nomina,monto_total")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.NOMINAS.Add(nOMINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nOMINA);
        }

        // GET: NOMINAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINAS.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // POST: NOMINAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_codigo,fecha_nomina,monto_total")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOMINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nOMINA);
        }

        //GET: NOMINAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINAS.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // POST: NOMINAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOMINA nOMINA = db.NOMINAS.Find(id);
            db.NOMINAS.Remove(nOMINA);
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
