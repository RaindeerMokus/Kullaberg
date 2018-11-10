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
            HttpThread();

            Console.Read();
        }
    }
}
