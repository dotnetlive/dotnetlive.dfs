using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.DFS.Core
{
    public interface IDistributedFileSystem
    {

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="stream">流</param>
        /// <returns>文件uuid</returns>
        string UploadFile(string fileName,Stream stream);
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileId">文件uuid</param>
        /// <returns>文件流</returns>
        DFSFileInfo DownloadFile(string fileId);

    }
}
