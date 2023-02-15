using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.ThongSoSanPham.ViewModel;

namespace WebBanGiayMVC.Business
{
    internal interface IThongSoSanPhamSerivce
    {
        ThongSoSanPhamViewModel GetThongTinSanPhamById(int thongtinspId);
    }
    public class ThongSoSanPhamService : IThongSoSanPhamSerivce
    {
        ThongSoSanPhamDA _chiTietSanPhamDA = new ThongSoSanPhamDA();


        public ThongSoSanPhamViewModel GetThongTinSanPhamById(int thongtinspId)
        {
            return _chiTietSanPhamDA.GetThongTinSanPhamById(thongtinspId);
        }
    }
}
