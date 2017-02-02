using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using InterfaceTests.Generics;

namespace InterfaceTests
{
    class Program
    {
        static void MainAPITest(string[] args)
        {
            StreamAPIBase twitch = new TwitchAPI("", "", ""); 


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
            public TwitchAPI(string username, string password, string apikey) : base()
            {

            }

            public async override Task<Response<string>> AuthTokenGet()
            {
                Response<string> res = new Response<string>();
                return res; 
            }
        }
    }


    

    
}
