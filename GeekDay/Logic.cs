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
        Dictionary<string,int> palaMovedhasgedusten;
        Dictionary<int, int> speeds;
        MapV2 mapperino;

        public Logic(int port)
        {
            this.port = port;
            activeStatus = new List<Dictionary<string, object>>();
            frendlyUnitsID = new List<int>();
            enemyUnitsID = new List<int>();
            palaMovedhasgedusten = new Dictionary<string, int>();
            mapperino = new MapV2(11,9);
        }
         void refres(string frendly, string enemy, string id)
        {
            activeStatus = Communication.UnitsValues(6969);
            frendlyUnitsID = frendly.Split('|').Select(x=>int.Parse(x)).ToList();
            enemyUnitsID= enemy.Split('|').Select(x => int.Parse(x)).ToList();
            activeId = int.Parse(id);
            speeds = new Dictionary<int, int>();
        }
        public string Move(string frendly, string enemy, string id)
        {
            Dictionary<int, int> LetsMoveNow = new Dictionary<int, int>();
            refres(frendly, enemy, id);
            show(frendly,enemy,id);
            foreach (var item in getDictByID(activeId))
            {
               Console.WriteLine(item.Key + "-" + item.Value);
            }
            Random rand = new Random();
            if (id[0] == (frendlyUnitsID[0].ToString()[0])) {
                if (id[2] == '4') {
                    Console.WriteLine("magiszter geci");
                    palaMovedhasgedusten[id] = mapperino.PointId(0,0);
                    speeds[activeId] = 6;
                    int mindef = 100;
                    int mini = 0;
                    foreach (int i in enemyUnitsID)
                    {
                        int def = getUnitParameter(getDictByID(i), "Defense");
                        if (def < mindef) {
                            mindef = def;
                            mini = 0;
                        }
                    }
                    return JsonConvert.SerializeObject(new Moveer(0, 0, (mini)));
                }
                if (id[2] == '3') {
                    Console.WriteLine("tápos négerpéló");
                    palaMovedhasgedusten[id] = mapperino.PointId(7,6);
                    speeds[activeId] = 5;

                    return JsonConvert.SerializeObject(new Moveer(7, 6, 0));
                }
                if (id[2] == '2') {
                    Console.WriteLine("seggbebaszosz sötétosz");
                    palaMovedhasgedusten[id] = mapperino.PointId(6,2);
                    speeds[activeId] = 5;
                    return JsonConvert.SerializeObject(new Moveer(6, 2, 0));
                }
                if (id[2] == '1') {
                    Console.WriteLine("rá se nézek baszod olyan ronda");
                    palaMovedhasgedusten[id] = mapperino.PointId(7,3);
                    speeds[activeId] = 3;
                    return JsonConvert.SerializeObject(new Moveer(7, 3, 0));
                }
                if (id[2] == '0') {
                    Console.WriteLine("na, ez meg köszönni akart, de csak a segge recsegett");
                    palaMovedhasgedusten[id] = mapperino.PointId(8,0);
                    speeds[activeId] = 2;
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
        
        public Dictionary<string, object> getDictByID(int id) {
            foreach (var item in activeStatus)
            {
                foreach (var csirabutyok in item)
                {
                    if(csirabutyok.Key=="ID" && csirabutyok.Value.ToString()==id.ToString()) {
                        return item;
                    }
                }
            }
            return null;
        }

        public int getUnitPosition(Dictionary<string, object> unit) {
            return 0;
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
