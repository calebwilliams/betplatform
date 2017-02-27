using InterfaceTests.ApiModels.HitBox;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.Generics
{
    public delegate Task<Response<string>> EndpointAction();
    public abstract class APIBase
    {
        public AppConfig _config;
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BaseURL { get; set; }
        public string APIKey { get; private set; }

        public Dictionary<string, string> Headers { get; set; }
        public CredentialsPost CredentialsPostRequest;
        public Dictionary<string, string> Endpoints { get; set; }
        public List<EndpointAction> EndpointActionCollection {get;set;}

        public APIBase(string name, string apikey)
        {
            Name = name;
            Headers = new Dictionary<string, string>();
            Endpoints = new Dictionary<string, string>(); 
            APIKey = apikey;
            EndpointActionCollection = new List<EndpointAction>();
            CredentialsPostRequest = new CredentialsPost();
        }

        public APIBase(AppConfig config, string name)
        {
            Name = name; 
            _config = config;
            Headers = new Dictionary<string, string>();
            Endpoints = new Dictionary<string, string>(); 
            APIKey = _config.Tokens[name];
            EndpointActionCollection = new List<EndpointAction>();
            CredentialsPostRequest = new CredentialsPost();
        }

        private HttpWebRequest prepareHeaders(HttpWebRequest request)
        {
            if (Headers.ContainsKey("Accept"))
                request.Accept = Headers["Accept"];
            //for everything else, add it in this probably should be moved into its own method
            foreach (var pair in Headers.Where(x => x.Key != "Accept"))
                request.Headers.Add(pair.Key, pair.Value);

            return request;
        }

        //right now this function only makes json post request payloads
        /// <summary>
        /// Makes Post call to endpoint
        /// </summary>
        /// <param name="endpoint">endpoint url</param>
        /// <param name="postData">json string post request data</param>
        /// <returns></returns>
        public virtual string makePostRequest(string endpoint, string postData)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(endpoint);
            req = prepareHeaders(req);

            //HttpWebRequest req = HttpWebRequest.CreateHttp(BaseURL + "/auth/login");
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = postData.Length;

            Stream writeStream = req.GetRequestStream();

            using (var streamWriter = new StreamWriter(writeStream))
            {
                streamWriter.Write(postData);
            }

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
                return reader.ReadToEnd();
        }

        public virtual string VisitEndpoint(string endpoint)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(endpoint);
            req = prepareHeaders(req);

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
                return reader.ReadToEnd();
        }

        public async Task<Response<string>> VisitEndpointAsync(string endpoint)
        {
            Response<string> response = new Response<string>();
            try
            {
                HttpWebRequest req = HttpWebRequest.CreateHttp(endpoint);
                if (Headers.ContainsKey("Accept"))
                    req.Accept = Headers["Accept"];
                foreach (var pair in Headers.Where(x => x.Key != "Accept")) //messy and difficult to adapt to other apis. Should separate headers
                    req.Headers.Add(pair.Key, pair.Value);

                using (WebResponse res = await req.GetResponseAsync())
                    using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                        response.Result = await reader.ReadToEndAsync();
            }
            catch (Exception ex)
            {
                response.Ex = ex;
            }
            return response;
        }

        public virtual Task<Response<string>> CacheChannelEndpointAsync(string apiData, string root)
        {
            var response = new Response<string>();
            response.Result = "Higher class not instantiated";
            response.Ex = new Exception("Call this method from the parent class");
            return Task.FromResult(response); 
        }


        public async Task<Response<string>> CacheChannelEndpoints()
        {
            Response<string> response = new Response<string>();
            foreach (var endpointMethod in EndpointActionCollection)
            {
                try
                {
                    await Task.Run(async () =>
                    {
                        response.Consume(await endpointMethod());
                        //unfortunately, here lies a black hole of logging 
                        //temp.CacheResponse(); //going to be necessary. error handling is fucked. need to make the incoming collection async safe... 
                        //likeiwse... it would have to be here to throttle queries at endpoints... 
                    });
                }
                catch (Exception ex)
                {
                    response.ReceiveException(ex, MethodBase.GetCurrentMethod());
                    response.Query = "Exception thrown cache channel endpoints";
                }
            }
            return response; 
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
