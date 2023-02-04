using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.Business
{
    internal interface ISanPhamService
    {
        List<Product> GetProducts();
    }

    public class Product : ISanPhamService
    {
        Model_Context model_Contextmodel;
        public List<Product> GetProducts()
        {
            model_Contextmodel= new Model_Context();
            model_Contextmodel.SanPhams.ToList();

            throw new NotImplementedException();

        }

    }
}


