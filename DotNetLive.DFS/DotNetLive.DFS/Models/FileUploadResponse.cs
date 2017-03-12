using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.DFS.Models
{
    /// <summary>
    /// 文件上传响应结果
    /// </summary>
    public class FileUploadResponse:ResponseBase
    {
        /// <summary>
        /// 成功上传文件信息
        /// </summary>
        public UploadedFileInfo File { set; get; }


    }
}
