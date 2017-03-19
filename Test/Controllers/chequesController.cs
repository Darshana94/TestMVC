using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class chequesController : Controller
    {
        private DemoEntities db = new DemoEntities();

        // GET: cheques
        public ActionResult Index()
        {
            return View(db.cheques.ToList());
        }

        // GET: cheques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cheque cheque = db.cheques.Find(id);
            if (cheque == null)
            {
                return HttpNotFound();
            }
            return View(cheque);
        }

        // GET: cheques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cheques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChequeID,Bank,Branch,Cheque_No,Amount")] cheque cheque)
        {
            if (ModelState.IsValid)
            {
                db.cheques.Add(cheque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cheque);
        }

        // GET: cheques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cheque cheque = db.cheques.Find(id);
            if (cheque == null)
            {
                return HttpNotFound();
            }
            return View(cheque);
        }

        // POST: cheques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChequeID,Bank,Branch,Cheque_No,Amount")] cheque cheque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cheque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cheque);
        }

        // GET: cheques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cheque cheque = db.cheques.Find(id);
            if (cheque == null)
            {
                return HttpNotFound();
            }
            return View(cheque);
        }

        // POST: cheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cheque cheque = db.cheques.Find(id);
            db.cheques.Remove(cheque);
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
