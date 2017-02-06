using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.Generics
{
    public class Response<T>
    {
        public List<T> ResultCollection { get; set; }
        public string Query { get; set; }
        public string Result { get; set; }

        public Exception Ex;

        public Response()
        {
            ResultCollection = new List<T>();
        }

    }
}
