using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Business
{
    internal interface IAdminService
    {
        Admin GetAdminByLogin(string name, string password);
        
    }
    public class AdminService : IAdminService
    {
        AdminDA _adminDA = new AdminDA();

        public Admin GetAdminByLogin(string name, string password)
        {
            return _adminDA.GetAdminByLogin(name,password);
        }
        
    }
}