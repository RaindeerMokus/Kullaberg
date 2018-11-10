using System;
using System.Collections.Generic;
using System.Net;

namespace GeekDay
{
    public class HTTPRequester
    {
        private WebServer webServer;

        public void Start(string url)
        {
            webServer = new WebServer(SendResponse, url);
            webServer.Run();
        }

        public void Stop()
        {
            webServer.Stop();
        }

        private String ApuOttEgyBenzinkut(string squadMoney) {
            int punci = int.Parse(squadMoney);
            int pala = punci / 600;
            punci -= pala*600;
            int rugo = punci/50;
            punci -= rugo*50;
            int peasant = punci/20;
            punci -= peasant*20;
            return "{\n\t\"Names\": [\n\t\t\"Paladin\"" + (rugo > 0 ? ",\n\t\t\"Rogue\"":"") + (peasant > 0 ? ",\n\t\t\"Peasant\"":"") + "\n\t]," + 
                "\n\t\"Numbers\": [" + "\n\t\t" + pala + (rugo > 0 ? (",\n\t\t" + rugo):"") + (peasant > 0 ? (",\n\t\t" + peasant):"") + "\n\t]\n}";
        }

        public string SendResponse(HttpListenerRequest request)
        {
            try
            {
                string req = ShowDatas(request);
                if (req.Split('\n').Length == 1) {
                    Console.WriteLine(ApuOttEgyBenzinkut);
                    return ApuOttEgyBenzinkut(request.Headers.Get("squadMoney"));
                } else {
                    Console.WriteLine("GYÖGYŐ IDE ÍRHATSZ BASZOD OK?");
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