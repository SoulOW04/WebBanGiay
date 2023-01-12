using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Business
{
    internal interface IDanhMucService
    {
        List<DanhMuc> GetAllDanhMuc(out int total);
    }

    public class DanhMucService : IDanhMucService
    {

        DanhMucDA _dataAccess = new DanhMucDA();
        public List<DanhMuc> GetAllDanhMuc(out int total)
        {
            
            return _dataAccess.GetAllDanhMucByEF(out total);
            
        }

    }
}
