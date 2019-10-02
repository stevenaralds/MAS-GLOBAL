using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MASGLOBAL.Models;

namespace MASGLOBAL.Controllers
{
    public class ContractsController : Controller
    {
        private DBPrueba db = new DBPrueba();

        // GET: Contracts
        public ActionResult Index()
        {
            return View(db.Contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            return View(contracts);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contracts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,Salary")] Contracts contracts)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contracts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contracts);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            return View(contracts);
        }

        // POST: Contracts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,Salary")] Contracts contracts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contracts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contracts);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            return View(contracts);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Contracts contracts = db.Contracts.Find(id);
            db.Contracts.Remove(contracts);
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
