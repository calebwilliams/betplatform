using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;



namespace InterfaceTests.Utility
{
    public class MongoAccess
    {
        
        IMongoClient Client;
        public IMongoDatabase DBContext;

        public MongoAccess(string conn, string database)
        {
            Client = new MongoClient(conn);
            DBContext = Client.GetDatabase(database); 
        }
    }
}
