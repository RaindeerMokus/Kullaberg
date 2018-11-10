using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GeekDay
{
    public class Communication
    {
        public static List<Dictionary<string, object>> UnitsValues(int port)
        {
            UdpClient udpServer = new UdpClient(port);
            List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();
            try {
                bool again = false;
                while (!again)
                {
                    var remoteEP = new IPEndPoint(IPAddress.Any, port);
                    var data = udpServer.Receive(ref remoteEP);
                    StreamReader reader = new StreamReader(new MemoryStream(data), Encoding.Default);
                    Dictionary<string, object> a = new JsonSerializer().Deserialize<Dictionary<string, object>>(new JsonTextReader(reader));
                    foreach (var item in ret)
                    {
                        if (item.Where(x => x.Key == "ID").FirstOrDefault().Value.ToString() == a.Where(x => x.Key == "ID").FirstOrDefault().Value.ToString())
                        {
                            again = true;
                            break;
                        }
                    }
                    if (!again) ret.Add(a);
                }
            } catch (Exception e) {

            } finally {
                udpServer.Close();
            }
            udpServer.Close();
            return ret;
        }

    }
}
