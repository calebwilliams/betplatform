using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.Generics
{
    public class Response<T>
    {
        public List<T> Payload { get; set; }
        public string Query { get; set; }
        public string ReturnMsg { get; set; }

        public Exception Ex;

        public Response()
        {
            Payload = new List<T>();
        }

    }
}
