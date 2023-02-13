using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Business
{
    internal interface ICauHinhService
    {
        CauHinh GetCauHinhByMaCauHinh(string code);
        List<CauHinh> GetCauHinhByLoai(int loai);
    }
    public class CauHinhService : ICauHinhService
    {
        CauHinhDA _cauHinhDA = new CauHinhDA();
        
        public CauHinh GetCauHinhByMaCauHinh(string code)
        {
            return _cauHinhDA.GetCauHinhByMaCauHinh(code);
        }
        public List<CauHinh> GetCauHinhByLoai(int loai)
        {
            return _cauHinhDA.GetCauHinhByLoai(loai);
        }
    }

}
