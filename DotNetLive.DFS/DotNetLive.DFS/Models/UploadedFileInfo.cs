using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.DFS.Models
{
    /// <summary>
    /// 上传文件信息
    /// </summary>
    public class UploadedFileInfo
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { set; get; }
    }
}
