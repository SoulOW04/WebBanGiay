using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.ChiTietDonHang.ViewModel;

namespace WebBanGiayMVC.DataAccess
{
    public class ChiTietDonHangDA
    {

        private string cs = ConfigurationManager.ConnectionStrings["Model_Context1"].ConnectionString;
        private Model_Context _context = new Model_Context();
        public List<ChiTietDonHangViewModel> GetThongTinGioHangById(int idSanPham)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "GetThongTinGioHangById";//ten proc

                    //Add param
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("idSanPham", idSanPham);
                    conn.Open();
                    var result = conn.Query<ChiTietDonHangViewModel>(storeName, dp, commandType: System.Data.CommandType.StoredProcedure).ToList();
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