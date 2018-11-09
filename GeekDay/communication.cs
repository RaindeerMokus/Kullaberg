using System;
using System.Collections.Generic;
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
                //  Console.WriteLine(data.ToString());
                Console.WriteLine( );
                Console.WriteLine("DataStart----------------------------------------------------");
                foreach (var item in data)
                {
                    Console.Write(item.ToString());
                }
                Console.WriteLine("DataEnd----------------------------------------------------");
                Console.WriteLine();
                //udpServer.Send(new byte[] { 1 }, 1, remoteEP); // if data is received reply letting the client know that we got his data          
                Console.ReadLine();
            }
        }

    }
}
