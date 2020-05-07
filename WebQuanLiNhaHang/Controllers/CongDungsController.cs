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
    public class CongDungsController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: CongDungs
        public ActionResult Index()
        {
            return View(db.CongDungs.ToList());
        }

        // GET: CongDungs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongDung congDung = db.CongDungs.Find(id);
            if (congDung == null)
            {
                return HttpNotFound();
            }
            return View(congDung);
        }

        // GET: CongDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CongDungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCongDung,TenCongDung")] CongDung congDung)
        {
            if (ModelState.IsValid)
            {
                db.CongDungs.Add(congDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congDung);
        }

        // GET: CongDungs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongDung congDung = db.CongDungs.Find(id);
            if (congDung == null)
            {
                return HttpNotFound();
            }
            return View(congDung);
        }

        // POST: CongDungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCongDung,TenCongDung")] CongDung congDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congDung);
        }

        // GET: CongDungs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongDung congDung = db.CongDungs.Find(id);
            if (congDung == null)
            {
                return HttpNotFound();
            }
            return View(congDung);
        }

        // POST: CongDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CongDung congDung = db.CongDungs.Find(id);
            db.CongDungs.Remove(congDung);
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
