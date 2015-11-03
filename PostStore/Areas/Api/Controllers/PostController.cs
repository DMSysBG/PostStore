using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Post.Models;

namespace PostStore.Areas.Api.Controllers
{
    public class PostController : Controller
    {
        // GET: Api/Post
        public ActionResult Index()
        {
            return View();
        }

        // GET: Api/Post/Add
        public JsonResult Add()
        {
            PostModel model = new PostModel();
            model.PDate = DateTime.Now;

            string fileName = Server.MapPath("~/App_Data/test.json");
            model.PText = fileName;


              System.Runtime.Serialization.Json.DataContractJsonSerializer ser = 
                  new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(PostModel));
  
            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

            ser.WriteObject(stream1, model);
            
            using (System.IO.FileStream f2 = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                byte[] jsonArray = stream1.ToArray();
                 f2.Write(jsonArray, 0, jsonArray.Length);
                    /*
                using (System.IO.Compression.GZipStream gz =
                    new System.IO.Compression.GZipStream(f2, System.IO.Compression.CompressionMode.Compress))
                {
                    gz.Write(jsonArray, 0, jsonArray.Length);
                }
                */
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Api/Post/Add3
        public JsonResult Add3()
        {
            PostModel model = new PostModel();
            model.PDate = DateTime.Now;

            string fileName = Server.MapPath("~/App_Data/test3.json");
            model.PText = fileName;

            System.Runtime.Serialization.Json.DataContractJsonSerializer ser =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(PostModel));

            System.IO.MemoryStream stream1 = new System.IO.MemoryStream();

            ser.WriteObject(stream1, model);

            using (System.IO.FileStream f2 = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                byte[] jsonArray = stream1.ToArray();

                using (System.IO.Compression.GZipStream gz =
                    new System.IO.Compression.GZipStream(f2, System.IO.Compression.CompressionMode.Compress))
                {
                    gz.Write(jsonArray, 0, jsonArray.Length);
                }
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}