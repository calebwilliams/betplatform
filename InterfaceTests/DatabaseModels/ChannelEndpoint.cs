using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using InterfaceTests.Generics;
using InterfaceTests.Utility;

namespace InterfaceTests.DatabaseModels
{
    public class ChannelEndpoint
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("aid")]
        public string ApiId { get; set; }
        [BsonElement("g")]
        public string Game { get; set; }
        [BsonElement("n")]
        public string Name { get; set; }
        [BsonElement("url")]
        public string Url { get; set; }
        [BsonElement("ocd") BsonDateTimeOptions(Kind = DateTimeKind.Local)] // 99.9% sure we need to convert to utc 
        public DateTime OrigionalCacheDate { get; set; }
        [BsonElement("lcd") BsonDateTimeOptions(Kind = DateTimeKind.Local)] //99.9% sure we need to convert to utc 
        public DateTime LatesteCacheDate { get; set; }
        [BsonElement("eurl")]
        public string EndpointUrl { get; set; }
        [BsonElement("cvc")]
        public int CurrentViewerCount { get; set; }
        [BsonElement("tvc")]
        public int TotalViewCount { get; set; } 
    }

    public class ChannelEndpointCollection
    {
        public List<ChannelEndpoint> Cache { get; set; }
        public string QueryBase { get; set; }
        public string Query { get; set; }
        public string OffsetUrl { get; set; }
        public int OffsetModifier { get; set; }

        public ChannelEndpointCollection(string queryBase)
        {
            QueryBase = queryBase;
            OffsetUrl = "&offset=";
            OffsetModifier = 100;
            Cache = new List<ChannelEndpoint>();
        }

        public void SetQuery(int iteration)
        {
            Query = QueryBase + OffsetUrl + (iteration * OffsetModifier).ToString();
        }

        public async Task<Response<string>> SaveCache(MongoAccess mongo, string collection)
        {
            Response<string> response = new Response<string>();
            var col = mongo.DBContext.GetCollection<ChannelEndpoint>(collection);
            await col.InsertManyAsync(Cache);
            return response; 
        }
    }
}
