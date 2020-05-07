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
    public class ChiTietHoaDonNhapsController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: ChiTietHoaDonNhaps
        public ActionResult Index()
        {
            var chiTietHoaDonNhaps = db.ChiTietHoaDonNhaps.Include(c => c.HoaDonNhap).Include(c => c.NguyenLieu);
            return View(chiTietHoaDonNhaps.ToList());
        }

        // GET: ChiTietHoaDonNhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonNhap chiTietHoaDonNhap = db.ChiTietHoaDonNhaps.Find(id);
            if (chiTietHoaDonNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDonNhap);
        }

        // GET: ChiTietHoaDonNhaps/Create
        public ActionResult Create()
        {
            ViewBag.MaHoaDonNhap = new SelectList(db.HoaDonNhaps, "MaHoaDonNhap", "MaNhanVien");
            ViewBag.MaNguyenLieu = new SelectList(db.NguyenLieux, "MaNguyenLieu", "TenNguyenLieu");
            return View();
        }

        // POST: ChiTietHoaDonNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguyenLieu,MaHoaDonNhap,SoLuong,DonGia,KhuyenMai,ThanhTien")] ChiTietHoaDonNhap chiTietHoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDonNhaps.Add(chiTietHoaDonNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHoaDonNhap = new SelectList(db.HoaDonNhaps, "MaHoaDonNhap", "MaNhanVien", chiTietHoaDonNhap.MaHoaDonNhap);
            ViewBag.MaNguyenLieu = new SelectList(db.NguyenLieux, "MaNguyenLieu", "TenNguyenLieu", chiTietHoaDonNhap.MaNguyenLieu);
            return View(chiTietHoaDonNhap);
        }

        // GET: ChiTietHoaDonNhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonNhap chiTietHoaDonNhap = db.ChiTietHoaDonNhaps.Find(id);
            if (chiTietHoaDonNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHoaDonNhap = new SelectList(db.HoaDonNhaps, "MaHoaDonNhap", "MaNhanVien", chiTietHoaDonNhap.MaHoaDonNhap);
            ViewBag.MaNguyenLieu = new SelectList(db.NguyenLieux, "MaNguyenLieu", "TenNguyenLieu", chiTietHoaDonNhap.MaNguyenLieu);
            return View(chiTietHoaDonNhap);
        }

        // POST: ChiTietHoaDonNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguyenLieu,MaHoaDonNhap,SoLuong,DonGia,KhuyenMai,ThanhTien")] ChiTietHoaDonNhap chiTietHoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHoaDonNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHoaDonNhap = new SelectList(db.HoaDonNhaps, "MaHoaDonNhap", "MaNhanVien", chiTietHoaDonNhap.MaHoaDonNhap);
            ViewBag.MaNguyenLieu = new SelectList(db.NguyenLieux, "MaNguyenLieu", "TenNguyenLieu", chiTietHoaDonNhap.MaNguyenLieu);
            return View(chiTietHoaDonNhap);
        }

        // GET: ChiTietHoaDonNhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonNhap chiTietHoaDonNhap = db.ChiTietHoaDonNhaps.Find(id);
            if (chiTietHoaDonNhap == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDonNhap);
        }

        // POST: ChiTietHoaDonNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietHoaDonNhap chiTietHoaDonNhap = db.ChiTietHoaDonNhaps.Find(id);
            db.ChiTietHoaDonNhaps.Remove(chiTietHoaDonNhap);
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
