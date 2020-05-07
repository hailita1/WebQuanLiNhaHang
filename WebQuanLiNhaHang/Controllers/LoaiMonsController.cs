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
    public class LoaiMonsController : Controller
    {
        private QLNhaHangEntities db = new QLNhaHangEntities();

        // GET: LoaiMons
        public ActionResult Index()
        {
            return View(db.LoaiMons.ToList());
        }

        // GET: LoaiMons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMon loaiMon = db.LoaiMons.Find(id);
            if (loaiMon == null)
            {
                return HttpNotFound();
            }
            return View(loaiMon);
        }

        // GET: LoaiMons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiMons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiMon loaiMon)
        {
            if (ModelState.IsValid)
            {
                db.LoaiMons.Add(loaiMon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiMon);
        }

        // GET: LoaiMons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMon loaiMon = db.LoaiMons.Find(id);
            if (loaiMon == null)
            {
                return HttpNotFound();
            }
            return View(loaiMon);
        }

        // POST: LoaiMons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiMon loaiMon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMon);
        }

        // GET: LoaiMons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMon loaiMon = db.LoaiMons.Find(id);
            if (loaiMon == null)
            {
                return HttpNotFound();
            }
            return View(loaiMon);
        }

        // POST: LoaiMons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiMon loaiMon = db.LoaiMons.Find(id);
            db.LoaiMons.Remove(loaiMon);
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
