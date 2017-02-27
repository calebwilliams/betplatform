using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.ApiModels.HitBox
{
    public class CredentialsPost
    {
        //reverted properties to lowercase because this is how Hitbox is expecting the values
        //if it worth it, maybe we should use string dictionary instead
        public string login { get; set; }
        public string pass { get; set; }
        public string app { get; set; }
    }
}
