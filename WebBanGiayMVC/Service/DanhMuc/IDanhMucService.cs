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
        List<DanhMuc> GetAllDanhMucs();
    }

    public class DanhMucSerVice : IDanhMucService
    {
        DanhMucDA _danhMucDA = new DanhMucDA();
        public List<DanhMuc> GetAllDanhMucs()
        {
            var total = 0;
            return _danhMucDA.GetAllDanhMucs(out total);
            
        }

    }
}
