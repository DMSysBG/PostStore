using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/GZPost
        public FileResult GZPost(int id = 0)
        {
            if (id <= 0)
            { return null; }
            else
            {
                string fileName = GetFilePath(id);
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.MemoryStream postMemory = new System.IO.MemoryStream();
                    using (System.IO.FileStream postFile = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
                    {
                        postFile.CopyTo(postMemory);
                        postFile.Close();
                    }
                    postMemory.Position = 0;
                    FileStreamResult model = new FileStreamResult(postMemory, "application/json");
                    Response.AppendHeader("Content-Encoding", "gzip");
                    return model;
                }
                else
                { return null; }
            }
        }

        private string GetFilePath(int id)
        {
            string fileId = id.ToString();
            string fileName = "";
            while( fileId.Length > 3 )
            {
                fileName += "/" + fileId.Substring(0, 3);
                fileId = fileId.Substring(3, fileId.Length - 3);
            }
            fileName += "/" + fileId;
            return Server.MapPath("~/App_Data" + fileName + ".json");
        }
    }
}