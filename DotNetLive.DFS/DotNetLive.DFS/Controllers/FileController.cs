using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DotNetLive.DFS.Core;
using System.IO;
using DotNetLive.DFS.Utils;
using DotNetLive.DFS.Models;

namespace DotNetLive.DFS.Controllers
{
    /// <summary>
    /// 文件
    /// </summary>
    [Route("api/file")]
    public class FileController : Controller
    {
        private IDistributedFileSystem _dfs;

        public FileController(IDistributedFileSystem dfs)
        {
            _dfs = dfs;
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("upload")]
        public FileUploadResponse Upload()
        {
            var form = Request.Form;
            var files = form.Files;
            if (files.Count() == 0)
            {
                return new FileUploadResponse() { Success = false, Msg = "没有文件" };
            }
            var result = new List<UploadedFileInfo>();
            foreach (var file in files)
            {
                using (var s = file.OpenReadStream())
                {
                    var uuid = _dfs.UploadFile(file.FileName, s);
                    result.Add(new UploadedFileInfo() { Id = uuid, FileName = file.FileName });
                }
            }
            return   new FileUploadResponse() { Success = true, Msg = "上传成功",Files=result };
        }
        
        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="id">文件id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public FileStreamResult Get(string id)
        {
            var fileInfo = _dfs.DownloadFile(id);
            var fileName = fileInfo.FileName;
            var minetype = FileContentType.GetMimeType(Path.GetExtension(fileName));
            return File(fileInfo.Stream, minetype, fileName);
        }
    }

}
