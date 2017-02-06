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

namespace InterfaceTests
{
    class Program
    {
        static void MainAPI(string[] args)
        {
            //we want this object to be separate, containing an iterable list of configutations
            //
            AppConfig config = new AppConfig();
            /*Overview of demo to query twitch api */
            //instantiate object 
            StreamAPIBase twitch = new TwitchAPI("twitch", config.Tokens["twitch-api"]);

            //test container 
            bool complete = false;
            Response<string> apiResponse = new Response<string>();
            Task.Run(async () =>
            {
                apiResponse = await twitch.VisitEndpointAsync("https://api.twitch.tv/kraken/streams/featured");
                complete = true;
            });
            while (!complete)
            {
                Thread.Sleep(3000);
            }
            //end test container

            Console.ReadLine();
        }

    }
}
