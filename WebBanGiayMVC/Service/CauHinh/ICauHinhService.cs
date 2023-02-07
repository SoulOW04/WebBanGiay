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
    }
    public class CauHinhService : ICauHinhService
    {
        ConfigDA _cauHinhDA = new ConfigDA();
        
        public CauHinh GetCauHinhByMaCauHinh(string code)
        {
            return _cauHinhDA.GetCauHinhByMaCauHinh(code);
        }
    }

}
