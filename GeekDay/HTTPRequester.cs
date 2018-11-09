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
<<<<<<< HEAD
            try {
            } catch {

            }
=======
            webServer = new WebServer(SendResponse, "http://192.168.1.79:8080/");
>>>>>>> 6a01f9a5f24d5dfa0302bea6e13a3bff39198399
        }

        public void Start()
        {
            webServer = new WebServer(SendResponse, "http://192.168.1.81:8080/");
            Console.WriteLine("SAJT");
            webServer.Run();
        }

        public void Stop()
        {
            webServer.Stop();
        }

        private string SendResponse(HttpListenerRequest request)
        {
<<<<<<< HEAD
            try {
                Console.WriteLine(request.RawUrl.ToString() + "\n###");
                foreach (string item in request.Url.Segments)
                {
                    Console.WriteLine(item);
                }
                if (request.Headers.AllKeys.Length == 1) {
                    Console.WriteLine(request.RawUrl.ToString());
                    int punci = int.Parse(request.Headers.Get("squadMoney"));
                    int pala = punci / 600;
                    punci -= pala*600;
                    int rugo = punci/50;
                    punci -= rugo*50;
                    int peasant = punci/20;
                    punci -= peasant*20;
                    return "{\n\t\"Names\": [\n\t\t\"Paladin\"" + (rugo > 0 ? ",\n\t\t\"Rogue\"":"") + (peasant > 0 ? ",\n\t\t\"Peasant\"":"") + "\n\t]," + 
                        "\n\t\"Numbers\": [" + "\n\t\t" + pala + (rugo > 0 ? (",\n\t\t" + rugo):"") + (peasant > 0 ? (",\n\t\t" + peasant):"") + "\n\t]\n}";
                }
            } catch(Exception e) {

            }
            Console.WriteLine("!!!Got request!!!");
=======
            ShowDatas(request);
>>>>>>> 6a01f9a5f24d5dfa0302bea6e13a3bff39198399
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