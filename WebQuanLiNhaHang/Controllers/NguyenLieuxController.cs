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
    public class NguyenLieuxController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: NguyenLieux
        public ActionResult Index()
        {
            return View(db.NguyenLieux.ToList());
        }

        // GET: NguyenLieux/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NguyenLieux/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguyenLieu,TenNguyenLieu,DonViTinh,SoLuong,DonGiaNhap,DonGiaBan,CongDung,YeuCau,ChongChiDinh")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                db.NguyenLieux.Add(nguyenLieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu);
        }

        // POST: NguyenLieux/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguyenLieu,TenNguyenLieu,DonViTinh,SoLuong,DonGiaNhap,DonGiaBan,CongDung,YeuCau,ChongChiDinh")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguyenLieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguyenLieu);
        }

        // GET: NguyenLieux/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu);
        }

        // POST: NguyenLieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            db.NguyenLieux.Remove(nguyenLieu);
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
