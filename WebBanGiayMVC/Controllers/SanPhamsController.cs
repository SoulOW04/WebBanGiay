using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.SanPham.ViewModel;

namespace WebBanGiayMVC.Controllers
{
    public class SanPhamsController : Controller
    {
        private Model_Context db = new Model_Context();
        SanPhamTrongDanhMucService sanPhamTrongDanhMucService;
        CauHinhService cauHinhService;
        DanhMucService danhMucService;
        SanPhamService sanPhamService;
        SanPham sp;
        ThongSoSanPhamService thongSoSanPhamService;
        

        CauHinh cauHinh = new CauHinh();

        // GET: SanPhams
        public SanPhamsController() {
            cauHinhService = new CauHinhService();
            sanPhamTrongDanhMucService = new SanPhamTrongDanhMucService();
            thongSoSanPhamService = new ThongSoSanPhamService();
            sanPhamService = new SanPhamService();
            sp = new SanPham();
            danhMucService = new DanhMucService();
        }

        public ActionResult Index(int? page, string searchSanPhamByName, string currentFilter)
        {
            var sanPham = sanPhamService.GetAllGiaSanPhamFormat();

            if (sanPham != null)
            {
                ViewBag.SanPham = sanPham;
            }

            //lay cau hinh logo
            var cauHinhLogo = cauHinhService.GetCauHinhByMaCauHinh("Logo");
            if (cauHinhLogo != null)
            {
                ViewBag.Logo = cauHinhLogo.GiaTriCauHinh;
            }

            var sanpham = from s in db.SanPhams
                          select s;
            if (searchSanPhamByName != null)
                page = 1;
            else
                searchSanPhamByName = currentFilter;

            ViewBag.CurrentFilter = searchSanPhamByName;

            if (!String.IsNullOrEmpty(searchSanPhamByName))
                sanpham = sanpham.Where(s => s.TenSanPham.Contains(searchSanPhamByName));

            sanpham = sanpham.OrderBy(s => s.TenSanPham);

            int pageSize = 5;
            int No_Of_Page = (page ?? 1);

            return View();
        }

        public ActionResult About()
        {
            var cauHinhProc = cauHinhService.GetCauHinhByMaCauHinh("About");
            if (cauHinhProc != null)
            {
                ViewBag.Anh = cauHinhProc.GiaTriCauHinh;
                ViewBag.TieuDe = cauHinhProc.TenCauHinh;
                ViewBag.MoTa = cauHinhProc.MoTa;
            }
            return View();
        }
        public ActionResult Add_To_Wishlist()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Order_Complete()
        {
            return View();
        }
        public ActionResult Product_Detail(int id)
        {
            var product = new ThongSoSanPhamDA().GetThongTinSanPhamById(id);

            return View(product);
        }
        public ActionResult AdminIndex()
        {
            var sanPham = sanPhamService.GetAllGiaSanPhamFormat();

            if (sanPham != null)
            {
                ViewBag.SanPham = sanPham;
            }
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
        }
        // GET: CauHinhs/Create
        public ActionResult InsertOrUpdate(int id = 0)
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                var dsDanhMuc = danhMucService.GetAllDanhMuc();
                if(dsDanhMuc != null)
                {
                    ViewBag.DsDanhMuc = danhMucService.GetAllDanhMuc();
                }
                var sp = new SanPham();
                var danhMucs = new List<SanPhamTrongDanhMuc>();
                ViewBag.Title = "Create San Pham";
                ViewBag.SummitButton = "Create";
                if(id > 0)
                {
                    ViewBag.Title = "Edit San Pham";
                    ViewBag.SummitButton = "Edit";
                    sp = db.SanPhams.Find(id);
                    danhMucs = db.SanPhamTrongDanhMucs.Where(r => r.SanPhamId == id).ToList();
                    ViewBag.DtDanhMuc = danhMucs.Select(r => r.DanhMucId).ToList();
                    var thongSos = from ts in db.ThongSoSanPhams.Where(r => r.SanPhamId == id).AsQueryable()
                                  select new ThongSoInsertUpdate
                                  {
                                      ThongSoId = ts.ThongSoKiThuatId,
                                      GiaTri = ts.GiaTriSp
                                  };
                    ViewBag.ThongSo = thongSos.ToList();

                }

                var thongSoKyThuat = db.ThongSoKiThuats.ToList();
                ViewBag.ThongSoSelect = thongSoKyThuat;
                
                return View(sp);
            }
        }


        // POST: CauHinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost, ValidateInput(false)]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,TenSanPham,MoTaSanPham,GiaSanPham,AvatarSanPham,DanhSachAnhSanPham,NoiDungSanPham,HangSanPham,Loai,TrangThai")] SanPham sanPham)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SanPhams.Add(sanPham);
        //        db.SaveChanges();
        //        return RedirectToAction("AdminIndex");
        //    }

        //    return View(sanPham);
        //}

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateWithDanhMuc(InsertSanPhamWithDanhMucs sp)
        {
            //Viet gi do vao day
            var spResult = sanPhamService.CreateSanPham(sp);
            return Content("OK");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SaveSP(InsertSanPhamFull sp)
        {
            //Viet gi do vao day
            var spResult = sanPhamService.SaveSP(sp);
            return Content("OK");
        }

        // GET: CauHinhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(sanPham);
            }
            
        }

        // POST: CauHinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ValidateInput(false)]
        public ActionResult EditWithDanhMuc(InsertSanPhamWithDanhMucs sp)
        {
            //Viet gi do vao day
            var spResult = sanPhamService.CreateSanPham(sp);
            return Content("OK");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenSanPham,MoTaSanPham,GiaSanPham,AvatarSanPham,DanhSachAnhSanPham,NoiDungSanPham,HangSanPham,Loai,TrangThai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminIndex");
            }
            return View(sanPham);
        }

        // GET: CauHinhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            if (Session["Name"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(sanPham);
            }
           
        }

        // POST: CauHinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("AdminIndex");
        }



    }
}
