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
    public class MonAnsController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: MonAns
        public ActionResult Index()
        {
            var monAns = db.MonAns.Include(m => m.CongDung);
            return View(monAns.ToList());
        }

        // GET: MonAns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // GET: MonAns/Create
        public ActionResult Create()
        {
            ViewBag.MaCongDung = new SelectList(db.CongDungs, "MaCongDung", "TenCongDung");
            return View();
        }

        // POST: MonAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMonAn,TenMonAn,MaCongDung,MaLoai,CachLam,YeuCau,DonGia")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.MonAns.Add(monAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCongDung = new SelectList(db.CongDungs, "MaCongDung", "TenCongDung", monAn.MaCongDung);
            return View(monAn);
        }

        // GET: MonAns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCongDung = new SelectList(db.CongDungs, "MaCongDung", "TenCongDung", monAn.MaCongDung);
            return View(monAn);
        }

        // POST: MonAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMonAn,TenMonAn,MaCongDung,MaLoai,CachLam,YeuCau,DonGia")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCongDung = new SelectList(db.CongDungs, "MaCongDung", "TenCongDung", monAn.MaCongDung);
            return View(monAn);
        }

        // GET: MonAns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // POST: MonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MonAn monAn = db.MonAns.Find(id);
            db.MonAns.Remove(monAn);
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
