using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DotNetLive.DFS.Core;
using System.IO;
using DotNetLive.DFS.Utils;


namespace DotNetLive.DFS.Controllers
{
    public class FileController : Controller
    {
        private IDistributedFileSystem _dfs;
        public FileController(IDistributedFileSystem dfs)
        {
            _dfs = dfs;
        }
        public IActionResult Upload()
        {
            var form = Request.Form;
            if (form.Files.Count == 0)
            {
                return Json(new { Success = false });
            }
            var result = new List<UploadedFileInfo>();
            foreach (var file in form.Files)
            {
                using (var s = file.OpenReadStream())
                {
                    var uuid = _dfs.UploadFile(file.FileName, s);
                    result.Add(new UploadedFileInfo() {Id=uuid,FileName=file.FileName });
                }
            }
            return Json(new { Success = true, Files=result });
        }
        public IActionResult Get(string id)
        {
            var fileInfo = _dfs.DownloadFile(id);
            var fileName = fileInfo.FileName;
            var minetype = FileContentType.GetMimeType(Path.GetExtension(fileName));
            return File(fileInfo.Stream, minetype, fileName);
        }
    }

    public class UploadedFileInfo
    {
        public string Id { set; get; }
        public string FileName { set; get;}
    }
}
