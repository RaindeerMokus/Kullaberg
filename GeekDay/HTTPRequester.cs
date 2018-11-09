using System;
using System.Collections.Generic;
using System.Net;

namespace GeekDay
{
    public class HTTPRequester
    {
        private WebServer webServer;

        public HTTPRequester()
        {
            webServer = new WebServer(SendResponse, "http://192.168.1.79:8080/");
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
            ShowDatas(request);
            return "";
        }
        List<string> SplitUrl(string url)
        {
            List<string> ret = new List<string>();
            var values=  url.Split('?')[1].Split('&');
            foreach (var item in values)
            {
                ret.Add(item.Split('=')[1]);
            }
            return ret;
        }
        void ShowDatas(HttpListenerRequest request)
        {
            Console.WriteLine(request.Url.ToString());
            foreach (var item in SplitUrl(request.Url.ToString()))
            {
                Console.WriteLine(item);
            }
        }
    }
}