using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekDay
{
    class Logic
    {
        int port;
        string[,] Map = new string[11, 9];
        List<Dictionary<string, object>> activeStatus;
        List<int> frendlyUnitsID;
        List<int> enemyUnitsID;
        int activeId;
        Dictionary<string,int[]> palaMovedhasgedusten;

        public Logic(int port)
        {
            this.port = port;
            activeStatus = new List<Dictionary<string, object>>();
            frendlyUnitsID = new List<int>();
            enemyUnitsID = new List<int>();
            palaMovedhasgedusten = new Dictionary<string, int[]>();

        }
         void refres(string frendly, string enemy, string id)
        {
            activeStatus = Communication.UnitsValues(6969);
            frendlyUnitsID = frendly.Split('|').Select(x=>int.Parse(x)).ToList();
            enemyUnitsID= enemy.Split('|').Select(x => int.Parse(x)).ToList();
            activeId = int.Parse(id);
        }
        public string Move(string frendly, string enemy, string id)
        {
            refres(frendly, enemy, id);
            Random rand = new Random();
            if (id[0] == (frendlyUnitsID[0].ToString()[0])) {
                if (id[2] == '4') {
                    Console.WriteLine("magiszter geci");
                    palaMovedhasgedusten[id] = new int[]{0,0};
                    return JsonConvert.SerializeObject(new Moveer(0, 0, (enemyUnitsID[rand.Next(5)])));
                }
                if (id[2] == '3') {
                    Console.WriteLine("tápos négerpéló");
                    palaMovedhasgedusten[id] = new int[]{7,6};
                    return JsonConvert.SerializeObject(new Moveer(7, 6, 0));
                }
                if (id[2] == '2') {
                    Console.WriteLine("seggbebaszosz sötétosz");
                    palaMovedhasgedusten[id] = new int[]{6,2};
                    return JsonConvert.SerializeObject(new Moveer(6, 2, 0));
                }
                if (id[2] == '1') {
                    Console.WriteLine("rá se nézek baszod olyan ronda");
                    palaMovedhasgedusten[id] = new int[]{7,3};
                    return JsonConvert.SerializeObject(new Moveer(7, 3, 0));
                }
                if (id[2] == '0') {
                    Console.WriteLine("na, ez meg köszönni akart, de csak a segge recsegett");
                    palaMovedhasgedusten[id] = new int[]{8,0};
                    return JsonConvert.SerializeObject(new Moveer(8, 0, 0));
                }
            }
            return JsonConvert.SerializeObject(new Moveer(-1, -1, (enemyUnitsID[rand.Next(5)])));

        }

        public class Moveer {
            public int MoveX;
            public int MoveY;
            public string AttackThis;
            public Moveer(int moveX, int moveY, int attackThis) {
                MoveX = moveX;
                MoveY = moveY;
                AttackThis = attackThis.ToString();
            }
        }
        
        void show(string frendly, string enemy, string id)
        {
            Console.WriteLine(frendly + "-" + enemy + "-" + id);
            foreach (var item in frendlyUnitsID)
            {
                Console.Write("+" + item);
            }
            Console.WriteLine();
            foreach (var item in enemyUnitsID)
            {
                Console.Write("-" + item);
            }
            Console.WriteLine();
            Console.WriteLine(activeId);
        }
 
    }
}
