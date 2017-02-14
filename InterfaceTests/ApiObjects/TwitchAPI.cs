using InterfaceTests.DatabaseModels;
using InterfaceTests.Generics;
using InterfaceTests.Utility;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
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
            this.Headers.Add("Client-ID", this.APIKey); //api key gets set in base constructor 

            //this.EndpointActionCollection.Add(new EndpointAction(ConsumeFeatured)); 
            this.EndpointActionCollection.Add(new EndpointAction(ConsumeGameList)); 
            
        }

        public async Task<Response<string>> ConsumeGameList()
        {
            Response<string> response = new Response<string>();
            GameModelCollection gameModels = new GameModelCollection("https://api.twitch.tv/kraken/games/top?"); 
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    gameModels.SetQuery(i); 
                    response.Consume(await VisitEndpointAsync(gameModels.Query));
                    
                    BsonDocument doc = BsonDocument.Parse(response.ResponseCollection[response.ResponseCollection.Count -1].Result);
                    foreach (var _doc in doc["top"].AsBsonArray)
                    {
                        GameModel temp = new GameModel();
                        temp.ApiId = (int)_doc["game"]["_id"]; 
                        temp.Game = (string)_doc["game"]["name"];
                        temp.TotalViewCount = (int)_doc["viewers"];
                        temp.Channels = (int)_doc["channels"];
                        gameModels.Cache.Add(temp); 
                    }
                    response.Consume(await gameModels.SaveCache(new MongoAccess(_config.ConnectionStrings["local"], "stream_cache")));
                    Thread.Sleep(10000); //query controller 
                }
            }
            catch (Exception ex)
            {
                response.ReceiveException(ex, MethodBase.GetCurrentMethod()); 
            }

            return response; 

        }

        public async Task<Response<string>> ConsumeFeatured()
        {
            Response<string> response = new Response<string>();
            ChannelEndpointCollection channelEndpoints = new ChannelEndpointCollection("https://api.twitch.tv/kraken/streams/featured?limit=100");
            try
            {
                for (int i = 0; i <= 4; i++)
                {
                    channelEndpoints.SetQuery(i);
                    response = await VisitEndpointAsync(channelEndpoints.Query);
                    BsonDocument doc = BsonDocument.Parse(response.Result);
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
                        channelEndpoints.Cache.Add(temp);
                    }
                    //a representation of a database to cache model 
                    response.Consume(await channelEndpoints.SaveCache(new MongoAccess(_config.ConnectionStrings["local"], "stream_cache"), "twitch"));
                    Thread.Sleep(10000); 
                }
            }
            catch(Exception ex) 
            {
                response.ReceiveException(ex, MethodBase.GetCurrentMethod());
            }
            return response; 
        }
    }

}
