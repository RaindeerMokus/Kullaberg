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

            public Fizunap(int pala, int magiszter, int rugo, int elf, int peasant) {
                Names = new string[5];
                Numbers = new int[5];
                Names[1] = "Paladin";
                Numbers[1] = pala;
                Names[0] = "Mage";
                Numbers[0] = magiszter;
                Names[2] = "Rogue";
                Numbers[2] = rugo;
                Names[3] = "Elf";
                Numbers[3] = elf;
                Names[4] = "Peasant";
                Numbers[4] = peasant;
            }
        }

        private string ApuOttEgyBenzinkut(string squadMoney) {
            int punci = int.Parse(squadMoney);
            int punci2AkaAss = punci / 3;
            punci -= punci2AkaAss;
            int rugo = 1;
            punci -= 50;
            int peasant = 1;
            punci -= 20;
            int pala = punci / 600;
            punci -= pala*600;
            rugo += punci/50;
            punci -= (rugo-1)*50;
            peasant += punci/20;
            punci -= (peasant-1)*20;

            int elf = 1;
            punci2AkaAss -= 40;
            punci2AkaAss += punci;
            int magiszter = punci2AkaAss/700;
            punci2AkaAss -= magiszter*700;
            elf += punci2AkaAss / 40;
            punci2AkaAss -= (elf-1)*40;

            return JsonConvert.SerializeObject(new Fizunap(pala, magiszter, rugo, elf, peasant));
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
                // using (StreamWriter sw = new StreamWriter("Error" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ".txt"))
                // {
                //     sw.WriteLine(e.ToString());
                // }
                
                
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