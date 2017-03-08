# dotnetlive.dfs

## 基于MongoDB GridFS分布式文件存储

目前已实现基本功能：
* 文件上传接口  
 /api/file/upload
* 文件下载接口  
/api/file/{uuid}
* mongodb信息配置


> MongoDB 配置说明 

```
"MongoDb": {
        "UserName": "admin",        //用户名
        "Password": "123456",   //密码
        "DbName": "test",           //库名
        "SlaveOk": false,           
        "Servers": [                //多个服务器ip+端口
           "localhost:2801",
           "localhost:2701",
        ]   
  }     
  ```
  [详细说明可以查看相关文章](http://www.cnblogs.com/imeiba/p/5702298.html)


  



