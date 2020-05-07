using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQuanLiNhaHang.Models;

namespace WebQuanLiNhaHang.Controllers
{
    public class QuesController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: Ques
        public ActionResult Index()
        {
            return View(db.Ques.ToList());
        }

        // GET: Ques/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Que que = db.Ques.Find(id);
            if (que == null)
            {
                return HttpNotFound();
            }
            return View(que);
        }

        // GET: Ques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQue,TenQue")] Que que)
        {
            if (ModelState.IsValid)
            {
                db.Ques.Add(que);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(que);
        }

        // GET: Ques/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Que que = db.Ques.Find(id);
            if (que == null)
            {
                return HttpNotFound();
            }
            return View(que);
        }

        // POST: Ques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQue,TenQue")] Que que)
        {
            if (ModelState.IsValid)
            {
                db.Entry(que).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(que);
        }

        // GET: Ques/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Que que = db.Ques.Find(id);
            if (que == null)
            {
                return HttpNotFound();
            }
            return View(que);
        }

        // POST: Ques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Que que = db.Ques.Find(id);
            db.Ques.Remove(que);
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
