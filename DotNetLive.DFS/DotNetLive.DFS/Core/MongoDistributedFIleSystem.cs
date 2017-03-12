using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;

namespace DotNetLive.DFS.Core
{
    public class MongoDistributedFIleSystem : IDistributedFileSystem
    {
        private MongoClient client;
        private IMongoDatabase database;
        private GridFSBucket fs;

        public MongoDistributedFIleSystem(IOptions<MongoDbOption> opts)
        {
            client = new MongoClient(opts.Value.ToString());
            database = client.GetDatabase(opts.Value.DbName);
            fs = new GridFSBucket(database);
        }
        public string UploadFile(string fileName, Stream stream)
        {
            var id = fs.UploadFromStream(fileName, stream);
            return id.ToString();
        }
        public DFSFileInfo DownloadFile(string fileId)
        {
            var stream = fs.OpenDownloadStream(new ObjectId(fileId));
            var result = new DFSFileInfo()
            {
                Stream = stream,
                FileName = stream.FileInfo.Filename,
                MD5 = stream.FileInfo.MD5
            };
            return result;
        }

    }
}
