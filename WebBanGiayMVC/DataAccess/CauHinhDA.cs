using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.DataAccess
{
    public class CauHinhDA
    {
        private string cs = ConfigurationManager.ConnectionStrings["Model_Context1"].ConnectionString;
        private Model_Context _context = new Model_Context();
        public CauHinh GetCauHinhByMaCauHinh(string code)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "GetCauHinhByMaCauHinh";//ten proc

                    //Add param
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("code", code);
                    conn.Open();
                    var result = conn.QueryFirst<CauHinh>(storeName, dp, commandType: System.Data.CommandType.StoredProcedure);
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
        public List<CauHinh> GetCauHinhByLoai(int loai)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "GetCauHinhByLoai";//ten proc

                    //Add param
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("loai", loai);
                    conn.Open();
                    var result = conn.Query<CauHinh>(storeName, dp, commandType: System.Data.CommandType.StoredProcedure).ToList();
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