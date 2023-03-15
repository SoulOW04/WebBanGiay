using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.DataAccess
{
    public class SanPhamDA
    {

        private string cs = ConfigurationManager.ConnectionStrings["Model_Context1"].ConnectionString;
        public List<SanPham> GetProduct() 
        {
            int a = 0;
            return new List<SanPham>();
        }

        public List<SanPham> GetAllGiaSanPhamFormat()
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "usp_WEB_GetAllGiaSanPhamFormat";//ten proc

                    //Add param
                    
                    conn.Open();
                    var result = conn.Query<SanPham>(storeName, commandType: System.Data.CommandType.StoredProcedure).ToList();
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

        public List<SanPham> GetAllGiaSanPhamByNameFormat(string name)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "usp_WEB_GetAllGiaSanPhamFormat";//ten proc

                    //Add param

                    conn.Open();

                    var result = conn.Query<SanPham>(storeName, commandType: System.Data.CommandType.StoredProcedure).ToList();
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


        public List<SanPham> GetAllSanPham()
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "usp_WEB_GetAllSanPham";//ten proc

                    //Add param

                    conn.Open();
                    var result = conn.Query<SanPham>(storeName, commandType: System.Data.CommandType.StoredProcedure).ToList();
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