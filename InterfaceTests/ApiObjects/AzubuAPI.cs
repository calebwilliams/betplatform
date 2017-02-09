using InterfaceTests.DatabaseModels;
using InterfaceTests.Generics;
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
                foreach (var _doc in doc[root].AsBsonArray)
                {

                }
            }
            catch (Exception ex)
            {


            }
            return response; 
        }
    }
}
