using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI.WebControls;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.Models;
using WebBanGiayMVC.Service.SanPham.ViewModel;

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
        public bool CreateSanPham(InsertSanPhamWithDanhMucs sp)
        {
            //
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "usp_CMS_CreateSanPham";//ten proc

                    //Add param
                    DynamicParameters parameters= new DynamicParameters();
                    parameters.Add("Id", sp.Id);
                    parameters.Add("TenSanPham", sp.TenSanPham);
                    parameters.Add("MoTaSanPham", sp.MoTaSanPham);
                    parameters.Add("GiaSanPham", sp.GiaSanPham);
                    parameters.Add("AvatarSanPham", sp.AvatarSanPham);
                    parameters.Add("DanhSachAnhSanPham", sp.DanhSachAnhSanPham);
                    parameters.Add("NoiDungSanPham", sp.NoiDungSanPham);
                    parameters.Add("HangSanPham", sp.HangSanPham);
                    parameters.Add("Loai", sp.Loai);
                    parameters.Add("TrangThai", sp.TrangThai);
                    parameters.Add("DanhSachDanhMucs", sp.DanhSachDanhMucs);

                    conn.Open();
                    var result = conn.Execute(storeName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    conn.Close();

                    return true;

                }
                throw new Exception();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public bool SaveSP(InsertSanPhamFull sp)
            {
            //
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    var storeName = "usp_CMS_SaveSanPham";//ten proc

                    //Add datatable ThongsoSanPham
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ThongSoId", typeof(int));
                    dt.Columns.Add("GiaTri", typeof(string));

                    foreach(var ts in sp.ThongSoInsertUpdates)
                    {
                        dt.Rows.Add(ts.ThongSoId, ts.GiaTri);
                    }
                    //Add param
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Id", sp.Id);
                    parameters.Add("TenSanPham", sp.TenSanPham);
                    parameters.Add("MoTaSanPham", sp.MoTaSanPham);
                    parameters.Add("GiaSanPham", sp.GiaSanPham);
                    parameters.Add("AvatarSanPham", sp.AvatarSanPham);
                    parameters.Add("DanhSachAnhSanPham", sp.DanhSachAnhSanPham);
                    parameters.Add("NoiDungSanPham", sp.NoiDungSanPham);
                    parameters.Add("HangSanPham", sp.HangSanPham);
                    parameters.Add("Loai", sp.Loai);
                    parameters.Add("TrangThai", sp.TrangThai);
                    parameters.Add("DanhSachDanhMucs", sp.DanhSachDanhMucs);
                    parameters.Add("thongSos", dt.AsTableValuedParameter("insert_tssp"));

                    conn.Open();
                    var result = conn.Execute(storeName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    conn.Close();

                    return true;

                }
                throw new Exception();
            }
            catch (Exception ex)
            {

                throw;
            }

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