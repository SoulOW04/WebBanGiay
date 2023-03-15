using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Controllers
{
    public class CauHinhsController : Controller
    {
        private Model_Context db = new Model_Context();

        // GET: CauHinhs
        public ActionResult Index()
        {
            return View(db.CauHinhs.ToList());
        }

        // GET: CauHinhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHinh cauHinh = db.CauHinhs.Find(id);
            if (cauHinh == null)
            {
                return HttpNotFound();
            }
            return View(cauHinh);
        }

        // GET: CauHinhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CauHinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenCauHinh,MaCauHinh,GiaTriCauHinh,Loai,TrangThai,MoTa")] CauHinh cauHinh)
        {
            if (ModelState.IsValid)
            {
                db.CauHinhs.Add(cauHinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cauHinh);
        }

        // GET: CauHinhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHinh cauHinh = db.CauHinhs.Find(id);
            if (cauHinh == null)
            {
                return HttpNotFound();
            }
            return View(cauHinh);
        }

        // POST: CauHinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenCauHinh,MaCauHinh,GiaTriCauHinh,Loai,TrangThai,MoTa")] CauHinh cauHinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cauHinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cauHinh);
        }

        // GET: CauHinhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHinh cauHinh = db.CauHinhs.Find(id);
            if (cauHinh == null)
            {
                return HttpNotFound();
            }
            return View(cauHinh);
        }

        // POST: CauHinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CauHinh cauHinh = db.CauHinhs.Find(id);
            db.CauHinhs.Remove(cauHinh);
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
