using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.DFS.Models
{
    /// <summary>
    /// 响应
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// 成功
        /// </summary>
        public bool Success { set; get; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { set; get; }
    }
}
