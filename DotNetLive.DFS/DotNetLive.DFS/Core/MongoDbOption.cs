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
        public string DbName { set; get; }
        public bool SlaveOk { set; get; }
        public List<string> Servers { set; get; }
        public override string ToString()
        {
            return $"mongodb://{UserName}:{Password}@{string.Join(",", Servers)}/{DbName}?slaveOk={SlaveOk}";
        }

    }
}
