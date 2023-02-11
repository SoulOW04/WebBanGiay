using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Business
{
    internal interface IDanhMucService
    {
        List<DanhMuc> PhanTrangDanhMuc();
        List<DanhMuc> GetAllDanhMuc();
        DanhMuc GetDanhMucByLoai(int? loai);
    }

    public class DanhMucService : IDanhMucService
    {
        DanhMucDA _danhMucDA = new DanhMucDA();
        public List<DanhMuc> PhanTrangDanhMuc()
        {
            var total = 0;
            return _danhMucDA.PhanTrangDanhMuc(out total);
            
        }
        public List<DanhMuc> GetAllDanhMuc()
        {
            
            return _danhMucDA.GetAllDanhMuc();

        }
        public DanhMuc GetDanhMucByLoai(int? loai)
        {

            return _danhMucDA.GetDanhMucByLoai(loai);

        }

    }
}
