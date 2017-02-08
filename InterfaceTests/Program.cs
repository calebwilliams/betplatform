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
            StreamAPIBase twitch = new TwitchAPI(config);

            //THIS CONNECTIONS TO API. FOR DEVELOPMENT USE /APIResponses/twitch-feature-result.txt instead
            string testData = ""; //string we'll load either api call or file.read into 
            bool complete = false;
            Response<string> apiResponse = new Response<string>();
            Response<string> cacheResponse = new Response<string>();
            Task.Run(async () =>
            {
                //a list of 
                apiResponse = await twitch.VisitEndpointAsync("https://api.twitch.tv/kraken/streams/featured");
                testData = apiResponse.Result;
                cacheResponse = await twitch.CacheChannelEndpointAsync(testData); 
                complete = true;
            });
            while (!complete)
            {
                Thread.Sleep(3000);
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
