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
    public class ThongSoKiThuatsController : Controller
    {
        private Model_Context db = new Model_Context();

        // GET: ThongSoKiThuats
        public ActionResult Index()
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(db.ThongSoKiThuats.ToList());   
            }

        }

        // GET: ThongSoKiThuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongSoKiThuat thongSoKiThuat = db.ThongSoKiThuats.Find(id);
            if (thongSoKiThuat == null)
            {
                return HttpNotFound();
            }
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(thongSoKiThuat);
            }
            return View();
        }

        // GET: ThongSoKiThuats/Create
        public ActionResult Create()
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }

        // POST: ThongSoKiThuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StyleSanPham,Mau,KichThuocSanPham")] ThongSoKiThuat thongSoKiThuat)
        {
            if (ModelState.IsValid)
            {
                db.ThongSoKiThuats.Add(thongSoKiThuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongSoKiThuat);
        }

        // GET: ThongSoKiThuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongSoKiThuat thongSoKiThuat = db.ThongSoKiThuats.Find(id);
            if (thongSoKiThuat == null)
            {
                return HttpNotFound();
            }
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(thongSoKiThuat);
            }
            
        }

        // POST: ThongSoKiThuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StyleSanPham,Mau,KichThuocSanPham")] ThongSoKiThuat thongSoKiThuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongSoKiThuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongSoKiThuat);
        }

        // GET: ThongSoKiThuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongSoKiThuat thongSoKiThuat = db.ThongSoKiThuats.Find(id);
            if (thongSoKiThuat == null)
            {
                return HttpNotFound();
            }
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(thongSoKiThuat);
            }
            
        }

        // POST: ThongSoKiThuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongSoKiThuat thongSoKiThuat = db.ThongSoKiThuats.Find(id);
            db.ThongSoKiThuats.Remove(thongSoKiThuat);
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
