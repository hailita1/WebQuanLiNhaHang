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
    public class PhieuDatBansController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: PhieuDatBans
        public ActionResult Index()
        {
            var phieuDatBans = db.PhieuDatBans.Include(p => p.Khach).Include(p => p.NhanVien);
            return View(phieuDatBans.ToList());
        }

        // GET: PhieuDatBans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatBan phieuDatBan = db.PhieuDatBans.Find(id);
            if (phieuDatBan == null)
            {
                return HttpNotFound();
            }
            return View(phieuDatBan);
        }

        // GET: PhieuDatBans/Create
        public ActionResult Create()
        {
            ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien");
            return View();
        }

        // POST: PhieuDatBans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,MaKhach,MaNhanVien,NgayDat,NgayDung,TongTien")] PhieuDatBan phieuDatBan)
        {
            if (ModelState.IsValid)
            {
                db.PhieuDatBans.Add(phieuDatBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach", phieuDatBan.MaKhach);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuDatBan.MaNhanVien);
            return View(phieuDatBan);
        }

        // GET: PhieuDatBans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatBan phieuDatBan = db.PhieuDatBans.Find(id);
            if (phieuDatBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach", phieuDatBan.MaKhach);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuDatBan.MaNhanVien);
            return View(phieuDatBan);
        }

        // POST: PhieuDatBans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,MaKhach,MaNhanVien,NgayDat,NgayDung,TongTien")] PhieuDatBan phieuDatBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuDatBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhach = new SelectList(db.Khaches, "MaKhach", "TenKhach", phieuDatBan.MaKhach);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "TenNhanVien", phieuDatBan.MaNhanVien);
            return View(phieuDatBan);
        }

        // GET: PhieuDatBans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatBan phieuDatBan = db.PhieuDatBans.Find(id);
            if (phieuDatBan == null)
            {
                return HttpNotFound();
            }
            return View(phieuDatBan);
        }

        // POST: PhieuDatBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuDatBan phieuDatBan = db.PhieuDatBans.Find(id);
            db.PhieuDatBans.Remove(phieuDatBan);
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
