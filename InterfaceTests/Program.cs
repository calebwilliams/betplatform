using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using InterfaceTests.Generics;
using System.Net;
using System.IO;
using System.Threading;
using InterfaceTests.ApiObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Linq;
using MongoDB.Driver;

namespace InterfaceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //we want this object to be separate, containing an iterable list of configutations
            AppConfig config = new AppConfig();

            /*Overview of demo to query twitch api */
            APIBase twitch = new TwitchAPI(config);
            APIBase azubu = new AzubuAPI(config);
            

            //THIS CONNECTS TO API. FOR DEVELOPMENT USE /APIResponses/twitch-feature-result.txt instead
            //string testData = ""; //string we'll load either api call or file.read into 
            int i = 10; 
            Response<string> apiResponse = new Response<string>();
            while (i != 0)
            {
                bool complete = false;
                Task.Run(async () =>
                {
                    apiResponse = await twitch.CacheChannelEndpoints();
                    complete = true;
                });
                while (!complete)
                {
                    Console.WriteLine("Thread sleeping for 3seconds"); 
                    Thread.Sleep(3000);
                }
                Console.WriteLine("Thread sleeping for 20 sesconds"); 
                Thread.Sleep(20000);
                i = i - 1;
            }
            //end test container
            
            /* THIS IS FOR LOCATION CONNECTIONS. EDIT THE C:/Users/caleb to whatever the twitch-feature-result.txt path is
            //bad untestable code. will break other's builds 
            string testData = File.ReadAllText(@"C:/Users/caleb/Documents/GitHub/BetPlatformAlpha/InterfaceTests/ApiResponses/twitch-feature-result.txt");
            */
            
            Console.ReadLine();
        }

    }
}
