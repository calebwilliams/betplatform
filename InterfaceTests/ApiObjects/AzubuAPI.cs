using InterfaceTests.DatabaseModels;
using InterfaceTests.Generics;
using InterfaceTests.Utility;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.ApiObjects
{
    public class AzubuAPI : APIBase
    {
        public AzubuAPI(AppConfig config) : base(config, "azubu")
        {
            this.EndPoints.Add("live", "http://api.azubu.tv/public/channel/live/list");
        }

        public override async Task<Response<string>> CacheChannelEndpointAsync(string apiData, string root)
        {
            Response<string> response = new Response<string>();
            List<ChannelEndpoint> cache = new List<ChannelEndpoint>();
            try
            {
                BsonDocument doc = BsonDocument.Parse(apiData);
                int cnt = doc[0].AsBsonArray.Count; 
                foreach (var _doc in doc[0].AsBsonArray)
                {
                    ChannelEndpoint temp = new ChannelEndpoint();
                    temp.ApiId= _doc["user"]["id"].ToString(); 
                    temp.Name = (string)_doc["user"]["username"];
                    temp.EndpointUrl = (string)_doc["url_channel"];
                    temp.TotalViewCount = (int)_doc["view_count"];
                    temp.OrigionalCacheDate = DateTime.Now;
                    temp.LatesteCacheDate = DateTime.Now;
                    cache.Add(temp);
                }
                MongoAccess mongo = new MongoAccess(_config.ConnectionStrings["local"], "stream_cache");
                var col = mongo.DBContext.GetCollection<ChannelEndpoint>("azubu");
                await col.InsertManyAsync(cache);
                response.Result = "Insert successful";
            }
            catch (Exception ex)
            {


            }
            return response; 
        }
    }
}
