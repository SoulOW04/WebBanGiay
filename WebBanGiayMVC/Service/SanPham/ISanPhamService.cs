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
    internal interface ISanPhamService
    {
        List<SanPham> GetAllGiaSanPhamFormat();
    }

    public class SanPhamService : ISanPhamService
    {
        Model_Context model_Contextmodel;

        
        //public List<Product> GetProducts()
        //{
        //    model_Contextmodel= new Model_Context();
        //    model_Contextmodel.SanPhams.ToList();

        //    throw new NotImplementedException();

        //}

        SanPhamDA spDa = new SanPhamDA();

        public List<SanPham> GetAllGiaSanPhamFormat()
        {
            return spDa.GetAllGiaSanPhamFormat();
        }

    
        




    }
}


