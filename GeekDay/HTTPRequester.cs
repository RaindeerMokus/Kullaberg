using System;
using System.Net;

namespace GeekDay
{
    public class HTTPRequester
    {
        private WebServer webServer;

        public HTTPRequester()
        {
            webServer = new WebServer(SendResponse, "http://192.168.1.119:8080/");
        }

        public void Start()
        {
            Console.WriteLine("SAJT");
            webServer.Run();
        }

        public void Stop()
        {
            webServer.Stop();
        }

        private string SendResponse(HttpListenerRequest request)
        {
            Console.WriteLine(request.HttpMethod.ToString());
            Console.WriteLine("!!!Got request!!!");
            return "";
        }
    }
}