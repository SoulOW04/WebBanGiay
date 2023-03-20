using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


