using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Business
{
    internal interface IThongSoSanPhamSerivce
    {
        ThongSoSanPham GetThongTinSanPhamById(int id);
    }
    public class ThongSoSanPhamService : IThongSoSanPhamSerivce
    {
        ThongSoSanPhamDA _chiTietSanPhamDA = new ThongSoSanPhamDA();


        public ThongSoSanPham GetThongTinSanPhamById(int id)
        {
            return _chiTietSanPhamDA.GetThongTinSanPhamById(id);
        }
    }
}
