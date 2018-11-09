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
    class Communication
    {
        public Communication()
        {
            Console.WriteLine("Done..");
        }
        public void Connect(int port)
        {


            UdpClient udpServer = new UdpClient(port);
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                var remoteEP = new IPEndPoint(IPAddress.Any, port);
                var data = udpServer.Receive(ref remoteEP);
                Console.WriteLine();
                Console.WriteLine("DataStart----------------------------------------------------");
                StreamReader reader = new StreamReader(new MemoryStream(data), Encoding.Default);
                Dictionary<string, object> actual = new JsonSerializer().Deserialize<Dictionary<string, object>>(new JsonTextReader(reader));

                foreach (var item in actual)
                {
                    Console.WriteLine(item.Key+":"+item.Value);
                }
                Console.WriteLine("DataEnd----------------------------------------------------");
                Console.WriteLine();
                Console.ReadLine();
            }
        }

    }
    public class Json
    {
      
    }
}
