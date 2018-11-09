using System;
using System.Collections.Generic;
using System.Net;

namespace GeekDay
{
    public class HTTPRequester
    {
        private WebServer webServer;

        public void Start()
        {
            webServer = new WebServer(SendResponse, "http://192.168.1.79:8080/");
            Console.WriteLine("SAJT");
            webServer.Run();
        }

        public void Stop()
        {
            webServer.Stop();
        }

        private string SendResponse(HttpListenerRequest request)
        {
            try
            {
                string req = ShowDatas(request);
                foreach (string item in request.Url.Segments)
                {
                    Console.WriteLine(item);
                }
                if (req.Split('\n').Length == 1)
                {
                    Console.WriteLine(request.RawUrl.ToString());
                    int punci = int.Parse(request.Headers.Get("squadMoney"));
                    int pala = punci / 600;
                    punci -= pala * 600;
                    int rugo = punci / 50;
                    punci -= rugo * 50;
                    int peasant = punci / 20;
                    punci -= peasant * 20;
                    return "{\n\t\"Names\": [\n\t\t\"Paladin\"" + (rugo > 0 ? ",\n\t\t\"Rogue\"" : "") + (peasant > 0 ? ",\n\t\t\"Peasant\"" : "") + "\n\t]," +
                        "\n\t\"Numbers\": [" + "\n\t\t" + pala + (rugo > 0 ? (",\n\t\t" + rugo) : "") + (peasant > 0 ? (",\n\t\t" + peasant) : "") + "\n\t]\n}";
                }
                else
                {
                    Logic logic = new Logic(6969);
                    var vs = SplitUrl(request.Url.ToString());
                    logic.Move(vs[0],vs[1],vs[2]);

                }
            }
            catch (Exception e)
            {

            }
            Console.WriteLine("!!!Got request!!!");
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
        string ShowDatas(HttpListenerRequest request)
        {
            string returnn = "";
            Console.WriteLine(request.Url.ToString());
            foreach (var item in SplitUrl(request.Url.ToString()))
            {
                Console.WriteLine(item);
                returnn += item + "\n";
            }
            return returnn;
        }
    }
}