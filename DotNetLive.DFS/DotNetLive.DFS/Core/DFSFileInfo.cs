using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.DFS.Core
{
    public class DFSFileInfo
    {
        public string FileName { set; get; }
        public string MD5 { set; get; }
        public Stream Stream { set; get; }


    }
}
