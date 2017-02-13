using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.DatabaseModels
{
    public class GameModel
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("g")]
        public string Game { get; set; }
        [BsonElement("aid")]
        public int ApiId { get; set; }
        [BsonElement("tvc")]
        public int TotalViewCount { get; set; }
        [BsonElement("c")]
        public int Channels { get; set; }
    }
}
