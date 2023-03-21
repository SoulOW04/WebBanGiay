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
    public class AdminDA
    {
        private string cs = ConfigurationManager.ConnectionStrings["Model_Context1"].ConnectionString;
        private Model_Context _context = new Model_Context();
        public Admin GetAdminByLogin(string name,string passWord)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "GetAdminByLogin";//ten proc

                    //Add param
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("tenDangNhap", name);
                    dp.Add("matKhauDangNhap", passWord);
                    conn.Open();
                    var result = conn.QueryFirst<Admin>(storeName, dp, commandType: System.Data.CommandType.StoredProcedure);
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