using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests
{
    public class AppConfig
    {

        public Dictionary<string, string> Tokens { get; set; }
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public AppConfig()
        {
            SetTokens();
            SetConnectionStrings();
        }

        private void SetConnectionStrings()
        {
            ConnectionStrings = new Dictionary<string, string>();
            ConnectionStrings.Add("local", "mongodb://localhost"); 
        }

        private void SetTokens()
        {
            Tokens = new Dictionary<string, string>();
            Tokens.Add("twitch", "");
            Tokens.Add("azubu", "");
        }
    }
}
