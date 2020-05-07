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
    public class NguyenLieu_MonAnController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: NguyenLieu_MonAn
        public ActionResult Index()
        {
            var nguyenLieu_MonAn = db.NguyenLieu_MonAn.Include(n => n.MonAn).Include(n => n.NguyenLieu);
            return View(nguyenLieu_MonAn.ToList());
        }

        // GET: NguyenLieu_MonAn/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu_MonAn nguyenLieu_MonAn = db.NguyenLieu_MonAn.Find(id);
            if (nguyenLieu_MonAn == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu_MonAn);
        }

        // GET: NguyenLieu_MonAn/Create
        public ActionResult Create()
        {
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn");
            ViewBag.MaNguyenLieu = new SelectList(db.NguyenLieux, "MaNguyenLieu", "TenNguyenLieu");
            return View();
        }

        // POST: NguyenLieu_MonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMonAn,MaNguyenLieu,SoLuong")] NguyenLieu_MonAn nguyenLieu_MonAn)
        {
            if (ModelState.IsValid)
            {
                db.NguyenLieu_MonAn.Add(nguyenLieu_MonAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", nguyenLieu_MonAn.MaMonAn);
            ViewBag.MaNguyenLieu = new SelectList(db.NguyenLieux, "MaNguyenLieu", "TenNguyenLieu", nguyenLieu_MonAn.MaNguyenLieu);
            return View(nguyenLieu_MonAn);
        }

        // GET: NguyenLieu_MonAn/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu_MonAn nguyenLieu_MonAn = db.NguyenLieu_MonAn.Find(id);
            if (nguyenLieu_MonAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", nguyenLieu_MonAn.MaMonAn);
            ViewBag.MaNguyenLieu = new SelectList(db.NguyenLieux, "MaNguyenLieu", "TenNguyenLieu", nguyenLieu_MonAn.MaNguyenLieu);
            return View(nguyenLieu_MonAn);
        }

        // POST: NguyenLieu_MonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMonAn,MaNguyenLieu,SoLuong")] NguyenLieu_MonAn nguyenLieu_MonAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguyenLieu_MonAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", nguyenLieu_MonAn.MaMonAn);
            ViewBag.MaNguyenLieu = new SelectList(db.NguyenLieux, "MaNguyenLieu", "TenNguyenLieu", nguyenLieu_MonAn.MaNguyenLieu);
            return View(nguyenLieu_MonAn);
        }

        // GET: NguyenLieu_MonAn/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu_MonAn nguyenLieu_MonAn = db.NguyenLieu_MonAn.Find(id);
            if (nguyenLieu_MonAn == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu_MonAn);
        }

        // POST: NguyenLieu_MonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NguyenLieu_MonAn nguyenLieu_MonAn = db.NguyenLieu_MonAn.Find(id);
            db.NguyenLieu_MonAn.Remove(nguyenLieu_MonAn);
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
