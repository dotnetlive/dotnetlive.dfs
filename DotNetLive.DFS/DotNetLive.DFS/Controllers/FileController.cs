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
    [Produces("application/json")]
    [Route("api/file")]
    public class FileController : Controller
    {
        private IDistributedFileSystem _dfs;

        public FileController(IDistributedFileSystem dfs)
        {
            _dfs = dfs;
        }
        /// <summary>
        /// 单文件上传
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        [HttpPost]
        public FileUploadResponse Upload([FromForm]IFormFile file)
        {
            if (file == null)
            {
                return new FileUploadResponse() { Success = false, Msg = "没有文件" };
            }
            using (var s = file.OpenReadStream())
            {
                var uuid = _dfs.UploadFile(file.FileName, s);
                var fileInfo = new UploadedFileInfo()
                {
                    Id = uuid,
                    FileName = file.FileName
                };
                return new FileUploadResponse()
                {
                    Success = true,
                    Msg = "上传成功",
                    File = fileInfo
                };
            }
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
