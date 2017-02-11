using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests.Generics
{
    public class Response<T>
    {
        public List<T> ResultCollection { get; set; }
        public string Query { get; set; }
        public string Result { get; set; }
        public Exception Exception { get; internal set; }

        public Exception Ex;

        public Response()
        {
            ResultCollection = new List<T>();
        }

        public Response(string query)
        {
            Query = query; 
        }

        internal void ReceiveException(Exception ex)
        {
            Exception = ex; 
        }

        internal void ReceiveException(Exception ex, MethodBase methodBase)
        {
            Exception = ex;
            Result = $"Error occured somewhere around {methodBase.Name} ...maybe.";

        }
    }
}
