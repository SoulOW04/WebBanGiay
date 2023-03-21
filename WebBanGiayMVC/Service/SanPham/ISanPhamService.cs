using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using WebBanGiayMVC.DataAccess;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.ThongSoSanPham.ViewModel;

namespace WebBanGiayMVC.Business
{
    internal interface ISanPhamService
    {
        List<SanPham> GetAllGiaSanPhamFormat();
        List<SanPham> GetSanPhamByName(string searchSanPhamByName);
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

        public List<SanPham> GetSanPhamByName(string searchSanPhamByName)
        {
            return spDa.GetSanPhamByName(searchSanPhamByName);
        }
        public List<SanPham> FilterSanPham(out int total,string keyword, int pageIndex, int pageSize)
        {
            total = 0;
            int totalPages = (int)Math.Ceiling(total / (decimal)pageSize);
            
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            else if (pageIndex > totalPages)
            {
                pageIndex = totalPages;
            }

            

            return spDa.FilterSanPham(out total, keyword, pageIndex, pageSize);
        }
    }
}


