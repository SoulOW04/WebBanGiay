using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanGiayMVC.Business
{
    internal interface IDanhMucService
    {
        List<Category> GetCategories();
    }

    public class Category : IDanhMucService
    {
        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

    }
}
