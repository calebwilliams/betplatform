using InterfaceTests.DatabaseModels;
using InterfaceTests.Generics;
using InterfaceTests.Utility;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.ApiObjects
{
    public class TwitchAPI : APIBase
    {
        /// <summary>
        /// https://dev.twitch.tv/docs
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="apikey"></param>
        public TwitchAPI(AppConfig config) : base(config, "twitch")
        {   
            ////twitch requires custom headers. had to use httpwebrequest object due that...
            this.Headers.Add("Accept", "application/vnd.twitchtv.v5+json");
            this.Headers.Add("Client-ID", this.APIKey);

        }

        public override async Task<Response<string>> CacheChannelEndpointAsync(string apiData, string root)
        {
            Response<string> response = new Response<string>();
            List<ChannelEndpoint> cache = new List<ChannelEndpoint>();
            try
            {
                BsonDocument doc = BsonDocument.Parse(apiData);
                foreach (var _doc in doc["featured"].AsBsonArray)
                {
                    //i'd like to be able for this to be configurable in a separate class
                    //so that you could iterate through a collection of array indexes to set the object's properties
                    ChannelEndpoint temp = new ChannelEndpoint();
                    temp.ApiId = (string)_doc["stream"]["channel"]["_id"];
                    temp.Name = (string)_doc["stream"]["channel"]["name"];
                    temp.Game = (string)_doc["stream"]["game"];
                    temp.Url = (string)_doc["stream"]["channel"]["url"];
                    temp.TotalViewCount = (int)_doc["stream"]["channel"]["views"];
                    cache.Add(temp);
                }
                MongoAccess mongo = new MongoAccess(_config.ConnectionStrings["local"], "stream_cache");
                var col = mongo.DBContext.GetCollection<ChannelEndpoint>("twitch");
                await col.InsertManyAsync(cache);
                response.Result = "Insert successful"; 
            }
            catch (Exception ex)
            {
                response.Ex = ex;
                response.Result = ex.Message; 
            }

            return response; 
        }
    }

}
