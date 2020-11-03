using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using studentmanagement.Models;

namespace studentmanagement.Controllers
{
    public class RegistrartionsController : Controller
    {
        private studEntities1 db = new studEntities1();

        // GET: Registrartions
        public ActionResult Index()
        {
            return View(db.Registrartions.ToList());
        }

        // GET: Registrartions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrartion registrartion = db.Registrartions.Find(id);
            if (registrartion == null)
            {
                return HttpNotFound();
            }
            return View(registrartion);
        }

        // GET: Registrartions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registrartions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FisrtName,MiddleName,LastName,Courseid,Batchid,PhoneNumber")] Registrartion registrartion)
        {
            if (ModelState.IsValid)
            {
                db.Registrartions.Add(registrartion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrartion);
        }

        // GET: Registrartions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrartion registrartion = db.Registrartions.Find(id);
            if (registrartion == null)
            {
                return HttpNotFound();
            }
            return View(registrartion);
        }

        // POST: Registrartions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FisrtName,MiddleName,LastName,Courseid,Batchid,PhoneNumber")] Registrartion registrartion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrartion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrartion);
        }

        // GET: Registrartions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrartion registrartion = db.Registrartions.Find(id);
            if (registrartion == null)
            {
                return HttpNotFound();
            }
            return View(registrartion);
        }

        // POST: Registrartions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registrartion registrartion = db.Registrartions.Find(id);
            db.Registrartions.Remove(registrartion);
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
