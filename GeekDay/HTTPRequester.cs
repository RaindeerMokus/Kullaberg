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
                Names[3] = "Paladin";
                Numbers[3] = pala;
                Names[4] = "Archmage";
                Numbers[4] = magiszter;
                Names[2] = "Rogue";
                Numbers[2] = rugo;
                Names[1] = "Goblin";
                Numbers[1] = elf;
                Names[0] = "Peasant";
                Numbers[0] = peasant;
            }
        }

        private string ApuOttEgyBenzinkut(string squadMoney) {
            int punci = int.Parse(squadMoney);
            Console.WriteLine(punci);
            int punci2AkaAss = punci / 3;
            punci -= (punci2AkaAss);
            int rugo = 1;
            punci -= 50;
            int elf = 1;
            punci -= 40;
            int pala = punci / 600;
            punci -= pala*600;
            rugo += punci/50;
            punci -= (rugo-1)*50;
            elf += punci / 40;
            punci -= (elf-1)*40;

            punci2AkaAss += punci;
            punci = 0;
            int peasant = 1;
            punci2AkaAss -= 20;
            int magiszter = punci2AkaAss/700;
            punci2AkaAss -= magiszter*700;
            peasant += punci2AkaAss/20;
            punci2AkaAss -= (peasant-1)*20;
            Console.WriteLine("p:" + pala + " am:" + magiszter + " r:" + rugo + " el:" + elf + " pf:" + peasant);
            Console.WriteLine(punci + ":" + punci2AkaAss);

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