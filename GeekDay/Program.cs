using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace GeekDay
{
    enum KEYS { ID, Count, CountAtStart, LastHP, X, Y, Hero, Unit, RetaliatedThisRound, TotalHP, Speed, Attack, Defense }
    class Program
    {
        static Thread httpThread = new Thread(new ThreadStart(HttpThread));

        static void HttpThread() {
            HTTPRequester hr = new HTTPRequester();
            hr.Start("http://192.168.1.79:8080/");
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            httpThread.Start();
            //foreach (Dictionary<string, object> item in Communication.UnitsValues(6969))
            //{
            //    var a = item.Where(x => x.Key == "ID").Select(x => new { x.Key, x.Value });
            //    var b = item.Where(x => x.Key == "Unit").Select(x => new { x.Key, x.Value });
            //    a.ToConsole();
            //    b.ToConsole();
            //    Console.WriteLine();
            //}
            Console.Read();
        }
    }
}
