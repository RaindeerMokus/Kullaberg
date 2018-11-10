using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        private class Fizunap {
            public string[] Names;
            public int[] Numbers;

            public Fizunap(int pala, int rugo, int peasant) {
                Names = new string[5];
                Numbers = new int[5];
                Names[0] = "Paladin";
                Numbers[0] = pala - 4;
                Names[1] = "Paladin";
                Numbers[1] = 1;
                Names[2] = "Paladin";
                Numbers[2] = 1;
                Names[3] = "Paladin";
                Numbers[3] = 1;
                Names[4] = "Paladin";
                Numbers[4] = 1;
                if (rugo >0) {
                    Names[1] = "Rogue";
                    Numbers[1] = rugo;
                    Numbers[0]++;
                    if (peasant > 0) {
                        Names[2] = "Peasant";
                        Numbers[2] = peasant;
                        Numbers[0]++;
                    }
                } else if (peasant > 0) {
                    Names[1] = "Peasant";
                    Numbers[1] = peasant;
                    Numbers[0]++;
                }
            }
        }

        private string ApuOttEgyBenzinkut(string squadMoney) {
            int punci = int.Parse(squadMoney);
            int pala = punci / 600;
            punci -= pala*600;
            int rugo = punci/50;
            punci -= rugo*50;
            int peasant = punci/20;
            punci -= peasant*20;

            return JsonConvert.SerializeObject(new Fizunap(pala, rugo, peasant));
        }

        public string SendResponse(HttpListenerRequest request)
        {
            try
            {
                List<string> spittedUrl = SplitUrl(request.Url.ToString());
                if (spittedUrl.Count == 1) {
                    return ApuOttEgyBenzinkut(spittedUrl[0]);
                }
                else
                {
                    Logic logic = new Logic(6969);
                    var vs = SplitUrl(request.Url.ToString());
                    return logic.Move(vs[0],vs[1],vs[2]);
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter("Error" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ".txt"))
                {
                    sw.WriteLine(e.ToString());
                }
                
                
            }
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