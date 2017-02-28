using InterfaceTests.DatabaseModels;
using InterfaceTests.Generics;
using InterfaceTests.Utility;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using InterfaceTests.ApiModels.HitBox;
using System.IO;

namespace InterfaceTests.ApiObjects
{
    class HitBoxAPI : APIBase
    {
        public HitBoxAPI(AppConfig config) : base(config, "hitbox")
        {
            BaseURL = "https://api.hitbox.tv/";
           
            CredentialsPostRequest.login = _config.Tokens["hitbox-login"] ?? string.Empty;
            CredentialsPostRequest.pass = _config.Tokens["hitbox-pass"] ?? string.Empty;
            CredentialsPostRequest.app = _config.Tokens["hitbox-app-name"] ?? string.Empty;            
        }      

        public string authenticateCall()
        {
            return makePostRequest(BaseURL + "auth/login", JsonConvert.SerializeObject(CredentialsPostRequest));
        }
        public string authenticateCall(string token, string app)
        {
            TokenPost creds = new TokenPost();

            creds.AuthToken = token;
            creds.App = app;

            string postData = JsonConvert.SerializeObject(creds);
            return makePostRequest(BaseURL + "auth/login", JsonConvert.SerializeObject(postData));
        }
    }
}
