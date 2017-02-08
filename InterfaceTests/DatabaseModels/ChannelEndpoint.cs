using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using InterfaceTests.Generics;

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
}
