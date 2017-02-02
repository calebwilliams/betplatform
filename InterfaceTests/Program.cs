using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using InterfaceTests.Generics;
using System.Net;
using System.IO;

namespace InterfaceTests
{
    class Program
    {
        static void MainAPI(string[] args)
        {
            /*Overview of demo to query twitch api */
            //instantiate object 
            StreamAPIBase twitch = new TwitchAPI("paxprose");

            //twitch requires custom headers. had to use httpwebrequest object due that...
            twitch.Headers.Add("Accept", "application/vnd.twitchtv.v5+json");
            twitch.Headers.Add("Client-ID:", twitch.Config.Tokens["twitch-api"]);

            //http web request has to be instantiated with url
            HttpWebRequest req = HttpWebRequest.CreateHttp("https://api.twitch.tv/kraken/streams/featured");

            //twitch v5 api
            req.Accept = "application/vnd.twitchtv.v5+json";
            //clientId as generated via your twitch account 

            req.Headers.Add($"Client-ID: {twitch.Config.Tokens["twitch-api"]}");

            //TODO wrap this specifically in the base class's EndpointGet using async/await pattern
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            string _res = "";
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                _res = reader.ReadToEnd(); 
            }

            //END TODO

            //output 
            Console.WriteLine(_res);

            Console.ReadLine();
        }

        public class TwitchAPI : StreamAPIBase
        {
            /// <summary>
            /// https://dev.twitch.tv/docs
            /// </summary>
            /// <param name="username"></param>
            /// <param name="password"></param>
            /// <param name="apikey"></param>
            public TwitchAPI(string username) : base()
            {
                this.Name = "twitch"; 
            }

        }
    }


    

    
}
