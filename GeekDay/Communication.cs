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
                //  Console.WriteLine(data.ToString());
             //   var str = MyClass.Desserialize(data).Id + "" + MyClass.Desserialize(data).Name + "" + MyClass.Desserialize(data).Data;
                
                Console.WriteLine();
                Console.WriteLine("DataStart----------------------------------------------------");
                string datastring = System.Text.Encoding.UTF8.GetString(data);
                Console.WriteLine(datastring);
                Console.WriteLine("DataEnd----------------------------------------------------");
                Console.WriteLine();
                //udpServer.Send(new byte[] { 1 }, 1, remoteEP); // if data is received reply letting the client know that we got his data          
                Console.ReadLine();
            }
        }

    }
    public class MyClass
    {

        /*public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }*/
      //  public List<string> Datas { get; set; }
        /*  public byte[] Serialize()
          {
              using (MemoryStream m = new MemoryStream())
              {
                  using (BinaryWriter writer = new BinaryWriter(m))
                  {
                      writer.Write(Id);
                      writer.Write(Name);
                  }
                  return m.ToArray();
              }
          }*/

        public static List<string> Desserialize(byte[] data)
        {
            MyClass result = new MyClass();
            List<string>Datas = new List<string>();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    try
                    {
                        while (true)
                        {
                            Datas.Add(reader.ReadString());
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n"+e.StackTrace+"\n" + e.ToString());
                        return Datas; 
                    }
                }
            }
            
        }

    }
}
