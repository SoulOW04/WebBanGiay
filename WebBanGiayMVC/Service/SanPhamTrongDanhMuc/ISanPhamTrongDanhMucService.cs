using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Service.ChiTietDonHang.ViewModel;
using WebBanGiayMVC.Service.SanPhamTrongDanhMuc.ViewModel;

namespace WebBanGiayMVC.Business
{
    internal interface ISanPhamTrongDanhMucService
    {
        List<SanPhamtTrongDanhMucViewModel> GetSanPhamTrongDanhMucByDanhMucId(int idDanhMuc);
    }
    public class SanPhamTrongDanhMucService : ISanPhamTrongDanhMucService
    {
        SanPhamTrongDanhMucDA _sanPhamTrongDanhMucDA = new SanPhamTrongDanhMucDA();

        public List<SanPhamtTrongDanhMucViewModel> GetSanPhamTrongDanhMucByDanhMucId(int idDanhMuc)
        {
            return _sanPhamTrongDanhMucDA.GetSanPhamTrongDanhMucByDanhMucId(idDanhMuc);
        }
    }
}
