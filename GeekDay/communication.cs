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
        public void Connect()
        {
            
            UdpClient udpServer = new UdpClient(6969);

            while (true)
            {
                var remoteEP = new IPEndPoint(IPAddress.Any, 6969);
                var data = udpServer.Receive(ref remoteEP); // listen on port 11000
                Console.Write("receive data from " + remoteEP.ToString());
                //udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
            }
        }

    }
}
