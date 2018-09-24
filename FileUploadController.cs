using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;


namespace DownSampleAPI.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        [Route("api/FileUpload")]
        public IHttpActionResult UploadFiles()
        {
            int i = 0;
            int cntSuccess = 0;
            var uploadedFileNames = new List<string>();
            string result = string.Empty;

            HttpResponseMessage response = new HttpResponseMessage();

            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[0];
                    var filePath = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                        uploadedFileNames.Add(httpRequest.Files[i].FileName);
                        cntSuccess++;
                }
            }

            result = cntSuccess.ToString() + " files uploaded succesfully.<br/>";

            result += "<ul>";

            foreach (var f in uploadedFileNames)
            {
                result += "<li>" + f + "</li>";
            }

            result += "</ul>";

           // return Request.CreateResponse(HttpStatusCode.Created);
            return Json(result);
        }
    }
}
