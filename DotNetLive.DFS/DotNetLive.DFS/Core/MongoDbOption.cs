using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.DFS.Core
{
    public class MongoDbOption
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Server { set; get; }
        public int Port { set; get; } = 27017;
        public string DbName { set; get; }

        public override string ToString()
        {
            return string.Format("mongodb://{0}:{1}@{2}:{3}/{4}",UserName,Password,Server,Port,DbName);
        }

    }
}
