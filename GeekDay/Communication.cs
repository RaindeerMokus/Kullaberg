﻿using Newtonsoft.Json;
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
        public static Dictionary<string, Dictionary<string, object>> UnitsValues(int port)
        {
            UdpClient udpServer = new UdpClient(port);
            Dictionary<string,Dictionary<string, object>> ret = new Dictionary<string,Dictionary<string, object>>();
            bool again = false;
            while (!again)
            {
                var remoteEP = new IPEndPoint(IPAddress.Any, port);
                var data = udpServer.Receive(ref remoteEP);
                StreamReader reader = new StreamReader(new MemoryStream(data), Encoding.Default);
                Dictionary<string, object> a = new JsonSerializer().Deserialize<Dictionary<string, object>>(new JsonTextReader(reader));

                var key = a["ID"].ToString();
                if (ret.Keys.Contains(key)) break;    
                ret.Add(key,a);
            }
            udpServer.Close();
            return ret;
        }

    }
}
