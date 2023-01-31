using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebBanGiayMVC.Business;
using WebBanGiayMVC.Models;
using Dapper;
using System.Data;

namespace WebBanGiayMVC.DataAccess
{
    public class DanhMucDA
    {
        private string cs = ConfigurationManager.ConnectionStrings["Model_Context1"].ConnectionString;
        private Model_Context _context = new Model_Context();
        public List<DanhMuc> GetAllDanhMucs(out int total,string keyword = "", int pageIndex = 1,int pageSize = 10) 
        {
            using (var conn = new SqlConnection(cs))
            {
                conn.Open();              

                //Add param
                DynamicParameters dp = new DynamicParameters();
                dp.Add("keyword", keyword);
                dp.Add("pageIndex", pageIndex);
                dp.Add("pageSize", pageSize);
                dp.Add("total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Close();

                var result = conn.Query<DanhMuc>("web_FilterDanhMuc", dp, commandType: CommandType.StoredProcedure).ToList();
                total = dp.Get<int>("total");
                conn.Close();
                return result;
            }
        }

        public List<DanhMuc> GetAllDanhMucByEF(out int total, string keyword = "", int pageIndex = 1, int pageSize = 10)
        {
            var result = _context.DanhMucs.AsQueryable();
            if (string.IsNullOrEmpty(keyword))
            {
                result = result.Where(r => r.TenDanhMuc.ToLower().Contains(keyword.ToLower()));
            }
            total = result.Count();
            if(pageIndex >= 1 && pageSize > 0)
            {
                result = result.OrderBy(r => r.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return result.ToList();
        }




    }
}