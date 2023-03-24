using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.SanPhamTrongDanhMuc.ViewModel;
using WebBanGiayMVC.Service.ThongSoSanPham.ViewModel;

namespace WebBanGiayMVC.DataAccess
{
    public class SanPhamTrongDanhMucDA
    {
        private string cs = ConfigurationManager.ConnectionStrings["Model_Context1"].ConnectionString;
        private Model_Context _context = new Model_Context();
        public List<SanPhamtTrongDanhMucViewModel> GetSanPhamTrongDanhMucByDanhMucId(int spdanhmuc)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "usp_WEB_GetSanPhamTrongDanhMucByDanhMucId";//ten proc

                    //Add param
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("spdanhmuc", spdanhmuc);
                    conn.Open();
                    var result = conn.Query<SanPhamtTrongDanhMucViewModel>(storeName, dp, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    conn.Close();

                    return result;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }


        }
        public List<SanPhamtTrongDanhMucViewModel> FilterSanPhamTrongDanhMuc(out int total, string keyword, int pageIndex, int pageSize,int category)
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "web_FilterDanhMuc";//ten proc
                    conn.Open();
                    //Add param
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("keyword", keyword);
                    parameters.Add("pageIndex", pageIndex);
                    parameters.Add("pageSize", pageSize);
                    parameters.Add("spdanhmuc", category);
                    parameters.Add("total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    var result = conn.Query<SanPhamtTrongDanhMucViewModel>(storeName, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    total = parameters.Get<int>("total");

                    conn.Close();
                    return result;

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                total = 0;
                return null;

            }

        }

    }
}