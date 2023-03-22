using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.SanPham.ViewModel;
using WebBanGiayMVC.Service.ThongSoSanPham.ViewModel;

namespace WebBanGiayMVC.Business
{
    internal interface ISanPhamService
    {
        List<SanPham> GetAllGiaSanPhamFormat();
        List<SanPham> GetAllGiaSanPhamByNameFormat();
        SanPham GetChiTietSanPham(int id);
        List<ThongSoSanPhamHT> GetThongSoSanPhams(int id);
        List<SanPham> GetSanPhamByName(string searchSanPhamByName);
    }

    public class SanPhamService : ISanPhamService
    {
       
        SanPhamDA spDa = new SanPhamDA();

        public List<SanPham> GetAllGiaSanPhamFormat()
        {
            return spDa.GetAllGiaSanPhamFormat();
        }
        public List<SanPham> GetAllGiaSanPhamByNameFormat()
        {
            return spDa.GetAllGiaSanPhamFormat();
        }

        public List<SanPham> GetSanPhamByName(string searchSanPhamByName)
        {
            return spDa.GetSanPhamByName(searchSanPhamByName);
        }
        public List<SanPham> FilterSanPham(out int total, string keyword, int pageIndex, int pageSize)
        {
            total = 0;
            
            return spDa.FilterSanPham(out total, keyword, pageIndex, pageSize);
        }
        public bool CreateSanPham(InsertSanPhamWithDanhMucs sp)
        {
            return spDa.CreateSanPham(sp);
        }

        public bool SaveSP(InsertSanPhamFull sp)
        {
            return spDa.SaveSP(sp);
        }

        public SanPham GetChiTietSanPham(int id)
        {
           return spDa.GetChiTietSanPham(id);
        }

        public List<ThongSoSanPhamHT> GetThongSoSanPhams(int id)
        {
            return spDa.GetThongSoSanPhams(id);
        }
            
        
    }
}


