using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.ChiTietDonHang.ViewModel;

namespace WebBanGiayMVC.Business
{
    internal interface IChiTietDonHangService
    {
        List<ChiTietDonHangViewModel> GetThongTinGioHangById(int idSanPham);
    }
    public class ChiTietDonHangService : IChiTietDonHangService
    {
        ChiTietDonHangDA _chiTietDonHangDA = new ChiTietDonHangDA();

        public List <ChiTietDonHangViewModel> GetThongTinGioHangById(int idSanPham)
        {
            return _chiTietDonHangDA.GetThongTinGioHangById(idSanPham);
        }
    }
}
