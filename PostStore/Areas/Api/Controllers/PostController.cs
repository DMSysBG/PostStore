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
        public JsonResult Add(string model)
        {
            string fileName = Server.MapPath("~/App_Data/4.json");
            PostModel mPost = DMSys.Systems.ObjectJsonSerializer.Deserialize<PostModel>(model);

            SaveWebPost(fileName, mPost);

            return Json(new JsonResponseModel() { Status = 0, Message = "Successfully completed" }
                , JsonRequestBehavior.AllowGet);
        }

        private void SaveWebPost(string fileName, PostModel model)
        {
            WebPostModel wPost = new WebPostModel()
            {
                PTitle = model.PTitle,
                PText = model.PText,
                PLink = model.PLink,
                PImage = model.PImage,
                PDate = model.PDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                PPrice = model.PPrice
            };

            System.IO.MemoryStream msPost = new System.IO.MemoryStream();
            System.Runtime.Serialization.Json.DataContractJsonSerializer dcJsonPost =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(WebPostModel));
            dcJsonPost.WriteObject(msPost, wPost);

            using (System.IO.FileStream f2 = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                byte[] jsonArray = msPost.ToArray();

                using (System.IO.Compression.GZipStream gz =
                    new System.IO.Compression.GZipStream(f2, System.IO.Compression.CompressionMode.Compress))
                {
                    gz.Write(jsonArray, 0, jsonArray.Length);
                }
            }
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