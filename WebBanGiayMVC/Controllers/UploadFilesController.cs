using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanGiayMVC.Controllers
{
    public class UploadFilesController : Controller
    {
        // GET: UploadFiles
        public ActionResult UploadSingleFile(HttpPostedFileBase file )
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    DateTime currentTime = DateTime.UtcNow;
                    long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
                    string _FileName = Path.GetFileName(file.FileName);
                    _FileName = unixTime + _FileName;
                    if (!Directory.Exists(Server.MapPath("~/footwear-master/images")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/footwear-master/images"));
                    }
                    string _path = Path.Combine(Server.MapPath("~/footwear-master/images"), _FileName);
                    file.SaveAs(_path);
                    var return_path = Path.Combine("/footwear-master/images", _FileName);
                    return Content(return_path);
                }
                throw new Exception();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}