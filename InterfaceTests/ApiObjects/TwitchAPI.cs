using InterfaceTests.Generics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.ApiObjects
{
    public class TwitchAPI : StreamAPIBase
    {
        /// <summary>
        /// https://dev.twitch.tv/docs
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="apikey"></param>
        public TwitchAPI(string name, string apikey) : base(name, apikey)
        {
            this.Name = "twitch";
            //twitch requires custom headers. had to use httpwebrequest object due that...
            this.Headers.Add("Accept", "application/vnd.twitchtv.v5+json");
            this.Headers.Add("Client-ID", this.APIKey);
        }

        public override string VisitEndpoint(string endpoint)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(endpoint);

            req.Accept = Headers["Accept"];
            foreach (var pair in Headers.Where(x => x.Key != "Accept"))
            {
                req.Headers.Add(pair.Key, pair.Value);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
                return reader.ReadToEnd();
        }

    }

}
