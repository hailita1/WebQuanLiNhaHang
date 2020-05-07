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
    public class ChiTietPhieuDBsController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: ChiTietPhieuDBs
        public ActionResult Index()
        {
            var chiTietPhieuDBs = db.ChiTietPhieuDBs.Include(c => c.LoaiMon).Include(c => c.MonAn).Include(c => c.PhieuDatBan);
            return View(chiTietPhieuDBs.ToList());
        }

        // GET: ChiTietPhieuDBs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuDB chiTietPhieuDB = db.ChiTietPhieuDBs.Find(id);
            if (chiTietPhieuDB == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuDB);
        }

        // GET: ChiTietPhieuDBs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiMons, "MaLoai", "TenLoai");
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn");
            ViewBag.MaPhieu = new SelectList(db.PhieuDatBans, "MaPhieu", "MaKhach");
            return View();
        }

        // POST: ChiTietPhieuDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,MaMonAn,MaLoai,SoLuong,GiamGia,ThanhTien")] ChiTietPhieuDB chiTietPhieuDB)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuDBs.Add(chiTietPhieuDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LoaiMons, "MaLoai", "TenLoai", chiTietPhieuDB.MaLoai);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", chiTietPhieuDB.MaMonAn);
            ViewBag.MaPhieu = new SelectList(db.PhieuDatBans, "MaPhieu", "MaKhach", chiTietPhieuDB.MaPhieu);
            return View(chiTietPhieuDB);
        }

        // GET: ChiTietPhieuDBs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuDB chiTietPhieuDB = db.ChiTietPhieuDBs.Find(id);
            if (chiTietPhieuDB == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiMons, "MaLoai", "TenLoai", chiTietPhieuDB.MaLoai);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", chiTietPhieuDB.MaMonAn);
            ViewBag.MaPhieu = new SelectList(db.PhieuDatBans, "MaPhieu", "MaKhach", chiTietPhieuDB.MaPhieu);
            return View(chiTietPhieuDB);
        }

        // POST: ChiTietPhieuDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,MaMonAn,MaLoai,SoLuong,GiamGia,ThanhTien")] ChiTietPhieuDB chiTietPhieuDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiMons, "MaLoai", "TenLoai", chiTietPhieuDB.MaLoai);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", chiTietPhieuDB.MaMonAn);
            ViewBag.MaPhieu = new SelectList(db.PhieuDatBans, "MaPhieu", "MaKhach", chiTietPhieuDB.MaPhieu);
            return View(chiTietPhieuDB);
        }

        // GET: ChiTietPhieuDBs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuDB chiTietPhieuDB = db.ChiTietPhieuDBs.Find(id);
            if (chiTietPhieuDB == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuDB);
        }

        // POST: ChiTietPhieuDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietPhieuDB chiTietPhieuDB = db.ChiTietPhieuDBs.Find(id);
            db.ChiTietPhieuDBs.Remove(chiTietPhieuDB);
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
