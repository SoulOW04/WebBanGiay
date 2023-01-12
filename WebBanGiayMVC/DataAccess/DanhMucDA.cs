using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using WebBanGiayMVC.Models;

namespace WebBanGiayMVC.DataAccess
{
    public class DanhMucDA
    {
        private string cs = ConfigurationManager.ConnectionStrings["Model_Context1"].ConnectionString;
        private Model_Context _context = new Model_Context();
        public List<DanhMuc> GetAllDanhMuc(out int total, string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            
            using (var conn = new SqlConnection(cs))
            {
                conn.Open();
                

                //Add cac parameter o day
                DynamicParameters parameters= new DynamicParameters();
                parameters.Add("keyword", keyword);
                parameters.Add("pageIndex", pageIndex);
                parameters.Add("pageSize", pageSize);
                parameters.Add("total", dbType: DbType.Int32, direction: ParameterDirection.Output);

                //Thuc hien query
                var result = conn.Query<DanhMuc>("web_FilterDanhMuc", parameters, commandType: CommandType.StoredProcedure).ToList();
                total = parameters.Get<int>("total");

                conn.Close();
                return result;
            }
        }
        public List<DanhMuc> GetAllDanhMucByEF(out int total, string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var result = _context.DanhMucs.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(r => r.TenDanhMuc.ToLower().Contains(keyword.ToLower()));
            }
            total = result.Count();
            if(pageIndex > 0 && pageSize > 0)
            {
                result = result.OrderBy(r => r.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return result.ToList();
        }
    }
}