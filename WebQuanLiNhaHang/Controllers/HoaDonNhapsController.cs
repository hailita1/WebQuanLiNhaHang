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
    public class HoaDonNhapsController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: HoaDonNhaps
        public ActionResult Index()
        {
            var hoaDonNhaps = db.HoaDonNhaps.Include(h => h.NhaCungCap);
            return View(hoaDonNhaps.ToList());
        }

        // GET: HoaDonNhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            return View();
        }

        // POST: HoaDonNhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDonNhap,NgayNhap,MaNhanVien,MaNhaCungCap,TongTien")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonNhaps.Add(hoaDonNhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", hoaDonNhap.MaNhaCungCap);
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", hoaDonNhap.MaNhaCungCap);
            return View(hoaDonNhap);
        }

        // POST: HoaDonNhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDonNhap,NgayNhap,MaNhanVien,MaNhaCungCap,TongTien")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonNhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", hoaDonNhap.MaNhaCungCap);
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonNhap);
        }

        // POST: HoaDonNhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            db.HoaDonNhaps.Remove(hoaDonNhap);
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
