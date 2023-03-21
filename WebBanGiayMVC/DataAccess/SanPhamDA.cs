using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
        public List<SanPham> FilterSanPham(out int total,string keyword, int pageIndex, int pageSize )
        {
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "web_FilterSanPham";//ten proc
                    conn.Open();
                    //Add param
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("keyword", keyword);
                    parameters.Add("pageIndex", pageIndex);
                    parameters.Add("pageSize", pageSize);
                    parameters.Add("total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    var result = conn.Query<SanPham>(storeName, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
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
        public List<SanPham> GetSanPhamByName(string searchSanPhamByName)
        {
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "usp_WEB_GetSanPhamByName";//ten proc

                    //Add param
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("name", searchSanPhamByName);
                    conn.Open();
                    var result = conn.Query<SanPham>(storeName, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
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