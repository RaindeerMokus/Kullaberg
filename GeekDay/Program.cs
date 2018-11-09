using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GeekDay
{
    class Program
    {
        static Thread httpThread = new Thread(new ThreadStart(HttpThead));

        static void HttpThead() {
            HTTPRequester hr = new HTTPRequester();
            hr.Start();
        }

        static void Main(string[] args)
        {
            httpThread.Start();
            Communication communication = new Communication();
            communication.Connect(6969);
        }
    }
}
