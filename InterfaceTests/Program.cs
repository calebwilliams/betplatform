using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTests
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public interface StreamAPI
    {
        Task<bool> IsConnected(); 
        Task<JsonResult> 
    }
}
