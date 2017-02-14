using InterfaceTests.Generics;
using InterfaceTests.Utility;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.DatabaseModels
{
    public class GameModel
    {
        //[BsonElement("_id")]
        //public ObjectId Id { get; set; }
        [BsonElement("g")]
        public string Game { get; set; }
        [BsonElement("aid")]
        public int ApiId { get; set; }
        [BsonElement("tvc")]
        public int TotalViewCount { get; set; }
        [BsonElement("c")]
        public int Channels { get; set; }
    }

    public class GameModelCollection
    {
        public List<GameModel> Cache { get; set; }
        public string QueryBase { get; set; }
        public string Query { get; set; }
        public string OffsetUrl { get; set; }
        public int OffsetModifier { get; set; }
   

        public GameModelCollection(string queryBase)
        {
            QueryBase = queryBase;
            OffsetUrl = "&offset=";
            OffsetModifier = 10; 
            Cache = new List<GameModel>();
        }

        public void SetQuery(int iteration)
        {
            this.Query = QueryBase + OffsetUrl + (iteration * OffsetModifier).ToString();
        }
        public async Task<Response<string>> SaveCache(MongoAccess mongo)
        {
            Response<string> response = new Response<string>();
            var col = mongo.DBContext.GetCollection<GameModel>("games");
            InsertManyOptions options = new InsertManyOptions();
            options.BypassDocumentValidation = true;
            await col.InsertManyAsync(Cache, options); 


            return response;
        }
    }
}
