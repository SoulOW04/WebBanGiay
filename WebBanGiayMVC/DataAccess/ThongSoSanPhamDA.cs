using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.DataAccess
{
    public class ThongSoSanPhamDA
    {
        private string cs = ConfigurationManager.ConnectionStrings["Model_Context1"].ConnectionString;
        private Model_Context _context = new Model_Context();
        public ThongSoSanPham GetThongTinSanPhamById(int id)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "usp_WEB_GetThongTinSanPhamById";//ten proc

                    //Add param
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("id", id);
                    conn.Open();
                    var result = conn.QueryFirst<ThongSoSanPham>(storeName, dp, commandType: System.Data.CommandType.StoredProcedure);
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

        public ThongSoSanPham GetKichThuongSanPhamByKichThuoc(int kichThuoc)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "GetKichThuongSanPhamByKichThuoc";//ten proc

                    //Add param
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("kichThuoc", kichThuoc);
                    conn.Open();
                    var result = conn.QueryFirst<ThongSoSanPham>(storeName, dp, commandType: System.Data.CommandType.StoredProcedure);
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
    }

    
}