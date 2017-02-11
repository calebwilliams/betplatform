using InterfaceTests.DatabaseModels;
using InterfaceTests.Generics;
using InterfaceTests.Utility;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.ApiObjects
{
    public class AzubuAPI : APIBase
    {
        public AzubuAPI(AppConfig config) : base(config, "azubu")
        {
            this.EndpointActionCollection.Add(new EndpointAction(ConsumeLive));
        }

        /// <summary>
        /// Live endpoint data... need to consume by games instead. 
        /// </summary>
        /// <returns></returns>
        public async Task<Response<string>> ConsumeLive()
        {
            Response<string> response = new Response<string>();
            string query = "http://api.azubu.tv/public/channel/live/list";
            try
            {
                response = await VisitEndpointAsync(query);
                response.Query = query;
                List<ChannelEndpoint> cache = new List<ChannelEndpoint>();

                BsonDocument doc = BsonDocument.Parse(response.Result);
                int cnt = doc[0].AsBsonArray.Count;
                foreach (var _doc in doc[0].AsBsonArray)
                {
                    ChannelEndpoint temp = new ChannelEndpoint();
                    temp.ApiId = _doc["user"]["id"].ToString();
                    //temp.Game = need to find a way to populate friggin' games. 
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
                response.ReceiveException(ex, MethodBase.GetCurrentMethod()); 
            }

            return response; 

        }
    }
}
