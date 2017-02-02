using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.Generics
{
    public class StreamAPIBase
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BaseURL { get; set; }
        public string APIKey { get; set; }
        public string APIToken { get; set; }
        public Dictionary<string, string> EndPoints { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public AppConfig Config { get; set; } 

        public StreamAPIBase()
        {
            Headers = new Dictionary<string, string>(); 
            EndPoints = new Dictionary<string, string>();
            Config = new AppConfig();
        }

        public virtual async Task<Response<string>> AuthTokenGet()
        {
            Response <string> res = new Response<string>();
            using (HttpClient client = new HttpClient())
            {
                
                
            }

                return res; 
        }

        /// <summary>
        /// an idea for a simple request to get a dataset from a generic api call
        /// would have to construct the baseurl to allow endpoint data to be connect at the end of the property
        /// </summary>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public virtual async Task<Response<string>> EndpointGet(string endPoint)
        {
            Response<string> res = new Response<string>();
            try
            {
                res.Query = $"{BaseURL}{EndPoints[endPoint]}";
                // probably will always be overriden due to how apikeys need to be inserted 
                using (var client = new HttpClient())
                using (var clientResponse = await client.GetAsync(res.Query))
                    res.Payload.Add(await clientResponse.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                res.Ex = ex;
            }
            return res;
        }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<MongoDB.Bson.BsonDocument>> SaveAsConfig()
        {
            //I like the idea of being able to save a template of an api object so 
            //we have the option to instantiate from a database call 
            //incase we have to query an api for something in the web application            
            throw new NotImplementedException();
        }
    }
}
