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
        public List<Response<T>> ResponseCollection { get; set; }
        public string Query { get; set; }
        public string Result { get; set; }
        public Exception Exception { get; internal set; }

        public Exception Ex;

        public Response()
        {
            ResponseCollection = new List<Response<T>>(); 
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

        internal void Consume(Response<T> response)
        {
            foreach (var res in response.ResponseCollection)
                this.ResponseCollection.Add(res);
            this.ResponseCollection.Add(response); 
        }
    }
}
